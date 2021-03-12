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

namespace CarSeller.UnitTests.Tests
{
    /// <summary>
    /// The CarServiceTest class is responsible for testing service methods.
    /// </summary>
    public class CarServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        Mock<IBaseRepository<Car>> baseRepositoryMock = new Mock<IBaseRepository<Car>>();

        /// <summary>
        /// Responsible for testing the Servicha method to get all the entity data
        /// </summary>
        /// <returns>Returns test result for type and non-null value</returns>
        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            mock.Setup(rep => rep.Car.GetAllAsync()).Returns(GetCarsTest());
            var service = new CarService(mock.Object, mapperMock.Object);

            var result = await service.GetAllAsync();

            result.Should().BeOfType<GetAllCarViewModel>();
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Responsible for testing the service method to create an object
        /// </summary>
        /// <returns>Returns the test result of the method</returns>
        [Test]
        public async Task CreateAsync_ParametersPassed_ExpectedResults() 
        {
            mock.Setup(rep => rep.Car.CreateAsync(CreateCarTest())).Returns(Task.FromResult<object>((object)null)).Verifiable();

            var service = new CarService(mock.Object, mapperMock.Object);

            var result = service.CreateAsync(CreateCarViewModelTest());

            await result.ConfigureAwait(false);
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Responsible for testing the method to get a specific object
        /// </summary>
        /// <returns>Returns the result of testing a value</returns>
        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            mock.Setup(rep => rep.Car.GetById(1)).Returns(GetByIdAsync());
            var service = new CarService(mock.Object, mapperMock.Object);

            GetByIdCarViewModel result = await service.GetById(1);

            result.Should().Be(null);
            result.Should().BeNull();
        }

        /// <summary>
        /// Responsible for testing a service method to delete a specific object
        /// </summary>
        /// <returns>Returns the test result of the method</returns>
        [Test]
        public async Task Delete_ParametersPassed_ExpectedResults() 
        {
            mock.Setup(rep => rep.Car.Remove(Remove()));

            var service = new CarService(mock.Object, mapperMock.Object);

            var result = service.Remove(1);

            await result.ConfigureAwait(false);
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Responsible for testing the service method to update the object's data
        /// </summary>
        /// <returns>Returns the result of testing a service method</returns>
        [Test]
        public async Task Update_ParametersPassed_ExpectedResults() 
        {
            mock.Setup(rep => rep.Car.Update(Update()));

            var service = new CarService(mock.Object, mapperMock.Object);

            var result = service.Remove(1);

            await result.ConfigureAwait(false);
            result.Should().NotBeNull();
        }


        #region GetAll
        private CreateCarViewModel CreateCarViewModelTest()
        {
            return new CreateCarViewModel { Brand = "Tesla", Name = "X", State = "New" };
        }
        #endregion

        #region Create
        private Car CreateCarTest()
        {
            return new Car { Brand = "Tesla", Name = "X", State = "New" };
        }

        private async Task<ICollection<Car>> GetCarsTest()
        {
            var cars = new List<Car>
            {
                new Car { Brand = "Tesla", Name = "X", State = "New"}
            };
            return cars;
        }
        #endregion

        #region GetById
        public async Task<Car>  GetByIdAsync() 
        {
            var car = new Car { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
            return car;
        }

        public async Task<GetByIdCarViewModel> GetById()
        {
            return new GetByIdCarViewModel { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
        }
        #endregion

        #region Remove
        public Car Remove()
        {
            return new Car { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
        }
        #endregion

        #region Update
        public Car Update()
        {
            return new Car { Id = 1, Name = "X", Brand = "Tesla", State = "new" };
        }
        #endregion
    }


}
