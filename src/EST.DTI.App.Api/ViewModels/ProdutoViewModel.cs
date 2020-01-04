using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EST.DTI.App.Api.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DateCadastro { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnidade { get; set; }
    }
}
