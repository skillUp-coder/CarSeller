using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class SellerServiceTest
    {
        Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Seller.GetAllAsync()).Returns(this.GetAllSellerAsyncTest());
            var service = new SellerService(unitOfWorkMock.Object, mapperMock.Object);

            var result = await service.GetAllAsync();
            result.Sellers = await this.GetAllSellerViewModelItemsAsyncTest();

            result.Should().BeOfType<GetAllSellerViewModel>();
            result.Should().NotBeNull();
            result.Sellers.Should().HaveCount(1);

            foreach (var seller in result.Sellers)
            {
                seller.Id.Should().Equals(1);
                seller.FirstName.Should().Equals("John");
                seller.LastName.Should().Equals("Jonson");
            }
        }

        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Seller.GetById(It.IsAny<int>())).Returns(this.GetByIdSellerAsyncTest());
            var service = new SellerService(unitOfWorkMock.Object, mapperMock.Object)
                .GetById(It.IsAny<int>());

            service = this.GetByIdSellerViewModelAsyncTest();

            var result = await service;

            result.Should().As<GetByIdSellerViewModel>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetByIdSellerViewModel { Id = 1, FirstName = "John", LastName = "Jonson" });
            result.Id.Should().Equals(1);
            result.FirstName.Should().Equals("John");
            result.LastName.Should().Equals("Jonson");
        }

        [Test]
        public void Delete_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Seller.Remove(this.DeleteSellerTest()))
                                                  .Verifiable();

            var service = new SellerService(unitOfWorkMock.Object, mapperMock.Object)
                .Remove(It.IsAny<int>());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        [Test]
        public void Update_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Seller.Update(this.UpdateSellerTest()))
                                                  .Verifiable();

            var service = new SellerService(unitOfWorkMock.Object, mapperMock.Object)
                .Update(this.UpdateSellerViewModelTest());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        [Test]
        public void Create_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Seller.CreateAsync(this.CreateSellerTest()))
                                                  .Verifiable();

            var service = new SellerService(unitOfWorkMock.Object, mapperMock.Object)
                .CreateAsync(this.CreateSellerViewModelTest());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }


        #region GetAll
        private async Task<ICollection<Seller>> GetAllSellerAsyncTest()
        {
            return new List<Seller>
            {
                new Seller { Id = 1, FirstName = "John", LastName = "Jonson"  }
            };
        }

        private async Task<ICollection<GetAllSellerViewModelItem>> GetAllSellerViewModelItemsAsyncTest()
        {
            return new List<GetAllSellerViewModelItem>
            {
                new GetAllSellerViewModelItem { Id = 1, FirstName = "John", LastName = "Jonson" }
            };
        }
        #endregion

        #region GetById
        private async Task<Seller> GetByIdSellerAsyncTest()
        {
            return new Seller { Id = 1, FirstName = "John", LastName = "Jonson" };
        }

        private async Task<GetByIdSellerViewModel> GetByIdSellerViewModelAsyncTest()
        {
            return new GetByIdSellerViewModel { Id = 1, FirstName = "John", LastName = "Jonson" };
        }
        #endregion

        #region Delete
        private Seller DeleteSellerTest()
        {
            return new Seller { Id = 1, FirstName = "John", LastName = "Jonson" };
        }
        #endregion

        #region Update
        private Seller UpdateSellerTest()
        {
            return new Seller { Id = 1, FirstName = "John", LastName = "Jonson" };
        }

        private UpdateSellerViewModel UpdateSellerViewModelTest()
        {
            return new UpdateSellerViewModel { Id = 1, FirstName = "John", LastName = "Jonson" };
        }
        #endregion

        #region Create
        private Seller CreateSellerTest()
        {
            return new Seller { Id = 1, FirstName = "John", LastName = "Jonson" };
        }

        private CreateSellerViewModel CreateSellerViewModelTest()
        {
            return new CreateSellerViewModel { FirstName = "John", LastName = "Jonson" };
        }
        #endregion
    }
}
