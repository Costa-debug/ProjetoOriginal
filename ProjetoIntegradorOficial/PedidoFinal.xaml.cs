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
    /// Interação lógica para PedidoFinal.xam
    /// </summary>
    public partial class PedidoFinal : Page
    {
        public PedidoFinal()
        {
            InitializeComponent();

            //dgPedidoFinal.ItemsSource= ((App)Application.Current).ItemPedido;
            tb_NomeCliente.Text = ((App)Application.Current).Nome;
            tb_TelefoneCliente.Text = ((App)Application.Current).Telefone;
            var total = 0.0;
            foreach (var item in ((App)Application.Current).ItemPedido)
            {
                total += item.Preco * item.Quantidade;
            }
            lb_Total.Content = total.ToString("C");
        }
    }
}
