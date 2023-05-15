

using Base.Data.DbContext;
using Base.Repositories.Interfaces;
using Base.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Base.Repositories.Implementations
{
    public abstract class GenirecRopoistories<T> : IGenericRepository<T> where T : class
    {
      
        public ApplicationDbContext _dbContext;
       

        public GenirecRopoistories( ApplicationDbContext dbContext)
        {
            //_unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task<IResult<T>> GetById(int Id)
        {
            try
            {
                var res = await _dbContext.Set<T>().FindAsync(Id);
                return await Result<T>.SucessAsync(res);
            }catch (Exception ex)
            {
         
                return await Result<T>.FailAsync($"Sorry! error when GetById  {ex.Message}");
            
        }

        }
        public async Task<IResult> Add(T entity)
        {
            try
            {


                var res = await _dbContext.Set<T>().AddAsync(entity);
                //   await SaveChange();

                return await Result<T>.SucessAsync("added successFully");
            }
            catch (Exception ex)
            {
                return await Result<T>.FailAsync($"Sorry! error when Add  {ex.Message}");
            }
        }

        public async Task<IResult<T>> AddAndReturn(T entity)
        {
            try
            {
                
                
                var res = await _dbContext.Set<T>().AddAsync(entity);
             //   await SaveChange();
              
                return await Result<T>.SucessAsync(res.Entity,"added sucessfully");
            }
            catch (Exception ex)
            {
                return await Result<T>.FailAsync($"Sorry! error when Add  {ex.Message}");
            }
        }

        public async Task<IResult<IEnumerable<T>>> GetAll()
        {
            try
            {
                var res = await _dbContext.Set<T>().AsNoTracking().ToListAsync();

                return await Result<IEnumerable<T>>.SucessAsync(res);
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<T>>.FailAsync($"Sorry! error when GetAll  {ex.Message}");
            }
        }   
        public async Task<IResult<IEnumerable<T>>> GetAllWithChaild<R>(Expression<Func<T,R>> child) where R : class
        {
            try
            {
                var res = await _dbContext.Set<T>().AsNoTracking().Include<T,R>(child).AsSplitQuery().ToListAsync();

                return await Result<IEnumerable<T>>.SucessAsync(res);
            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<T>>.FailAsync($"Sorry! error when GetAll  {ex.Message}");
            }
        }
        public async Task<IResult<T>> Remove(T entity)
        {
            try
            {
                var res = _dbContext.Set<T>().Remove(entity);
                //  await SaveChange();
                return await Result<T>.SucessAsync(res.Entity);
            }catch (Exception ex)
            {
                return await Result<T>.FailAsync($"Sorry! error when remove  {ex.Message}");
            }

        }
        public async Task<IResult<T>> Update(T entity)
        {
            try
            {
                var res = _dbContext.Set<T>().Update(entity);
                // await SaveChange();
                return await Result<T>.SucessAsync(res.Entity);
            }
            catch (Exception ex)
            {
                return await Result<T>.FailAsync($"Sorry! error when Update  {ex.Message}");
            }
        }
        public async Task<IResult<IEnumerable<T>>> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                var res = await _dbContext.Set<T>().Where(expression).ToListAsync();
                if (res.Any())
                {
                    return await Result<IEnumerable<T>>.SucessAsync(res, "data is Retrive");
                }
                return await Result<IEnumerable<T>>.FailAsync($"Sorry! error when Find");

            }
            catch (Exception ex)
            {
                
                return await Result<IEnumerable<T>>.FailAsync($"Sorry! error when Find  {ex.Message}");
            }
        }

        public async Task<IResult<IEnumerable<R>>> Find<R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> expression)
        {
            try
            {
                var res = await _dbContext.Set<T>().Where(expression).Select(selector).ToListAsync();
                return await Result<IEnumerable<R>>.SucessAsync(res, "data is Retrive");

            }
            catch (Exception ex)
            {
                return await Result<IEnumerable<R>>.FailAsync($"Sorry! error when Find  {ex.Message}");
            }
        } 
       
        //public async Task<int> SaveChange(CancellationToken cancellationToken = default)
        //{
        //    var res = await _unitOfWork.CompleteAsync(cancellationToken);
        //    return res;
        //}

    }
}
