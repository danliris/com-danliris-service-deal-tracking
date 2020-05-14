using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Com.DanLiris.Service.DealTracking.WebApi.Utilities;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.ViewModels;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using AutoMapper;
using Com.DanLiris.Service.DealTracking.Lib.Services;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Interfaces;

namespace Com.DanLiris.Service.DealTracking.WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/companies")]
    [Authorize]
    public class CompanyController : BaseController<Company, CompanyViewModel, ICompanyFacade>
    {
        private readonly static string apiVersion = "1.0";
        private readonly IIdentityService Service;

        public CompanyController(IMapper mapper, IIdentityService identityService, IValidateService validateService, ICompanyFacade CompanyFacade) : base(mapper, identityService, validateService, CompanyFacade, apiVersion)
        {
            Service = identityService;
        }
    }
}