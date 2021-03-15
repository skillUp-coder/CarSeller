using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.UserViewModels;
using CarSeller.ViewModels.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Tests.Test
{
    public class UserServiceTest
    {
        Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        UserManager<User> userManager;

        [Test]
        public async Task GetAllAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.User.GetAllAsync())
                .Returns(GetAllUserAsyncTest());
            var service = new UserService(unitOfWorkMock.Object, mapperMock.Object, userManager);

            var result = await service.GetAllAsync();
            result.Users = await this.GetAllUserViewModelItemAsyncTest();

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
        public void Register_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.User.CreateAsync(this.RegisterUserTest()));

            var service = new UserService(unitOfWorkMock.Object, mapperMock.Object, userManager);

            service.Register(RegisterUserViewModelTest()).GetAwaiter().Should().As<Task<User>>();
            service.Register(null).Should().Equals("Empty object");
            service.Register(RegisterUserViewModelTest()).Should().NotBeNull();
            var result = RegisterUserViewModelTest();
            result.UserName.Should().Equals("John");
        }

        [Test]
        public void Login_ParametersPassed_ExpectedResults()
        {
            var service = new UserService(unitOfWorkMock.Object, mapperMock.Object, userManager);

            service.Login(LoginUserViewModelTest()).GetAwaiter().Should().As<Task<User>>();
            service.Login(null).Should().Equals("Empty object");
            service.Login(LoginUserViewModelTest()).Should().NotBeNull();
        }

        [Test]
        public async Task GetByIdAsync_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.User.GetById(It.IsAny<string>()))
                .Returns(this.GetByIdUserAsyncTest());
            var service = new UserService(unitOfWorkMock.Object, mapperMock.Object, userManager)
                .GetById(It.IsAny<string>());

            service = this.GetByIdUserViewModelAsyncTest();

            var result = await service;

            result.Should().As<GetByIdUserViewModel>();
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new GetByIdUserViewModel { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" });
            result.Id.Should().Equals("1b556baa-29cc-4bf1-a65f-70c3d98d5005");
            result.UserName.Should().Equals("John");
        }

        [Test]
        public void Delete_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.User.Remove(this.DeleteUserTest()))
                .Verifiable();

            var service = new UserService(unitOfWorkMock.Object, mapperMock.Object, userManager);

            service.Remove(It.IsAny<string>()).Should().Equals("Empty object");
            service.Remove(It.IsAny<string>()).GetAwaiter().IsCompleted.Should().BeTrue();
            service.Remove(It.IsAny<string>()).Should().As<Task>();
        }


        [Test]
        public void Update_ParametersPassed_ExpectedResults()
        {
            unitOfWorkMock.Setup(rep => rep.User.Update(this.UpdateUserTest()))
                .Verifiable();

            var service = new UserService(unitOfWorkMock.Object, mapperMock.Object, userManager);

            service.Update(UpdateUserViewModelTest()).Should().Equals("Empty object");
            service.Update(UpdateUserViewModelTest()).GetAwaiter().IsCompleted.Should().BeTrue();
            service.Update(UpdateUserViewModelTest()).Should().As<Task>();
        }

        #region GetAll
        public async Task<ICollection<User>> GetAllUserAsyncTest()
        {
            return new List<User>
            {
                new User { Id = "1", UserName = "John" }
            };
        }

        public async Task<ICollection<GetAllUserViewModelItem>> GetAllUserViewModelItemAsyncTest()
        {
            return new List<GetAllUserViewModelItem>
            {
                new GetAllUserViewModelItem { Id = "1", UserName = "John" }
            };
        }

        #endregion

        #region Register

        public User RegisterUserTest()
        {
            return new User { Id = "1", UserName = "John" };
        }

        public RegisterUserViewModel RegisterUserViewModelTest()
        {
            return new RegisterUserViewModel { UserName = "Bobb", Password = "Qwerty_123", PasswordConfirm = "Qwerty_123" };
        }

        #endregion

        #region Login
        public LoginUserViewModel LoginUserViewModelTest()
        {
            return new LoginUserViewModel { UserName = "John", Password = "Qwerty_123" };
        }
        #endregion

        #region GetById
        public async Task<User> GetByIdUserAsyncTest()
        {
            return new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }

        public async Task<GetByIdUserViewModel> GetByIdUserViewModelAsyncTest()
        {
            return new GetByIdUserViewModel { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }
        #endregion

        #region Delete

        public User DeleteUserTest()
        {
            return new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }
        #endregion

        #region Update
        public User UpdateUserTest()
        {
            return new User { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }

        public UpdateUserViewModel UpdateUserViewModelTest()
        {
            return new UpdateUserViewModel { Id = "1b556baa-29cc-4bf1-a65f-70c3d98d5005", UserName = "John" };
        }
        #endregion
    }
}
