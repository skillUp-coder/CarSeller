using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<ICollection<TEntity>> GetAllAsync() 
        {
            return await this.baseRepository.GetAllAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await this.baseRepository.CreateAsync(entity);
        }
    }
}
