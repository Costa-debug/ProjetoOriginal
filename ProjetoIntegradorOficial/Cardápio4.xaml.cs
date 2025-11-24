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
    public partial class Cardápio4 : Page
    {
        public Cardápio4()
        {
            InitializeComponent();
            if (((App)Application.Current).checkCoca == true)
            {
                Coca.IsChecked = true;
            }

            if (((App)Application.Current).checkÁgua == true)
            {
                Água.IsChecked = true;
            }

            if (((App)Application.Current).checkSuco == true)
            {
                Suco.IsChecked = true;
            }
        }

        private void Button_Voltar2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio3());
        }

        private void Button_Finalisar4_Click(object sender, RoutedEventArgs e)
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

        private void Coca_Checked(object sender, RoutedEventArgs e)
        {
            if (Coca.IsChecked == true)
            {
                var list = ((App)Application.Current).ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == Coca.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(Coca.Name, int.Parse(tb_Coca.Text), 5.00);
                    ((App)Application.Current).UpdateQuantidade(Coca, tb_Coca.Name, tb_Coca.Text);
                    ((App)Application.Current).checkCoca = true;
                }
            }
            else
            {
                ((App)Application.Current).checkCoca = false;
                RemoveValue(Coca.Name);
            }
        }

        private void Água_Checked(object sender, RoutedEventArgs e)
        {
            if (Água.IsChecked == true)
            {
                var list = ((App)Application.Current).ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == Água.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(Água.Name, int.Parse(tb_Água.Text), 3.00);
                    ((App)Application.Current).UpdateQuantidade(Água, tb_Água.Name, tb_Água.Text);
                    ((App)Application.Current).checkÁgua = true;
                }
            }
            else
            {
                ((App)Application.Current).checkÁgua = false;
                RemoveValue(Água.Name);
            }
        }

        private void Suco_Checked(object sender, RoutedEventArgs e)
        {
            if (Suco.IsChecked == true)
            {
                var list = ((App)Application.Current).ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == Suco.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(Suco.Name, int.Parse(tb_Suco.Text), 7.00);
                    ((App)Application.Current).UpdateQuantidade(Suco, tb_Suco.Name, tb_Suco.Text);
                    ((App)Application.Current).checkSuco = true;
                }
            }
            else
            {
                ((App)Application.Current).checkSuco = false;
                RemoveValue(Suco.Name);
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
       
        private void CocaQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(Coca, tb_Coca.Name, tb_Coca.Text);
        }

        private void ÁguaQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(Água, tb_Água.Name, tb_Água.Text);
        }

        private void SucoQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(Suco, tb_Suco.Name, tb_Suco.Text);
        }
    }
}
