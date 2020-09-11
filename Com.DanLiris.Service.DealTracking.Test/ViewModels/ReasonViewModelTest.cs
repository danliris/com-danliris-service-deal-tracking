using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
   public class ReasonViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateReasonViewModel()
        {
            ReasonViewModel reasonViewModel = new ReasonViewModel();
            reasonViewModel.Code = "Code";
            reasonViewModel.LoseReason = "LoseReason";

            Assert.Equal("Code", reasonViewModel.Code);
            Assert.Equal("LoseReason", reasonViewModel.LoseReason);


        }

        [Fact]
        public void Validate_Success()
        {
            ReasonViewModel reasonViewModel = new ReasonViewModel();
            reasonViewModel.LoseReason = "";


            var defaultValidationResult = reasonViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
