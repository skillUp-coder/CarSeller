using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.CarViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class CarServiceTest
    {
        Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Car.GetAllAsync()).Returns(this.GetCarsAsyncTest());
            var service = new CarService(unitOfWorkMock.Object, mapperMock.Object);

            var result = await service.GetAllAsync();
            result.Cars = await this.GetAllCarViewModelItemAsyncTest();

            result.Should().BeOfType<GetAllCarViewModel>();
            result.Should().NotBeNull();
            result.Cars.Should().HaveCount(1);

            foreach (var car in result.Cars)
            {
                car.Id.Should().Equals(1);
                car.Brand.Should().Equals("Tesla");
                car.Name.Should().Equals("X");
                car.State.Should().Equals("new");
            }
        }

        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Car.GetById(It.IsAny<int>())).Returns(this.GetByIdAsyncTest());
            var service = new CarService(unitOfWorkMock.Object, mapperMock.Object)
                .GetById(It.IsAny<int>());
            service = this.GetByIdCarViewModelAsyncTest();

            var result = await service;

            result.Should().As<GetByIdCarViewModel>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetByIdCarViewModel { Id = 1, Name = "X", Brand = "Tesla", State = "new" });
            result.Id.Should().Equals(1);
            result.Brand.Should().Equals("Tesla");
            result.Name.Should().Equals("X");
            result.State.Should().Equals("new");
        }

        [Test]
        public void Delete_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Car.Remove(this.DeleteTest()))
                                                  .Verifiable();

            var service = new CarService(unitOfWorkMock.Object, mapperMock.Object)
                .Remove(It.IsAny<int>());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        [Test]
        public void Update_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Car.Update(this.UpdateCarTest()))
                                                  .Verifiable();

            var service = new CarService(unitOfWorkMock.Object, mapperMock.Object)
                .Update(this.UpdateCarViewModelTest());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }

        [Test]
        public void Create_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.Car.CreateAsync(this.CreateCarTest()))
                                                  .Verifiable();

            var service = new CarService(unitOfWorkMock.Object, mapperMock.Object)
                .CreateAsync(this.CreateCarViewModelTest());

            service.Should().Equals("Empty object");
            service.GetAwaiter().IsCompleted.Should().BeTrue();
            service.Should().As<Task>();
        }


        #region GetAll
        private async Task<ICollection<Car>> GetCarsAsyncTest()
        {
            return new List<Car>
            {
                new Car { Brand = "Tesla", Name = "X", State = "New"}
            };
        }

        private async Task<ICollection<GetAllCarViewModelItem>> GetAllCarViewModelItemAsyncTest()
        {
            return new List<GetAllCarViewModelItem> {
                new GetAllCarViewModelItem { Brand = "Tesla", Name = "X", State = "New" }
            };
        }

        #endregion

        #region Create
        private Car CreateCarTest()
        {
            return new Car { Brand = "Tesla", Name = "X", State = "New" };
        }

        private CreateCarViewModel CreateCarViewModelTest()
        {
            return new CreateCarViewModel { Brand = "Tesla", Name = "X", State = "New" };
        }


        #endregion

        #region GetById
        private async Task<Car> GetByIdAsyncTest()
        {
            var car = new Car { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
            return car;
        }

        private async Task<GetByIdCarViewModel> GetByIdCarViewModelAsyncTest()
        {
            return new GetByIdCarViewModel { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
        }
        #endregion

        #region Delete
        private Car DeleteTest()
        {
            return new Car { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
        }
        #endregion

        #region Update
        private Car UpdateCarTest()
        {
            return new Car { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
        }

        public UpdateCarViewModel UpdateCarViewModelTest()
        {
            return new UpdateCarViewModel { Brand = "Tesla", Name = "X", State = "New" };
        }
        #endregion
    }
}
