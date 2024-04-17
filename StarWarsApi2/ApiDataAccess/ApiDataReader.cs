﻿using StarWarsPlanetsStats.ApiDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApi2.ApiDataAccess
{
    public class ApiDataReader : IApiDataReader
    {
        public async Task<string> Read(string baseAddress, string requestUri)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
