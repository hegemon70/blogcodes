using System;
using System.Windows.Forms;

namespace ComncDesacoplada
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            IForm miInterfaz = this.Owner as IForm;
            if (miInterfaz != null)
                miInterfaz.cambiarTexto(textBox1.Text);
            this.Dispose();
        }
    }
}
