using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace ProjetoIntegradorOficial
{
    /// <summary>
    /// Interação lógica para Introdução.xam
    /// </summary>
    public partial class Introdução : Page
    {
        public Introdução()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).Nome = tb_Nome.Text;
            ((App)Application.Current).Telefone = tb_Telefone.Text;

            NavigationService.Navigate(new Informações());
        }
    }
}
