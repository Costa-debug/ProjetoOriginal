using Mysqlx.Crud;
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
        private App app = (App)Application.Current;

        public Cardápio2()
        {
            InitializeComponent();
            var item = ((App)Application.Current).tb_Quantidade;

            for (int i = 0; i < item.Count; i++)
            {
                if (app.checkCoração == true)
                {
                    XCoração.IsChecked = true;
                    if (item[i].Name == tb_XCoração.Name)
                    {
                        tb_XCoração.Text = item[i].Text;
                    }
                }

                if (app.checkEntrevero == true)
                {
                    XEntrevero.IsChecked = true;
                    if (item[i].Name == tb_XEntrevero.Name)
                    {
                        tb_XEntrevero.Text = item[i].Text;
                    }
                }

                if (app.checkVegetal == true)
                {
                    XVegetal.IsChecked = true;
                    if (item[i].Name == tb_XVegetal.Name)
                    {
                        tb_XVegetal.Text = item[i].Text;
                    }
                }
            }

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
            if (app.ItemPedido.Count > 0)
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
                var list = app.ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == XCoração.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(XCoração.Name, int.Parse(tb_XCoração.Text), 25.00);
                    app.UpdateQuantidade(XCoração, tb_XCoração.Name, tb_XCoração.Text);
                    app.checkCoração = true;
                }
            }
            else
            {
                app.checkCoração = false;
                RemoveValue(XCoração.Name);
            }
        }

        private void XEntrevero_Checked(object sender, RoutedEventArgs e)
        {
            if (XEntrevero.IsChecked == true)
            {
                var list = app.ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == XEntrevero.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(XEntrevero.Name, int.Parse(tb_XEntrevero.Text), 35.00);
                    app.UpdateQuantidade(XEntrevero, tb_XEntrevero.Name, tb_XEntrevero.Text);
                    app.checkEntrevero = true;
                }
            }
            else
            {
                app.checkBurguer = false;
                RemoveValue(XEntrevero.Name);
            }
        }

        private void XVegetal_Checked(object sender, RoutedEventArgs e)
        {
            if (XVegetal.IsChecked == true)
            {
                var list = app.ItemPedido;
                var canAdd = true;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item == XVegetal.Name)
                    {
                        canAdd = false;
                        break;
                    }
                }

                if (canAdd)
                {
                    SetValue(XVegetal.Name, int.Parse(tb_XVegetal.Text), 30.00);
                    app.UpdateQuantidade(XVegetal, tb_XVegetal.Name, tb_XVegetal.Text);
                    app.checkVegetal = true;
                }
            }
            else
            {
                app.checkVegetal = false;
                RemoveValue(XVegetal.Name);
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

        private void XCoraçãoQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_XCoração);
            app.UpdateQuantidade(XCoração, tb_XCoração.Name, tb_XCoração.Text);
        }

        private void XEntreveroQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_XEntrevero);
            app.UpdateQuantidade(XEntrevero, tb_XEntrevero.Name, tb_XEntrevero.Text);
        }

        private void XVegetalQt(object sender, TextChangedEventArgs e)
        {
            app.InsertQt(tb_XVegetal);
            app.UpdateQuantidade(XVegetal, tb_XVegetal.Name, tb_XVegetal.Text);
        }
    }
}
