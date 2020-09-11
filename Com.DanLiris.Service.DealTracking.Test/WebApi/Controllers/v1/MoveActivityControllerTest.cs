using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Interfaces;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.WebApi.Controllers.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.WebApi.Controllers.v1
{
    
   public class MoveActivityControllerTest 
    {

        protected virtual MoveActivityController GetController(Mock<IDealFacade> facade)
        {
            var user = new Mock<ClaimsPrincipal>();
            var claims = new Claim[]
            {
                new Claim("username", "unittestusername")
            };
            user.Setup(u => u.Claims).Returns(claims);



            //serviceProvider
            //   .Setup(s => s.GetService(typeof(IIdentityService)))
            //   .Returns(new IdentityService() { TimezoneOffset = 1, Token = "token", Username = "username" });
             
            var validateService = new Mock<IValidateService>();
            var identityService = new Mock<IIdentityService>();
            identityService.Setup(s => s.Username).Returns("usernametest");
            identityService.Setup(s => s.Token).Returns("Token");


            MoveActivityController controller =new  MoveActivityController(identityService.Object,validateService.Object,facade.Object);
            controller.ControllerContext = new ControllerContext()
            {

                HttpContext = new DefaultHttpContext()
                {
                    User = user.Object,

                }
            };
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer unittesttoken";
            controller.ControllerContext.HttpContext.Request.Path = new PathString("/v1/unit-test");

            return controller;
        }
        protected virtual int GetStatusCode(IActionResult response)
        {
            return (int)response.GetType().GetProperty("StatusCode").GetValue(response, null);
        }

        [Fact]
        public async Task Post_Return_OK()
        {
            MoveActivityViewModel viewModel = new MoveActivityViewModel();
            var facade = new Mock<IDealFacade>();
            facade.Setup(s => s.MoveActivity(It.IsAny<MoveActivityViewModel>())).ReturnsAsync(1);
            IActionResult response =await  GetController(facade).Put(viewModel);
           
            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.NoContent, statusCode);
        }


        [Fact]
        public async Task Post_Throws_DbUpdateConcurrencyException()
        {
            MoveActivityViewModel viewModel = new MoveActivityViewModel();
            var facade = new Mock<IDealFacade>();
         
            var readOnlyList = new Mock<IReadOnlyList<IUpdateEntry>>();
            readOnlyList.Setup(s => s.Count).Returns(1);
            //  IReadOnlyList<IUpdateEntry> 
            DbUpdateConcurrencyException e = new DbUpdateConcurrencyException("message", readOnlyList.Object);
            facade.Setup(s => s.MoveActivity(It.IsAny<MoveActivityViewModel>())).ThrowsAsync(e);
            IActionResult response = await GetController(facade).Put(viewModel);


            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

        [Fact]
        public async Task Post_Throws_BadRequest()
        {
            MoveActivityViewModel viewModel = new MoveActivityViewModel();
            var facade = new Mock<IDealFacade>();

            facade.Setup(s => s.MoveActivity(It.IsAny<MoveActivityViewModel>())).ReturnsAsync(1);

            var controller = GetController(facade);
            controller.ModelState.AddModelError("test", "test");
            IActionResult response = await controller.Put(viewModel);

            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.BadRequest, statusCode);
        }

        [Fact]
        public async Task Post_Throws_Exception()
        {
            MoveActivityViewModel viewModel = new MoveActivityViewModel();
            var facade = new Mock<IDealFacade>();
            
            facade.Setup(s => s.MoveActivity(It.IsAny<MoveActivityViewModel>())).ThrowsAsync(new Exception());
            IActionResult response = await GetController(facade).Put(viewModel);

            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }

    }
}
