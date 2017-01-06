using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoPrateleira.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        //[System.ComponentModel.Browsable(false)]
        public virtual Prateleira Prateleira { get; set; }


        public override string ToString()
        {
            return "Id: " + Id 
                + "\r\n" 
                + "Nome: " + Nome
                + "\r\n"
                + "Quantidade:" + Quantidade
                + "\r\n";
        }
    }
}
