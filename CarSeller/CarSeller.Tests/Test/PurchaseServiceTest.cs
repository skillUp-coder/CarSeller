using AutoMapper;
using CarSeller.BusinessLogic.MapperProfiles;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Enums;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.PurchaseViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class PurchaseServiceTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private IMapper mapper;
        private Mock<IPurchaseRepository> purchaseRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.purchaseRepositoryMock = new Mock<IPurchaseRepository>();

            var mapperMock = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MappingProfile());
            });

            this.mapper = mapperMock.CreateMapper();
        }

        [Test]
        public async Task Create_ParametersPassed_ExpectedResults()
        {
            this.unitOfWorkMock.Setup(opt => opt.Purchase)
                .Returns(this.purchaseRepositoryMock.Object);

            var service = new PurchaseService(this.unitOfWorkMock.Object, this.mapper);
            await service.CreateAsync(this.CreatePurchaseViewModel());

            this.purchaseRepositoryMock.Verify
                (opt => opt.CreateAsync(It.IsAny<Purchase>()), Times.Once);
        }

        [Test]
        public void Create_NullParameters_ThrowException()
        {
            this.unitOfWorkMock.Setup(opt => opt.Purchase)
                .Returns(this.purchaseRepositoryMock.Object);

            var service = new PurchaseService(this.unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.CreateAsync(null))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("There was no Purchase object to create.");
        }

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup
                (rep => rep.Purchase.GetAllAsync()).Returns(this.GetPurchaseAsyncTest());
            var service = new PurchaseService(unitOfWorkMock.Object, this.mapper);

            var result = await service.GetAllAsync();

            result.Should().BeOfType<GetAllPurchaseViewModel>();
            result.Should().NotBeNull();
            result.Purchases.Should().HaveCount(1);

            foreach (var purchase in result.Purchases)
            {
                purchase.Id.Should().Equals(1);
            }
        }

        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup
                (rep => rep.Purchase.GetById(It.IsAny<int>())).Returns(this.GetByIdAsyncTest());

            var service = new PurchaseService(unitOfWorkMock.Object, this.mapper);

            var result = await service.GetByIdAsync(It.IsAny<int>());

            result.Should().As<GetByIdPurchaseViewModel>();
            result.Should().NotBeNull();
            result.Id.Should().Equals(1);
            result.Car.Id.Should().Equals(1);
            result.Car.Brand.Should().Equals("Tesla");
            result.Car.Name.Should().Equals("X");
            result.Car.State.Should().Equals(CarState.New);
            result.User.Id.Should().Equals("1");
            result.User.Id.Should().Equals("John");
        }

        [Test]
        public void GetByIdAsync_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Purchase.GetById(It.IsAny<int>()));

            var service = new PurchaseService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.GetByIdAsync(It.IsAny<int>()))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("Purchase not found.");
        }

        [Test]
        public void Delete_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Purchase.Remove(null)).Verifiable();

            var service = new PurchaseService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.RemoveAsync(It.IsAny<int>()))
                  .Should()
                  .Throw<Exception>()
                  .WithMessage("Purchase not found.");
        }

        [Test]
        public void Update_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Purchase.Update(this.UpdatePurchaseTest())).Verifiable();

            var service = new PurchaseService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.UpdateAsync(null))
                  .Should()
                  .Throw<Exception>()
                  .WithMessage("There was no Purchase object to update.");
        }

        #region GetAll
        private Task<ICollection<Purchase>> GetPurchaseAsyncTest()
        {
            var purchase = new List<Purchase>
            {
                new Purchase { Id = 1, CarId = 1, UserId = "1b556baa-29cc-4bf1-a65f-70c3d98d5005" }
            };
            return Task.FromResult<ICollection<Purchase>>(purchase);
        }
        #endregion

        #region Create
        private CreatePurchaseViewModel CreatePurchaseViewModel()
        {
            return new CreatePurchaseViewModel { CarId = 1, UserId = "1" };
        }
        #endregion

        #region GetById
        private Task<Purchase> GetByIdAsyncTest()
        {
            var purchase = new Purchase
            {
                Id = 1,
                Car = new Car { Id = 1, Brand = "Tesla", Name = "X", State = CarState.New },
                User = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" }
            };
            return Task.FromResult<Purchase>(purchase);
        }
        #endregion

        #region Delete
        private Purchase DeleteTest()
        {
            return new Purchase { CarId = 1, Id = 1, UserId = "1" };
        }
        #endregion

        #region Update
        private Purchase UpdatePurchaseTest()
        {
            return new Purchase { CarId = 1, Id = 1, UserId = "1" };
        }
        #endregion
    }
}
