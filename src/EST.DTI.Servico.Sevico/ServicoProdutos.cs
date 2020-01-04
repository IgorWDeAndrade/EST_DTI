using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Repositorio;
using EST.DTI.Domain.Interfaces.Servicos;

namespace EST.DTI.Servico.Sevico
{
    public class ServicoProdutos : ServicoBase<Produto> , IServicoProdutos
    {
        private readonly IRepositorioProdutos _repositorioProdutos;
        public ServicoProdutos(IRepositorioProdutos repositorioProdutos) : base(repositorioProdutos)
        {
            _repositorioProdutos = repositorioProdutos;
        }
    }
}
