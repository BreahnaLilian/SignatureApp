using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Signature.WebAPI.Controllers;
using SignatureApplication.Users.ViewModels;
using SignatureCommon.Models.JsonResponseModels;

namespace WebAPI.UnitTests.UserTests
{
    public class UserControllerTests
    {
        private readonly IMediator _iMediator;
        private readonly UserController _userController;
        private readonly CancellationToken _cancellationToken;
        public UserControllerTests()
        {
            _iMediator = A.Fake<IMediator>();
            _userController = new UserController(_iMediator);
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]
        public async Task GetUsers_ListOfUsers_ReturnsCreateJsonOkListOfUsers()
        {
            //Arange - variables, classes, mocks

            //Act
            var result = await _userController.GetUsers(_cancellationToken);
            var objResult = result as JsonResult;
            var deserializedValue = objResult.Value as BaseJsonResponse;

            //Assert
            result.Should().BeOfType<JsonResult>();
            objResult.Value.Should().BeOfType<SingleJsonResponse<UsersViewModel>>();
            deserializedValue.Result.Should().Be(SignatureCommon.Enums.ExecutionResult.OK);

        }

        [Fact]
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]
        public async Task DetailsUser_RandomUser_ReturnsCreateJsonOkUser()
        {
            //Arange - variables, classes, mocks

            //Act
            var result = await _userController.DetailsUser(Guid.NewGuid(), _cancellationToken);
            var objResult = result as JsonResult;
            var deserializedValue = objResult.Value as BaseJsonResponse;

            //Assert
            result.Should().BeOfType<JsonResult>();
            objResult.Value.Should().BeOfType<SingleJsonResponse<DetailsUserViewModel>>();
            deserializedValue.Result.Should().Be(SignatureCommon.Enums.ExecutionResult.OK);
        }

        [Fact]
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]
        public async Task DetailsUser_NotExistingUser_ReturnsCreateJsonError()
        {
            //Arange - variables, classes, mocks

            //Act
            var result = await _userController.DetailsUser(Guid.Empty, _cancellationToken);
            var objResult = result as JsonResult;
            var deserializedValue = objResult.Value as BaseJsonResponse;

            //Assert
            result.Should().BeOfType<JsonResult>();
            deserializedValue.Result.Should().Be(SignatureCommon.Enums.ExecutionResult.ERROR);
        }

        [Fact]
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]
        public async Task CreateUser_NewUserData_ReturnsCreateJsonOk()
        {
            //Arange - variables, classes, mocks
            CreateUserViewModel createUserViewModel = new CreateUserViewModel()
            {
                Address = "Test Address",
                DateOfBirth = DateTime.Now,
                Email = "emailTest@emailTest.com",
                FirstName = "TestFirst",
                Gender = SignatureCommon.Enums.Gender._,
                IDNP = "1234567890123",
                LastName = "TestLast",
                PhoneNumber = "00000000",

            };
            //Act
            var result = await _userController.CreateUser(createUserViewModel, _cancellationToken);
            var objResult = result as JsonResult;
            var deserializedValue = objResult.Value as BaseJsonResponse;

            //Assert
            result.Should().BeOfType<JsonResult>();
            deserializedValue.Result.Should().Be(SignatureCommon.Enums.ExecutionResult.OK);
        }

        //[Fact]
        //public async Task CreateUser_Empty_ReturnsCreateJsonNotValid()
        //{
        //    //Arange
        //    CreateUserViewModel createUserViewModel = new CreateUserViewModel();

        //    //Act
        //    var result = await _userController.CreateUser(createUserViewModel, _cancellationToken);
        //    var objResult = result as JsonResult;
        //    var deserializedValue = objResult.Value as BaseJsonResponse;

        //    //Assert
        //    result.Should().BeOfType<JsonResult>();
        //    deserializedValue.Result.Should().Be(SignatureCommon.Enums.ExecutionResult.NOTVALID);
        //}

        //[Fact]
        //public async Task CreateUser_NotValidOneField_ReturnsCreateJsonNotValid()
        //{
        //    //Arange

        //    //Act

        //    //Assert
        //}

        //[Fact]
        //public async Task CreateUser_NotValidEmailField_ReturnsCreateJsonNotValid()
        //{
        //    //Arange

        //    //Act

        //    //Assert
        //}

        //[Fact]
        //public async Task CreateUser_NotValidPhoneNrField_ReturnsCreateJsonNotValid()
        //{
        //    //Arange

        //    //Act

        //    //Assert
        //}
    }
}
