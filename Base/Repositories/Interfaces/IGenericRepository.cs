using Base.Wrapper;
using System.Linq.Expressions;

namespace Base.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IResult<T>> GetById(int Id);
        Task<IResult<IEnumerable<T>>> GetAll();
        Task<IResult<IEnumerable<T>>>GetAllWithChaild<R>( Expression<Func<T,R>> child)where R : class;
        Task<IResult<IEnumerable<R>>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression);
        Task<IResult<IEnumerable<T>>> Find(Expression<Func<T, bool>> expression);
       

        Task<IResult> Add(T entity);
        Task<IResult<T>> AddAndReturn(T entity);
        Task<IResult<T>> Remove(T entity);
        Task<IResult<T>> Update(T entity);
    //    Task<int> SaveChange(CancellationToken cancellationToken=default);
    }
}
