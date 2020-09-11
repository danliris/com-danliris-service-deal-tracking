using Com.DanLiris.Service.DealTracking.Lib;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Implementation;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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


        [Fact]
        public  async Task Create_Throws_DbUpdateConcurrencyException()
        {
            var dbContext = DbContext(GetCurrentAsyncMethod());
           
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };

            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new Mock<DealLogic>(serviceProviderMock.Object, dbContext);
            var readOnlyList = new Mock<IReadOnlyList<IUpdateEntry>>();
            readOnlyList.Setup(s => s.Count).Returns(1);

            DbUpdateConcurrencyException exception = new DbUpdateConcurrencyException("message", readOnlyList.Object);

            dealLogic.Setup(s => s.Create(It.IsAny<Deal>())).Throws(exception);

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic.Object);

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

            DealFacade facade = new DealFacade(serviceProviderMock.Object, dbContext);
          
            Deal model = new Deal();

            await Assert.ThrowsAsync<System.Exception>(() => facade.Create(model));
           
        }


        [Fact]
        public async Task Create_Throws_Exception()
        {
            var dbContext = DbContext(GetCurrentAsyncMethod());
           
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };

            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new Mock<DealLogic>(serviceProviderMock.Object, dbContext);
            
            dealLogic.Setup(s => s.Create(It.IsAny<Deal>())).Throws(new Exception());

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic.Object);

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

            DealFacade facade = new DealFacade(serviceProviderMock.Object, dbContext);

            Deal model = new Deal();

            await Assert.ThrowsAsync<System.Exception>(() => facade.Create(model));

        }


        [Fact]
        public async Task Create_MoveActivit_When_TypeOrdery_Return_Success()
        {
            var dbContext = DbContext(GetCurrentAsyncMethod());
            Deal deal = new Deal()
            {
                Code = "Code",
                Name = "Name",
                Amount = 1,
                UomUnit = "1",
                Quantity = 1,
                CompanyId = 1,
                CompanyCode = "CompanyCode",
                CompanyName = "CompanyName",
                ContactId = 1,
                ContactCode = "ContactCode",
                ContactName = "ContactName",
                CloseDate = DateTimeOffset.Now,
                CreatedAgent = "CreatedAgent",
                CreatedUtc = DateTime.Now,
                CreatedBy = "someone",
                LastModifiedBy = "",
                LastModifiedAgent = "",
                UId = "1",
                Description = "Description",
                Reason = "Reason",
                StageId = 1,
                Stage = new Stage()
                {
                    Active = true,
                    Name = "Name",
                    DealsOrder = "DealsOrder",
                    BoardId = 1,
                    Code = "Code",
                    UId = "1",
                    Board = new Board()
                    {
                        Active = true,
                        Code = "Code",

                        Title = "Title",
                        CurrencyId = 1,
                        CurrencyCode = "Rupiah",
                        CurrencySymbol = "Rp",

                    },
                    Deals = new List<Deal>()
                    {

                        new Deal()
                        {
                            Code ="Code",
                            Active =true,
                            Name="Name",
                            Stage = new Stage()
                            {
                                Active = true
                            }
                        }
                    }
                }
            };
            dbContext.DealTrackingDeals.Add(deal);
            dbContext.SaveChanges();
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };

            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new Mock<DealLogic>(serviceProviderMock.Object, dbContext);

            

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic.Object);

            var activityLogic = new ActivityLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
               .Setup(x => x.GetService(typeof(ActivityLogic)))
               .Returns(activityLogic);


            var stageLogic = new Mock<StageLogic>(serviceProviderMock.Object, dbContext);
            stageLogic.Setup(s => s.UpdateDealsOrder(It.IsAny<long>(), It.IsAny<string>())).Verifiable();

            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageLogic)))
               .Returns(stageLogic.Object);

            var stageFacade = new StageFacade(serviceProviderMock.Object, dbContext);

           
            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageFacade)))
               .Returns(stageFacade);

            DealFacade facade = new DealFacade(serviceProviderMock.Object, dbContext);

            MoveActivityViewModel model = new MoveActivityViewModel()
            {
                Type= "Order"
            };


            var result =await facade.MoveActivity(model);
       
        }

        [Fact]
        public async Task Create_MoveActivit_When_TypeMove_Return_Success()
        {
            var dbContext = DbContext(GetCurrentAsyncMethod());
            Deal deal = new Deal()
            {
                Code = "Code",
                Name = "Name",
                Amount = 1,
                UomUnit = "1",
                Quantity = 1,
                CompanyId = 1,
                CompanyCode = "CompanyCode",
                CompanyName = "CompanyName",
                ContactId = 1,
                ContactCode = "ContactCode",
                ContactName = "ContactName",
                CloseDate = DateTimeOffset.Now,
                CreatedAgent = "CreatedAgent",
                CreatedUtc = DateTime.Now,
                CreatedBy = "someone",
                LastModifiedBy = "",
                LastModifiedAgent = "",
                UId = "1",
                Description = "Description",
                Reason = "Reason",
                StageId = 1,
                Stage = new Stage()
                {
                    Active = true,
                    Name = "Name",
                    DealsOrder = "DealsOrder",
                    BoardId = 1,
                    Code = "Code",
                    UId = "1",
                    Board = new Board()
                    {
                        Active = true,
                        Code = "Code",

                        Title = "Title",
                        CurrencyId = 1,
                        CurrencyCode = "Rupiah",
                        CurrencySymbol = "Rp",

                    },
                    Deals = new List<Deal>()
                    {

                        new Deal()
                        {
                            Code ="Code",
                            Active =true,
                            Name="Name",
                            Stage = new Stage()
                            {
                                Active = true
                            }
                        }
                    }
                }
            };
            dbContext.DealTrackingDeals.Add(deal);
            dbContext.SaveChanges();

            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };

            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new DealLogic(serviceProviderMock.Object, dbContext);
           // dealLogic.Setup(s => s.ReadById(It.IsAny<int>())).ReturnsAsync(new Deal() { Active = true });

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic);

            var activityLogic = new ActivityLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
               .Setup(x => x.GetService(typeof(ActivityLogic)))
               .Returns(activityLogic);


            var stageLogic = new Mock<StageLogic>(serviceProviderMock.Object, dbContext);
            stageLogic.Setup(s => s.UpdateDealsOrder(It.IsAny<long>(), It.IsAny<string>())).Verifiable();

            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageLogic)))
               .Returns(stageLogic.Object);

            var stageFacade = new StageFacade(serviceProviderMock.Object, dbContext);


            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageFacade)))
               .Returns(stageFacade);

            DealFacade facade = new DealFacade(serviceProviderMock.Object, dbContext);

            MoveActivityViewModel model = new MoveActivityViewModel()
            {
                Type = "Move",
                TargetStageId =1,
                DealId=1,
                SourceStageId =1,
                SourceStageName = "SourceStageName",
               
            };


            var result = await facade.MoveActivity(model);
            Assert.True(0 < result);

        }

        [Fact]
        public async Task MoveActivity_Throws_DbUpdateConcurrencyException()
        {
            var dbContext = DbContext(GetCurrentAsyncMethod());
            
            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };

            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new DealLogic(serviceProviderMock.Object, dbContext);
            // dealLogic.Setup(s => s.ReadById(It.IsAny<int>())).ReturnsAsync(new Deal() { Active = true });

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic);

            var activityLogic = new ActivityLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
               .Setup(x => x.GetService(typeof(ActivityLogic)))
               .Returns(activityLogic);

            var readOnlyList = new Mock<IReadOnlyList<IUpdateEntry>>();
            readOnlyList.Setup(s => s.Count).Returns(1);

            DbUpdateConcurrencyException exception = new DbUpdateConcurrencyException("message", readOnlyList.Object);

            var stageLogic = new Mock<StageLogic>(serviceProviderMock.Object, dbContext);
            stageLogic.Setup(s => s.UpdateDealsOrder(It.IsAny<long>(), It.IsAny<string>())).Throws(exception);

            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageLogic)))
               .Returns(stageLogic.Object);

            var stageFacade = new StageFacade(serviceProviderMock.Object, dbContext);


            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageFacade)))
               .Returns(stageFacade);

            DealFacade facade = new DealFacade(serviceProviderMock.Object, dbContext);

            MoveActivityViewModel model = new MoveActivityViewModel()
            {
                Type = "Move",
                TargetStageId = 1,
                DealId = 1,
                SourceStageId = 1,
                SourceStageName = "SourceStageName",

            };

            await Assert.ThrowsAsync<System.Exception>(() => facade.MoveActivity(model));
          
        }

        [Fact]
        public async Task MoveActivity_Throws_Exception()
        {
            var dbContext = DbContext(GetCurrentAsyncMethod());

            var serviceProviderMock = new Mock<IServiceProvider>();
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "TokenUnitTest" };

            serviceProviderMock
               .Setup(x => x.GetService(typeof(IdentityService)))
               .Returns(identityService);

            var dealLogic = new DealLogic(serviceProviderMock.Object, dbContext);
            // dealLogic.Setup(s => s.ReadById(It.IsAny<int>())).ReturnsAsync(new Deal() { Active = true });

            serviceProviderMock
                .Setup(x => x.GetService(typeof(DealLogic)))
                .Returns(dealLogic);

            var activityLogic = new ActivityLogic(serviceProviderMock.Object, dbContext);

            serviceProviderMock
               .Setup(x => x.GetService(typeof(ActivityLogic)))
               .Returns(activityLogic);

          
            var stageLogic = new Mock<StageLogic>(serviceProviderMock.Object, dbContext);
            stageLogic.Setup(s => s.UpdateDealsOrder(It.IsAny<long>(), It.IsAny<string>())).Throws(new Exception());

            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageLogic)))
               .Returns(stageLogic.Object);

            var stageFacade = new StageFacade(serviceProviderMock.Object, dbContext);


            serviceProviderMock
               .Setup(x => x.GetService(typeof(StageFacade)))
               .Returns(stageFacade);

            DealFacade facade = new DealFacade(serviceProviderMock.Object, dbContext);

            MoveActivityViewModel model = new MoveActivityViewModel()
            {
                Type = "Move",
                TargetStageId = 1,
                DealId = 1,
                SourceStageId = 1,
                SourceStageName = "SourceStageName",

            };

            await Assert.ThrowsAsync<System.Exception>(() => facade.MoveActivity(model));

        }


    }
}
