using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Mod_Lang_JAEX
{
    public class Translation
    {
        const string PREFIX_FILENAME = "Mod_Lang_JAEX.";

        private static Dictionary<string, string> textDictionary;

        public static string GetString(string key)
        {
            if (textDictionary == null)
            {
                string filename = PREFIX_FILENAME + "text.txt";
                string[] lines;
                using (Stream st = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
                {
                    using (StreamReader sr = new StreamReader(st))
                    {
                        lines = sr.ReadToEnd().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
                    }
                }
                textDictionary = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    if (line == null || line.Trim().Length == 0)
                    {
                        continue;
                    }
                    int delimiterIndex = line.Trim().IndexOf('\t');
                    if (delimiterIndex > 0)
                    {
                        textDictionary.Add(line.Substring(0, delimiterIndex), line.Substring(delimiterIndex + 1).Trim().Replace("\\n", "\n"));
                    }
                }
            }
            if (textDictionary.ContainsKey(key))
            {
                return textDictionary[key];
            }
            else
            {
                return key;
            }
        }

        public static void Release()
        {
            textDictionary = null;
        }
    }
}
