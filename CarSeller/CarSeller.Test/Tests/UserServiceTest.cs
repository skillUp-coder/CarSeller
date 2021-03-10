using AutoMapper;
using CarSeller.BusinessLogic.Services;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.Test.Tests
{
    public class UserServiceTest
    {
        Mock<IUnitOfWork> mock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new Mock<IMapper>();

        [Test]
        public async Task GetAllReturns()
        {
            //mock.Setup(rep => rep.User.GetAllAsync()).Returns(GetUserTest());
            //var service = new UserService(mock.Object, mapperMock.Object);

            //var result = service.GetAllAsync();

            //var typeResult = Assert.IsType<Task<ICollection<UserInfoViewModel>>>(result);
            //var modelResult = Assert.IsAssignableFrom<Task<ICollection<UserInfoViewModel>>>(typeResult);

        }

        private async Task<ICollection<User>> GetUserTest()
        {
            var purchases = new List<User>
            {
                new User {  Id = "83bcac58-f6fa-490b-b996-8680f6baecbe", UserName = "Elon"  }
            };
            return purchases;
        }
    }
}
