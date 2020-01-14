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
using System.Data.OleDb;
using ExcelDataReader;


namespace S7Connection
{
    public partial class DBpicker : Form
    {
        public DataGridViewSelectedRowCollection DBList;
        public DBpicker()
        {
            InitializeComponent();
        }

        private void DBpicker_Load(object sender, EventArgs e)
        {
            if (SymboleFilePath_text.Text == "") OpenDBFile();
        }

        void OpenDBFile()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Filter = "XLSX/XLS File (*.xlsx;*.xls)|*.xlsx;*.xls";

            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                SymboleFilePath_text.Text = Dialog.FileName;
                string extension = Path.GetExtension(Dialog.FileName);
                switch (extension)
                {
                    case ".xlsx":
                        Parse_XLSX(SymboleFilePath_text.Text);
                        break;

                    default:
                        break;
                }

            }
        }

        DataTableCollection tableCollection;

        void Parse_XLSX(string path)
        {
            if (path != "")
            {
                try
                {
                    using(var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var start = 7;
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() {
                                    UseHeaderRow = true,       
                                    }
                            }) ;
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                    Symbole_dataGridView.Rows.Clear();
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
            OpenDBFile();
        }

        private void Select_button_Click(object sender, EventArgs e)
        {
            DBList = Symbole_dataGridView.SelectedRows;

            this.Close();

        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 7; i < tableCollection[cboSheet.SelectedIndex].Rows.Count; i++)
            {
                DataRow row = tableCollection[cboSheet.SelectedIndex].Rows[i];
                if (row[2].ToString() == "BOOL" || row[2].ToString() == "BYTE" || row[2].ToString() == "WORD" || row[2].ToString() == "DWORD" || row[2].ToString() == "REAL" || row[2].ToString() == "INT" || row[2].ToString() == "DINT")
                {
                    if (row[2].ToString() == "BYTE" && row[0].ToString().Contains("DBX"))
                    {
                        row[0] = row[0].ToString().Replace("DBX","DBB").Substring(0,row[0].ToString().Length-2);
                    }
                    else if (row[2].ToString() == "WORD" && row[0].ToString().Contains("DBX"))
                    {
                        row[0] = row[0].ToString().Replace("DBX", "DBW").Substring(0, row[0].ToString().Length - 2);
                    }
                    else if (row[2].ToString() == "DWORD" && row[0].ToString().Contains("DBX"))
                    {
                        row[0] = row[0].ToString().Replace("DBX", "DBD").Substring(0, row[0].ToString().Length - 2);
                    }
                    else if (row[2].ToString() == "REAL" && row[0].ToString().Contains("DBX"))
                    {
                        row[0] = row[0].ToString().Replace("DBX", "DBD").Substring(0, row[0].ToString().Length - 2);
                    }
                    else if (row[2].ToString() == "INT" && row[0].ToString().Contains("DBX"))
                    {
                        row[0] = row[0].ToString().Replace("DBX", "DBW").Substring(0, row[0].ToString().Length - 2);
                    }
                    else if (row[2].ToString() == "DINT" && row[0].ToString().Contains("DBX"))
                    {
                        row[0] = row[0].ToString().Replace("DBX", "DBD").Substring(0, row[0].ToString().Length - 2);
                    }

                    row[0] = tableCollection[cboSheet.SelectedIndex].TableName + "." + row[0]; 

                    string[] propValues = { row[1].ToString(), row[0].ToString(), row[2].ToString(), row[5].ToString() };
                    Symbole_dataGridView.Rows.Add(propValues);
                } 
            }
        }
    }
}
