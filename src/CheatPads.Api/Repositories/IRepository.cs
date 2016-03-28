namespace CheatPads.Api.Repositories
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Mvc;
    using CheatPads.Api.Model;

    public interface IRepository<T>
    {
        void Delete(long id);
        T Get(long id);
        List<T> GetAll();
        void Post(T Event);
        void Put(long id, [FromBody] T Event);
    }
}