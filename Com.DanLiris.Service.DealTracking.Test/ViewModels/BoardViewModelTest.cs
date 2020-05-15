using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class BoardViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateBoardViewModel()
        {
            BoardViewModel boardViewModel = new BoardViewModel();
            boardViewModel.Code = "Code";
            boardViewModel.Title = "Title";

            CurrencyViewModel currencyViewModel = new CurrencyViewModel()
            {
                Id = 1,
                Code = "Dollar",
                Symbol = "$"
            };
            boardViewModel.Currency = currencyViewModel;
            Assert.Equal("Code", boardViewModel.Code);
            Assert.Equal("Title", boardViewModel.Title);
            Assert.Equal(currencyViewModel, boardViewModel.Currency);
        }

        [Fact]
        public void Validate_Success()
        {
            BoardViewModel boardViewModel = new BoardViewModel();
            boardViewModel.Title = "";
            boardViewModel.Currency = null;

            var defaultValidationResult = boardViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }
    }
}
