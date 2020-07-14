using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Lib.Utilities;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.Services
{
   public class ValidateServiceTest
    {
        [Fact]
        public void Should_Success_Instantiate()
        {
            Mock<IServiceProvider> serviceProviderMock = new Mock<IServiceProvider>();
            ValidateService service = new ValidateService(serviceProviderMock.Object);
            StageViewModel stage = new StageViewModel();
            Assert.Throws<ServiceValidationException>(() => service.Validate(stage));
           
        }
    }
}
