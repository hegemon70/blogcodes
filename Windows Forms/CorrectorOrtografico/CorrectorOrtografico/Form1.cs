// Nicolas Herrera
// :)
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CorrectorOrtografico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CorregirClick(object sender, EventArgs e)
        {
            richTextBox1.Text = RevisarOrtografia(richTextBox1.Text);
        }

        private static string RevisarOrtografia(string texto)
        {
            var app = new Microsoft.Office.Interop.Word.Application();
            string corregido = string.Empty;
            if (!String.IsNullOrEmpty(texto))
            {
                app.Visible = false;
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object documentType = Missing.Value;
                object visible = false;

                Microsoft.Office.Interop.Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate,
                                                                                 ref documentType, ref visible);
                doc1.Words.First.InsertBefore(texto);
                object optional = Missing.Value;
                doc1.CheckSpelling(
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);

                object first = 0;
                object last = doc1.Characters.Count - 1;
                corregido = doc1.Range(ref first, ref last).Text;
            }
            object saveChanges = false;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            app.Application.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
            return corregido;
        }
    }
}