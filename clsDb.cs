using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S7Connection
{
    public class clsDb
    {
        // Fields
        private bool myReadDone;
        private int Level;
        private int myId;
        private int myNumber;
        private string mySymbol;
        private string mySymbolComment;
        private string MyAuthor;
        private string myFamily;
        private string myName;
        private string myComment;
        private string myDirectory;
        private string myVersion;
        private Collection myTags;
        private int myLength;

        // Properties
        public bool ReadDone { get { return myReadDone;} set { myReadDone = value;} }
        public int Id { get { return myId; } }
        public int Number { get { return myNumber; } }
        public string Symbol { get { return mySymbol; } set { mySymbol = value; } }
        public string SymbolComment { get { return mySymbolComment; } set { mySymbolComment = value; } }
        public string Author { get { return MyAuthor; } }
        public string Family { get { return myFamily; } }
        public string Name { get { return myName; } }
        public string Comment { get { return myComment; } set { myComment = value; } }
        public string Directory { get { return myDirectory; } }
        public string Version { get { return myVersion; } }
        public Collection Tags { get { return myTags; } }
        public int NumberOfTags { get; }
        public int Length { get { return myLength; } set { myLength = value; } }

        public clsDb(OleDbDataReader dr, object Comment, string Dir)
        {
            this.myTags = new Collection();
            this.myId = Conversions.ToInteger(dr["OBJECTID"]);
            this.myNumber = Conversions.ToInteger(dr["BLKNUMBER"]);
            if (!Information.IsDBNull(dr["MC5LEN"]) && Versioned.IsNumeric(dr["MC5LEN"]))
            {
                this.myLength = Conversions.ToInteger(dr["MC5LEN"]);
            }
            if (!Information.IsDBNull(dr["BLOCKNAME"]))
            {
                this.myName = Conversions.ToString(dr["BLOCKNAME"]);
            }
            if (!Information.IsDBNull(dr["BLOCKFNAME"]))
            {
                this.myFamily = Conversions.ToString(dr["BLOCKFNAME"]);
            }
            if (!Information.IsDBNull(dr["USERNAME"]))
            {
                this.MyAuthor = Conversions.ToString(dr["USERNAME"]);
            }
            if (!Information.IsDBNull(Comment))
            {
                object[] objArray;
                bool[] flagArray;
                Encoding instance = Encoding.Default;
                object[] objArray1 = new object[] { Comment };
                bool[] flagArray1 = new bool[] { true };
                byte[] bytes = (byte[])NewLateBinding.LateGet(instance, null, "GetBytes", objArray = objArray1, null, null, flagArray = flagArray1);
                if (flagArray[0])
                {
                    Comment = objArray[0];
                }
                this.myComment = instance.GetString(bytes, 3, bytes.GetLength(0) - 4);
                this.myDirectory = Dir;
            }
            this.myVersion = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(Conversions.ToInteger(Operators.SubtractObject(Operators.DivideObject(dr["VERSION"], (int)0x10), 0.499))) + ".", Operators.ModObject(dr["VERSION"], 8)));
            this.myReadDone = false;
        }

        public clsDb(int iNumber, string sComment, string sAuthor, string sFamily, string sName, string sVersion)
        {
            this.myTags = new Collection();
            this.myId = 1;
            this.myNumber = iNumber;
            this.myComment = sComment;
            this.MyAuthor = sAuthor;
            this.myFamily = sFamily;
            this.myName = sName;
            this.myVersion = sVersion;
            this.myLength = 0;
            this.myDirectory = "";
            this.myReadDone = false;
        }

        public string GetToolTip()
        {
            string[] textArray1 = new string[14];
            textArray1[0] = "DB";
            textArray1[1] = Conversions.ToString(this.myNumber);
            textArray1[2] = "\r\nSymbol: ";
            textArray1[3] = this.mySymbol;
            textArray1[4] = "\r\nSymbol comment: ";
            textArray1[5] = this.mySymbolComment;
            textArray1[6] = "\r\nAuthor: ";
            textArray1[7] = this.MyAuthor;
            textArray1[8] = "\r\nName: ";
            textArray1[9] = this.myName;
            textArray1[10] = "\r\nFamily: ";
            textArray1[11] = this.myFamily;
            textArray1[12] = "\r\nComment: ";
            textArray1[13] = this.myComment;
            return string.Concat(textArray1);
        }

        public override string ToString()
        {
            return ("DB" + Conversions.ToString(this.myNumber)).PadRight(9) + this.mySymbol;
        }
    }
}
