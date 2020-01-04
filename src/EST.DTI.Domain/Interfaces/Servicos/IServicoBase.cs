using EST.DTI.Domain.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EST.DTI.Domain.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Deletar(int id);
        void Deletar(TEntity predicate);
        TEntity Obter(int id);
        TEntity Obter(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> ObterVarios(Expression<Func<TEntity, bool>> predicate); 
    }
}
