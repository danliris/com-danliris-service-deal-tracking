using Com.DanLiris.Service.DealTracking.Lib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
 public  class BaseViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateBaseViewModel()
        {

            BaseViewModel baseViewModel = new BaseViewModel();
            baseViewModel.Id = 1;
            baseViewModel.Active = true;
            baseViewModel.IsDeleted = false;

            var now = DateTime.Now;
            baseViewModel.CreatedUtc = now;
            baseViewModel.CreatedBy = "someone";
            baseViewModel.CreatedAgent = "CreatedAgent";
            baseViewModel.LastModifiedUtc = now;
            baseViewModel.LastModifiedBy = "someone";
            baseViewModel.LastModifiedAgent = "LastModifiedAgent";

            Assert.Equal(1, baseViewModel.Id);
            Assert.Equal(true, baseViewModel.Active);
            Assert.Equal(false, baseViewModel.IsDeleted);
           Assert.Equal(now, baseViewModel.CreatedUtc);
            Assert.Equal("someone", baseViewModel.CreatedBy);
            Assert.Equal("CreatedAgent", baseViewModel.CreatedAgent);
           Assert.Equal(now, baseViewModel.LastModifiedUtc);
            Assert.Equal("someone", baseViewModel.LastModifiedBy);
            Assert.Equal("LastModifiedAgent", baseViewModel.LastModifiedAgent);
        }
        }
}
