using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class MoveActivityViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateMoveActivityViewModel() {

            MoveActivityViewModel moveActivityViewModel = new MoveActivityViewModel();
            moveActivityViewModel.SourceStageId = 1;
            moveActivityViewModel.SourceDealsOrder = "SourceDealsOrder";
            moveActivityViewModel.SourceStageName = "SourceStageName";
            moveActivityViewModel.Type = "Type";
            moveActivityViewModel.TargetStageId = 1;
            moveActivityViewModel.TargetDealsOrder = "TargetDealsOrder";
            moveActivityViewModel.TargetStageName = "TargetStageName";
            moveActivityViewModel.DealId = 1;

            Assert.Equal(1, moveActivityViewModel.SourceStageId);
            Assert.Equal("SourceDealsOrder", moveActivityViewModel.SourceDealsOrder);
            Assert.Equal("SourceStageName", moveActivityViewModel.SourceStageName);
            Assert.Equal("Type", moveActivityViewModel.Type);
            Assert.Equal(1, moveActivityViewModel.TargetStageId);
            Assert.Equal("TargetDealsOrder", moveActivityViewModel.TargetDealsOrder);
            Assert.Equal("TargetStageName", moveActivityViewModel.TargetStageName);
            Assert.Equal(1, moveActivityViewModel.DealId);

        }

    }
}
