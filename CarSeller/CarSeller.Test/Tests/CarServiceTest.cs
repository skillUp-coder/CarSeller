using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Test.Tests
{
    public class CarServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        Mock<IBaseRepository<Car>> baseRepositoryMock = new Mock<IBaseRepository<Car>>();

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults() 
        {
            //mock.Setup(rep => rep.Car.GetAllAsync()).Returns(GetCarsTest());
            //var service = new CarService(mock.Object, mapperMock.Object, baseRepositoryMock.Object);

            //var result = await service.GetAllAsync();

            ////var typeResult = Assert.IsType<Task<ICollection<CarInfoViewModel>>>(result);
            ////var modelResult = Assert.IsAssignableFrom<Task<ICollection<CarInfoViewModel>>>(typeResult);

            //result.Should().BeOfType<ICollection<CarInfoViewModel>>();
        }

        [Test]
        public async Task Create() 
        {
            //mock.Setup(rep => rep.Car.CreateAsync(CreateCarTest())).Returns(Task.FromResult<object>((object)null)).Verifiable(); 

            //var service = new CarService(mock.Object, mapperMock.Object, baseRepositoryMock.Object);

            //var result =  service.CreateAsync(CreateCarViewModelTest());

            //await result.ConfigureAwait(false);
        }


        private CarViewModel CreateCarViewModelTest() 
        {
            return new CarViewModel { Brand = "Tesla", Name = "X", State = "New" };
        }

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
    }
}
