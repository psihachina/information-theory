using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static RGR_Kudelin.Main;

namespace RGR_Kudelin
{
    class Hamming
    {
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

        public struct Hamm
        {
            private string _char;
            private string _code;
            public string Char { get { return _char; } }
            public string Code { get { return _code; } }

            public static Hamm[] GetHammings(List<String> strings)
            {
                var result = new List<Hamm>();

                foreach (var item in strings)
                {
                    var record = new Hamm();
                    record._char = item;
                    record._code = Hamming.Ham(item);
                    result.Add(record);
                }

                return result.ToArray();
            }
        }

        public static string Ham(string s)
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

        public static string HamDec(string s)
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

        public static string CodeGoll(string s)
        {
            int i, px = 2052;
            int x = ((s[0] == '1') ? 16384 : 0) + ((s[2] == '1') ? 4096 : 0) + ((s[4] == '1') ? 1024 : 0) + ((s[5] == '1') ? 512 : 0) + ((s[6] == '1') ? 256 : 0) + ((s[10] == '1') ? 16 : 0) + ((s[11] == '1') ? 8 : 0);
            int rx = x % px;
            int ax = x + rx;
            string xa = "";
            int a = 4194304;
            for (i = 0; i < 23; i++)
            {
                xa += (ax / a == 1) ? "1" : "0";
                if (ax / a == 1) ax -= a;
                a /= 2;
            }
            return xa;
        }

        public static string CodeCRC(string s)
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
    }
}
