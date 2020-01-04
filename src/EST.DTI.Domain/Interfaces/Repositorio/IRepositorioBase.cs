using EST.DTI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EST.DTI.Domain.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        void Adicionar(TEntity obj);
        void AdicionarVarios(IEnumerable<TEntity> obj);
        void Atualizar(TEntity obj);
        void Deletar(TEntity obj);
        void Deletar(int id);
        void DeletarVarios(ICollection<TEntity> obj);
        TEntity Obter(int id);
        TEntity Obter(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> ObterVarios(Expression<Func<TEntity, bool>> predicate);
        void Commit();
        void Dispose();
    }
}
