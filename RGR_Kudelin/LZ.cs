using System.Collections.Generic;
using System.Linq;

namespace RGR_Kudelin
{
    class LZ
    {
        public class LZ78
        {
            public List<string> Dictionary { get; set; }
            public List<string> FutureDictionary { get; set; }
            public string Buffer { get; set; }
            public string FutureBuffer { get; set; }
            public string DictionatyString { get; set; }
            public string Code { get; set; }
            public int LengthCode { get; set; }
            public LZ78()
            {
                Dictionary = new List<string>();
                FutureDictionary = new List<string>();
            }
        }

        public class LZSS
        {
            public string Dictionary { get; set; }
            public string FutureDictionary { get; set; }
            public string Buffer { get; set; }
            public string Code { get; set; }
            public int LengthCode { get; set; }
        }

        public static List<LZSS> SetLZSS(string text)
        {

            var lzss = new List<LZSS>();
            int i = 0;
            while (i < text.Count())
            {
                var lz = new LZSS();
                if (lzss.Count == 0)
                {
                    lz.Dictionary = "";
                    lz.FutureDictionary = text[0].ToString();
                    lz.Buffer = text.Substring(0, 8);
                    lz.Code = $"0, {text[0]} ";
                    lz.LengthCode = 9;
                    lzss.Add(lz);
                }
                else
                {
                    int vh = -1;
                    bool flag = false;
                    lz.Dictionary = lzss.LastOrDefault().FutureDictionary;
                    int length = 0;
                    if (text.Length - (i + 1) >= 8)
                    {
                        length = 8;
                        lz.Buffer = text.Substring(i, length);
                    }
                    else
                    {
                        length = text.Length - (i + 1);
                        lz.Buffer = text.Substring(i, length);
                    }
                    for (int j = lz.Buffer.Length - 1; j >= 0; j--)
                    {
                        vh = lz.Dictionary.IndexOf(lz.Buffer.Substring(0, j + 1));
                        if (vh != -1)
                        {
                            flag = true;
                            int lengthSub = 0;
                            if (j == 0 && vh != 0)
                            {
                                if (lz.Buffer.Count() != 1)
                                {
                                    lengthSub = j + 2;
                                }
                                else
                                {
                                    lengthSub = j + 1;
                                }
                            }
                            else if (j == 0 && vh == 0)
                            {
                                lengthSub = j + 1;
                            }
                            else if (j != 0)
                            {
                                lengthSub = j + 1;
                            }
                            if (lz.Dictionary.Length >= 16 || (lz.Dictionary + lz.Buffer.Substring(0, lengthSub)).Length >= 16)
                            {
                                int dict = lz.Dictionary.Length + lz.Buffer.Substring(0, lengthSub).Length - lz.Dictionary.Length;
                                lz.FutureDictionary = lz.Dictionary.Remove(0, dict) + lz.Buffer.Substring(0, lengthSub);
                                lz.Code = $"1, ({vh}, {lengthSub})";
                                lz.LengthCode = 7;
                                i = i + dict - 1;
                                break;
                            }
                            else
                            {
                                int dict = lz.Dictionary.Length + lz.Buffer.Substring(0, lengthSub).Length - lz.Dictionary.Length;
                                lz.FutureDictionary = lz.Dictionary + lz.Buffer.Substring(0, lengthSub);
                                lz.Code = $"1, ({vh}, {lengthSub})";
                                lz.LengthCode = 7;
                                i = i + dict - 1;
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        if (lz.Dictionary.Length >= 16)
                        {
                            lz.FutureDictionary = lz.Dictionary.Remove(0, 1) + text[i];
                            lz.Code = $"0, {text[i]} ";
                            lz.LengthCode = 9;
                        }
                        else
                        {
                            lz.FutureDictionary = lz.Dictionary + text[i];
                            lz.Code = $"0, {text[i]} ";
                            lz.LengthCode = 9;
                        }
                    }
                    lzss.Add(lz);
                }
                i++;
            }
            return lzss;
        }

        public static List<LZ78> SetLZ78(string text)
        {
            var lz78 = new List<LZ78>();
            int i = 0;
            while (i < text.Count())
            {
                var lz = new LZ78();
                if (i == 0)
                {
                    lz.Code = $"0, {text[i]}";
                    lz.LengthCode = 9;
                    lz.FutureDictionary.Add(text[i].ToString());
                    lz.Buffer = text;
                    lz.FutureBuffer = text.Remove(0, 1);
                }
                else
                {
                    foreach (var item in lz78.LastOrDefault().FutureDictionary)
                    {
                        lz.Dictionary.Add(item);
                    }
                    lz.Buffer = lz78.LastOrDefault().FutureBuffer;
                    bool flag = false;
                    string newWord = "";
                    int j = 0;
                    int b = i;
                    int length = lz.Buffer.Length;
                    while (j <= lz.Buffer.Length - 1)
                    {
                        string SubText = lz.Buffer.Substring(0, length);
                        foreach (var item in lz.Dictionary)
                        {
                            if (SubText == item)
                            {
                                flag = true;
                                if (lz.Buffer.Count() != 1)
                                {
                                    newWord = item + lz.Buffer[item.Count()];
                                }
                                else
                                {
                                    newWord = item;
                                }
                                lz.Code = $"1, {lz.Dictionary.IndexOf(item)}, {newWord[newWord.Length - 1]}";
                                lz.FutureBuffer = lz.Buffer.Remove(0, newWord.Length);
                                i = i + (newWord.Length - 1);
                                break;
                            }
                        }
                        if (flag == true)
                        {
                            break;
                        }
                        j++;
                        length--;
                    }
                    if (flag == false)
                    {
                        newWord = text[i].ToString();
                        lz.Code = $"0, {text[i]}";
                        lz.FutureBuffer = lz.Buffer.Remove(0, 1);
                    }

                    if (lz.Dictionary.Count == 16)
                    {
                        foreach (var item in lz.Dictionary)
                        {
                            lz.FutureDictionary.Add(item);
                        }
                        lz.FutureDictionary.RemoveAt(0);
                        lz.FutureDictionary.Add(newWord);
                    }
                    else
                    {
                        foreach (var item in lz.Dictionary)
                        {
                            lz.FutureDictionary.Add(item);
                        }
                        lz.FutureDictionary.Add(newWord);
                    }
                }
                i++;
                lz78.Add(lz);
            }

            foreach (var lz in lz78)
            {
                foreach (var item in lz.Dictionary)
                {
                    lz.DictionatyString += "'" + item + "',";
                }
            }
            return lz78;
        }
    }
}
