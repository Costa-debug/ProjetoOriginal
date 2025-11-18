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
    /// Interação lógica para Cardápio1.xam
    /// </summary>
    public partial class Cardápio1 : Page
    {
        public Cardápio1()
        {
            InitializeComponent();
        }

        private void Button_Mopções_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio2());
        }

        private void Button_Finalisar1_Click(object sender, RoutedEventArgs e)
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

        private void CheckXburguer(object sender, RoutedEventArgs e)
        {
            if (XBurguer.IsChecked == true)
            {
                SetValue(XBurguer.Name, tb_XBurguer.Text);
                ((App)Application.Current).UpdateQuantidade(XBurguer, tb_XBurguer.Name, tb_XBurguer.Text);
            }
            else
            {
                RemoveValue(XBurguer.Name);
            }
        }

        private void XBacon_Checked(object sender, RoutedEventArgs e)
        {
            if (XBacon.IsChecked == true)
            {
                SetValue(XBacon.Name, tb_XBacon.Text);
                ((App)Application.Current).UpdateQuantidade(XBacon, tb_XBacon.Name, tb_XBacon.Text);
            }
            else
            {
                RemoveValue(XBacon.Name);
            }
        }

        private void XFrango_Checked(object sender, RoutedEventArgs e)
        {
            if (XFrango.IsChecked == true)
            {
                SetValue(XFrango.Name, tb_XFrango.Text);
                ((App)Application.Current).UpdateQuantidade(XFrango, tb_XFrango.Name, tb_XFrango.Text);
            }
            else
            {
                RemoveValue(XBacon.Name);
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

        private void XBurguerQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(XBurguer, tb_XBurguer.Name, tb_XBurguer.Text);
        }

        private void XFrangoQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(XFrango, tb_XFrango.Name, tb_XFrango.Text);
        }

        private void XBaconQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(XBacon, tb_XBacon.Name, tb_XBacon.Text);
        }
    }
}
