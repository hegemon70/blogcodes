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
    public partial class Form2 : Form
    {
        //Variable Privada :D
        private string recibir_datos;

        //Variable Publica :S
        public string recibir_datos_p;

        //Metodo de la clase
        public Form2()
        {
            InitializeComponent();       
        }

        //Sobrecarga con un argumento
        public Form2(string el_parametro)
        {
            InitializeComponent();
            recibir_datos = el_parametro;
        }

        //Con metodo Propio
        public void setearvariable(string el_otro_parametro)
        {
            recibir_datos = el_otro_parametro;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(recibir_datos_p))
                MessageBox.Show(recibir_datos_p);            

            if(!string.IsNullOrEmpty(recibir_datos))
                MessageBox.Show(recibir_datos);            
        }
    }
}
