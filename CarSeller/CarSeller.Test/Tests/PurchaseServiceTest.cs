using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Test.Tests
{
    public class PurchaseServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        Mock<IBaseRepository<Purchase>> baseRepositoryMock = new Mock<IBaseRepository<Purchase>>();

        [Test]
        public async Task GetAllReturns() 
        {
            //mock.Setup(rep => rep.Purchase.GetAllAsync()).Returns(GetPurchaseTest());
            //var service = new PurchaseService(mock.Object, mapperMock.Object, baseRepositoryMock.Object);

            //var result = service.GetAllAsync();

            //var typeResult = Assert.IsType<Task<ICollection<PurchaseInfoViewModel>>>(result);
            //var modelResult = Assert.IsAssignableFrom<Task<ICollection<PurchaseInfoViewModel>>>(typeResult);

        }

        [Test]
        public async Task Create()
        {
            //mock.Setup(rep => rep.Purchase.CreateAsync(CreatePurchaseTest()))
            //                     .Returns(Task.FromResult<object>((object)null))
            //                     .Verifiable();

            //var service = new PurchaseService(mock.Object, mapperMock.Object, baseRepositoryMock.Object);

            //var result = service.CreateAsync(CreatePurchaseViewModelTest());

            //await result.ConfigureAwait(false);
        }


        private PurchaseViewModel CreatePurchaseViewModelTest()
        {
            return new PurchaseViewModel { CarId = 1, UserId = "83bcac58-f6fa-490b-b996-8680f6baecbe" };
        }

        private Purchase CreatePurchaseTest()
        {
            return new Purchase { CarId = 1, UserId = "83bcac58-f6fa-490b-b996-8680f6baecbe" };
        }

        private async Task<ICollection<Purchase>> GetPurchaseTest()
        {
            var purchases = new List<Purchase>
            {
                new Purchase {  CarId = 1, UserId = "83bcac58-f6fa-490b-b996-8680f6baecbe" }
            };
            return purchases;
        }
    }
}
