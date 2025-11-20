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
        public Cardápio3()
        {
            InitializeComponent();
            if (((App)Application.Current).checkBatata100g == true)
            {
                Batata100g.IsChecked = true;
            }

            if (((App)Application.Current).checkBatata200g == true)
            {
                Batata200g.IsChecked = true;
            }

            if (((App)Application.Current).checkBatata400g == true)
            {
                Batata400g.IsChecked = true;
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
            if (((App)Application.Current).ItemPedido.Count > 0)
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
                SetValue(Batata100g.Name, int.Parse(tb_Batata100g.Text), 10.00);
                ((App)Application.Current).UpdateQuantidade(Batata100g, tb_Batata100g.Name, tb_Batata100g.Text);
                ((App)Application.Current).checkBatata100g = true;
            }
            else
            {
                ((App)Application.Current).checkBatata100g = false;
                RemoveValue(Batata100g.Name);
            }
        }

        private void Batata200g_Checked(object sender, RoutedEventArgs e)
        {
            if (Batata200g.IsChecked == true)
            {
                SetValue(Batata200g.Name, int.Parse(tb_Batata200g.Text), 15.00);
                ((App)Application.Current).UpdateQuantidade(Batata200g, tb_Batata200g.Name, tb_Batata200g.Text);
                ((App)Application.Current).checkBatata200g = true;
            }
            else
            {
                ((App)Application.Current).checkBatata200g = true;
                RemoveValue(Batata200g.Name);
            }
        }

        private void Batata400g_Checked(object sender, RoutedEventArgs e)
        {
            if (Batata400g.IsChecked == true)
            {
                SetValue(Batata400g.Name, int.Parse(tb_Batata400g.Text), 20.00);
                ((App)Application.Current).UpdateQuantidade(Batata400g, tb_Batata400g.Name, tb_Batata400g.Text);
                ((App)Application.Current).checkBatata400g = true;
            }
            else
            {
                ((App)Application.Current).checkBatata400g = true;
                RemoveValue(Batata400g.Name);
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

        private void Batata100gQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(Batata100g, tb_Batata100g.Name, tb_Batata100g.Text);
        }

        private void Batata200gQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(Batata200g, tb_Batata200g.Name, tb_Batata200g.Text);
        }

        private void Batata400gQt(object sender, TextChangedEventArgs e)
        {
            ((App)Application.Current).UpdateQuantidade(Batata400g, tb_Batata400g.Name, tb_Batata400g.Text);
        }
    }
}
