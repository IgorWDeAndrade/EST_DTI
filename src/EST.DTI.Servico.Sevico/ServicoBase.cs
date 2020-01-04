using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Repositorio;
using EST.DTI.Domain.Interfaces.Servicos;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EST.DTI.Servico.Sevico
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly IRepositorioBase<TEntity> _repositorioBase;

        public ServicoBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }
        public void Adicionar(TEntity entity)
        {
            _repositorioBase.Adicionar(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _repositorioBase.Atualizar(entity);
        }

        public void Deletar(int id)
        {
            _repositorioBase.Deletar(id);
        }

        public void Deletar(TEntity predicate)
        {
            _repositorioBase.Deletar(predicate);
        }

        public TEntity Obter(int id)
        {
            return _repositorioBase.Obter(id);
        }

        public TEntity Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositorioBase.Obter(predicate);
        }

        public IQueryable<TEntity> ObterVarios(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositorioBase.ObterVarios(predicate);
        }
    }
}
