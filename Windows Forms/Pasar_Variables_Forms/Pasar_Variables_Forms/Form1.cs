using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blog1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string variable = "Texto enviado de un form a otro con variable PUBLICA :S";
            Form2 frm2 = new Form2();
            frm2.recibir_datos_p = variable;            
            frm2.Show();            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string variable = "Texto enviado de un form a otro en el METODO DE LA CLASE";
            Form2 frm2 = new Form2(variable);
            frm2.Show();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(); //Fijate que no he pasado Valores. el message box no se muestra :D
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string variable = "Texto enviado de un form a otro con NUESTRO METODO :D";
            Form2 frm2 = new Form2();
            frm2.setearvariable(variable);
            frm2.Show();
        }
    }
}
