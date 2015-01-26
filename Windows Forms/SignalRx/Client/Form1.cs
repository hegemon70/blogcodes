using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            var connection = new HubConnection("http://localhost:8088/signalr");
            var myHub = connection.CreateHubProxy("MyHub");
            connection.Start().ContinueWith(task => { MessageBox.Show(task.IsFaulted ? "Error en la conexión" : "Conectado!"); }).Wait();
            var observable =
                myHub.Observe("AddMessage")
                    .Select(hub => new { Message = hub.First().ToString() })
                    .Where(m => m.Message == "Hola")
                    .Select(m => m.Message);
            observable.Subscribe(x => MessageBox.Show(x));
        }
    }
}

