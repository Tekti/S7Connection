using System;
using System.Net;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp7;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;
using System.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

using System.Runtime.InteropServices;


namespace S7Connection
{
    public partial class MainWindow : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "GetOEMCP")]
        public static extern int GetOEMCP();

        private Collection Containers;
        private string DirStep7;
        private string DirExcel;
        private string DirAwl;
        private int CodePage;
        public Encoding enc;
        public Encoding enc2;


        //Declare variables 
        private S7Client Client;
        private byte[] BufferAB = new byte[65536];
        S7MultiVar Reader;
        DataTable snapshot;
        private char[] numbers = new char[10];
        private long ElapsedTime;
        SymbolsPick SymbolsPick = new SymbolsPick();
        DBpicker DBpicker = new DBpicker();

        string DateTimeFormat;

        DataTable Values_table;
        private List<S7Address> Variable_array;

        //int Program_Status = 0; //0 stopped, 1, started
        Timer Timer1 = new Timer();
        private int Max_Time;
        private int Refresh_Time;

        ToolTip GeneralTooltip = new ToolTip();

        private void ShowResult(int Result)
        {
            // This function returns a textual explaination of the error code
            textBoxError.Text = Client.ErrorText(Result);
            if (Result == 0)
                textBoxError.Text = textBoxError.Text + " (" + Client.ExecutionTime.ToString() + " ms)";
        }
        public MainWindow()
        {
            this.Containers = new Collection();
            this.CodePage = (int)(GetOEMCP() % 0x1000L);
            this.enc = Encoding.GetEncoding(this.CodePage);
            this.enc2 = Encoding.GetEncoding(this.CodePage);

            InitializeComponent();
            this.chart1.MouseWheel += new MouseEventHandler(chart1_MouseWheel);
            Client = new S7Client();
            if (IntPtr.Size == 4)
                this.Text = this.Text + " - Running 32 bit Code";
            else
                this.Text = this.Text + " - Running 64 bit Code";
            
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ipAddress = textBoxIP.Text;

                if (!IsValidIp(ipAddress) && !textBoxIP.Text.Contains("simulation"))
                {
                    throw new ArgumentException("Ip address is not valid");
                }
                int Result;
                short Rack = short.Parse(textBoxRack.Text);
                short Slot = short.Parse(textBoxSlot.Text);

                Result = Client.ConnectTo(ipAddress, Rack, Slot);
                ShowResult(Result);
                if (Result != 0 && !textBoxIP.Text.Contains("simulation")) MessageBox.Show("Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    textBoxError.Text = textBoxError.Text + " PDU Negotiated : " + Client.PduSizeNegotiated.ToString();
                    textBoxIP.Enabled = false;
                    textBoxRack.Enabled = false;
                    textBoxSlot.Enabled = false;
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    buttonStop.Enabled = false;
                    buttonStart.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                int Result;
                Result = Client.Disconnect();
                if (Result != 0) MessageBox.Show("Disconnection Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    textBoxError.Text = "Disconnected";
                    textBoxIP.Enabled = true;
                    textBoxRack.Enabled = true;
                    textBoxSlot.Enabled = true;
                    buttonDisconnect.Enabled = false;
                    buttonConnect.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Values_table = new DataTable();
            Values_table.TableName = "Data";
            DataColumn tmpColumn;
            Values_table.Columns.Add("Time");
            //Build DateTimeFormat String)
            DateTimeFormat = BuildDateTimeFormat();
            //Clear the tables
            Values_table.Clear();
            chart1.Series.Clear();
            //Get the values for Max Time and Refresh Rate
            maxtime_textbox_Leave(this, e);
            Refresh_text_Leave(this, e);

            double field_value_Max;
            double field_value_Min;
            double.TryParse(Properties.Settings.Default.Y_MaxScale, out field_value_Max);
            double.TryParse(Properties.Settings.Default.Y_MinScale, out field_value_Min);

            chart1.ChartAreas[0].AxisY.Maximum = field_value_Max;
            chart1.ChartAreas[0].AxisY.Minimum = field_value_Min;

            foreach (S7Address var in Variable_array)
            {
                ///////////////////////////////
                tmpColumn = new DataColumn();
                tmpColumn.ColumnName = var.SymbolicName.Replace(",", "."); //column name doesn't handle comma :(
                tmpColumn.DataType = System.Type.GetType("System.Double");
                Values_table.Columns.Add(tmpColumn);
                chart1.Series.Add(tmpColumn.ColumnName);
                chart1.Series[tmpColumn.ColumnName].XValueMember = "Time";
                chart1.Series[tmpColumn.ColumnName].YValueMembers = tmpColumn.ColumnName;
                chart1.Series[tmpColumn.ColumnName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart1.Series[tmpColumn.ColumnName].Color = var.Color;
                Values_table.AcceptChanges();
            }



            // if max time is set then fill the table with blank values 
            if (Max_Time > 0 && Refresh_Time > 0)
            {
                DataRow row = Values_table.NewRow();
                DateTime Current_Time = DateTime.Now;
                int numberofrows;
                numberofrows = Max_Time * 1000 / Refresh_Time;
                for (int i1 = 0; i1 <= numberofrows; i1++)
                {
                    row["Time"] = Current_Time.AddMilliseconds(i1 * Refresh_Time * (-1)).ToString(DateTimeFormat);
                    Values_table.Rows.InsertAt(row, 0);
                    row = Values_table.NewRow();
                }

            }
            //Save data to file

            if (LogData_checkbox.Checked)
            {
                //Generate Column names (one time only)
                File.WriteAllText(LogData_textbox.Text, String.Empty);
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = Values_table.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(";", columnNames));
                try
                {
                    File.AppendAllText(LogData_textbox.Text, sb.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogData_checkbox.Checked = false;
                }
            }

            //Get the refresh rate for the timer
            if (int.TryParse(Refresh_text.Text, out Refresh_Time)) CommunicationTimer.Interval = Refresh_Time;
            else MessageBox.Show("Wrong Refresh Rate Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Initialize timer
            CommunicationTimer.Stop();
            CommunicationTimer.Start();
            //bind data sources
            chart1.DataSource = Values_table;
            dataGridView.DataSource = Values_table;

            chart1.DataBind();

            Refresh_text.Enabled = false;
            Pause_checkBox.Enabled = true;
            buttonDisconnect.Enabled = false;
            LogData_checkbox.Enabled = false;
            Remove_button.Enabled = false;
            LoadVars_button.Enabled = false;
            AddToChart_button.Enabled = false;
            Modify_button.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CommunicationTimer.Stop();

            Refresh_text.Enabled = true;

            buttonDisconnect.Enabled = true;
            LogData_checkbox.Enabled = true;
            Remove_button.Enabled = true;
            AddToChart_button.Enabled = true;
            LoadVars_button.Enabled = true;
            Modify_button.Enabled = true;
            Pause_checkBox.Enabled = true;
            Refresh_text.Enabled = true;
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                }

                if (e.Delta > 0)
                {
                    double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                    double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                    double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                    double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                    double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 2;
                    double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 2;
                    double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 2;
                    double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 2;

                    chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                    chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            if (chart1.Focused)
                chart1.Parent.Focus();
        }

        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            if (!chart1.Focused)
                chart1.Focus();
        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        tooltip.Show("X=" + prop.AxisLabel + ", Y=" + prop.YValues[0], this.chart1, pos.X, pos.Y - 15);
                    }
                }
            }


        }

        private void MaxVal_textbox_MouseLeave(object sender, EventArgs e)
        {
            double MaxSenVal = 0, MinSenVal = 0, MaxPLCVal = 0, MinPLCVal = 1, result = 0;
            if (double.TryParse(MaxVal_textbox.Text, out result))
            {
                MaxSenVal = result;
            }
            if (double.TryParse(MinVal_textbox.Text, out result))
            {
                MinSenVal = result;
            }
            if (double.TryParse(PLCMax_textbox.Text, out result))
            {
                MaxPLCVal = result;
            }
            if (double.TryParse(PLCMin_textbox.Text, out result))
            {
                MinPLCVal = result;
            }
            double offset = 0;
            double multiplicator = 1;
            offset = MinSenVal - multiplicator * MinPLCVal;
            multiplicator = (MaxSenVal - offset) / MaxPLCVal;
            Multiply_text.Text = multiplicator.ToString();
            Add_text.Text = offset.ToString();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                chart1.SaveImage(ms, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
                Bitmap Chart_Image = new Bitmap(ms);
                Clipboard.SetImage(Chart_Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Image_Dialog = new SaveFileDialog();
                Image_Dialog.Filter = "Image files (*.bmp)|*.bmp";
                Image_Dialog.ShowDialog();
                chart1.SaveImage(Image_Dialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Export_Dialog = new SaveFileDialog();
                Export_Dialog.Filter = "Xml files (*xml)|*.xml";
                Export_Dialog.ShowDialog();
                Values_table.WriteXml(Export_Dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddToChart_button_Click(object sender, EventArgs e)
        {
            S7Address InputAddress = new S7Address();
            InputAddress = VariableToList(SymbolicName_text.Text, Variable_text.Text, Comment_textBox.Text, Add_text.Text,
            Multiply_text.Text, Color_button.BackColor, GetFreeBufferAddress(), DisplayFormat_comboBox.GetItemText(DisplayFormat_comboBox.SelectedItem));
            if (isDuplicate(InputAddress))
            {
                MessageBox.Show("Symbolic Name: " + InputAddress.SymbolicName + " already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (InputAddress.DBNumber >= 0) Variable_array.Add(InputAddress);
                //Refresh Variables list
                RefreshVarList();

                Variable_text.Text = "";
                SymbolicName_text.Text = "";
                Add_text.Text = "";
                Multiply_text.Text = "";
                Comment_textBox.Text = "";
                DisplayFormat_comboBox.SelectedIndex = 0;

            }
        }

        private void Remove_button_Click(object sender, EventArgs e)
        {
            if (Variable_array.Count > 0 && Variables_list.SelectedIndex <= Variable_array.Count && Variables_list.SelectedIndex >= 0) Variable_array.RemoveAt(Variables_list.SelectedIndex);
            if (Variables_list.Items.Count == 0) Modify_button.Enabled = false;
            //Refresh Variables List
            RefreshVarList();
        }

        private void Pause_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Pause_checkBox.Checked) snapshot = Values_table.Copy();
        }

        private void Color_button_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color_button.BackColor = colorDialog1.Color;
        }

        private void Modify_button_Click(object sender, EventArgs e)
        {
            if (Variables_list.SelectedIndex >= 0)
            {
                S7Address InputAddress = new S7Address();
                InputAddress = VariableToList(SymbolicName_text.Text, Variable_text.Text, Comment_textBox.Text, Add_text.Text,
                    Multiply_text.Text, Color_button.BackColor, GetFreeBufferAddress(), DisplayFormat_comboBox.GetItemText(DisplayFormat_comboBox.SelectedItem));
                if (InputAddress.DBNumber >= 0)
                {
                    Variable_array[Variables_list.SelectedIndex] = InputAddress;
                    Modify_button.Enabled = false;
                }

                //Refresh Variables list
                RefreshVarList();

            }
        }

        private void LogData_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog Export_Dialog = new SaveFileDialog();
            Export_Dialog.Filter = "CSV files (*csv)|*.csv";
            Export_Dialog.ShowDialog();
            LogData_textbox.Text = Export_Dialog.FileName;
        }

        private void LoadVars_button_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Dialog = new OpenFileDialog();
                //Dialog.InitialDirectory = "C:\\Users\\Default\\Documents";
                Dialog.Filter = "XML File (*.xml)|*.xml";
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    //create the serialiser to create the xml
                    XmlSerializer serialiser = new XmlSerializer(typeof(List<S7Address>));

                    // Create the TextWriter for the serialiser to use
                    TextReader reader = new StreamReader(Dialog.FileName);

                    // Deserialize the file
                    Variable_array = (List<S7Address>)serialiser.Deserialize(reader);

                    // Close the file
                    reader.Close();
                }
                Random randonGen = new Random(); //generate random color
                foreach (S7Address var in Variable_array)
                {
                    var.Color = System.Drawing.Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
                    randonGen.Next(255));
                }
                RefreshVarList();

                Properties.Settings.Default.VariablesList = Dialog.FileName;
                Properties.Settings.Default.Save();
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveVars_button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Dialog = new SaveFileDialog();
                //Dialog.InitialDirectory = "C:\\Users\\Default\\Documents";
                Dialog.Filter = "XML File (*.xml)|*.xml";
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    //create the serialiser to create the xml
                    XmlSerializer serialiser = new XmlSerializer(typeof(List<S7Address>));

                    // Create the TextWriter for the serialiser to use
                    TextWriter writer = new StreamWriter(Dialog.FileName);

                    //write to the file
                    serialiser.Serialize(writer, Variable_array);

                    // Close the file
                    writer.Close();
                }

                Properties.Settings.Default.VariablesList = Dialog.FileName;
                Properties.Settings.Default.Save();
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Variables_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Variables_list.SelectedIndex >= 0)
            {
                Color_button.BackColor = Variable_array[Variables_list.SelectedIndex].Color;
                Variable_text.Text = Variable_array[Variables_list.SelectedIndex].Address;
                SymbolicName_text.Text = Variable_array[Variables_list.SelectedIndex].SymbolicName;
                Add_text.Text = Convert.ToString(Variable_array[Variables_list.SelectedIndex].Add);
                Multiply_text.Text = Convert.ToString(Variable_array[Variables_list.SelectedIndex].Multiply);
                Comment_textBox.Text = Convert.ToString(Variable_array[Variables_list.SelectedIndex].Comment);

                DisplayFormat_comboBox.SelectedIndex = DisplayFormat_comboBox.FindStringExact(Variable_array[Variables_list.SelectedIndex].DisplayFormat);

                //Refresh Variables List
                RefreshVarList();

                Modify_button.Enabled = true;
            }
        }

        private void calculate_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (calculate_checkbox.Checked)
            {
                MaxVal_label.Visible = true;
                MaxVal_textbox.Visible = true;
                MinVal_label.Visible = true;
                MinVal_textbox.Visible = true;
                PLCMax_label.Visible = true;
                PLCMin_label.Visible = true;
                PLCMax_textbox.Visible = true;
                PLCMin_textbox.Visible = true;
            }
            else
            {
                MaxVal_label.Visible = false;
                MaxVal_textbox.Visible = false;
                MinVal_label.Visible = false;
                MinVal_textbox.Visible = false;
                PLCMax_label.Visible = false;
                PLCMin_label.Visible = false;
                PLCMax_textbox.Visible = false;
                PLCMin_textbox.Visible = false;
            }
        }

        private void buttonReadCPUInfo_Click(object sender, EventArgs e)
        {
            ReadCPUInfo();
            ReadOrderCode();
        }

        private void buttonBlockInfo_Click(object sender, EventArgs e)
        {
            GetBlockInfo();
        }

        private void buttonGetDB_Click(object sender, EventArgs e)
        {
            GetSelectedDB();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                CBBlock.SelectedIndex = 1;
                Modify_button.Enabled = false;

                //Initialize Variable Table
                Variable_array = new List<S7Address>();

                OpenFileDialog Dialog = new OpenFileDialog();

                Dialog.FileName = Properties.Settings.Default.VariablesList;
                Dialog.Filter = "XML File (*.xml)|*.xml";
                if (Dialog.ShowDialog() == DialogResult.OK)
                {
                    //create the serialiser to create the xml
                    XmlSerializer serialiser = new XmlSerializer(typeof(List<S7Address>));

                    // Create the TextWriter for the serialiser to use
                    TextReader reader = new StreamReader(Dialog.FileName);

                    // Deserialize the file
                    Variable_array = (List<S7Address>)serialiser.Deserialize(reader);

                    // Close the file
                    reader.Close();
                }
                Random randonGen = new Random(); //generate random color
                foreach (S7Address var in Variable_array)
                {
                    var.Color = System.Drawing.Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
                    randonGen.Next(255));
                }
                RefreshVarList();

                Properties.Settings.Default.VariablesList = Dialog.FileName;
                Properties.Settings.Default.Save();

                textBoxIP.Text = Properties.Settings.Default.IPAddress;
                textBoxRack.Text = Properties.Settings.Default.Rack;
                textBoxSlot.Text = Properties.Settings.Default.Slot;
                LogData_textbox.Text = Properties.Settings.Default.LogPath;
                maxtime_textbox.Text = Properties.Settings.Default.MaxTime;
                Refresh_text.Text = Properties.Settings.Default.RefreshRate;
                Year_checkbox.Checked = Properties.Settings.Default.Year;
                Month_checkBox.Checked = Properties.Settings.Default.Month;
                Day_checkbox.Checked = Properties.Settings.Default.Day;
                Ygrid_checkbox.Checked = Properties.Settings.Default.Y_Major;
                Y_MinorGrid_checkbox.Checked = Properties.Settings.Default.Y_Minor;
                Xgrid_checkBox.Checked = Properties.Settings.Default.X_Major;
                X_MinorGrid_checkbox.Checked = Properties.Settings.Default.X_Minor;
                Maxscale_text.Text = Properties.Settings.Default.Y_MaxScale;
                MinScale_text.Text = Properties.Settings.Default.Y_MinScale;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Client.Disconnect();
                Properties.Settings.Default.IPAddress = textBoxIP.Text;
                Properties.Settings.Default.Rack = textBoxRack.Text;
                Properties.Settings.Default.Slot = textBoxSlot.Text;
                Properties.Settings.Default.LogPath = LogData_textbox.Text;
                Properties.Settings.Default.MaxTime = maxtime_textbox.Text;
                Properties.Settings.Default.RefreshRate = Refresh_text.Text;
                Properties.Settings.Default.Year = Year_checkbox.Checked;
                Properties.Settings.Default.Month = Month_checkBox.Checked;
                Properties.Settings.Default.Day = Day_checkbox.Checked;
                Properties.Settings.Default.Y_Major = Ygrid_checkbox.Checked;
                Properties.Settings.Default.Y_Minor = Y_MinorGrid_checkbox.Checked;
                Properties.Settings.Default.X_Major = Xgrid_checkBox.Checked;
                Properties.Settings.Default.X_Minor = X_MinorGrid_checkbox.Checked;
                Properties.Settings.Default.Y_MaxScale = Maxscale_text.Text;
                Properties.Settings.Default.Y_MinScale = MinScale_text.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool isDuplicate(S7Address input)
        {
            foreach (S7Address variable in Variable_array)
            {
                if (variable.SymbolicName == input.SymbolicName) return true;
            }
            return false;
        }

        private bool isBufferAddressFree(int BufferOffset)
        {
            foreach (S7Address variable in Variable_array)
            {
                if (variable.BufferOffset == BufferOffset) return false;
            }
            return true;
        }

        private int GetFreeBufferAddress()
        {
            int BufferOffset = 0;
            while (!isBufferAddressFree(BufferOffset)) BufferOffset += 10; //find free buffer address
            return BufferOffset;
        }

        private bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }

        void ReadCPUInfo()
        {
            S7Client.S7CpuInfo Info = new S7Client.S7CpuInfo();
            txtModuleTypeName.Text = "";
            txtSerialNumber.Text = "";
            txtAsName.Text = "";
            txtModuleName.Text = "";
            int Result = Client.GetCpuInfo(ref Info);
            ShowResult(Result);
            if (Result == 0)
            {
                txtModuleTypeName.Text = Info.ModuleTypeName;
                txtSerialNumber.Text = Info.SerialNumber;
                txtAsName.Text = Info.ASName;
                txtModuleName.Text = Info.ModuleName;
            }
        }

        void GetBlockInfo()
        {
            S7Client.S7BlockInfo BI = new S7Client.S7BlockInfo();
            int[] BlockType =
            {
                S7Client.Block_OB,
                S7Client.Block_DB,
                S7Client.Block_SDB,
                S7Client.Block_FC,
                S7Client.Block_SFC,
                S7Client.Block_FB,
                S7Client.Block_SFB
            };
            txtBI.Text = "";
            int Result = Client.GetAgBlockInfo(BlockType[CBBlock.SelectedIndex], System.Convert.ToInt32(txtBlockNum.Text), ref BI);
            ShowResult(Result);
            if (Result == 0)
            {
                // Here a more descriptive Block Type, Block lang and so on, are needed, 
                // but I'm too lazy, do it yourself.
                txtBI.Text = txtBI.Text + "Block Type    : " + HexByte((byte)BI.BlkType) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Block Number  : " + Convert.ToString(BI.BlkNumber) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Block Lang    : " + HexByte((byte)BI.BlkLang) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Block Flags   : " + HexByte((byte)BI.BlkFlags) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "MC7 Size      : " + Convert.ToString(BI.MC7Size) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Load Size     : " + Convert.ToString(BI.LoadSize) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Local Data    : " + Convert.ToString(BI.LocalData) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "SBB Length    : " + Convert.ToString(BI.SBBLength) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Checksum      : " + HexWord((ushort)BI.CheckSum) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Version       : 0." + Convert.ToString(BI.Version) + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Code Date     : " + BI.CodeDate + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Intf.Date     : " + BI.IntfDate + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Author        : " + BI.Author + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Family        : " + BI.Family + (char)13 + (char)10;
                txtBI.Text = txtBI.Text + "Header        : " + BI.Header;
            }
        }

        void GetSelectedDB()
        {
            int Size = 65536; // 64 K (the maximum for a S7400)
            byte[] Buffer = new byte[Size];
            txtDBGet.Text = "";
            int Result = Client.DBGet(System.Convert.ToInt32(txtBlockNum.Text), Buffer, ref Size);
            ShowResult(Result);
            if (Result == 0)
            {
                HexDump(txtDBGet, Buffer, Size);
            }
        }

        string HexByte(byte B)
        {
            string Result = Convert.ToString(B, 16);
            if (Result.Length < 2)
                Result = "0" + Result;
            return "0x" + Result;
        }

        string HexWord(ushort W)
        {
            string Result = Convert.ToString(W, 16);
            while (Result.Length < 4)
                Result = "0" + Result;
            return "0x" + Result;
        }

        private void HexDump(TextBox DumpBox, byte[] bytes, int Size)
        {
            if (bytes == null)
                return;
            int bytesLength = Size;
            int bytesPerLine = 16;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            DumpBox.Text = result.ToString();
        }

        private string BuildDateTimeFormat()
        {//"MM/dd/yyyy HH:mm:ss.fff"
            string ret_val = "";
            if (Year_checkbox.Checked) ret_val += "yyyy/";
            if (Month_checkBox.Checked) ret_val += "MM/";
            if (Day_checkbox.Checked) ret_val += "dd";
            if (Hour_checkbox.Checked) ret_val += " HH";
            if (Minute_checkbox.Checked) ret_val += ":mm";
            if (Seconds_checkbox.Checked) ret_val += ":ss";
            if (Miliseconds_checkBox.Checked) ret_val += ".fff";
            if (Regex.IsMatch(ret_val, @"^\W")) ret_val = ret_val.Remove(0, 1);
            return ret_val;
        }

        private void maxtime_textbox_Leave(object sender, EventArgs e)
        {
            int field_value;
            if (int.TryParse(maxtime_textbox.Text, out field_value)) Max_Time = field_value;
        }

        private void Refresh_text_Leave(object sender, EventArgs e)
        {
            int field_value;
            if (int.TryParse(Refresh_text.Text, out field_value)) Refresh_Time = field_value;
        }

        public class S7Address
        {
            public string SymbolicName { get; set; }
            public string Address { get; set; }
            public string Comment = "";
            public string DisplayFormat = "";
            public double Add;
            public double Multiply;
            public Color Color;
            public int Area;
            public int Start;
            public int DBNumber;
            public int Bit;
            public int WordLen;
            public int BufferOffset;
            public double ActualValue;
            //private 

            public int Parse_Address(String Input)
            {

                //string pattern = @"^[iqmtcd][bdw]?\G\d+.*\d*";
                //string pattern = @"^[iqm]{1}[bdw]?\d+.?\d?";
                //string pattern = @"^[iqm]{1}(?([bdw])\d+.\d;\d+)";
                //Make input uppercase and delete whitespaces
                Input = Input.ToUpper();
                Input = Input.Replace(" ", "");
                Address = Input;
                var result = 0;
                //Exception - handle Simulation values
                if (Input.Contains("SIM"))
                {
                    Area = S7Consts.S7AreaPE;
                    WordLen = S7Consts.S7WLByte;
                    Bit = -1;
                    DBNumber = 0;
                    return 1;
                }


                //Split input string with a single dot "."
                string FirstPart = "";
                string SecondPart = "";
                int DotsNo = Input.Length - Input.Replace(".", "").Length;
                if (DotsNo > 2) return -1;
                if (DotsNo >= 1)
                {
                    string[] substrings = Input.Split('.');
                    if (Regex.IsMatch(substrings[0], @"^db\d+\z", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)) //DB
                    {
                        Area = S7Consts.S7AreaDB;
                        string strDBNumber = Regex.Match(substrings[0], @"\d+\z", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToString();
                        if (int.TryParse(strDBNumber, out result)) DBNumber = result;
                        FirstPart = substrings[1];
                        if (DotsNo == 2) SecondPart = substrings[2];
                    }
                    else
                    {
                        FirstPart = substrings[0];
                        SecondPart = substrings[1];
                        DBNumber = 0;
                    }
                }
                else if (DotsNo == 0) FirstPart = Input;


                //Check the first string for proper structure 
                //first letter is i,q,m,t,c,d, second may be b,d,w proceded with numbers
                string pattern = @"^(i|q|m|t|c|db)[bdwx]?\d+\z";
                Match Regex_Match = Regex.Match(FirstPart, pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                if (!Regex_Match.Success) return -1;
                //Extract the type from the string
                string strArea = Regex.Match(FirstPart, @"^(i|q|m|t|c|db)[bdwx]?", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToString();
                string strType = Regex.Match(FirstPart, @"[bdw]", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToString();
                //Extract the start location in the PLC memory from the string
                string strStart = Regex.Match(FirstPart, @"\d+\z", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToString();
                if (int.TryParse(strStart, out result)) Start = result;
                else return -1;
                //Case 1 IQM
                if (Regex.IsMatch(FirstPart, @"^(i|q|m)[bdw]?\d+\z", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                {
                    if (strArea[0] == 'I') Area = S7Consts.S7AreaPE;
                    else if (strArea[0] == 'M') Area = S7Consts.S7AreaMK;
                    else if (strArea[0] == 'Q') Area = S7Consts.S7AreaPA;
                    if (strArea.Length == 1 && DotsNo == 1)
                    {
                        WordLen = S7Consts.S7WLByte;
                        DisplayFormat = "BOOL";
                        if (int.TryParse(SecondPart, out result) && result >= 0 && result <= 7) Bit = result;
                        else return -1;
                    }
                    else if (strArea.Length == 2 && DotsNo == 0)
                    {
                        Bit = -1;
                        if (strArea[1] == 'D')
                        {
                            WordLen = S7Consts.S7WLDWord;
                            DisplayFormat = "DWORD";
                        }
                        else if (strArea[1] == 'B')
                        {
                            WordLen = S7Consts.S7WLByte;
                            DisplayFormat = "BYTE";
                        }

                        else if (strArea[1] == 'W')
                        {
                            WordLen = S7Consts.S7WLWord;
                            DisplayFormat = "WORD";
                        }
                        else return -1;
                    }
                    else return -1;
                }
                //Case 2 CT
                else if (Regex.IsMatch(FirstPart, @"^[ct]{1}\d+\z", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace) && DotsNo == 0)
                {
                    DBNumber = 0;
                    if (strArea[0] == 'C')
                    {
                        Area = S7Consts.S7AreaCT;
                        WordLen = S7Consts.S7WLCounter;
                        DisplayFormat = "COUNTER";
                    }
                    else if (strArea[0] == 'T')
                    {
                        Area = S7Consts.S7AreaTM;
                        WordLen = S7Consts.S7WLTimer;
                        DisplayFormat = "TIMER1MS";
                    }
                }//Case 3 DB
                else if (Regex.IsMatch(FirstPart, @"^db[bdwx]\d+\z", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                {
                    if (strArea[2] == 'X')
                    {
                        WordLen = S7Consts.S7WLByte;
                        DisplayFormat = "BOOL";
                        if (int.TryParse(SecondPart, out result) && result >= 0 && result <= 7) Bit = result;
                        else return -1;
                    }
                    else if (DotsNo == 1)
                    {
                        Bit = -1;
                        if (strArea[2] == 'D')
                        {
                            WordLen = S7Consts.S7WLDWord;
                            DisplayFormat = "DOUBLE";
                        }
                        else if (strArea[2] == 'B')
                        {
                            WordLen = S7Consts.S7WLByte;
                            DisplayFormat = "BYTE";
                        }
                        else if (strArea[2] == 'W')
                        {
                            WordLen = S7Consts.S7WLWord;
                            DisplayFormat = "WORD";
                        }
                        else return -1;
                    }
                    else return -1;

                }
                else return -1;
                return 1;

            }
        }

        private S7Address VariableToList(string name, string address, string comment, string offset, string multiplier, Color color, int bufferOffset, string displayformat = "default")
        {
            S7Address InputAddress = new S7Address();
            if (InputAddress.Parse_Address(address) < 0)
            {
                MessageBox.Show("Address incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Unsuccesfull return
                InputAddress.DBNumber = -1;
            }
            else
            {
                double result;
                if (double.TryParse(offset, out result)) InputAddress.Add = result;
                else InputAddress.Add = 0;
                if (double.TryParse(multiplier, out result)) InputAddress.Multiply = result;
                else InputAddress.Multiply = 1;
                InputAddress.Color = color;
                InputAddress.BufferOffset = bufferOffset;
                if (name.Length > 0) InputAddress.SymbolicName = name;
                else InputAddress.SymbolicName = InputAddress.Address;
                InputAddress.Comment = comment;

                if (InputAddress.WordLen == S7Consts.S7WLDWord &&
                    (displayformat == "DWORD"
                    || displayformat == "REAL"
                    || displayformat == "DINT")) InputAddress.DisplayFormat = displayformat;
                else if (InputAddress.WordLen == S7Consts.S7WLWord &&
                    (displayformat == "WORD"
                    || displayformat == "INT")) InputAddress.DisplayFormat = displayformat;
                else if (InputAddress.WordLen == S7Consts.S7WLByte && InputAddress.Bit == -1 &&
                    displayformat == "BYTE") InputAddress.DisplayFormat = displayformat;
                else if (InputAddress.WordLen == S7Consts.S7WLByte && InputAddress.Bit != -1 &&
                    displayformat == "BOOL") InputAddress.DisplayFormat = displayformat;
                else if (InputAddress.WordLen == S7Consts.S7WLTimer &&
                     (displayformat == "TIMER1MS"
                    || displayformat == "TIMER1S")) InputAddress.DisplayFormat = displayformat;
                else if (InputAddress.WordLen == S7Consts.S7WLCounter &&
                     displayformat == "COUNTER") InputAddress.DisplayFormat = displayformat;
                //else if (displayformat == "default") ;//do nothing
                else
                {
                    MessageBox.Show("Wrong Display Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Unsuccesfull return
                    InputAddress.DBNumber = -1;
                }

                //Successful return

            }
            return InputAddress;

        }

        private void RefreshVarList()
        {
            Variables_list.DataSource = null;
            Variables_list.DataSource = Variable_array;
            Variables_list.DisplayMember = "SymbolicName";
        }

        private double S7TimertoDouble(int inp)
        {
            //check timer base
            /*The value is stored into a word and its format is W#16#BXYZ
                where B is the Base:
                10 ms 00
                100 ms 01
                1 s 10
                10 s 11*/
            int a = 0; //multiplicator
            int x, y, z;
            int res;
            res = (inp & (0xf000));
            if (res == 0x1000) a = 100;//100ms
            else if (res == 0x2000) a = 1000; //1s
            else if (res == 0x3000) a = 10000; //10s
            else a = 10; //10ms
            inp &= 0x0FFF;
            z = inp & 0x0f;
            y = ((inp >> 4) & 0x0f) * 10;
            x = ((inp >> 8) & 0x0f) * 100;
            return a * (x + y + z); //return time in miliseconds

        }

        private double S7CountertoDouble(int inp)
        {
            int x, y, z;
            z = inp & 0x0f;
            y = ((inp >> 4) & 0x0f) * 10;
            x = ((inp >> 8) & 0x0f) * 100;
            return (x + y + z);
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            try
            {
                Reader = new S7MultiVar(Client);

                foreach (S7Address var in Variable_array)
                {
                    Reader.Add(var.Area, var.WordLen, var.DBNumber, var.Start, var.WordLen, ref BufferAB, var.BufferOffset);
                }

                DataRow row = Values_table.NewRow();
                row["Time"] = DateTime.Now.ToString(DateTimeFormat);

                ElapsedTime += Refresh_Time;

                int Result = Reader.Read();
                int r = Reader.Results[0];
                ShowResult(Result);

                foreach (DataColumn column in Values_table.Columns)
                {
                    if (column.ColumnName != "Time")
                    {

                        double result = 0;
                        bool bitresult = false;

                        if (Variable_array[column.Ordinal - 1].WordLen == 0x02)
                        {
                            if (Variable_array[column.Ordinal - 1].Bit >= 0)
                            {
                                bitresult = S7.GetBitAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset, Variable_array[column.Ordinal - 1].Bit);
                                if (bitresult) result = 1;
                                else result = 0;
                            }
                            else result = S7.GetByteAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        }
                        if (Variable_array[column.Ordinal - 1].DisplayFormat == "WORD") result = S7.GetWordAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        if (Variable_array[column.Ordinal - 1].DisplayFormat == "INT") result = S7.GetIntAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        if (Variable_array[column.Ordinal - 1].DisplayFormat == "DINT") result = S7.GetDIntAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        //if (Variable_array[column.Ordinal - 1].WordLen == S7Client.S7WLDWord) result = S7.GetDWordAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        if (Variable_array[column.Ordinal - 1].DisplayFormat == "DWORD") result = S7.GetDWordAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        if (Variable_array[column.Ordinal - 1].DisplayFormat == "REAL") result = S7.GetRealAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset);
                        //Simulation values
                        if (column.ColumnName.Contains("SIM"))
                        {
                            double x = ElapsedTime / Refresh_Time / 100.0;
                            result = System.Math.Sin(x);
                        }

                        // Siemens timers handling
                        if (Variable_array[column.Ordinal - 1].WordLen == 0x1D)
                        {
                            result = S7TimertoDouble(S7.GetWordAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset));
                            if (Variable_array[column.Ordinal - 1].DisplayFormat == "TIMER1S") result = result / 1000;
                        }
                        // Siemens Counter handling
                        if (Variable_array[column.Ordinal - 1].WordLen == 0x1C) result = S7CountertoDouble(S7.GetWordAt(BufferAB, Variable_array[column.Ordinal - 1].BufferOffset));

                        // apply multiplicator and offset
                        result = result * Variable_array[column.Ordinal - 1].Multiply + Variable_array[column.Ordinal - 1].Add;
                        // add value to tables
                        row[column.Ordinal] = result;
                        Variable_array[column.Ordinal - 1].ActualValue = result;


                    }
                }
                // Save last view
                int tmpScrollingRowIndex = Variables_dataGridView.FirstDisplayedScrollingRowIndex;
                Point tmpCell = Variables_dataGridView.CurrentCellAddress;
                //Clear the table
                Variables_dataGridView.Rows.Clear();
                //Populate Actual Value Table
                foreach (S7Address variable in Variable_array)
                {
                    string[] row1 = new string[] { variable.Address.ToString(), variable.SymbolicName.ToString(), variable.Comment, variable.DisplayFormat, variable.ActualValue.ToString(), "" };
                    Variables_dataGridView.Rows.Add(row1);
                    Variables_dataGridView.Rows[Variables_dataGridView.Rows.Count - 1].Cells["Color"].Style.BackColor = variable.Color;
                }
                //restore last view   
                if (tmpCell.X >= 0 && tmpCell.Y >= 0) Variables_dataGridView.CurrentCell = Variables_dataGridView[tmpCell.X, tmpCell.Y];
                if (tmpScrollingRowIndex >= 0) Variables_dataGridView.FirstDisplayedScrollingRowIndex = tmpScrollingRowIndex;




                //keep the chart in the same length
                if (Max_Time > 0 && Refresh_Time > 0)
                {
                    DateTime tmp = DateTime.Parse(Values_table.Rows[0]["Time"].ToString());
                    DateTime now = DateTime.Now;
                    double ms = now.Subtract(tmp).TotalMilliseconds;

                    while (ms > Max_Time * 1000)
                    {
                        //Max_Rows = Max_Time * 1000 / Refresh_Time;
                        Values_table.Rows[0].Delete();
                        Values_table.AcceptChanges();
                        tmp = DateTime.Parse(Values_table.Rows[0]["Time"].ToString());

                        ms = now.Subtract(tmp).TotalMilliseconds;
                    }


                }


                Values_table.Rows.Add(row);
                Values_table.AcceptChanges();

                //Save data to file

                if (LogData_checkbox.Checked)
                {
                    //Append values
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(";", fields));
                    //DataLog.WriteLine(sb.ToString());
                    try
                    {
                        File.AppendAllText(LogData_textbox.Text, sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogData_checkbox.Checked = false;
                    }
                }

                //refresh chart and grid view only if visible
                tabControl1_SelectedIndexChanged(this, e);
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CommunicationTimer.Stop();
            }
        }

        private void TooltipEvent(object sender, EventArgs e)
        {
            GeneralTooltip.SetToolTip(textBoxIP, "IP Address in a form xxx.xxx.xxx.xxx \n or write simulation for demo");
            GeneralTooltip.SetToolTip(maxtime_textbox, "Maximal time for chart and table view. Values older are not kept.\nIf 0, the time is infinite.");
            GeneralTooltip.SetToolTip(Refresh_text, "Time in miliseconds between each value collection from PLC.");
            GeneralTooltip.SetToolTip(Variable_text, "PLC variable Address, no spaces \n e.g. I400.0, DB300.DBB3, IW360\n or SIM1, SIM2 etc. for demo");
            GeneralTooltip.SetToolTip(SymbolicName_text, "Name used for variable display in chart and table");
            GeneralTooltip.SetToolTip(Add_text, "Raw value is increased by this value.\n Can be used to move a variable verticaly on chart");
            GeneralTooltip.SetToolTip(Multiply_text, "Raw value is multiplied by this value.");
            GeneralTooltip.SetToolTip(Variables_list, "Maximum variables in single list = " + S7Client.MaxVars.ToString());

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDown.SelectedIndex == 0 && !Pause_checkBox.Checked) chart1.DataBind();

            if (tabDown.SelectedIndex == 1)
            {
                if (Pause_checkBox.Checked)
                {
                    dataGridView.DataSource = snapshot;
                }
                else dataGridView.DataSource = Values_table;

            }
            else dataGridView.DataSource = null;
        }

        private void InterfaceRefreshtimer_Tick(object sender, EventArgs e)
        {
            //Get PLC Status
            int PLCStatus = 0;
            Client.PlcGetStatus(ref PLCStatus);
            switch (PLCStatus)
            {
                case 0x08:
                    CPUStatus_label.Text = "RUN";
                    CPU_STATUS.BackColor = System.Drawing.Color.Green;
                    break;
                case 0x04:
                    CPUStatus_label.Text = "STOP";
                    CPU_STATUS.BackColor = System.Drawing.Color.Red;
                    break;
                default:
                    CPUStatus_label.Text = "Unknown";
                    CPU_STATUS.BackColor = System.Drawing.Color.Transparent;
                    break;
            }
        }

        private void IP_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonConnect_Click(this, e);
            }
        }

        private void ReadOrderCode()
        {
            S7Client.S7OrderCode Info = new S7Client.S7OrderCode();
            txtOrderCode.Text = "";
            txtVersion.Text = "";
            int Result = Client.GetOrderCode(ref Info);
            ShowResult(Result);
            if (Result == 0)
            {
                txtOrderCode.Text = Info.Code;
                txtVersion.Text = Info.V1.ToString() + "." + Info.V2.ToString() + "." + Info.V3.ToString();
            }
        }

        private void More_button_Click(object sender, EventArgs e)
        {
            SymbolsPick.ShowDialog();
            S7Address variable;
            if (SymbolsPick.SymboleList != null)
            {

                Random randonGen = new Random();

                foreach (DataGridViewRow row in SymbolsPick.SymboleList)
                {
                    //generate random colour
                    Color randomColor = System.Drawing.Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
                    randonGen.Next(255));
                    variable = VariableToList(row.Cells["Symbol"].Value.ToString(), row.Cells["Address"].Value.ToString(),
                        row.Cells["Comment"].Value.ToString(), "", "", randomColor, GetFreeBufferAddress());
                    if (variable.DBNumber >= 0) Variable_array.Add(variable);
                }
            }
            RefreshVarList();
        }

        private void dbPicker_button_Click(object sender, EventArgs e)
        {
            DBpicker.ShowDialog();
            S7Address variable;
            if (DBpicker.DBList != null)
            {
                Random randonGen = new Random();

                foreach (DataGridViewRow row in DBpicker.DBList)
                {
                    //generate random colour
                    Color randomColor = System.Drawing.Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
                    randonGen.Next(255));
                    variable = VariableToList(row.Cells["Symbol"].Value.ToString(), row.Cells["Address"].Value.ToString(),
                        row.Cells["Comment"].Value.ToString(), "", "", randomColor, GetFreeBufferAddress(), row.Cells[2].Value.ToString());
                    if (variable.DBNumber >= 0) Variable_array.Add(variable);
                }
            }
            RefreshVarList();
        }

        private void MinScale_text_TextChanged(object sender, EventArgs e)
        {
            double field_value;
            if (double.TryParse(MinScale_text.Text, out field_value) && field_value < chart1.ChartAreas[0].AxisY.Maximum)
            {
                chart1.ChartAreas[0].AxisY.Minimum = field_value;
                Properties.Settings.Default.Y_MinScale = MinScale_text.Text;
                Properties.Settings.Default.Save();
            }
            else chart1.ChartAreas[0].AxisY.Minimum = double.NaN;

        }

        private void Maxscale_text_TextChanged(object sender, EventArgs e)
        {
            double field_value;
            if (double.TryParse(Maxscale_text.Text, out field_value) && field_value > chart1.ChartAreas[0].AxisY.Minimum)
            {
                chart1.ChartAreas[0].AxisY.Maximum = field_value;
                Properties.Settings.Default.Y_MaxScale = Maxscale_text.Text;
                Properties.Settings.Default.Save();
            }
            else chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
        }

        private void Legend_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Legends[0].Enabled = Legend_checkbox.Checked;
        }

        private void Xgrid_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = Xgrid_checkBox.Checked;
        }
        private void X_MinorGrid_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = X_MinorGrid_checkbox.Checked;
        }

        private void Ygrid_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = Ygrid_checkbox.Checked;
        }
        private void Y_MinorGrid_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = Y_MinorGrid_checkbox.Checked;
        }

        private void Interval_text_TextChanged(object sender, EventArgs e)
        {
            double field_value;
            if (double.TryParse(X_Interval_text.Text, out field_value))
            {
                //field_value = field_value;
                chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = field_value;
                chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = field_value / 5;
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = field_value;
            }
        }

        private void Y_Interval_text_TextChanged(object sender, EventArgs e)
        {
            double field_value;
            if (double.TryParse(Y_Interval_text.Text, out field_value))
            {
                chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = field_value;
                chart1.ChartAreas[0].AxisY.MinorTickMark.Interval = field_value / 5;
                chart1.ChartAreas[0].AxisY.LabelStyle.Interval = field_value;
            }
        }

        private void btnOpenS7Project_Click(object sender, EventArgs e)
        {
            int left = 0;
            int num1 = 0;
            int num2 = 0;
            int codepage = 0;
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            OleDbConnection connection2 = new OleDbConnection();
            OleDbCommand command2 = new OleDbCommand();

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "";
            ofd.Filter = "S7 projects (*.s7p)|*.s7p";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                string directoryName = Path.GetDirectoryName(fileName);

                if (fileName != "")
                {
                    if (File.Exists(directoryName + @"\Global\Language.old") | File.Exists(directoryName + @"\Global\Language"))
                    {
                        try
                        {
                            FileStream stream = !File.Exists(directoryName + @"\Global\Language") ? new FileStream(directoryName + @"\Global\Language.old", FileMode.Open, FileAccess.Read, FileShare.ReadWrite) : new FileStream(directoryName + @"\Global\Language", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            StreamReader reader3 = new StreamReader(stream);
                            int num4 = 0;
                            while (true)
                            {
                                if (reader3.Peek() <= 0)
                                {
                                    this.enc2 = (codepage <= 0) ? Encoding.GetEncoding(this.CodePage) : Encoding.GetEncoding(codepage);
                                    reader3.Close();
                                    stream.Close();
                                    break;
                                }
                                string str4 = reader3.ReadLine();
                                if (num4 == 3)
                                {
                                    codepage = Convert.ToInt16(str4);
                                }
                                num4++;
                            }
                        }
                        catch (Exception exception1)
                        {
                            Exception ex = exception1;
                            Exception exception = ex;
                        }
                    }
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directoryName + @"\ombstx\offline\;Extended Properties=dBASE IV;";
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT ID, NAME, ANZDB FROM BSTCNTOF.DBF ORDER BY ID";
                    OleDbDataReader reader = command.ExecuteReader();

                    if (connection.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Can not connect to Data base", "Ha Ha Ha !!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        while (true)
                        {
                            if (!reader.Read())
                            {
                                break;
                            }
                            if (Operators.ConditionalCompareObjectGreater(reader["ANZDB"], 0, false))
                            {
                                clsBlockCont item = new clsBlockCont(Conversions.ToString(reader["NAME"]), Conversions.ToInteger(reader["ID"]), directoryName);
                                this.Containers.Add(item, null, null, null);
                                left = Conversions.ToInteger(Operators.AddObject(left, reader["ANZDB"]));
                            }
                        }
                    }
                    connection.Close();

                    IEnumerator enumerator2;
                    try
                    {
                        clsBlockCont current;
                        OleDbDataReader reader4;
                        enumerator2 = this.Containers.GetEnumerator();
                        goto TR_0051;
                    TR_000D:
                        connection.Close();
                        goto TR_0051;
                    TR_0028:
                        while (true)
                        {
                            if (!reader4.Read())
                            {
                                break;
                            }
                            string str8 = Conversions.ToString(reader4["BLKNUMBER"]);
                            object expression = reader4["USERNAME"];
                            bool flag26 = !Information.IsDBNull(expression);
                            if (!flag26 || !Operators.ConditionalCompareObjectEqual(expression, "ES_MAP", false))
                            {
                                try
                                {
                                    object obj3;
                                    clsDb db;
                                    OleDbCommand command4 = new OleDbCommand
                                    {
                                        Connection = connection,
                                        CommandText = "SELECT OBJECTID, SUBBLKTYP, BLKNUMBER, MC5LEN, USERNAME, BLOCKFNAME, BLOCKNAME, VERSION  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00010' AND BLKNUMBER = '" + str8 + "' "
                                    };
                                    OleDbDataReader dr = command4.ExecuteReader();
                                    dr.Read();
                                    if (!Information.IsDBNull(reader4["MC5CODE"]))
                                    {
                                        try
                                        {
                                            obj3 = reader4["MC5CODE"];
                                            goto TR_001C;
                                        }
                                        catch (Exception exception11)
                                        {
                                            Exception ex = exception11;
                                            ProjectData.SetProjectError(ex);
                                            Exception exception5 = ex;
                                            ProjectData.ClearProjectError();
                                        }
                                    }
                                    continue;
                                TR_0010:
                                    dr.Close();
                                    dr = null;
                                    command4.Dispose();
                                    continue;
                                TR_0011:
                                    current.Dbs.Add(db, null, null, null);
                                    num2++;
                                    this.tstStatus.Text = "DB " + Conversions.ToString(db.Number);
                                    this.tpbProgress.Value = num2;
                                    base.Update();
                                    goto TR_0010;
                                TR_001C:
                                    object[] objArray1 = new object[] { "\r\n" };
                                    string[] strArray = (string[])NewLateBinding.LateGet(obj3, null, "Split", objArray1, null, null, null);
                                    if ((strArray.GetUpperBound(0) <= 1) || LikeOperator.LikeString(strArray[1], "*VAR*", Microsoft.VisualBasic.CompareMethod.Binary))
                                    {
                                        goto TR_0010;
                                    }
                                    else
                                    {
                                        OleDbDataReader reader7 = new OleDbCommand
                                        {
                                            Connection = connection,
                                            CommandText = "SELECT OBJECTID, SSBPART, BLKNUMBER  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00020' AND BLKNUMBER = '" + str8 + "' "
                                        }.ExecuteReader();
                                        reader7.Read();
                                        db = new clsDb(dr, reader7[1], current.Directory);
                                        if (current.SymbolDirectory != "")
                                        {
                                            try
                                            {
                                                connection2.Open();
                                                command2.Connection = connection2;
                                                command2.CommandText = "SELECT [_SKZ], [_COMMENT] FROM SYMLIST.DBF WHERE ([_OPCODE] = 5) AND ([_OPBYTEO] = " + Conversions.ToString(db.Number) + ")";
                                                OleDbDataReader reader2 = command2.ExecuteReader();
                                                if (connection2.State == ConnectionState.Open)
                                                {
                                                    reader2.Read();
                                                    string s = reader2[0].ToString();
                                                    string str10 = reader2[1].ToString();
                                                    byte[] bytes = this.enc.GetBytes(s);
                                                    s = this.enc2.GetString(bytes);
                                                    byte[] buffer4 = this.enc.GetBytes(str10);
                                                    str10 = this.enc2.GetString(buffer4);
                                                    if (!Information.IsDBNull(s))
                                                    {
                                                        db.Symbol = s;
                                                        db.SymbolComment = str10;
                                                    }
                                                }
                                                connection2.Close();
                                            }
                                            catch (Exception exception12)
                                            {
                                                Exception ex = exception12;
                                                ProjectData.SetProjectError(ex);
                                                Exception exception6 = ex;
                                                connection2.Close();
                                                ProjectData.ClearProjectError();
                                            }
                                        }
                                    }
                                    goto TR_0011;
                                }
                                catch (Exception exception13)
                                {
                                    Exception ex = exception13;
                                    ProjectData.SetProjectError(ex);
                                    Exception exception7 = ex;
                                    ProjectData.ClearProjectError();
                                }
                            }
                        }
                        goto TR_000D;
                    TR_0029:
                        this.lbxBlockCont.Items.Add(current);
                        connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + current.Directory + ";Extended Properties=dBASE IV;";
                        connection.Open();
                        reader4 = new OleDbCommand
                        {
                            Connection = connection,
                            CommandText = "SELECT MC5CODE, BLKNUMBER, USERNAME FROM SUBBLK.DBF WHERE SUBBLKTYP = '00006'  ORDER BY BLKNUMBER"
                        }.ExecuteReader();
                        if (connection.State != ConnectionState.Open)
                        {
                            goto TR_000D;
                        }
                        goto TR_0028;
                    TR_003B:
                        if (current.ContId > 0)
                        {
                            try
                            {
                                connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + current.ProjectDirectory + @"\YDBs\;Extended Properties=dBASE IV;";
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = "SELECT SOI  FROM YLNKLIST.DBF WHERE TOI = " + Conversions.ToString(current.ContId);
                                reader = command.ExecuteReader();
                                if (connection.State == ConnectionState.Open)
                                {
                                    reader.Read();
                                    int num6 = 0;
                                    string str5 = Conversions.ToString(reader["SOI"]);
                                    if (Versioned.IsNumeric(reader["SOI"]))
                                    {
                                        num6 = Conversions.ToInteger(reader["SOI"]);
                                        current.SymbolDirectory = current.ProjectDirectory + @"\YDBs\" + Conversions.ToString(num6) + @"\";
                                    }
                                }
                                connection.Close();
                                File.Copy(current.SymbolDirectory + @"\SYMLIST.DBF", Application.StartupPath + @"\SYMLIST.DBF", true);
                                FileStream output = new FileStream(Application.StartupPath + @"\SYMLIST.DBF", FileMode.Open);
                                BinaryWriter writer = new BinaryWriter(output);
                                writer.Seek(15, SeekOrigin.Begin);
                                writer.Write((byte)0);
                                output.Close();
                                connection2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + ";Extended Properties=dBASE IV;";
                                if (current.ProgramName != "")
                                {
                                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + current.ProjectDirectory + @"\hrs\;Extended Properties=dBASE IV;";
                                    connection.Open();
                                    command.Connection = connection;
                                    command.CommandText = "SELECT RSRVD2_L, RSRVD10_C  FROM S7RESONL.DBF WHERE [NAME] = '" + current.ProgramName + "'";
                                    reader = command.ExecuteReader();
                                    if (connection.State == ConnectionState.Open)
                                    {
                                        reader.Read();
                                        int num7 = 0;
                                        string expression = Conversions.ToString(reader[0]);
                                        if (Versioned.IsNumeric(expression))
                                        {
                                            num7 = Conversions.ToInteger(expression);
                                            current.Rack = (int)Math.Round(Conversion.Int((double)(((double)num7) / 0x20)));
                                            current.Slot = num7 % 0x20;
                                        }
                                        string s = Conversions.ToString(reader[1]);
                                        byte[] bytes = this.enc.GetBytes(s);
                                        string[] textArray1 = new string[] { Conversions.ToString(bytes[0]), ".", Conversions.ToString(bytes[1]), ".", Conversions.ToString(bytes[2]), ".", Conversions.ToString(bytes[3]) };
                                        current.IPAddress = string.Concat(textArray1);
                                    }
                                    connection.Close();
                                }
                            }
                            catch (Exception exception10)
                            {
                                Exception ex = exception10;
                                ProjectData.SetProjectError(ex);
                                Exception exception4 = ex;
                                connection.Close();
                                ProjectData.ClearProjectError();
                            }
                        }
                        goto TR_0029;
                    TR_0042:
                        if (current.ContId > 0)
                        {
                            try
                            {
                                connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + current.ProjectDirectory + @"\hrs\;Extended Properties=dBASE IV;";
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = "SELECT [ID], [NAME]  FROM S7RESOFF.DBF WHERE ID = " + Conversions.ToString(current.ContId);
                                reader = command.ExecuteReader();
                                if (connection.State == ConnectionState.Open)
                                {
                                    reader.Read();
                                    current.ProgramName = Conversions.ToString(reader["NAME"]);
                                }
                                connection.Close();
                            }
                            catch (Exception exception9)
                            {
                                Exception ex = exception9;
                                ProjectData.SetProjectError(ex);
                                Exception exception3 = ex;
                                connection.Close();
                                ProjectData.ClearProjectError();
                            }
                        }
                        goto TR_003B;
                    TR_0051:
                        while (true)
                        {
                            if (enumerator2.MoveNext())
                            {
                                current = (clsBlockCont)enumerator2.Current;
                                if (File.Exists(current.Directory + "links.lnk"))
                                {
                                    try
                                    {
                                        FileStream input = new FileStream(current.Directory + "links.lnk", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                        BinaryReader reader5 = new BinaryReader(input);
                                        input.Seek(0x210L, SeekOrigin.Begin);
                                        bool flag14 = true;
                                        byte[] buffer = new byte[8];
                                        while (true)
                                        {
                                            if (!(flag14 & (input.Length > (input.Position + 8L))))
                                            {
                                                input.Close();
                                                break;
                                            }
                                            buffer = reader5.ReadBytes(8);
                                            if (((buffer[0] == 1) & (buffer[1] == 0x41)) & (buffer[2] == 20))
                                            {
                                                current.ContId = (buffer[3] * 0x100) + buffer[4];
                                                flag14 = false;
                                            }
                                        }
                                    }
                                    catch (Exception exception8)
                                    {
                                        Exception ex = exception8;
                                        ProjectData.SetProjectError(ex);
                                        Exception exception2 = ex;
                                        ProjectData.ClearProjectError();
                                    }
                                }
                            }
                            else
                            {
                                File.Delete(Application.StartupPath + @"\SYMLIST.DBF");
                                this.tstStatus.Text = Conversions.ToString(num2) + " Data blocks found";
                                if (this.lbxBlockCont.Items.Count > 0)
                                {
                                    this.lbxBlockCont.SelectedIndex = 0;
                                }
                                if (this.lbxDbs.Items.Count > 0)
                                {
                                    this.lbxDbs.SelectedIndex = 0;
                                }
                                this.tpbProgress.Value = 0;
                                this.Cursor = Cursors.Arrow;
                                return;
                            }
                            break;
                        }
                        goto TR_0042;
                    }
                    finally
                    {
                        enumerator2 = this.Containers.GetEnumerator();
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                }
            }
        }

        private void lbxBlockCont_MouseMove(object sender, MouseEventArgs e)
        {
            object[] arguments = new object[] { new Point(e.X, e.Y) };
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, null, "IndexFromPoint", arguments, null, null, null));
            tstStatus.Text = num.ToString();

            if ((num != -1))
            {
                object[] objArray;
                bool[] flagArray;
                object[] objArray2 = new object[] { num };
                bool[] flagArray1 = new bool[] { true };
                object instance = NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Items", new object[0], null, null, null), null, "Item", objArray = objArray2, null, null, flagArray = flagArray1);
                if (flagArray[0])
                {
                    num = (int)Conversions.ChangeType(objArray[0], typeof(int));
                }
                string caption = Conversions.ToString(NewLateBinding.LateGet(instance, null, "GetToolTip", new object[0], null, null, null));
                this.toolTip1.SetToolTip((Control)sender, caption);
            }
        }

        private void lbxBlockCont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbxBlockCont.SelectedItem == null)
            {
                return;
            }
            else
            {
                clsBlockCont selectedItem = (clsBlockCont)this.lbxBlockCont.SelectedItem;
                if (true)
                {
                    IEnumerator enumerator;
                    this.lbxDbs.Items.Clear();
                    //this.lbxSelDbs.Items.Clear();
                    //this.tvwDbTags.Nodes.Clear();
                    try
                    {
                        enumerator = selectedItem.Dbs.GetEnumerator();
                        while (true)
                        {
                            if (!enumerator.MoveNext())
                            {
                                break;
                            }
                            clsDb current = (clsDb)enumerator.Current;
                            this.lbxDbs.Items.Add(current);
                        }
                    }
                    finally
                    {
                        enumerator = selectedItem.Dbs.GetEnumerator();
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                }
            }
        }
    }
}
