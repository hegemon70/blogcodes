using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace ZipNet45
{
    public partial class Form1 : Form
    {
        private const string RutaZip = @"C:\Tests\MusicZip.zip";

        public Form1()
        {
            InitializeComponent();
        }

        private void BtVerContenidoClick(object sender, EventArgs e)
        {
            using (var zip = new FileStream(RutaZip, FileMode.Open))
            {
                using (var archivo = new ZipArchive(zip, ZipArchiveMode.Read))
                {
                    var nombrearchivos = new StringBuilder();
                    foreach (ZipArchiveEntry zipArchiveEntry in archivo.Entries)
                    {
                        nombrearchivos.AppendLine(zipArchiveEntry.FullName);
                    }
                    richTextBox1.Text = nombrearchivos.ToString();
                }
            }
        }

        private void BtAgregarArchivoClick(object sender, EventArgs e)
        {
            using (var zip = new FileStream(RutaZip, FileMode.Open))
            {
                using (var archivo = new ZipArchive(zip, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry nuevoArchivo = archivo.CreateEntry("07 Track 7.wma");
                    using (var archivoAgregar = new FileStream(@"C:\Tests\07 Track 7.wma", FileMode.Open))
                    {
                        archivoAgregar.CopyTo(nuevoArchivo.Open());
                    }
                    var archivos = new StringBuilder();
                    foreach (ZipArchiveEntry zipArchiveEntry in archivo.Entries)
                    {
                        archivos.AppendLine(zipArchiveEntry.FullName);
                    }
                    richTextBox1.Text = archivos.ToString();
                }
            }
        }

        private void BtExtraerTodoClick(object sender, EventArgs e)
        {
            const string rutaExtraido = @"C:\Tests\Extraidos\";

            using (var zip = new FileStream(RutaZip, FileMode.Open))
            {
                using (var archivo = new ZipArchive(zip, ZipArchiveMode.Update))
                {
                    archivo.ExtractToDirectory(rutaExtraido);
                }
            }
        }
    }
}