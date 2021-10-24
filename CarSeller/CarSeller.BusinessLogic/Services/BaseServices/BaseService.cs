using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces.UnitOfWork;

namespace CarSeller.BusinessLogic.Services.BaseServices
{
    /// <inheritdoc cref="IBaseService"/>
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        /// <summary>
        ///     Creates an instance of <see cref="IBaseService"/>.
        /// </summary>
        /// <param name="unitOfWork">
        ///     The UnitOfWork.
        /// </param>
        /// <param name="mapper">
        ///     The Mapper.
        /// </param>
        public BaseService(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}