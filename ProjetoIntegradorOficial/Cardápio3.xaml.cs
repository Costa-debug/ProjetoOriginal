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
    /// Interação lógica para Cardápio3.xam
    /// </summary>
    public partial class Cardápio3 : Page
    {
        private App app = (App)Application.Current;

        public Cardápio3()
        {
            InitializeComponent();
            var item = ((App)Application.Current).tb_Quantidade;

            for (int i = 0; i < item.Count; i++)
            {
                if (app.checkBatata100g == true)
                {
                    Batata100g.IsChecked = true;
                    if (item[i].Name == tb_Batata100g.Name)
                    {
                        tb_Batata100g.Text = item[i].Text;
                    }
                }

                if (app.checkBatata200g == true)
                {
                    Batata200g.IsChecked = true;
                    if (item[i].Name == tb_Batata200g.Name)
                    {
                        tb_Batata200g.Text = item[i].Text;
                    }
                }

                if (app.checkBatata400g == true)
                {
                    Batata400g.IsChecked = true;
                    if (item[i].Name == tb_Batata400g.Name)
                    {
                        tb_Batata400g.Text = item[i].Text;
                    }
                }
            }
        }

        private void Button_Porções_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio4());
        }

        private void Button_Voltar2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cardápio2());
        }

        private void Button_Finalisar3_Click(object sender, RoutedEventArgs e)
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

        private void Batata100g_Checked(object sender, RoutedEventArgs e)
        {
            if (Batata100g.IsChecked == true)
            {
                var list = app.ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == Batata100g.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(Batata100g.Name, int.Parse(tb_Batata100g.Text), 10.00);
                    app.UpdateQuantidade(Batata100g, tb_Batata100g.Name, tb_Batata100g.Text);
                    app.checkBatata100g = true;
                }
            }
            else
            {
                app.checkBatata100g = false;
                RemoveValue(Batata100g.Name);
            }
        }

        private void Batata200g_Checked(object sender, RoutedEventArgs e)
        {
            if (Batata200g.IsChecked == true)
            {
                var list = app.ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == Batata200g.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(Batata200g.Name, int.Parse(tb_Batata200g.Text), 15.00);
                    app.UpdateQuantidade(Batata200g, tb_Batata200g.Name, tb_Batata200g.Text);
                    app.checkBatata200g = true;
                }
            }
            else
            {
                app.checkBatata200g = false;
                RemoveValue(Batata200g.Name);
            }
        }

        private void Batata400g_Checked(object sender, RoutedEventArgs e)
        {
            if (Batata400g.IsChecked == true)
            {
                var list = app.ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == Batata400g.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(Batata400g.Name, int.Parse(tb_Batata400g.Text), 20.00);
                    app.UpdateQuantidade(Batata400g, tb_Batata400g.Name, tb_Batata400g.Text);
                    app.checkBatata400g = true;
                }
            }
            else
            {
                app.checkBatata400g = false;
                RemoveValue(Batata400g.Name);
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

        private void Batata100gQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_Batata100g);
            app.UpdateQuantidade(Batata100g, tb_Batata100g.Name, tb_Batata100g.Text);
        }

        private void Batata200gQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_Batata200g);
            app.UpdateQuantidade(Batata200g, tb_Batata200g.Name, tb_Batata200g.Text);
        }

        private void Batata400gQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_Batata400g);
            app.UpdateQuantidade(Batata400g, tb_Batata400g.Name, tb_Batata400g.Text);
        }
    }
}
