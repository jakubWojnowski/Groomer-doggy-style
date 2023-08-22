using System.Linq.Expressions;

namespace GroomerDoggyStyle.Domain.Interfaces;

public interface IGenericRepository<TEntity, in TKey> where TEntity : class
{
    Task<TEntity?> GetById(TKey id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<int> Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TEntity?>  GetNextRecordAsync(Expression<Func<TEntity, bool>>filter);
}