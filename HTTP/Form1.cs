using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace HTTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void button1_Click(object sender, EventArgs e)
        {

            List<string> words = new List<string>();

            string site = textBox1.Text; 
            string content="";
            
            listBox2.Items.Clear();
            string path = textBox2.Text +"Test.txt";
           

            if (textBox1.Text != "")
            {
                try
                {
                    content = Parser.Parser_HTTP(site,path);                    
                    SearchWords.Search(content, words);
                    foreach (var pair in Statistic(words).OrderBy(pair => pair.Value))
                    {
                        listBox2.Items.Add(pair.Key + " - " + pair.Value);
                    }
                }
                catch (System.Exception error) {
                    Log.Write(error);                      
                    MessageBox.Show(error.ToString());
                }
            } 
        }
        //статистика уникальных слов 
        public Dictionary<string,int> Statistic(List<string> word)
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            foreach (string w in word)
            {
                if (pairs.ContainsKey(w))
                {
                    pairs[w]++;
                }
                else pairs.Add(w, 1);
            }
            return pairs;          

        }
    } 
}







                
