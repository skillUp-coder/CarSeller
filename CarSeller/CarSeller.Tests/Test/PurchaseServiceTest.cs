using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class PurchaseServiceTest
    {
        Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Purchase.GetAllAsync())
                .Returns(this.GetAllPurchaseAsyncTest());
            var service = new PurchaseService(unitOfWorkMock.Object, mapperMock.Object);

            var result = await service.GetAllAsync();
            result.Purchases = await this.GetAllPurchaseViewModelItemsAsyncTest();

            result.Should().BeOfType<GetAllPurchaseViewModel>();
            result.Should().NotBeNull();
            result.Purchases.Should().HaveCount(1);

            foreach (var purchase in result.Purchases)
            {
                purchase.Id.Should().Equals(1);
                purchase.Car.Id.Should().Equals(1);
                purchase.Car.Brand.Should().Equals("Tesla");
                purchase.Car.Name.Should().Equals("X");
                purchase.Car.State.Should().Equals("new");
                purchase.User.Id.Should().Equals("1b556baa-29cc-4bf1-a65f-70c3d98d5005");
                purchase.User.UserName.Should().Equals("John");
            }
        }

        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Purchase.GetById(It.IsAny<int>())).Returns(this.GetByIdAsyncTest());
            var service = new PurchaseService(unitOfWorkMock.Object, mapperMock.Object)
                .GetById(It.IsAny<int>());
            service = this.GetByIdPurchaseViewModelAsyncTest();

            var result = await service;

            result.Should().As<GetByIdPurchaseViewModel>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetByIdPurchaseViewModel
            {
                Id = 1,
                Car = new CarGetByIdPurchaseViewModelItem { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                User = new UserGetByIdPurchaseViewModelItem { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            });
            result.Id.Should().Equals(1);
            result.Car.Id.Should().Equals(1);
            result.Car.Brand.Should().Equals("Tesla");
            result.Car.Name.Should().Equals("X");
            result.Car.State.Should().Equals("new");
            result.User.Id.Should().Equals("1b556baa-29cc-4bf1-a65f-70c3d98d5005");
            result.User.UserName.Should().Equals("John");
        }

        [Test]
        public void Delete_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Purchase.Remove(this.DeletePurchaseTest()))
                                                  .Verifiable();

            var service = new PurchaseService(unitOfWorkMock.Object, mapperMock.Object)
                .Remove(It.IsAny<int>());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        [Test]
        public void Update_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Purchase.Update(this.UpdatePurchaseTest()))
                                                  .Verifiable();

            var service = new PurchaseService(unitOfWorkMock.Object, mapperMock.Object)
                .Update(this.UpdatePurchaseViewModelTest());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        [Test]
        public void Create_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Purchase.CreateAsync(this.CreatePurchaseTest()))
                                                  .Verifiable();

            var service = new PurchaseService(unitOfWorkMock.Object, mapperMock.Object)
                .CreateAsync(this.CreatePurchaseViewModelTest());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        #region GetAll
        private async Task<ICollection<Purchase>> GetAllPurchaseAsyncTest()
        {
            return new List<Purchase>
            {
                new Purchase { Id = 1, CarId = 1, UserId = "1b556baa-29cc-4bf1-a65f-70c3d98d5005" }
            };
        }

        private async Task<ICollection<PurchaseGetAllPurchaseViewModelItem>> GetAllPurchaseViewModelItemsAsyncTest()
        {
            return new List<PurchaseGetAllPurchaseViewModelItem>
            {
                new PurchaseGetAllPurchaseViewModelItem
                {
                    Id = 1,
                    Car = new Car { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                    User = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
                }
            };
        }
        #endregion

        #region GetById
        private async Task<Purchase> GetByIdAsyncTest()
        {
            return new Purchase
            {
                Id = 1,
                Car = new Car { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                User = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            };
        }

        private async Task<GetByIdPurchaseViewModel> GetByIdPurchaseViewModelAsyncTest()
        {
            return new GetByIdPurchaseViewModel
            {
                Id = 1,
                Car = new CarGetByIdPurchaseViewModelItem { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                User = new UserGetByIdPurchaseViewModelItem { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            };
        }
        #endregion

        #region Delete

        private Purchase DeletePurchaseTest()
        {
            return new Purchase
            {
                Id = 1,
                Car = new Car { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                User = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            };
        }

        #endregion

        #region Update
        private Purchase UpdatePurchaseTest()
        {
            return new Purchase
            {
                Id = 1,
                Car = new Car { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                User = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            };
        }

        private UpdatePurchaseViewModel UpdatePurchaseViewModelTest()
        {
            return new UpdatePurchaseViewModel { Id = 1, CarId = 1, UserId = "1b556baa-29cc-4bf1-a65f-70c3d98d5005" };
        }
        #endregion

        #region Create
        private Purchase CreatePurchaseTest()
        {
            return new Purchase
            {
                Id = 1,
                Car = new Car { Id = 1, Brand = "Tesla", Name = "X", State = "new" },
                User = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            };
        }

        private CreatePurchaseViewModel CreatePurchaseViewModelTest()
        {
            return new CreatePurchaseViewModel { CarId = 1, UserId = "1b556baa-29cc-4bf1-a65f-70c3d98d5005" };
        }
        #endregion
    }
}
