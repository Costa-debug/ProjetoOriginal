using MySql.Data.MySqlClient;
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
    /// Interação lógica para Produto.xam
    /// </summary>
    public partial class Produto : Page
    {
        public Produto()
        {
            InitializeComponent();
        }

        private void Button_Adm(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Introdução2());
        }

        private void Button_Concluir_Click(object sender, RoutedEventArgs e)
        {
            var sql = $"INSERT INTO estoque (produto, quantidade, preco, validade) VALUES (@produto, @quantidade, @preco, @validade)";
            MySqlCommand cmd = new MySqlCommand(sql, ConectarBD.Conexao);

            cmd.Parameters.AddWithValue("@produto", tb_ProdutoN.Text);
            cmd.Parameters.AddWithValue("@quantidade", int.Parse(tb_QuantidadeN.Text));
            cmd.Parameters.AddWithValue("@preco", double.Parse(tb_PreçoN.Text));
            cmd.Parameters.AddWithValue("@validade", dt_Validade.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Produto cadastrado com sucesso!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
