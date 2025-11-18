using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoIntegradorOficial
{
    public class Pedidos
    {
        public string Item { get; set; }
        public int Quantidade { get; set; }

        public Pedidos(string item, int quantidade)
        {
            Item = item;
            Quantidade = quantidade;
        }
    }
}
