using EST.DTI.Domain.Entity;
using EST.DTI.Domain.Interfaces.Repositorio;
using EST.DTI.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EST.DTI.Infra.Data.Repositorio
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity>, IDisposable where TEntity : EntidadeBase
    {
        private readonly Contexto _contexto;
        private readonly DbSet<TEntity> _entity;
        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
            _entity = _contexto.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            obj.DateCadastro = DateTime.Now;
            obj.Ativo = true;
            _entity.Add(obj);
            Commit();
        }

        public void AdicionarVarios(IEnumerable<TEntity> obj)
        {
            obj.ToList().ForEach(x =>
            {
                x.DateCadastro = DateTime.Now;
                x.Ativo = true;
            });
            _entity.AddRange(obj);
            Commit();
        }

        public void Atualizar(TEntity obj)
        {
            _entity.Update(obj);
            Commit();
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void Deletar(TEntity obj)
        {
            obj.Ativo = false;
            _entity.Update(obj);
            Commit();
        }

        public void Deletar(int id)
        {
            var obj = Obter(id);
            Deletar(obj);
        }

        public void DeletarVarios(ICollection<TEntity> obj)
        {
            foreach (var item in obj)
            {
                Deletar(item);
            }
        }

        public void Dispose()
        {
            _contexto?.Dispose();
        }

        public TEntity Obter(int id)
        {
            return _entity.Find(id);
        }

        public TEntity Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> ObterVarios(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate);
        }
    }
}
