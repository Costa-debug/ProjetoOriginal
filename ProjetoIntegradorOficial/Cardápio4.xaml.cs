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
        private App app = (App)Application.Current;

        public Cardápio4()
        {
            InitializeComponent();
            var item = ((App)Application.Current).tb_Quantidade;

            for (int i = 0; i < item.Count; i++)
            {
                if (app.checkCoca == true)
                {
                    Coca.IsChecked = true;
                    if (item[i].Name == tb_Coca.Name)
                    {
                        tb_Coca.Text = item[i].Text;
                    }
                }
                
                if (app.checkÁgua == true)
                {
                    Água.IsChecked = true;
                    if (item[i].Name == tb_Água.Name)
                    {
                        tb_Água.Text = item[i].Text;
                    }
                }

                if (app.checkSuco == true)
                {
                    Suco.IsChecked = true;
                    if (item[i].Name == tb_Suco.Name)
                    {
                        tb_Suco.Text = item[i].Text;
                    }
                }
            }
        }

        private void Button_Voltar2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio3());
        }

        private void Button_Finalisar4_Click(object sender, RoutedEventArgs e)
        {
            if (app.ItemPedido.Count > 0)
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
                var list = app.ItemPedido;
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
                    app.UpdateQuantidade(Coca, tb_Coca.Name, tb_Coca.Text);
                    app.checkCoca = true;
                }
            }
            else
            {
                app.checkCoca = false;
                RemoveValue(Coca.Name);
            }
        }

        private void Água_Checked(object sender, RoutedEventArgs e)
        {
            if (Água.IsChecked == true)
            {
                var list = app.ItemPedido;
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
                    app.UpdateQuantidade(Água, tb_Água.Name, tb_Água.Text);
                    app.checkÁgua = true;
                }
            }
            else
            {
                app.checkÁgua = false;
                RemoveValue(Água.Name);
            }
        }

        private void Suco_Checked(object sender, RoutedEventArgs e)
        {
            if (Suco.IsChecked == true)
            {
                var list = app.ItemPedido;
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
                    app.UpdateQuantidade(Suco, tb_Suco.Name, tb_Suco.Text);
                    app.checkSuco = true;
                }
            }
            else
            {
                app.checkSuco = false;
                RemoveValue(Suco.Name);
            }
        }
       
        private void SetValue(string item, int quantidade, double preco)
        {
            try
            {
                app.ItemPedido.Add(new PedidoFinalInfo(item, quantidade, preco, quantidade));
            }
            catch { }

        }
        
        private void RemoveValue(string item)
        {
            var pedido = app.ItemPedido;

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
            app.InsertQt(tb_Coca);
            app.UpdateQuantidade(Coca, tb_Coca.Name, tb_Coca.Text);
        }

        private void ÁguaQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_Água);
            app.UpdateQuantidade(Água, tb_Água.Name, tb_Água.Text);
        }

        private void SucoQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_Suco);
            app.UpdateQuantidade(Suco, tb_Suco.Name, tb_Suco.Text);
        }
    }
}
