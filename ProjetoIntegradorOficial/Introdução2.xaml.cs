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

namespace ProjetoIntegradorOficial
{
    /// <summary>
    /// Interação lógica para Introdução2.xam
    /// </summary>
    public partial class Introdução2 : Page
    {
        public Introdução2()
        {
            InitializeComponent();
        }

        private void Button_Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void Button_Produto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Produto());
        }

        private void Button_Estoque_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Estoque());
        }
    }
}