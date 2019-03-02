namespace MatchesSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Detach(T entity);

        int SaveChanges();

        void BulkMerge(IEnumerable<T> entities);

        void BulkSaveChanges();
    }
}
