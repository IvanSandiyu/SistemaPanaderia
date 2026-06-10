using Panaderia.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panaderia.Application.Interfaces
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<List<TEntity>> ListAsync();

        Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification);

        Task<TEntity?> FirstOrDefaultAsync(
            ISpecification<TEntity> specification);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
