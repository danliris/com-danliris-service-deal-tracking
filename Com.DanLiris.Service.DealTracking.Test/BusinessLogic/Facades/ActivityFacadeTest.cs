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
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Facades
{
  public  class ActivityFacadeTest : BaseFacadeTest<DealTrackingDbContext, ActivityFacade, ActivityLogic, Activity, ActivityDataUtil>
    {
        private const string ENTITY = "DealTrackingActivities";
        public ActivityFacadeTest() : base(ENTITY)
        {

        }

        protected override Mock<IServiceProvider> GetServiceProviderMock(DealTrackingDbContext dbContext)
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };
            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var memoryStream = new Mock<MemoryStream>();
            var azureStorageServiceMock = new Mock<IAzureStorageService>();
            azureStorageServiceMock.Setup(s => s.DeleteImage(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(memoryStream));
            serviceProviderMock
                .Setup(x => x.GetService(typeof(IAzureStorageService)))
                .Returns(azureStorageServiceMock.Object);

            var activityLogic = new ActivityLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
                .Setup(x => x.GetService(typeof(ActivityLogic)))
                .Returns(activityLogic);

            
            

            return serviceProviderMock;
        }

        [Fact]
        public virtual async void CreateAttachment_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;
            ActivityFacade facade = new ActivityFacade(serviceProvider, dbContext);
            var data = await DataUtil(facade, dbContext).GetTestData();

            List<ActivityAttachment> attachments = new List<ActivityAttachment>()
            {
                new ActivityAttachment()
                {
                    FileName ="FileName",
                    FilePath ="FilePath"
                }
            };
            var response = await facade.CreateAttachment(1, attachments);
            Assert.NotEqual(response, 0);
        }

        [Fact]
        public virtual async void DeleteAttachment_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;
            ActivityFacade facade = new ActivityFacade(serviceProvider, dbContext);
            var data = await DataUtil(facade, dbContext).GetTestData();

            var response = await facade.DeleteAttachment(1);
            Assert.NotEqual(response, 0);
        }
    }
}
