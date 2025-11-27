using Google.Protobuf.WellKnownTypes;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoIntegradorOficial
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        public List<PedidoFinalInfo> ItemPedido = new List<PedidoFinalInfo>();
       
        public List<TextBox> tb_Quantidade = new List<TextBox>();
        public bool checkBurguer { get; set; }
        public bool checkBacon { get; set; }
        public bool checkFrango { get; set; }
        public bool checkCoração { get; set; }
        public bool checkEntrevero { get; set; }
        public bool checkVegetal { get; set; }
        public bool checkBatata100g { get; set; }
        public bool checkBatata200g { get; set; }
        public bool checkBatata400g { get; set; }
        public bool checkCoca { get; set; }
        public bool checkÁgua { get; set; }
        public bool checkSuco { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public void UpdateQuantidade(CheckBox curCheckbox, string curitem, string qt)
        {
            var itm = curitem.Split('_');

            try
            {
                if (curCheckbox.IsChecked == true)
                    ItemPedido.Last().Quantidade = int.Parse(qt);
            }
            catch { }
        }

        public void InsertQt(TextBox itmAdd)
        {
            if (!tb_Quantidade.Contains(itmAdd))
            {
                tb_Quantidade.Add(itmAdd);
            }
        }
    }

    public class PedidoFinalInfo
    {
        public string Item { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

        public int Total { get; set; }

        public PedidoFinalInfo(string Item, int Quantidade, double Preco, int Total)
        {
            this.Item = Item;
            this.Quantidade = Quantidade;
            this.Preco = Preco;
            this.Total = Total;
        }
    }
}
