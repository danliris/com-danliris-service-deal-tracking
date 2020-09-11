using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.DanLiris.Service.DealTracking.WebApi.Utilities;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using AutoMapper;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Interfaces;

namespace Com.DanLiris.Service.DealTracking.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/deal-tracking-stages")]
    [Authorize]
    public class StageController : BaseController<Stage, StageViewModel, IStageFacade>
    {
        private readonly static string apiVersion = "1.0";
        public StageController(IMapper mapper, IIdentityService identityService, IValidateService validateService, IStageFacade stageFacade) : base(mapper, identityService, validateService, stageFacade, apiVersion)
        {
        }
    }
}