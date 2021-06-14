using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HTTP
{
    class SearchWords
    {
        public static void Search(string content, List<string> words)
        {
            //получение текста со страницы
            List<string> sentenses = new List<string>();
            string text = "";
            string[] tags = { "<h2", "<title", "<a", "<div", "<span", "<p", "<h1", "<h3", "<h4", "<h5", "<br", "<input" };
            int length_tag = 0;
            foreach (string tag in tags)
            {
                length_tag = tag.Length;
                if (content.Contains(tag))
                    for (int i = 0; i < content.Length - length_tag; i++)
                    {
                        if (content.Substring(i, length_tag) == tag)
                        {
                            text = "";
                            i += length_tag;
                            while (content.Substring(i, 1) != ">" && i < content.Length - 1) i++;
                            i++;
                            while (content.Substring(i, 1) != "<" && i < content.Length - 1)
                            {
                                text += content.Substring(i, 1);
                                i++;
                            }
                            sentenses.Add(text);
                            i--;
                        }
                    }
            }
            //разбиение на отдельные слова
            for (int i = 0; i < sentenses.Count; i++)
            {
                string[] word = sentenses[i].Split('«', '»', '|', '/', '—', '©', '#','-', '&', '*', '%', '^', ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t');
                
                if (word != null)
                    foreach (string s in word)
                        if (s != "")
                        {
                            words.Add(s.ToUpper());
                        }
            }








        }
        
    }
}
