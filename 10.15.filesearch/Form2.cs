using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._15.filesearch
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                textBox1.Text=folderBrowserDialog1.SelectedPath;
            }
        }

        // https://stackoverflow.com/questions/725341/how-to-determine-if-a-file-matches-a-file-mask
        private bool FitsMask(string fileName, string fileMask)
        {
            Regex mask = new Regex(
                '^' +
                fileMask
                    .Replace(".", "[.]")
                    .Replace("*", ".*")
                    .Replace("?", ".")
                + '$',
                RegexOptions.IgnoreCase);
            return mask.IsMatch(fileName);
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listBox1.Items.Clear();
                string[] files = Directory.GetFiles(textBox1.Text);
                foreach(string file in files)
                {
                    if (FitsMask(file,textBox2.Text))
                    {
                        listBox1.Items.Add(file);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
