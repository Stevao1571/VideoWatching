using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VideoWatching
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, RoutedEventArgs e)
        {
            RoboExecucao exec = new RoboExecucao();

            exec.Executar(txtUsuario.Text, txtSenha.Text);

        }


        private void txtxSenha_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Return)
            {
                RoboExecucao exec = new RoboExecucao();

                exec.Executar(txtUsuario.Text, txtSenha.Text);

            }

        }

        private void txtSenha_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
