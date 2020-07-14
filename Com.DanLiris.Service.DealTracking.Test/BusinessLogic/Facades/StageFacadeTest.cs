using Com.DanLiris.Service.DealTracking.Lib;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Implementation;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Facades
{
  
    public class StageFacadeTest : BaseFacadeTest<DealTrackingDbContext, StageFacade, StageLogic, Stage, StageDataUtil>
    {
        private const string ENTITY = "DealTrackingStages";
        public StageFacadeTest():base(ENTITY)
        {

        }

        protected override Mock<IServiceProvider> GetServiceProviderMock(DealTrackingDbContext dbContext)
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };
            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var stageLogic = new StageLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
                .Setup(x => x.GetService(typeof(StageLogic)))
                .Returns(stageLogic);



            return serviceProviderMock;
        }

        [Fact]
        public void Should_Success_UpdateDealsOrder()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };
            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dbContext = DbContext(GetCurrentMethod());
            Stage stage = new Stage()
            {
                Code = "Code",
                CreatedBy ="Mehmet"
            };
            dbContext.DealTrackingStages.Add(stage);
            dbContext.SaveChanges();
            var stageLogic = new StageLogic(serviceProviderMock.Object, dbContext);
            
            stageLogic.UpdateDealsOrder(1, "DealsOrders");


        }

        [Fact]
        public void Should_Success_UpdateDealsOrderCreate_When_DealsOrder_isNull()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };
            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dbContext = DbContext(GetCurrentMethod());
            Stage stage = new Stage()
            {
                Code = "Code",
                CreatedBy = "Mehmet",
                DealsOrder = null
            };
            dbContext.DealTrackingStages.Add(stage);
            dbContext.SaveChanges();
            var stageLogic = new StageLogic(serviceProviderMock.Object, dbContext);

            stageLogic.UpdateDealsOrderCreate(1,1);


        }
    }
}
