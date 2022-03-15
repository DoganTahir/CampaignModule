using CampaignModuleApi.BusinessServices;
using CampaignModuleApi.Models;
using CampaignModuleSimulation.ServiceCalls;
using System;
using System.Threading.Tasks;

namespace CampaignModuleSimulation
{
    internal class Program
    {
        CampaignBusiness campaignBusiness = new CampaignBusiness();
        static async Task Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Tahir\source\repos\CampaignModule\CampaignModuleSimulation\TextFile1.txt");
            ApiHelper.InitializeClient();

            DateTime increase_time = new DateTime();
            Console.WriteLine(increase_time);
            foreach (string line in lines)
            {
                string[] command = line.Split(' ');

                switch (command[0])
                {
                    case "create_product":
                        PostProductCreateRequest productModel = new PostProductCreateRequest();
                        productModel.ProductCode = command[1];
                        productModel.Price = command[2]!=""? Convert.ToDecimal( command[2]):0;
                        productModel.Stock = command[3]!= "" ? Convert.ToInt32(command[3]) : 0;
                        var postproduct = await ProductServiceCall.AddProduct(productModel);
                        Console.WriteLine(postproduct);
                        break;
                    case "create_campaign":
                        PostCampaignCreateRequest campaignModel = new PostCampaignCreateRequest();
                        campaignModel.Name = command[1];
                        campaignModel.ProductCode = command[2];
                        campaignModel.CampaignStartDate = increase_time;
                        campaignModel.CampaignFinishDate = increase_time.AddHours(Convert.ToInt32(command[3]));
                        campaignModel.ManipulationLimit =Convert.ToInt32(command[4]);
                        campaignModel.TargetCount = Convert.ToInt32(command[5]);
                        campaignModel.CampaignStatus =1 ;
                        var postCampaign= await CampaignServiceCall.AddCampaign(campaignModel);
                        Console.WriteLine(postCampaign); break;
                    case "get_product_info":
                        var getproduct = await ProductServiceCall.GetProductById(command[1]);
                        Console.WriteLine(line+'='+getproduct);
                        break;
                    case "get_campaign_info":
                        var getCampaign = await CampaignServiceCall.GetCampaignByName(command[1]);
                        Console.WriteLine(line + '=' + getCampaign);
                        break;
                    case "increase_time":
                        increase_time = increase_time.AddHours(Convert.ToInt32(command[1]));
                        //var result = campaignBusiness.CheckCampaignTime(increase_time);
                        Console.WriteLine("Hour:"+increase_time.ToString("hh:mm"));
                        break;
                    case "create_order":
                        PostOrderCreateRequest postOrderCreateRequest = new PostOrderCreateRequest();
                        postOrderCreateRequest.ProductCode = command[1];
                        postOrderCreateRequest.Quantity = command[2] != "" ? Convert.ToInt32(command[2]) : 0;
                        postOrderCreateRequest.OrderTime = increase_time;
                        var create_order = await OrderService.AddOrder(postOrderCreateRequest);
                        Console.WriteLine(create_order);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
