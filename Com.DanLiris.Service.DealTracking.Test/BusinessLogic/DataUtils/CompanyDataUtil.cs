using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils
{
  public  class CompanyDataUtil : BaseDataUtil<CompanyFacade, Company>
    {
        public CompanyDataUtil(CompanyFacade facade) : base(facade)
        {
        }
        public override async Task<Company> GetNewData()
        {
            return new Company()
            {
                Code = "Code",
                Name = "Name",
                Website = "www.Website.com",
                Industry = "Industry",
                PhoneNumber = "0812999999",
                City = "Solo",
                Information = "Information"
            };
        }
    }
}
