using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTP
{
    class Parser
    {
        public static string Parser_HTTP(string site, string path)
        {
            //получение страницы
            string content = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        content += line;
                    }
                }
            }
            response.Close();
            //запись в файл 
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(content);
            }
            MessageBox.Show("Запись в файл выполнена");
            return content;
        }

    }
}
