using System;
using System.Windows.Forms;

namespace ComncDesacoplada
{
    public partial class Form1 : Form, IForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void cambiarTexto(string text)
        {
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show(this);
        }
    }
}
