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
    public class ProductServiceCall
    {
        public static async Task<string> GetProductById(string productCode)
        {
            try
            {
                string path = $"http://localhost:8080/products/id/" + productCode;

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    GetProductByIdResponse getProductByIdResponse = await response.Content.ReadAsAsync<GetProductByIdResponse>();
                    var output = "get_product_info" + JsonConvert.SerializeObject(getProductByIdResponse);
                    return output;
                }
                else if (Convert.ToInt32(response.StatusCode) == 460)
                {
                    var output = "get_product_info" + "Ürün Bulunamadı";
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

        public static async Task<string> AddProduct(PostProductCreateRequest productModelRequest)
        {
            try
            {
                string path = $"http://localhost:8080/products";
                HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(
                    path, productModelRequest);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    return "Product created;"+ JsonConvert.SerializeObject(productModelRequest);
                }
                return "başarılı";

            }
            catch
            {
                return null;
            }

        }
    }
}
