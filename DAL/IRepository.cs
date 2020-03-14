using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IRepository<TEntity>: IDisposable
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int TEntityId);
        void Add(TEntity TEntity);
        void Delete(int TEntityId);
        void Delete(TEntity TEntity);
        void Update(TEntity TEntity);
        void Save();
    }
}
