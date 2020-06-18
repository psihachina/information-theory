using HuffmanTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static RGR_Kudelin.Hamming;

namespace RGR_Kudelin
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
        }

        public struct FrequencyRecord
        {
            private char _char;
            private int _freq;
            private double _freqPercent;
            private string _code;

            private static double _entropy;
            private static double _avg;
            private static int _lenght;


            public char Char { get { return _char; } }
            public int Frequency { get { return _freq; } }
            public double FrequencyPercentage { get { return _freqPercent; } }
            public string Code { get { return _code; } }

            public static double Entropy { get { return _entropy; } }
            public static double Avg { get { return _avg; } }
            public static int Lenght { get { return _lenght; } }

            public static FrequencyRecord[] GetFrequencyDictionary(string text)
            {
                var result = new List<FrequencyRecord>();
                var huffmanTree = new HuffmanTree();
                huffmanTree.Build(text);

                _entropy = 0;

                for (int i=0; i < huffmanTree.Frequencies.Count; i++)
                {
                    var record = new FrequencyRecord();
                    record._char = huffmanTree.Frequencies.ElementAt(i).Key;
                    
                    record._freq = huffmanTree.Frequencies.ElementAt(i).Value;
                    record._freqPercent = Math.Round(record._freq / ((float)text.Length), 2);
                    foreach (var item in huffmanTree.EncodeChar(record._char))
                    {
                        record._code += (item ? 1 : 0);
                    }
                    result.Add(record);
                    _entropy += Math.Round((-(result[i]._freqPercent * Math.Log(result[i]._freqPercent, 2))), 2);
                }

                BitArray encoded = huffmanTree.Encode(text);

                Console.Write("Encoded: ");
                var str = "";
                foreach (bool bit in encoded)
                {
                    str += (bit ? 1 : 0);
                }
                _avg = Math.Round((float)str.Length / (float)text.Length, 2);
                _lenght = str.Length;
                return result.ToArray();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            HaffmanGrid.DataSource = FrequencyRecord.GetFrequencyDictionary(InputMessage.Text);
            Entropy.Text = "Entropy: " + FrequencyRecord.Entropy;
            Avg.Text = "Avg bit/character: " + FrequencyRecord.Avg;
            EMLenght.Text = "Encoded message lenght: " + FrequencyRecord.Lenght;
        }

        static List<string> SplitString(string str, int count)
        {
            List<string> list = new List<string>();
            int i = 0;
            while (i < str.Length - 1)
            {
                list.Add(str.Substring(i, count));
                i += count;
            }
            return list;
        }

        static List<string> SplitString(string str, int count, int k)
        {
            List<string> list = new List<string>();
            int i = 0;
            while (i < str.Length - 1)
            {
                list.Add(str.Substring(i, count).Substring(4,4));
                i += count;
            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EncodedMessage.Text = "";
            BinaryString.Text = "";
            ASCIIGrid.DataSource = ASCII.GetASCIIs(FrequencyRecord.GetFrequencyDictionary(InputMessage2.Text));

            foreach (var ch in InputMessage2.Text)
            {
                if (Convert.ToString(ch, 2).Length == 6)
                {
                    BinaryString.Text += "00" + Convert.ToString(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).GetBytes(new char[] { ch })[0], 2);
                }
                else
                {
                    BinaryString.Text += Convert.ToString(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).GetBytes(new char[] { ch })[0], 2);
                }
            }


            HamGrid.DataSource = Hamm.GetHammings(SplitString(BinaryString.Text, 4));
                       
            foreach(var item in Hamm.GetHammings(SplitString(BinaryString.Text, 4)))
            {
                EncodedMessage.Text += item.Code;
            }
        }

        

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            BinaryString.Text = "";
            InputMessage2.Text = "";
            foreach(var item in SplitString(EncodedMessage.Text, 7))
            {
                BinaryString.Text += RGR_Kudelin.Hamming.HamDec(item);
            }
            InputMessage2.Text = BinaryToString(BinaryString.Text);
        }

        public string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();
            foreach (var item in SplitString(BinaryString.Text, 8))
                byteList.Add(Convert.ToByte(item, 2));
            return Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).GetString(byteList.ToArray());
        }

        

        private void CRCBtn_Click(object sender, EventArgs e)
        {
            EncodedMessage.Text = "";

            foreach (var item in SplitString(BinaryString.Text, 8, 1))
            {
                EncodedMessage.Text += RGR_Kudelin.Hamming.CodeCRC(item);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EncodedMessage.Text = "";

            var c = BinaryString.Text;
            string c1 ="";
            int j = 0;
            for (int ind = 0; ind < c.Length; ind++)
            {
                c1 += ((c[ind] == '1') ? '1' : '0');
                j++;
                if (j % 12 == 0)
                {
                    EncodedMessage.Text += RGR_Kudelin.Hamming.CodeGoll(c1);
                    j = 0;
                    c1 = "";
                }
            }
        }

        private void ChangeBtn1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < EncodedMessage.Text.Length; i++)
            {
                if((i+1) % 66 == 0)
                {
                    char[] charStr = EncodedMessage.Text.ToCharArray();
                    charStr[i] = ((EncodedMessage.Text[i] == '1') ? '0' : '1');
                    EncodedMessage.Text = new string(charStr);
                }
            }
        }

        private void ChangeBtn2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < EncodedMessage.Text.Length; i++)
            {
                if ((i + 1) % 66 == 0)
                {
                    char[] charStr = EncodedMessage.Text.ToCharArray();
                    charStr[i] = ((EncodedMessage.Text[i] == '1') ? '0' : '1');
                    charStr[i+1] = ((EncodedMessage.Text[i+1] == '1') ? '0' : '1');
                    EncodedMessage.Text = new string(charStr);
                }
            }
        }

        private void StartBtn2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LZ.SetLZSS(InputMessage3.Text);
            dataGridView2.DataSource = LZ.SetLZ78(InputMessage3.Text);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView1.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView1.Rows[index].HeaderCell.Value = indexStr;
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridView2.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dataGridView2.Rows[index].HeaderCell.Value = indexStr;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
