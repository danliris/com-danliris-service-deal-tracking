using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils
{
    public class DealLDataUtil : BaseDataUtil<DealFacade, Deal>
    {
        public DealLDataUtil(DealFacade facade) : base(facade)
        {

        }

       
        public override async Task<Deal> GetNewData()
        {
            return new Deal()
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
                LastModifiedBy ="",
                LastModifiedAgent = "",
                UId = "1",
                Description = "Description",
                Reason = "Reason",
                StageId = 1,
                Stage =new Stage()
                {
                    Active = true,
                    Name = "Name",
                    DealsOrder = "DealsOrder",
                    BoardId =1,
                    Code = "Code",
                    UId = "1",
                    Board = new Board()
                    {
                        Active =true,
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
        }
    }
}
