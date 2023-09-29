using System.Linq.Expressions;

namespace Static.Services.Abstracts.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();

        Task<T> FindById(int id);

        Task<T> FindByProperty<TValue>(Expression<Func<T, TValue>> selector, TValue value);

        Task<IEnumerable<T>> SearchByProperty<TValue>(string propertyName, TValue value);

        Task<T?> NullableFindById(int id);

        Task<T> Delete(int id);

        Task<T> Update(T entityToUpdate);

        Task<T> Create(T entityDTO);
    }
}
