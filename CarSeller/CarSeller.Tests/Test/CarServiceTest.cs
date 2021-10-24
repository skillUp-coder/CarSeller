// using AutoMapper;
// using CarSeller.BusinessLogic.MapperProfiles;
// using CarSeller.BusinessLogic.Services;
// using CarSeller.DataAccess.Interfaces;
// using CarSeller.Entities.Enums;
// using CarSeller.Entities.Models;
// using CarSeller.ViewModels.CarViewModels;
// using CarSeller.ViewModels.Enums;
// using CarSeller.ViewModels.ViewModels;
// using FluentAssertions;
// using Moq;
// using NUnit.Framework;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
//
// namespace CarSeller.Tests.Test
// {
//     public class CarServiceTest
//     {
//         private Mock<IUnitOfWork> unitOfWorkMock;
//         private IMapper mapper;
//         private Mock<ICarRepository> carRepositoryMock;
//
//         [SetUp]
//         public void SetUp() 
//         {
//             this.unitOfWorkMock = new Mock<IUnitOfWork>();
//             this.carRepositoryMock = new Mock<ICarRepository>();
//
//             var mapperMock = new MapperConfiguration(opt =>
//             {
//                 opt.AddProfile(new MappingProfile());
//             });
//
//             this.mapper = mapperMock.CreateMapper();
//         }
//
//         [Test]
//         public async Task Create_ParametersPassed_ExpectedResults()
//         {
//             this.unitOfWorkMock.Setup(opt => opt.Car)
//                 .Returns(this.carRepositoryMock.Object);
//
//             var service = new CarService(this.unitOfWorkMock.Object, this.mapper);
//             await service.CreateAsync(this.CreateCarViewModelTest());
//
//             this.carRepositoryMock.Verify
//                 (opt => opt.CreateAsync(It.IsAny<Car>()), Times.Once);
//         }
//
//         [Test]
//         public void Create_NullParameters_ThrowException() 
//         {
//             this.unitOfWorkMock.Setup(opt => opt.Car)
//                 .Returns(this.carRepositoryMock.Object);
//
//             var service = new CarService(this.unitOfWorkMock.Object, this.mapper);
//
//             service.Invoking(opt => opt.CreateAsync(null))
//                    .Should()
//                    .Throw<Exception>()
//                    .WithMessage("There was no Car object to create.");
//         }
//
//         [Test]
//         public async Task GetAllAsync_ParametersPassed_ExpectedResults()
//         {
//             unitOfWorkMock.Setup
//                 (rep => rep.Car.GetAllAsync()).Returns(this.GetCarsAsyncTest());
//             var service = new CarService(unitOfWorkMock.Object, this.mapper);
//
//             var result = await service.GetAllAsync();
//
//             result.Should().BeOfType<GetAllCarViewModel>();
//             result.Should().NotBeNull();
//             result.Cars.Should().HaveCount(1);
//
//             foreach (var car in result.Cars)
//             {
//                 car.Id.Should().Be(1);
//                 car.Brand.Should().Be("Tesla");
//                 car.Name.Should().Be("X");
//                 car.State.Should().Be(CarStateEnumView.New);
//             }
//         }
//
//         [Test]
//         public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
//         {
//             unitOfWorkMock.Setup
//                 (rep => rep.Car.GetById(It.IsAny<int>())).Returns(this.GetByIdAsyncTest());
//
//             var service = new CarService(unitOfWorkMock.Object, this.mapper);
//
//             var result = await service.GetByIdAsync(It.IsAny<int>()); 
//
//             result.Should().BeOfType<GetByIdCarViewModel>();
//             result.Should().NotBeNull();
//             result.Should().BeEquivalentTo(new GetByIdCarViewModel { Id = 1, Name = "X", Brand = "Tesla", State = CarStateEnumView.New });
//             result.Id.Should().Be(1);
//             result.Brand.Should().Be("Tesla");
//             result.Name.Should().Be("X");
//             result.State.Should().Be(CarStateEnumView.New);
//         }
//
//         [Test]
//         public void GetByIdAsync_NullParameters_ThrowException()
//         {
//             unitOfWorkMock.Setup
//                 (rep => rep.Car.GetById(It.IsAny<int>()));
//
//             var service = new CarService(unitOfWorkMock.Object, this.mapper);
//
//             service.Invoking(opt => opt.GetByIdAsync(It.IsAny<int>()))
//                    .Should()
//                    .Throw<Exception>()
//                    .WithMessage("Car not found.");
//         }
//
//         [Test]
//         public void Delete_NullParameters_ThrowException()
//         {
//             unitOfWorkMock.Setup
//                 (rep => rep.Car.Remove(null)).Verifiable();
//
//             var service = new CarService(unitOfWorkMock.Object, this.mapper);
//
//             service.Invoking(opt => opt.RemoveAsync(It.IsAny<int>()))
//                   .Should()
//                   .Throw<Exception>()
//                   .WithMessage("Car not found.");
//         }
//
//         [Test]
//         public void Update_NullParameters_ThrowException()
//         {
//             unitOfWorkMock.Setup
//                 (rep => rep.Car.Update(this.UpdateCarTest())).Verifiable();
//
//             var service = new CarService(unitOfWorkMock.Object, this.mapper);
//
//             service.Invoking(opt => opt.UpdateAsync(null))
//                   .Should()
//                   .Throw<Exception>()
//                   .WithMessage("There was no Car object to update.");
//         }
//
//         [Test]
//         public void Update_InvalidParametersPassed_ThrowException() 
//         {
//             unitOfWorkMock.Setup
//                 (rep => rep.Car.Update(this.UpdateCarTest())).Verifiable();
//
//             var service = new CarService(unitOfWorkMock.Object, this.mapper);
//
//             service.Invoking(opt => opt.UpdateAsync(this.UpdateCarViewModelTest()))
//                    .Should()
//                    .Throw<Exception>()
//                    .WithMessage("Car not found.");
//         }
//
//         #region GetAll
//         private Task<ICollection<Car>> GetCarsAsyncTest()
//         {
//             var cars = new List<Car>
//             {
//                 new Car { Brand = "Tesla", Name = "X", State = CarState.New }
//             };
//             return Task.FromResult<ICollection<Car>>(cars);
//         }
//         #endregion
//
//         #region Create
//         private CreateCarViewModel CreateCarViewModelTest()
//         {
//             return new CreateCarViewModel { Brand = "Tesla", Name = "X", State = CarStateEnumView.New, SellerId = 1 };
//         }
//         #endregion
//
//         #region GetById
//         private Task<Car> GetByIdAsyncTest()
//         {
//             var car = new Car { Id = 1, Name = "X", Brand = "Tesla", State = CarState.New };
//             return Task.FromResult<Car>(car);
//         }
//         #endregion
//
//         #region Delete
//         private Car DeleteTest()
//         {
//             return new Car { Id = 1, Name = "X", Brand = "Tesla", State = CarState.New };
//         }
//         #endregion
//
//         #region Update
//         private Car UpdateCarTest()
//         {
//             return new Car { Id = 1, Name = "X", Brand = "Tesla", State = CarState.New };
//         }
//
//         private UpdateCarViewModel UpdateCarViewModelTest()
//         {
//             return new UpdateCarViewModel { Brand = "Tesla", Name = "X", State = CarStateEnumView.New };
//         }
//         #endregion
//     }
// }