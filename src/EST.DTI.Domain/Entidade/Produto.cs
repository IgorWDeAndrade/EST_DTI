using System;
using System.Collections.Generic;
using System.Text;

namespace EST.DTI.Domain.Entity
{
    public class Produto : EntidadeBase
    {
        public Produto()
        {

        }

        public int Quantidade { get; set; }
        public double ValorUnidade { get; set; }
    }
}
