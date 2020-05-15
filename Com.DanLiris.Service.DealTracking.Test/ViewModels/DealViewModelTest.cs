using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class DealViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateDealViewModel()
        {
            DealViewModel dealViewModel = new DealViewModel();
            dealViewModel.Amount = 1;
            dealViewModel.Name = "Name";
            dealViewModel.Quantity = 1;
            dealViewModel.Code = "Code";
            CompanyViewModel companyViewModel = new CompanyViewModel()
            {
                City = "Solo"
            };

            dealViewModel.Company = companyViewModel;

            ContactViewModel contactViewModel = new ContactViewModel()
            {
                Code = "Code"
            };

            dealViewModel.Contact = contactViewModel;

            UomViewModel uomViewModel = new UomViewModel()
            {
                Unit = "Unit",
            };
            dealViewModel.Uom = uomViewModel;
            var closeDate = DateTime.Now;
            dealViewModel.CloseDate = closeDate;
            dealViewModel.Description = "Description";
            dealViewModel.Reason = "Reason";
            dealViewModel.StageId = 1;

            Assert.Equal("Code", dealViewModel.Code);
            Assert.Equal("Name", dealViewModel.Name);
            Assert.Equal(1, dealViewModel.Amount);
            Assert.Equal(1, dealViewModel.Quantity);
            Assert.Equal(companyViewModel, dealViewModel.Company);
            Assert.Equal(contactViewModel, dealViewModel.Contact);
            Assert.Equal(closeDate, dealViewModel.CloseDate);
            Assert.Equal("Description", dealViewModel.Description);
            Assert.Equal("Reason", dealViewModel.Reason);
            Assert.Equal(1, dealViewModel.StageId);
        }

        [Fact]
        public void Validate_Success()
        {
            DealViewModel dealViewModel = new DealViewModel();
            dealViewModel.Name = "";
            dealViewModel.Quantity = 0;
            dealViewModel.Uom = null;
            dealViewModel.Amount = 0;
            

            var defaultValidationResult = dealViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
