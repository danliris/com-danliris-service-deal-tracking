﻿using Com.DanLiris.Service.DealTracking.Lib.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Test
{
    public class HttpClientTestService : IHttpClientService
    {
        public static string Token;

        public Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return Task.Run(() => new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            });
        }
        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return Task.Run(() => new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("{data:{'data':'data', 'Buyers':{'Id':1}, 'Address' :'ad', 'BankAddress':'ad', 'SwiftCode':'ad', 'BankName':'ad'}}")
            });
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return Task.Run(() => new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.Created
            });
        }
    }
}
