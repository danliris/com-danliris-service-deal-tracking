using Com.DanLiris.Service.DealTracking.Lib.Models;
using Com.DanLiris.Service.DealTracking.Lib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Com.DanLiris.Service.DealTracking.Test.Utilities
{
    public class QueryHelperTest
    {
        [Fact]
        public void Filter_Return_Success()
        {
            var model = new List<Reason>() { new Reason() {
            Code ="Code",
            LoseReason ="LoseReason"
            } }.AsQueryable();
            Dictionary<string, object> filterDictionary = new Dictionary<string, object>();
            filterDictionary.Add("Code", "Code");
            var result = QueryHelper<Reason>.Filter(model, filterDictionary);
            Assert.NotNull(result);
        }

        [Fact]
        public void Order_Return_Success()
        {
            var model = new List<Reason>() { new Reason() {
            Code ="Code",
            LoseReason ="LoseReason"
            } }.AsQueryable();
            Dictionary<string, string> filterDictionary = new Dictionary<string, string>();
            filterDictionary.Add("Code", "desc");
            var result = QueryHelper<Reason>.Order(model, filterDictionary);
            Assert.NotNull(result);
        }

    }
}
