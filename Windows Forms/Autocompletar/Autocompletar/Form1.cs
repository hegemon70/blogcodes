using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Autocompletar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> getPaises()
        {
            var listPaises = new List<string>();
            listPaises.Add("Colombia");
            listPaises.Add("Venezuela");
            listPaises.Add("Ecuador");
            listPaises.Add("Peru");
            listPaises.Add("Brazil");

            return listPaises;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> allPaises = getPaises();
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();            
            accl.AddRange(allPaises.ToArray());
            textBox1.AutoCompleteCustomSource = accl;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
