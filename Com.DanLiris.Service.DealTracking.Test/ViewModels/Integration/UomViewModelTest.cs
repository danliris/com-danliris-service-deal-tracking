using Com.DanLiris.Service.DealTracking.Lib.ViewModels.Integration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels.Integration
{
    public class UomViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateCurrencyViewModel()
        {
            UomViewModel viewModel = new UomViewModel();
         
            viewModel.Unit = "Unit";
            Assert.Equal("Unit", viewModel.Unit);
           

        }
    }
}
