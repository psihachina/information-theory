using HuffmanTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RGR_Kudelin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
        }

        public struct ASCII
        {
            private char _char;
            private string _code;
            public char Char { get { return _char; } }
            public string Code { get { return _code; } }

            public static ASCII[] GetASCIIs(FrequencyRecord[] frequencyRecords)
            {
                var result = new List<ASCII>();

                foreach (var item in frequencyRecords)
                {
                    var record = new ASCII();
                    record._char = item.Char;
                    record._code = Convert.ToString(Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.ANSICodePage).GetBytes(new char[] { item.Char })[0], 2);
                    result.Add(record);
                }

                return result.ToArray();
            }
        }

        public struct Hamming
        {
            private string _char;
            private string _code;
            public string Char { get { return _char; } }
            public string Code { get { return _code; } }

            public static Hamming[] GetHammings(List<String> strings)
            {
                var result = new List<Hamming>();

                foreach (var item in strings)
                {
                    var record = new Hamming();
                    record._char = item;
                    record._code = Ham(item);
                    result.Add(record);
                }

                return result.ToArray();
            }
        }

        public struct FrequencyRecord
        {
            private char _char;
            private int _freq;
            private float _freqPercent;
            private string _code;

            private static double _entropy;
            private static double _avg;

            public char Char { get { return _char; } }
            public int Frequency { get { return _freq; } }
            public float FrequencyPercentage { get { return _freqPercent; } }
            public string Code { get { return _code; } }

            public static double Entropy { get { return _entropy; } }
            public static double Avg { get { return _avg; } }

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
                    record._freqPercent = record._freq / ((float)text.Length);
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

                return result.ToArray();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            HaffmanGrid.DataSource = FrequencyRecord.GetFrequencyDictionary(InputMessage.Text);
            Entropy.Text = "Entropy: " + FrequencyRecord.Entropy;
            Avg.Text = "Avg bit/character: " + FrequencyRecord.Avg;
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


            HamGrid.DataSource = Hamming.GetHammings(SplitString(BinaryString.Text, 4));
                       
            foreach(var item in Hamming.GetHammings(SplitString(BinaryString.Text, 4)))
            {
                EncodedMessage.Text += item.Code;
            }
        }

        static string Ham(string s)
        {
            string h = "";
            int x, y, z;
            x = (s[0] + s[1] + s[3]) % 2;
            y = (s[0] + s[2] + s[3]) % 2;
            z = (s[1] + s[2] + s[3]) % 2;
            h += Convert.ToBoolean(x) ? "1" : "0";
            h += Convert.ToBoolean(y) ? "1" : "0";
            h += s[0];
            h += Convert.ToBoolean(z) ? "1" : "0";
            h += s[1];
            h += s[2];
            h += s[3];
            return h;
        }

        string HamDec(string s)
        {
            string h = "";
            int x, y, z, v = 0;
            x = (s[2] + s[4] + s[6] + s[0]) % 2;
            y = (s[2] + s[5] + s[6] + s[1]) % 2;
            z = (s[4] + s[5] + s[6] + s[3]) % 2;
            v = (Convert.ToBoolean(x) ? 1 : 0) + (Convert.ToBoolean(y) ? 2 : 0) + (Convert.ToBoolean(z) ? 4 : 0);
            if (v > 0)
            {
                char[] charStr = s.ToCharArray();
                charStr[v - 1] = (s[v - 1] == '1') ? '0' : '1';
                s = new string(charStr);
            }
            h += (s[2] == '1') ? "1" : "0";
            h += (s[4] == '1') ? "1" : "0";
            h += (s[5] == '1') ? "1" : "0";
            h += (s[6] == '1') ? "1" : "0";
            return h;
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            BinaryString.Text = "";
            InputMessage2.Text = "";
            foreach(var item in SplitString(EncodedMessage.Text, 7))
            {
                BinaryString.Text += HamDec(item);
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

        string CodeCRC(string s)
        {
            int i, px = 29;
            int x = ((s[0] == '1') ? 16 : 0) + ((s[1] == '1') ? 8 : 0) + ((s[2] == '1') ? 4 : 0) + ((s[3] == '1') ? 2 : 0);
            int ax = x % px;
            string xa = "";
            int a = 16;
            for (i = 0; i < 4; i++)
            {
                xa += (ax / a == 1) ? "1" : "0";
                if (ax / a == 1) ax -= a;
                a /= 2;
            }
            return xa;
        }

        private void CRCBtn_Click(object sender, EventArgs e)
        {
            EncodedMessage.Text = "";

            foreach (var item in SplitString(BinaryString.Text, 8, 1))
            {
                EncodedMessage.Text += CodeCRC(item);

            }

        }

        string CodeGoll(string s)
        {
            int i, px = 2052;
            int x = ((s[0] == '1') ? 16384 : 0) + ((s[2] == '1') ? 4096 : 0) + ((s[4] == '1') ? 1024 : 0) + ((s[5] == '1') ? 512 : 0) + ((s[6] == '1') ? 256 : 0) + ((s[10] == '1') ? 16 : 0) + ((s[11] == '1') ? 8 : 0);
            int rx = x % px;
            int ax = x + rx;
            string xa = "";
            int a = 4194304;
            for (i = 0; i < 23; i++)
            {
                xa +=(ax / a == 1) ? "1" : "0";
                if (ax / a == 1) ax -= a;
                a /= 2;
            }
            return xa;
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
                    EncodedMessage.Text += CodeGoll(c1);
                    j = 0;
                    c1 = "";
                }
            }
        }

        private void ChangeBtn1_Click(object sender, EventArgs e)
        {
            var buf = "";
            foreach(var item in SplitString(EncodedMessage.Text, 7))
            {
                buf += ((item[0] == '1') ? '0' : '1')  +  item.Substring(1, 6);
            }

            EncodedMessage.Text = buf;
        }

        private void ChangeBtn2_Click(object sender, EventArgs e)
        {
            var buf = "";
            foreach (var item in SplitString(EncodedMessage.Text, 7))
            {
                buf += ((item[0] == '1') ? "0" : "1") + ((item[1] == '1') ? "0" : "1") + item.Substring(2, 5);
            }

            EncodedMessage.Text = buf;
        }
    }
}
