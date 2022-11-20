using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shoope.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public decimal Preco { get; set; }
        public string Categoria {get; set;}


    }
}