using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class ContactViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateContactViewModel()
        {

            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.Code = "Code";
            contactViewModel.Name = "Name";
            contactViewModel.Email = "someone@gmail.com";
            contactViewModel.PhoneNumber = "082242424233";
            contactViewModel.JobTitle = "JobTitle";
            contactViewModel.Information = "Information";
            CompanyViewModel companyViewModel = new CompanyViewModel()
            {
                Active =true,
                Code ="Code",
                City ="solo"
            };

            contactViewModel.Company = companyViewModel;
            Assert.Equal("Code", contactViewModel.Code);
            Assert.Equal("Name", contactViewModel.Name);
            Assert.Equal("someone@gmail.com", contactViewModel.Email);
            Assert.Equal("082242424233", contactViewModel.PhoneNumber);
            Assert.Equal("JobTitle", contactViewModel.JobTitle);
            Assert.Equal("Information", contactViewModel.Information);
            Assert.Equal(companyViewModel, contactViewModel.Company);
        }

        [Fact]
        public void Validate_Success()
        {
            ContactViewModel contactViewModel = new ContactViewModel();
            contactViewModel.Name = "";

            var defaultValidationResult = contactViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
