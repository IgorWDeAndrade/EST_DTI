using System;

namespace EST.DTI.Domain.Entity
{
    public class Produto : EntidadeBase
    {
        public Produto()
        {

        }

        public int Quantidade { get; set; }
        public double ValorUnidade { get; set; }

        public void AtivarProduto(Produto prod) { prod.Ativo = true; }

        public void PrepararProdutoNovo(Produto prod) { prod.Ativo = true; prod.DateCadastro = DateTime.Now; }
    }
}
