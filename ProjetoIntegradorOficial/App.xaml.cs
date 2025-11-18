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
        public Dictionary<string, int> ItemPedido = new Dictionary<string, int>();

        public string Nome { get; set; }
        public string Telefone { get; set; }

        public void UpdateQuantidade(CheckBox curCheckbox, string curitem, string qt)
        {
            var itm = curitem.Split('_');

            try
            {
                if (curCheckbox.IsChecked == true)
                    ItemPedido[itm.Last()] = int.Parse(qt);
            }
            catch { }
        }
    }
}
