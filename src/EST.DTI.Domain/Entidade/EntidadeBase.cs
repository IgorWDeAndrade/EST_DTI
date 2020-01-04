using System;
using System.Collections.Generic;
using System.Text;

namespace EST.DTI.Domain.Entity
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DateCadastro { get; set; }
    }
}
