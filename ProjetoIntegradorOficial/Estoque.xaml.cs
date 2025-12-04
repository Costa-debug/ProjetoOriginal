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
    /// Interação lógica para Estoque.xam
    /// </summary>
    public partial class Estoque : Page
    {
        public class EstoqueItem
        {
            public string Produto { get; set; }
            public int Quantidade { get; set; }
            public double Preco { get; set; }
            public string Validade { get; set; }
        }

        public Estoque()
        {
            InitializeComponent();

            string sql = "SELECT produto, quantidade, preco, validade FROM estoque";
            MySqlCommand cmd = new MySqlCommand(sql, ConectarBD.Conexao);

            MySqlDataReader leitor = cmd.ExecuteReader();

            List<EstoqueItem> lista = new List<EstoqueItem>();

            while (leitor.Read())
            {
                lista.Add(new EstoqueItem()
                {
                    Produto = leitor["produto"].ToString(),
                    Quantidade = int.Parse(leitor["quantidade"].ToString()),
                    Preco = double.Parse(leitor["preco"].ToString()),
                    Validade = leitor["validade"].ToString()
                });
            }

            leitor.Close();

            dtEstoque.ItemsSource = lista;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Introdução2());
        }
    }
}
