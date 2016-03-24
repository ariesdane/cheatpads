namespace AspNet5SQLite.Repositories
{
    using System.Collections.Generic;
    using AspNet5SQLite.Model;
    using Microsoft.AspNet.Mvc;

    public interface IRepository<T>
    {
        void Delete(long id);
        T Get(long id);
        List<T> GetAll();
        void Post(T Event);
        void Put(long id, [FromBody] T Event);
    }
}