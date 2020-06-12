using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
    public class ActivityAttachmentViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateActivityViewModel()
        {
            ActivityAttachmentViewModel viewModel = new ActivityAttachmentViewModel();
            viewModel.Id = 1;
            viewModel.FileName = "FileName";
            viewModel.FilePath = "FilePath";
            Assert.Equal(1, viewModel.Id);
            Assert.Equal("FileName", viewModel.FileName);
            Assert.Equal("FilePath", viewModel.FilePath);
            
        }
        }
}
