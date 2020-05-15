using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    class CompanyViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateCompanyViewModel()
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            companyViewModel.Code = "Code";
            companyViewModel.Name = "Name";
            companyViewModel.Website = "Website";
            companyViewModel.Industry = "Industry";
            companyViewModel.PhoneNumber = "PhoneNumber";
            companyViewModel.City = "City";
            companyViewModel.Information = "Information";
            Assert.Equal("Code", companyViewModel.Code);
            Assert.Equal("Name", companyViewModel.Name);
            Assert.Equal("Industry", companyViewModel.Industry);
            Assert.Equal("PhoneNumber", companyViewModel.PhoneNumber);
            Assert.Equal("City", companyViewModel.City);
            Assert.Equal("Information", companyViewModel.Information);


        }

        [Fact]
        public void Validate_Success()
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            companyViewModel.Name = "";

            var defaultValidationResult = companyViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
