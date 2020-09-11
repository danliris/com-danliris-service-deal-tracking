using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils
{
    public class ContactDataUtil : BaseDataUtil<ContactFacade, Contact>
    {
        public ContactDataUtil(ContactFacade facade) : base(facade)
        {
        }

        public override async Task<Contact> GetNewData()
        {
            return new Contact()
            {
                Code = "Code",
                Name = "Name",
                Email = "someone@gmail.com",
                PhoneNumber = "0812999999",
                JobTitle = "JobTitle",
                Information = "Information",
                CompanyId = 1,
                Active =false,
                IsDeleted =false,
                Company = new Company()
                {

                    Code = "Code",
                    Name = "Name",
                    Website = "www.Website.com",
                    Industry = "Industry",
                    PhoneNumber = "0812999999",
                    City = "Solo",
                    Information = "Information",
                    Active =false,
                    IsDeleted =false
                }
                
            };
        }
    }


}
