using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;

namespace CarSeller.BusinessLogic.Services
{
    /// <summary>
    /// The BaseService class is responsible for the implementation of the dependency constructor.
    /// </summary>
    /// <typeparam name="TEntity">Generalized entity.</typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork database;
        protected readonly IMapper mapper;

        /// <summary>
        /// Creates an instance of BaseService.
        /// </summary>
        /// <param name="database">The UnitOfWork object for interacting with repositories.</param>
        /// <param name="mapper">The Mapper object to transform objects.</param>
        public BaseService(IUnitOfWork database, 
                           IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
    }
}
