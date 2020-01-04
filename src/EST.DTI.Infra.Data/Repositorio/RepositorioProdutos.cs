using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Repositorio;
using EST.DTI.Infra.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EST.DTI.Infra.Data.Repositorio
{
    public class RepositorioProdutos : RepositorioBase<Produto>, IRepositorioProdutos
    {
        private readonly Contexto _contexto;

        public RepositorioProdutos(Contexto contexto) : base (contexto)
        {
            _contexto = contexto;
        }
    }
}
