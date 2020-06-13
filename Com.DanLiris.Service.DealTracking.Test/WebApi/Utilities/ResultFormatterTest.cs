using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.Utilities;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.WebApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.WebApi.Utilities
{
    public class ResultFormatterTest
    {
        [Fact]
        public void Should_Success_OK()
        {
            string ApiVersion = "V1";
            int StatusCode = 200;
            string Message = "OK";
            ResultFormatter formatter = new ResultFormatter(ApiVersion, StatusCode, Message);
           
            MoveActivityViewModel data = new MoveActivityViewModel();

            var result = formatter.Ok(data);
            Assert.NotNull(result);
        }



        [Fact]
        public void Should_Success_OK_with_Order()
        {
            string ApiVersion = "V1";
            int StatusCode = 200;
            string Message = "OK";
            ResultFormatter formatter = new ResultFormatter(ApiVersion, StatusCode, Message);

            Dictionary<string, string> Order = new Dictionary<string, string>();
            Order.Add("Type", "asc");

            List<string> Select = new List<string>()
            {
                "Type"
            };

            List<MoveActivityViewModel> data = new List<MoveActivityViewModel>()
            {
                new MoveActivityViewModel()
            };
           
            var result = formatter.Ok(data,1,1,1,1,Order,Select,"username");
            Assert.NotNull(result);
        }

        [Fact]
        public void Fail_Return_Success()
        {
            string ApiVersion = "V1";
            int StatusCode = 200;
            string Message = "OK";
            ResultFormatter formatter = new ResultFormatter(ApiVersion, StatusCode, Message);

            var result = formatter.Fail("test");
            Assert.NotNull(result);
        }

        [Fact]
        public void Fail_Throws_ServiceValidationException()
        {
            string ApiVersion = "V1";
            int StatusCode = 200;
            string Message = "OK";
            ResultFormatter formatter = new ResultFormatter(ApiVersion, StatusCode, Message);

            Reason reason = new Reason();
            
            //Create object
            var data = new
            {
                key ="value",
            };

            string memberName = JsonConvert.SerializeObject(data);
            ValidationContext validationContext = new ValidationContext(reason);
            var validationResult = new ValidationResult("FirstName cannot be null", new string[] { memberName });
            
            var validationResults = new List<ValidationResult>()
            {
                validationResult
            };
            ServiceValidationException exception = new ServiceValidationException(validationContext, validationResults);

            

            var result = formatter.Fail(exception);
            Assert.NotNull(result);
        }
    }
}
