using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
            if (((App)Application.Current).checkBurguer == true)
            {
                XBurguer.IsChecked = true;
            }

            if (((App)Application.Current).checkBacon == true)
            {
                XBacon.IsChecked = true;
            }

            if (((App)Application.Current).checkFrango == true)
            {
                XFrango.IsChecked = true;
            }
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
                var list = ((App)Application.Current).ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == XBurguer.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(XBurguer.Name, int.Parse(tb_XBurguer.Text), 20.00);
                    ((App)Application.Current).UpdateQuantidade(XBurguer, tb_XBurguer.Name, tb_XBurguer.Text);
                    ((App)Application.Current).checkBurguer = true;
                }
            }
            else
            {
                ((App)Application.Current).checkBurguer = false;
                RemoveValue(XBurguer.Name);
            }
        }

        private void XBacon_Checked(object sender, RoutedEventArgs e)
        {
            if (XBacon.IsChecked == true)
            {
                var list = ((App)Application.Current).ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == XBacon.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(XBacon.Name, int.Parse(tb_XBacon.Text), 25.00);
                    ((App)Application.Current).UpdateQuantidade(XBacon, tb_XBacon.Name, tb_XBacon.Text);
                    ((App)Application.Current).checkBacon = true;
                }
            }
            else
            {
                ((App)Application.Current).checkBacon = false;
                RemoveValue(XBacon.Name);
            }
        }

        private void XFrango_Checked(object sender, RoutedEventArgs e)
        {
            if (XFrango.IsChecked == true)
            {
                var list = ((App)Application.Current).ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == XFrango.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(XFrango.Name, int.Parse(tb_XFrango.Text), 25.00);
                    ((App)Application.Current).UpdateQuantidade(XFrango, tb_XFrango.Name, tb_XFrango.Text);
                    ((App)Application.Current).checkFrango = true;
                }
            }
            else
            {
                ((App)Application.Current).checkFrango = false;
                RemoveValue(XFrango.Name);
            }
        }

        private void SetValue(string item, int quantidade, double preco)
        {
            try
            {
                ((App)Application.Current).ItemPedido.Add(new PedidoFinalInfo(item, quantidade, preco, quantidade));
            }
            catch { }

        }

        private void RemoveValue(string item)
        {
            var pedido = ((App)Application.Current).ItemPedido;

            foreach (var pedidoItem in pedido)
            {
                if (pedidoItem.Item == item)
                {
                    pedido.Remove(pedidoItem);
                    break;
                }
            }
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
