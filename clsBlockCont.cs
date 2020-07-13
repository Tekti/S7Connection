using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace S7Connection
{
    public class clsBlockCont
    {
        private libnodave.daveConnection myDc;
        private libnodave.daveOSserialType myFds;
        private libnodave.daveInterface myDi;
        private bool myConnected;
        private string myName;
        private int myId;
        private int myContId;
        private string myProjectDirectory;
        private string mySymbolDirectory;
        private string myDirectory;
        private Collection myDbs;
        private string mySource;
        private string myProgramName;
        private string myIPAddress;
        private int myRack;
        private int mySlot;
        private string myCodePage1;
        private string myCodePage2;

        // Properties
        public libnodave.daveConnection MyDc { get { return myDc; } set { myDc = value; } }

        public string Name { get { return myName; } set { myName = value; } }

        public int Id { get { return myId; } set { myId = value; } }

        public int ContId { get { return myContId; } set { myContId = value; } }

        public string ProjectDirectory =>
            this.myProjectDirectory;

        public string SymbolDirectory { get { return mySymbolDirectory; } set { mySymbolDirectory = value; } }

        public string Directory =>
            this.myDirectory;

        public Collection Dbs =>
            this.myDbs;

        public string Source { get { return mySource; } set { mySource = value; } }

        public string ProgramName { get { return myProgramName; } set { myProgramName = value; } }

        public string IPAddress { get { return myIPAddress; } set { myIPAddress = value; } }

        public int Rack { get { return myRack; } set { myRack = value; } }

        public int Slot { get { return mySlot; } set { mySlot = value; } }

        public string CodePage1 { get { return myCodePage1; } set { myCodePage1 = value; } }

        public string CodePage2 { get { return myCodePage2; } set { myCodePage2 = value; } }

        public clsBlockCont(string Name)
        {
            this.myIPAddress = "192.168.0.1";
            this.myRack = 0;
            this.mySlot = 1;
            this.myDbs = new Collection();
            this.myName = Name;
            this.myProjectDirectory = "";
            this.myId = 0;
            this.myDirectory = "";
            this.myContId = 0;
            this.myProgramName = "";
            this.mySource = "Excel";
        }

        public clsBlockCont(string Name, int Id, string ProjmyDir)
        {
            this.myIPAddress = "192.168.0.1";
            this.myRack = 0;
            this.mySlot = 1;
            this.myDbs = new Collection();
            this.myName = Name;
            this.myProjectDirectory = ProjmyDir;
            this.myId = Id;
            string str = "00000000" + Conversion.Hex(Id);
            this.myDirectory = this.myProjectDirectory + @"\ombstx\offline\" + str.Substring(str.Length - 8, 8) + @"\";
            this.myContId = 0;
            this.myProgramName = "";
            this.mySource = "S7";
        }

        public string GetToolTip()
        {
            string[] textArray1 = new string[11];
            textArray1[0] = this.myName;
            textArray1[1] = ", ID=";
            textArray1[2] = Conversions.ToString(this.myId);
            textArray1[3] = ", \r\n";
            textArray1[4] = this.myDirectory;
            textArray1[5] = "IP Address: ";
            textArray1[6] = this.myIPAddress;
            textArray1[7] = ", Rack: ";
            textArray1[8] = Conversions.ToString(this.myRack);
            textArray1[9] = ", Slot:";
            textArray1[10] = Conversions.ToString(this.mySlot);
            return string.Concat(textArray1);
        }

        public override string ToString()
        {
            string myProgramName = this.myProgramName;
            if (this.myProgramName != "")
            {
                myProgramName = myProgramName + "/";
            }
            return (myProgramName + this.myName);
        }

       

    }
}
