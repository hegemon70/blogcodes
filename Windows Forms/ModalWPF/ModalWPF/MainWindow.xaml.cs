using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LlamarModalClick(object sender, RoutedEventArgs e)
        {
            Modal modal = new Modal();
            modal.Owner = this;
            AplicarEfecto(this);
            modal.ShowDialog();
            bool? resultado = modal.DialogResult;
            if (resultado != null)
            {
                if (resultado == false)
                {
                    QuitarEfecto(this);
                }
            }
        }

        private void AplicarEfecto(Window win)
        {
            var objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 5;
            win.Effect = objBlur;
        }

        private void QuitarEfecto(Window win)
        {
            win.Effect = null;
        }
    }
}
