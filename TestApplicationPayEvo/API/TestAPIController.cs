using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestApplicationPayEvo.Model;

namespace TestApplicationPayEvo
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        private HttpClient httpClient = new HttpClient();
        private ModelTest1 modelTest;
        

        public async Task<DataTable> GetTimeTaskAsync()
        {
            DataTable dataTable = new DataTable();
            string path = "https://api.harvestapp.com/v2/time_entries";
            string result = "";
            string key = "Bearer 3033552.pt.14cZwk70CfW_4W9LkQNUrOrqoX5VoCPT8kz1NCtzAEfa9Yxd6fIzU_YRtcvt8rIJkGgKY5AH0tjnarIdqb9rtQ";
            modelTest = null;
            httpClient.DefaultRequestHeaders.Add("Harvest-Account-ID", "1596805");
            httpClient.DefaultRequestHeaders.Add("Authorization", key);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Harvest API Example");
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
                dataTable = JsonConvert.DeserializeObject<DataTable>(result);
            }
            //return product;
            return dataTable;
        }
    }
}
