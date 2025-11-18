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
                SetValue(Coca.Name, tb_Coca.Text);
                ((App)Application.Current).UpdateQuantidade(Coca, tb_Coca.Name, tb_Coca.Text);
            }
            else
            {
                RemoveValue(Coca.Name);
            }
        }

        private void Água_Checked(object sender, RoutedEventArgs e)
        {
            if (Água.IsChecked == true)
            {
                SetValue(Água.Name, tb_Água.Text);
                ((App)Application.Current).UpdateQuantidade(Água, tb_Água.Name, tb_Água.Text);
            }
            else
            {
                RemoveValue(Água.Name);
            }
        }

        private void Suco_Checked(object sender, RoutedEventArgs e)
        {
            if (Suco.IsChecked == true)
            {
                SetValue(Suco.Name, tb_Suco.Text);
                ((App)Application.Current).UpdateQuantidade(Suco, tb_Suco.Name, tb_Suco.Text);
            }
            else
            {
                RemoveValue(Suco.Name);
            }
        }
       
        private void RemoveValue(string item)
        {
            ((App)Application.Current).ItemPedido.Remove(item);
        }

        private void SetValue(string item, string quantidade)
        {
            try
            {
                ((App)Application.Current).ItemPedido.Add(item, int.Parse(quantidade));
            }
            catch { }

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
