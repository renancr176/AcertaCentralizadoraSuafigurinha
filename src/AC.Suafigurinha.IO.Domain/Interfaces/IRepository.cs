using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AC.Suafigurinha.IO.Domain.Core.Models;


namespace AC.Suafigurinha.IO.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Insert(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
