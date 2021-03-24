using AutoMapper;
using CarSeller.BusinessLogic.MapperProfiles;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.SellerViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class SellerServiceTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private IMapper mapper;
        private Mock<ISellerRepository> sellerRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.sellerRepositoryMock = new Mock<ISellerRepository>();

            var mapperMock = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MappingProfile());
            });

            this.mapper = mapperMock.CreateMapper();
        }

        [Test]
        public async Task Create_ParametersPassed_ExpectedResults()
        {
            this.unitOfWorkMock.Setup(opt => opt.Seller)
                .Returns(this.sellerRepositoryMock.Object);

            var service = new SellerService(this.unitOfWorkMock.Object, this.mapper);
            await service.CreateAsync(this.CreateSellerViewModelTest());

            this.sellerRepositoryMock.Verify
                (opt => opt.CreateAsync(It.IsAny<Seller>()), Times.Once);
        }

        [Test]
        public void Create_NullParameters_ThrowException()
        {
            this.unitOfWorkMock.Setup(opt => opt.Seller)
                .Returns(this.sellerRepositoryMock.Object);

            var service = new SellerService(this.unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.CreateAsync(null))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("There was no Seller object to create.");
        }

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup
                (rep => rep.Seller.GetAllAsync()).Returns(this.GetSellerAsyncTest());
            var service = new SellerService(unitOfWorkMock.Object, this.mapper);

            var result = await service.GetAllAsync();

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
            unitOfWorkMock.Setup
                (rep => rep.Seller.GetById(It.IsAny<int>())).Returns(this.GetByIdAsyncTest());

            var service = new SellerService(unitOfWorkMock.Object, this.mapper);

            var result = await service.GetByIdAsync(It.IsAny<int>());

            result.Should().As<GetByIdSellerViewModel>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetByIdSellerViewModel { Id = 1, FirstName = "John", LastName = "Jonson" });
            result.Id.Should().Equals(1);
            result.FirstName.Should().Equals("John");
            result.LastName.Should().Equals("Jonson");
        }

        [Test]
        public void GetByIdAsync_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Seller.GetById(It.IsAny<int>()));

            var service = new SellerService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.GetByIdAsync(It.IsAny<int>()))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("Seller not found.");
        }

        [Test]
        public void Delete_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Seller.Remove(null)).Verifiable();

            var service = new SellerService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.RemoveAsync(It.IsAny<int>()))
                  .Should()
                  .Throw<Exception>()
                  .WithMessage("Seller not found.");
        }

        [Test]
        public void Update_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Seller.Update(this.UpdateSellerTest())).Verifiable();

            var service = new SellerService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.UpdateAsync(null))
                  .Should()
                  .Throw<Exception>()
                  .WithMessage("There was no Seller object to update.");
        }

        [Test]
        public void Update_InvalidParametersPassed_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.Seller.Update(this.UpdateSellerTest())).Verifiable();

            var service = new SellerService(unitOfWorkMock.Object, this.mapper);

            service.Invoking(opt => opt.UpdateAsync(this.UpdateSellerViewModelTest()))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("Seller not found.");
        }

        #region GetAll
        private Task<ICollection<Seller>> GetSellerAsyncTest()
        {
            var sellers = new List<Seller>
            {
                new Seller { FirstName = "John", LastName = "Jonson" }
            };
            return Task.FromResult<ICollection<Seller>>(sellers);
        }
        #endregion

        #region Create
        private CreateSellerViewModel CreateSellerViewModelTest()
        {
            return new CreateSellerViewModel { FirstName = "John", LastName = "Jonson" };
        }
        #endregion

        #region GetById
        private Task<Seller> GetByIdAsyncTest()
        {
            var seller = new Seller { Id = 1, FirstName = "John", LastName = "Jonson" };
            return Task.FromResult<Seller>(seller);
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
            return new UpdateSellerViewModel { FirstName = "John", LastName = "Jonson" };
        }
        #endregion
    }
}
