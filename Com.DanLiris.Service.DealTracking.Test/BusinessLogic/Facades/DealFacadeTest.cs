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
    public class DealFacadeTest : BaseFacadeTest<DealTrackingDbContext, DealFacade, DealLogic, Deal, DealLDataUtil>
    {
        private const string ENTITY = "DealTrackingDeals";
        public DealFacadeTest() : base(ENTITY)
        {
        }

        protected override Mock<IServiceProvider> GetServiceProviderMock(DealTrackingDbContext dbContext)
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };
            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new DealLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic);

            var activityLogic = new ActivityLogic(serviceProviderMock.Object, dbContext);
            serviceProviderMock
               .Setup(x => x.GetService(typeof(ActivityLogic)))
               .Returns(activityLogic);


            var stageLogic = new StageLogic(serviceProviderMock.Object, dbContext);
            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageLogic)))
               .Returns(stageLogic);

            var stageFacade = new StageFacade(serviceProviderMock.Object, dbContext);
            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageFacade)))
               .Returns(stageFacade);

            return serviceProviderMock;
        }


       
    }
}
