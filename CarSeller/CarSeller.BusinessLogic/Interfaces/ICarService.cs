using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.ViewModels;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        Task<GetAllCarViewModel> GetAllAsync();

        Task CreateAsync(CreateCarViewModel entity);

        Task<GetByIdCarViewModel> GetById(int id);

        Task Remove(int id);

        Task Update(UpdateCarViewModel entity);
    }
}
