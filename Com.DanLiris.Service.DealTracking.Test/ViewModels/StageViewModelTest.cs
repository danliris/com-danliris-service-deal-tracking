using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class StageViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateStageViewModel()
        {
            StageViewModel stageViewModel = new StageViewModel();
            stageViewModel.Code = "Code";
            stageViewModel.Name = "Name";
            stageViewModel.BoardId =1;
            stageViewModel.DealsOrder = "DealsOrder";
            var deals= new List<StageDealViewModel>()
            {
                new StageDealViewModel()
                {
                    Code ="Code"
                }
            };
            stageViewModel.Deals = deals;

            Assert.Equal("Code", stageViewModel.Code);
            Assert.Equal("Name", stageViewModel.Name);
            Assert.Equal(1, stageViewModel.BoardId);
            Assert.Equal("DealsOrder", stageViewModel.DealsOrder);
            Assert.Equal(deals, stageViewModel.Deals);

        }

        [Fact]
        public void Validate_Success()
        {
            StageViewModel stageViewModel = new StageViewModel();
            stageViewModel.Name = "";


            var defaultValidationResult = stageViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

    }
}
