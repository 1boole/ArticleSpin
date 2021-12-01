using Business.Concrete;
using Business.Utilities.FileHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomationUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var request = WebRequest.Create("logo.png");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                thtBanner.Image = Bitmap.FromStream(stream);
            }

            var request2 = WebRequest.Create("ARGE-logo.png");

            using (var response = request2.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                argeLogo.Image = Bitmap.FromStream(stream);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VariableManeger variable = new VariableManeger();
            var result= variable.VariablesSpiner(richTextBox1.Text,dataGridView1);
            richTextBox2.Text = result;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            XlsxFileReader.OpenXlsx(dataGridView1);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
