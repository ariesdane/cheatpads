using System.Linq;

namespace CheatPads.Framework.Entity
{
    public interface IEntityStore<T>
    {
        bool Exists(params object[] key);

        IQueryable<T> List();

        T Get(params object[] key);

        T Create(T entity);

        bool Update(T entity, params object[] key);

        bool Delete(params object[] key);

    }
}