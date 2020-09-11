using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Interfaces;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.Test.WebApi.Utilities;
using Com.DanLiris.Service.DealTracking.WebApi.Controllers.v1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.DanLiris.Service.DealTracking.Test.WebApi.Controllers.v1
{

    public   class DealControllerTest : BaseControllerTest<DealController, Deal, DealViewModel, IDealFacade>
    {
    }
}
