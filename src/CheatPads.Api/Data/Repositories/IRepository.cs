﻿using System.Linq;

namespace CheatPads.Api.Data.Repositories
{
    public interface IRepository<T>
    {
        bool Exists(params object[] key);

        IQueryable<T> List();

        T Get(params object[] key);

        void Create(T entity);

        void Update(T entity, params object[] key);

        void Delete(params object[] key);

    }
}