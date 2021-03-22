using AutoMapper;
using CarSeller.BusinessLogic.MapperProfiles;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class UserServiceTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private IMapper mapper;
        private IUserStore<User> userStoreMock;
        private Mock<UserManager<User>> userManagerMock;

        [SetUp]
        public void SetUp()
        {
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.userStoreMock = Mock.Of<IUserStore<User>>();
            this.userManagerMock = new Mock<UserManager<User>>
                (this.userStoreMock, null, null, null, null, null, null, null, null);

            var mapperMock = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new MappingProfile());
            });

            this.mapper = mapperMock.CreateMapper();
        }

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup
                (rep => rep.User.GetAllAsync()).Returns(this.GetAllUserAsyncTest());
            var service = new UserService(this.unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);

            var result = await service.GetAllAsync();

            result.Should().BeOfType<GetAllUserViewModel>();
            result.Should().NotBeNull();
            result.Users.Should().HaveCount(1);

            foreach (var car in result.Users)
            {
                car.UserName.Should().Equals("John");
                car.Id.Should().Equals("1b556baa-29cc-4bf1-a65f-70c3d98d5005");
            }
        }

        [Test]
        public void Register_NullParameters_ThrowException()
        {
            var service = new UserService(this.unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);

            service.Invoking(opt => opt.RegisterAsync(null))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("There was no User object to register.");
        }

        [Test]
        public void Login_ParametersPassed_ExpectedResults()
        {
            var service = new UserService(this.unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);

            service.Invoking(opt => opt.LoginAsync(null))
                   .Should()
                   .Throw<Exception>()
                   .WithMessage("There was no User object to login.");
        }

        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.User.GetById(It.IsAny<string>()))
                .Returns(this.GetByIdUserAsyncTest());
            var service = new UserService(this.unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);
            var result = await service.GetByIdAsync(It.IsAny<string>());

            result.Should().As<GetByIdUserViewModel>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetByIdUserViewModel { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" });
            result.Id.Should().Equals("1b556baa-29cc-4bf1-a65f-70c3d98d5005");
            result.UserName.Should().Equals("John");
        }

        [Test]
        public void Delete_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.User.Remove(this.DeleteUserTest())).Verifiable();

            var service = new UserService(unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);

            service.Invoking(opt => opt.RemoveAsync(null))
                  .Should()
                  .Throw<Exception>()
                  .WithMessage("User not found.");
        }

        [Test]
        public void Update_NullParameters_ThrowException()
        {
            unitOfWorkMock.Setup
                (rep => rep.User.Update(this.UpdateUserTest())).Verifiable();

            var service = new UserService(unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);

            service.Invoking(opt => opt.UpdateAsync(null))
                  .Should()
                  .Throw<NullReferenceException>()
                  .WithMessage("Object reference not set to an instance of an object.");
        }

        [Test]
        public void Update_InvalidParametersPassed_ThrowException() 
        {
            unitOfWorkMock.Setup
                (rep => rep.User.Update(this.UpdateUserTest())).Verifiable();

            var service = new UserService(unitOfWorkMock.Object, this.mapper, this.userManagerMock.Object);

            service.Invoking(opt => opt.UpdateAsync(this.UpdateUserViewModelTest()))
                  .Should()
                  .Throw<Exception>()
                  .WithMessage("There was no User object to update.");
        }

        #region GetAll
        private async Task<ICollection<User>> GetAllUserAsyncTest()
        {
            var users = new List<User>
            {
                new User { Id = "1", UserName = "John" }
            };
            return await Task.FromResult<ICollection<User>>(users);
        }
        #endregion

        #region GetById
        private async Task<User> GetByIdUserAsyncTest()
        {
            var user = new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
            return await Task.FromResult<User>(user);
        }
        #endregion

        #region Delete
        private User DeleteUserTest()
        {
            return new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }
        #endregion

        #region Update
        private User UpdateUserTest()
        {
            return new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }

        private UpdateUserViewModel UpdateUserViewModelTest()
        {
            return new UpdateUserViewModel { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }
        #endregion
    }
}
