using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils
{
    public class ReasonDataUtil : BaseDataUtil<ReasonFacade, Reason>
    {
        public ReasonDataUtil(ReasonFacade facade) : base(facade)
        {

        }
        public override async Task<Reason> GetNewData()
        {
            return new Reason()
            {
                Code ="Code",
                LoseReason = "LoseReason"
            };

        }
    }
}
