using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.ViewModels
{
   public class ActivityViewModelTest
    {
        [Fact]
        public void ShouldSuccesIntantiateActivityViewModel()
        {
            ActivityViewModel activityViewModel = new ActivityViewModel();
            activityViewModel.AssignedTo = "AssignedTo";
            activityViewModel.Code = "Code";
            activityViewModel.DealCode = "DealCode";
            activityViewModel.DealId = 1;
            activityViewModel.DealName = "DealName";
            activityViewModel.Notes = "Notes";
            activityViewModel.Type = "TASK";

            //Task
            var dueDate = DateTime.Now;
            activityViewModel.Status = true;
            activityViewModel.TaskTitle = "TaskTitle";
            activityViewModel.AssignedTo = "AssignedTo";
            activityViewModel.DueDate = dueDate;
            activityViewModel.DueDate = dueDate;
            //Note
            var attachments = new List<ActivityAttachmentViewModel>()
            {
                new ActivityAttachmentViewModel()
                {
                    Id =1,
                    FileName ="FileName",
                    FilePath ="FilePath"
                }
            };
            activityViewModel.Attachments = attachments;

            //Move
            activityViewModel.StageFromId = 1;
            activityViewModel.StageFromName = "StageFromName";
            activityViewModel.StageToId = 1;
            activityViewModel.StageToName = "StageToName";

            Assert.Equal("AssignedTo", activityViewModel.AssignedTo);
            Assert.Equal("Code", activityViewModel.Code);
            Assert.Equal("DealCode", activityViewModel.DealCode);
            Assert.Equal(1, activityViewModel.DealId);
            Assert.Equal("TASK", activityViewModel.Type);
            Assert.Equal("DealName", activityViewModel.DealName);
            Assert.Equal("Notes", activityViewModel.Notes);
            Assert.Equal(true, activityViewModel.Status);
            Assert.Equal("TaskTitle", activityViewModel.TaskTitle);
            Assert.Equal("AssignedTo", activityViewModel.AssignedTo);
            Assert.Equal(dueDate, activityViewModel.DueDate);
            Assert.Equal(attachments, activityViewModel.Attachments);
            Assert.Equal(1, activityViewModel.StageFromId);
            Assert.Equal("StageFromName", activityViewModel.StageFromName);
            Assert.Equal(1, activityViewModel.StageToId);
            Assert.Equal("StageToName", activityViewModel.StageToName);

        }

        [Fact]
        public void Validate_Success_When_Type_is_Task()
        {
            ActivityViewModel activityViewModel = new ActivityViewModel();
            activityViewModel.Type = "TASK";
            var defaultValidationResult = activityViewModel.Validate(null);
            Assert.True(defaultValidationResult.Count() > 0);
        }

    }
}
