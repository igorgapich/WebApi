using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params string[] includeProperties);
        Task<TEntity?> GetByIDAsync(object id);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entityToDelete);
        Task UpdateAsync(TEntity entityToUpdate);
        Task <TEntity?> GetItemBySpec(ISpecification<TEntity> specification);
        Task <IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification);
        Task SaveAsync();
    }
}
