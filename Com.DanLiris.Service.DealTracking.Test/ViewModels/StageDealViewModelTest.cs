using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class StageDealViewModelTest
    {

        [Fact]
        public void ShouldSuccesIntantiateStageDealViewModel()
        {
            StageDealViewModel stageDealViewModel = new StageDealViewModel();
            stageDealViewModel.Id = 1;
            stageDealViewModel.CreatedBy = "someone";
            stageDealViewModel.Code = "Code";
            stageDealViewModel.Name = "Name";
            stageDealViewModel.Amount = 1;
            stageDealViewModel.Quantity = 1;
            stageDealViewModel.CompanyName = "CompanyName";
            stageDealViewModel.UomUnit = "UomUnit";
            var closeDate = DateTime.Now;
            stageDealViewModel.CloseDate = closeDate;
            stageDealViewModel.ContactName = "ContactName";
            stageDealViewModel.StageId = 1;

            Assert.Equal(1, stageDealViewModel.Id);
            Assert.Equal("someone", stageDealViewModel.CreatedBy);
            Assert.Equal("Code", stageDealViewModel.Code);
            Assert.Equal("Name", stageDealViewModel.Name);
            Assert.Equal("CompanyName", stageDealViewModel.CompanyName);
            Assert.Equal("ContactName", stageDealViewModel.ContactName);
            Assert.Equal(1, stageDealViewModel.Amount);
            Assert.Equal(1, stageDealViewModel.Quantity);
            Assert.Equal("UomUnit", stageDealViewModel.UomUnit);
            Assert.Equal(closeDate, stageDealViewModel.CloseDate);
            Assert.Equal(1, stageDealViewModel.StageId);

        }
    }
}
