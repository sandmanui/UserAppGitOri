﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserApplication.WebApi.Helpers
{
    public static class RestHelper
    {
        public static async Task<string> GetStringAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}
