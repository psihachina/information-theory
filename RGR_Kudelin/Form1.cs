using HuffmanTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR_Kudelin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            
            dataGridView1.DataSource = FrequencyRecord.GetFrequencyDictionary(textBox1.Text);
            label1.Text = "Entropy: " + FrequencyRecord.Entropy;
            label2.Text = "Avg bit/character: " + FrequencyRecord.Avg;
        }
    }
}
