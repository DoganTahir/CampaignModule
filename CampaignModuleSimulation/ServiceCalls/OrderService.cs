using CampaignModuleApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModuleSimulation.ServiceCalls
{
    internal class OrderService
    {
        public static async Task<string> AddOrder(PostOrderCreateRequest postOrderCreateRequest)
        {
            try
            {
                string path = $"http://localhost:8080/orders";
                HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(
                    path, postOrderCreateRequest);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return "create_order;" + JsonConvert.SerializeObject(postOrderCreateRequest);
                }
                return "hata oluştu";

            }
            catch
            {
                return null;
            }
        }
        }
    }
