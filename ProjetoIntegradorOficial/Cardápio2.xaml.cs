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
            if (((App)Application.Current).checkCoração == true)
            {
                XCoração.IsChecked = true;
            }

            if (((App)Application.Current).checkEntrevero == true)
            {
                XEntrevero.IsChecked = true;
            }

            if (((App)Application.Current).checkVegetal == true)
            {
                XVegetal.IsChecked = true;
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
                SetValue(XCoração.Name, int.Parse(tb_XCoração.Text), 25.00);
                ((App)Application.Current).UpdateQuantidade(XCoração, tb_XCoração.Name, tb_XCoração.Text);
                ((App)Application.Current).checkCoração = true;
            }
            else
            {
                ((App)Application.Current).checkCoração = false;
                RemoveValue(XCoração.Name);
            }
        }

        private void XEntrevero_Checked(object sender, RoutedEventArgs e)
        {
            if (XEntrevero.IsChecked == true)
            {
                SetValue(XEntrevero.Name, int.Parse(tb_XEntrevero.Text), 35.00);
                ((App)Application.Current).UpdateQuantidade(XEntrevero, tb_XEntrevero.Name, tb_XEntrevero.Text);
                ((App)Application.Current).checkEntrevero = true;
            }
            else
            {
                ((App)Application.Current).checkEntrevero = false;
                RemoveValue(XEntrevero.Name);
            }
        }

        private void XVegetal_Checked(object sender, RoutedEventArgs e)
        {
            if (XVegetal.IsChecked == true)
            {
                SetValue(XVegetal.Name, int.Parse(tb_XVegetal.Text), 30.00);
                ((App)Application.Current).UpdateQuantidade(XVegetal, tb_XVegetal.Name, tb_XVegetal.Text);
                ((App)Application.Current).checkVegetal = true;
            }
            else
            {
                ((App)Application.Current).checkVegetal = false;
                RemoveValue(XVegetal.Name);
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
