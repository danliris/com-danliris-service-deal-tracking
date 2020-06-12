using Com.DanLiris.Service.DealTracking.Lib.ViewModels.Integration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels.Integration
{
    public class CurrencyViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateCurrencyViewModel()
        {
            CurrencyViewModel viewModel = new CurrencyViewModel();
            viewModel.Id = 1;
            viewModel.Code = "Code";
            viewModel.Symbol = "Symbol";
            Assert.Equal(1, viewModel.Id);
            Assert.Equal("Code", viewModel.Code);
            Assert.Equal("Symbol", viewModel.Symbol);

        }
    }
}
