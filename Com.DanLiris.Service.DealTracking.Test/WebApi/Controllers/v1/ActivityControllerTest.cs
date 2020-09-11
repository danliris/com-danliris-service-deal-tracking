using AutoMapper;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Interfaces;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.Test.WebApi.Utilities;
using Com.DanLiris.Service.DealTracking.WebApi.Controllers.v1;
using Com.DanLiris.Service.DealTracking.WebApi.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.WebApi.Controllers.v1
{
    public class ActivityControllerTest
    {

        protected virtual ActivityController GetController(Mock<IActivityFacade> facade,Mock<IAzureStorageService> azureStorageService)
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

            var mapper = new Mock<IMapper>();
            ActivityController controller = new ActivityController(mapper.Object,identityService.Object, validateService.Object, facade.Object, azureStorageService.Object);
            controller.ControllerContext = new ControllerContext()
            {
                
                HttpContext = new DefaultHttpContext()
                {
                    User = user.Object,
                    
                }
            };
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer unittesttoken";
            controller.ControllerContext.HttpContext.Request.Path = new PathString("/v1/unit-test");

            //Dictionary<string, StringValues> fields = new Dictionary<string, StringValues>();
            //fields.Add("key", "value");
            //FormCollection form = new FormCollection(fields);
            //controller.ControllerContext.HttpContext.Request.Form = form;
           

            return controller;
        }
        protected virtual int GetStatusCode(IActionResult response)
        {
            return (int)response.GetType().GetProperty("StatusCode").GetValue(response, null);
        }

        [Fact]
        public async Task GetFile_Return_Success()
        {
       
            var azureStorageService = new Mock<IAzureStorageService>();
            var memorystream = new MemoryStream();
            azureStorageService.Setup(s => s.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(memorystream);
            var facade = new Mock<IActivityFacade>();
            var  controller =  GetController(facade, azureStorageService);
            var response =await controller.GetFile("filename_filename2");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task UploadFile_WhenUpdate_isTrue_Return_NoContent()
        {

            var azureStorageService = new Mock<IAzureStorageService>();
            var memorystream = new MemoryStream();
            azureStorageService.Setup(s => s.GenerateFileName(It.IsAny<string>())).Returns("filename.jpg");

            azureStorageService.Setup(s => s.UploadFile(It.IsAny<MemoryStream>(),It.IsAny<string>(),It.IsAny<string>()));
            
            var facade = new Mock<IActivityFacade>();
            facade.Setup(s => s.ReadById(It.IsAny<long>())).ReturnsAsync(new Activity());
            var controller = GetController(facade, azureStorageService);

            var fileColection = new FormFileCollection();
            var IFormFileMock = new Mock<IFormFile>();
            fileColection.Add(IFormFileMock.Object);
           

            Dictionary<string, StringValues> fields = new Dictionary<string, StringValues>();
            fields.Add("update", "true");
            fields.Add("note", "note");
            FormCollection form = new FormCollection(fields, fileColection);
            controller.ControllerContext.HttpContext.Request.Form = form;


            var response = await controller.UploadFile();
            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.NoContent, statusCode);
        }

        [Fact]
        public async Task UploadFile_When_Update_IsFalse_Return_Create()
        {

            var azureStorageService = new Mock<IAzureStorageService>();
            var memorystream = new MemoryStream();
            azureStorageService.Setup(s => s.GenerateFileName(It.IsAny<string>())).Returns("filename.jpg");

            azureStorageService.Setup(s => s.UploadFile(It.IsAny<MemoryStream>(), It.IsAny<string>(), It.IsAny<string>()));

            var facade = new Mock<IActivityFacade>();
            facade.Setup(s => s.ReadById(It.IsAny<long>())).ReturnsAsync(new Activity());
            var controller = GetController(facade, azureStorageService);

            var fileColection = new FormFileCollection();
            var IFormFileMock = new Mock<IFormFile>();
            fileColection.Add(IFormFileMock.Object);


            Dictionary<string, StringValues> fields = new Dictionary<string, StringValues>();
            fields.Add("update", "false");
            fields.Add("note", "note");
            FormCollection form = new FormCollection(fields, fileColection);
            controller.ControllerContext.HttpContext.Request.Form = form;


            var response = await controller.UploadFile();
            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.Created, statusCode);
        }

        [Fact]
        public async Task UploadFile_Throws_InternalServerError()
        {

            var azureStorageService = new Mock<IAzureStorageService>();
            var memorystream = new MemoryStream();
            azureStorageService.Setup(s => s.GenerateFileName(It.IsAny<string>())).Throws(new Exception());
            azureStorageService.Setup(s => s.UploadFile(It.IsAny<MemoryStream>(), It.IsAny<string>(), It.IsAny<string>()));

            var facade = new Mock<IActivityFacade>();
            var controller = GetController(facade, azureStorageService);

            var fileColection = new FormFileCollection();
            var IFormFileMock = new Mock<IFormFile>();
            fileColection.Add(IFormFileMock.Object);

            Dictionary<string, StringValues> fields = new Dictionary<string, StringValues>();
            fields.Add("key", "value");

            FormCollection form = new FormCollection(fields, fileColection);
            controller.ControllerContext.HttpContext.Request.Form = form;
         
            var response = await controller.UploadFile();
            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.InternalServerError, statusCode);
        }



        [Fact]
        public async Task GetFile_with_activityAttachment_Return_Success()
        {

            var azureStorageService = new Mock<IAzureStorageService>();
            var memorystream = new MemoryStream();
            azureStorageService.Setup(s => s.DeleteImage(It.IsAny<string>(), It.IsAny<string>()));
            var facade = new Mock<IActivityFacade>();
            var controller = GetController(facade, azureStorageService);

            ActivityAttachmentViewModel activityAttachment = new ActivityAttachmentViewModel();
            var response = await controller.GetFile(activityAttachment);
            int statusCode = this.GetStatusCode(response);
            Assert.Equal((int)HttpStatusCode.NoContent, statusCode);
        }
    }
}
