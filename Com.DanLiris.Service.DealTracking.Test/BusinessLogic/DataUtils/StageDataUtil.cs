using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils
{
   public class StageDataUtil : BaseDataUtil<StageFacade, Stage>
    {
        public StageDataUtil(StageFacade facade) : base(facade)
        {

        }

        public override async Task<Stage> GetNewData()
        {
            return new Stage()
            {
                Code = "Code",
                Name = "Name",
                DealsOrder = "DealsOrder",
                BoardId =1,
                Board = new Board()
                {
                    Active = true,
                    Code = "Code",
                    CreatedAgent = "CreatedAgent",
                    CreatedBy = "someone",
                    CreatedUtc = DateTime.Now,
                    CurrencyCode ="Rp",
                    CurrencySymbol ="Rp",
                    CurrencyId =1,
                    DeletedAgent ="",
                    DeletedBy ="",
                    IsDeleted=false,
                    Title ="Title",
                    UId ="Uid",
                },
                Deals = new List<Deal>()
                {
                    new Deal()
                    {
                        Active =true,
                        Amount =1,
                        CloseDate =DateTimeOffset.Now,
                        Code ="Code",
                        CompanyCode ="CompanyCode",
                        CompanyName ="CompanyName",
                        ContactCode ="ContactCode",
                        ContactName = "ContactName",
                        Name ="Name",
                        Description ="Description",
                        Quantity =1,
                        CompanyId=1,
                        ContactId=1,
                        Reason="Reason",
                    }
                }
            };

        }
    }
}
