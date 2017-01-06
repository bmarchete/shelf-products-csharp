using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoPrateleira.Models
{
    public class Prateleira
    {
        public int Id { get; set; }
        public string  Setor { get; set; }

        
        public virtual List<Produto> Produtos { get; set; }
    }
}
