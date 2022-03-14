using CampaignModuleApi.Models;
using CampaignModuleSimulation.ServiceCalls;
using System;
using System.Threading.Tasks;

namespace CampaignModuleSimulation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Tahir\source\repos\CampaignModule\CampaignModuleSimulation\TextFile1.txt");
            ApiHelper.InitializeClient();

            DateTime increase_time = new DateTime();
            increase_time=increase_time.AddHours(5);
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
                        Console.WriteLine("Kampanya oluşturuldu");
                        break;
                    case "get_product_info":
                        var getproduct = await ProductServiceCall.GetProductById(command[1]);
                        Console.WriteLine(line+'='+getproduct);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
