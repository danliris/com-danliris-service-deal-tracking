using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Facades;
using Com.DanLiris.Service.DealTracking.Lib.BusinessLogic.Interfaces;
using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Test.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test.BusinessLogic.DataUtils
{
    public class BoardDataUtil : BaseDataUtil<BoardFacade, Board>
    {
        public BoardDataUtil(BoardFacade facade) : base(facade)
        {
        }
        public override async Task<Board> GetNewData()
        {
            return new Board()
            {
                Code = "Code",
                Title ="Title",
                CurrencyId =1,
                CurrencyCode ="Rupiah",
                CurrencySymbol = "Rp",

            };
        }
    }
}