using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CarSeller.Test.Tests
{
    public class SellerServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        Mock<IBaseRepository<Seller>> baseRepositoryMock = new Mock<IBaseRepository<Seller>>();

        [Test]
        public async Task Create()
        {
            //mock.Setup(rep => rep.Seller.CreateAsync(CreateSellerTest()))
            //                     .Returns(Task.FromResult<object>((object)null))
            //                     .Verifiable();

            //var service = new SellerService(mock.Object, mapperMock.Object, baseRepositoryMock.Object);

            //var result = service.CreateAsync(CreateSellerViewModelTest());

            //await result.ConfigureAwait(false);
        }

        private CreateSellerViewModel CreateSellerViewModelTest()
        {
            return new CreateSellerViewModel { FirstName = "Elon", LastName = "Musk" };
        }

        private Seller CreateSellerTest()
        {
            return new Seller { Id = 1, FirstName = "Elon", LastName = "Musk" };
        }
    }
}
