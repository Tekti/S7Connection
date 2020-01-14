using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace S7Connection
{
    public partial class SymbolsPick : Form
    {
        public DataGridViewSelectedRowCollection SymboleList;
        
        public SymbolsPick()
        {
            InitializeComponent();
        }

        private void SymbolePicker_Load(object sender, EventArgs e)
        {
            if (SymboleFilePath_text.Text == "") OpenSymboleFile();

        }
        void OpenSymboleFile()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "DIF/SEQ File (*.dif;*.seq)|*.dif;*.seq";

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SymboleFilePath_text.Text = Dialog.FileName;
                string extension = Path.GetExtension(Dialog.FileName);
                switch (extension)
                {
                    case ".seq":
                        Parse_SEQ(SymboleFilePath_text.Text);
                        break;
                    case ".dif":
                        Parse_DIF(SymboleFilePath_text.Text);
                        break;

                    default:
                        break;
                }

            }
        }

        void Parse_DIF(string path)
        {
            if (path != "")
            {

                try
                {
                    System.IO.File.OpenRead(path);

                    StreamReader File = new StreamReader(path, true);
                    string line;
                    string[] values;
                    int MaxColumnNumber = 0;
                    //int Row = 0;
                    int Cell = 0;
                    int MaxRowNumber = 0;
                    Symbole_dataGridView.Rows.Clear();
                    while (!File.EndOfStream)
                    {
                        line = File.ReadLine();
                        switch (line)
                        {
                            case "TABLE":
                                //stub
                                break;
                            case "VECTORS":
                                line = File.ReadLine();
                                values = line.Split(',');
                                int.TryParse(values[1], out MaxRowNumber);   //get number of rows from file
                                //Symbole_dataGridView.Rows.Add(MaxRowNumber);
                                break;
                            case "TUPLES":
                                line = File.ReadLine();
                                values = line.Split(',');
                                int.TryParse(values[1], out MaxColumnNumber);   //get number of columns from file
                                /*while (MaxColumnNumber < tmpvalue)
                                {
                                    Symbole_dataGridView.Columns.Add(MaxColumnNumber.ToString(), MaxColumnNumber.ToString());
                                    MaxColumnNumber++;
                                }*/
                                break;
                            case "DATA":
                                break;
                            case "BOT":

                                line = File.ReadLine();
                                values = line.Split(',');
                                string[] propValues = new string[5];
                                //single row parsing
                                while (values[0] == "1" || values[0] == "0") //1 = there is a string, 0 = there is a value, -1 end of row
                                {

                                    if (values[0] == "1")//a string value
                                    {
                                        line = File.ReadLine(); //value is in another line
                                        line = line.Trim('"');
                                        propValues[Cell] = line;
                                        //Symbole_dataGridView.Rows[Row].Cells[Cell].Value = line; //write value to cell
                                    }
                                    else //a numeric value
                                        propValues[Cell] = values[1];
                                    //Symbole_dataGridView.Rows[Row].Cells[Cell].Value = values[1];// value is after comma


                                    if (Cell <= MaxColumnNumber) Cell++; //move to another cell, but do not exceed number of columns
                                    // Read another line to be checked if we reached the end
                                    line = File.ReadLine();
                                    values = line.Split(',');
                                }
                                Symbole_dataGridView.Rows.Add(propValues);
                                // if (Row<=MaxRowNumber)Row++;// at the end increase row if we didn't reach the end                            
                                Cell = 0; //reset Cell number
                                break;
                            default:
                                break;
                        }

                    }
                }
                catch (Exception exept)
                {
                    MessageBox.Show(exept.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SymboleFilePath_text.Text = "";
                }
            }
        }

        void Parse_SEQ(string path)
        {
            if (path != "")
            {

                try
                {
                    System.IO.File.OpenRead(path);

                    StreamReader File = new StreamReader(path, Encoding.GetEncoding(1257));
                    string line;
                    Symbole_dataGridView.Rows.Clear();
                    while (!File.EndOfStream)
                    {
                        line = File.ReadLine();
                        string[] values = line.Split('\t');
                        string[] propValues = { values[2], values[1], "", values[3] };
                        Symbole_dataGridView.Rows.Add(propValues);
                    }
                }
                catch (Exception exept)
                {
                    MessageBox.Show(exept.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SymboleFilePath_text.Text = "";
                }
            }


        }

        private void Open_button_Click(object sender, EventArgs e)
        {
            OpenSymboleFile();
        }

        private void Select_button_Click(object sender, EventArgs e)
        {
            SymboleList = Symbole_dataGridView.SelectedRows;

            this.Close();

        }
    }
}
