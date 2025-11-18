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
    /// Interação lógica para Cardápio2.xam
    /// </summary>
    public partial class Cardápio2 : Page
    {
        public Cardápio2()
        {
            InitializeComponent();
        }
       
        private void Button_Porções_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio3());
        }
        
        private void Button_Voltar1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio1());
        }

        private void Button_Finalisar2_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).ItemPedido.Count > 0)
            {
                NavigationService.Navigate(new PedidoFinal());
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado no pedido!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void XCoração_Checked(object sender, RoutedEventArgs e)
        {
            if (XCoração.IsChecked == true)
            {
                SetValue(XCoração.Name, tb_XCoração.Text);
                ((App)Application.Current).UpdateQuantidade(XCoração, tb_XCoração.Name, tb_XCoração.Text);
            }
            else
            {
                RemoveValue(XCoração.Name);
            }
        }

        private void XEntrevero_Checked(object sender, RoutedEventArgs e)
        {
            if (XEntrevero.IsChecked == true)
            {
                SetValue(XEntrevero.Name, tb_XEntrevero.Text);
                ((App)Application.Current).UpdateQuantidade(XEntrevero, tb_XEntrevero.Name, tb_XEntrevero.Text);
            }
            else
            {
                RemoveValue(XEntrevero.Name);
            }
        }

        private void XVegetal_Checked(object sender, RoutedEventArgs e)
        {
            if (XVegetal.IsChecked == true)
            {
                SetValue(XVegetal.Name, tb_XVegetal.Text);
                ((App)Application.Current).UpdateQuantidade(XVegetal, tb_XVegetal.Name, tb_XVegetal.Text);
            }
            else
            {
                RemoveValue(XVegetal.Name);
            }
        }
        
        private void SetValue(string item, string quantidade)
        {
            try
            {
                ((App)Application.Current).ItemPedido.Add(item, int.Parse(quantidade));
            }
            catch { }

        }

        private void RemoveValue(string item)
        {
            ((App)Application.Current).ItemPedido.Remove(item);
        }

        private void XCoraçãoQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(XCoração,tb_XCoração.Name, tb_XCoração.Text);
        }

        private void XEntreveroQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(XEntrevero, tb_XEntrevero.Name, tb_XEntrevero.Text);
        }

        private void XVegetalQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(XVegetal, tb_XVegetal.Name, tb_XVegetal.Text);
        }
    }
}
