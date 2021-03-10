using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;

namespace CarSeller.BusinessLogic.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork database;
        protected readonly IMapper mapper;

        public BaseService(IUnitOfWork database, 
                           IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
    }
}
