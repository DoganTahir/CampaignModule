using CampaignModuleApi.BusinessServices;
using CampaignModuleApi.Data;
using CampaignModuleApi.Models;
using CampaignModuleApi.Models.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CampaignModuleSimulation.ServiceCalls
{
    public class CampaignServiceCall
    {
        CampaignBusiness campaignBusiness = new CampaignBusiness();

        public static async Task<string> AddCampaign(PostCampaignCreateRequest CampaignModelRequest)
        {
            try
            {
                string path = $"http://localhost:8080/campaigns";
                HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(
                    path, CampaignModelRequest);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return "create_campaign;" + JsonConvert.SerializeObject(CampaignModelRequest);
                }
                return "başarılı";

            }
            catch
            {
                return null;
            }

        }

        public static async Task<string> GetCampaignByName(string campaignName)
        {
            try
            {
                string path = $"http://localhost:8080/campaigns/name/" + campaignName;

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    GetCampaignByNameResponse getCampaignByNameResponse = await response.Content.ReadAsAsync<GetCampaignByNameResponse>();
                    var output = "get_campaign_info" + JsonConvert.SerializeObject(getCampaignByNameResponse);
                    return output;
                }
                else if (Convert.ToInt32(response.StatusCode) == 460)
                {
                    var output = "get_campaign_info" + "Ürün Bulunamadı";
                    return output;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
