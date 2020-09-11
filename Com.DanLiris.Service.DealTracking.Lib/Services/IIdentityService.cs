using System;
using System.Collections.Generic;
using System.Text;

namespace Com.DanLiris.Service.DealTracking.Lib.Services
{
  public  interface IIdentityService
    {
        string Username { get; set; }
        string Token { get; set; }
    }
}
