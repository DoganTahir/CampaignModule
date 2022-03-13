using System;

namespace CampaignModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Tahir\source\repos\CampaignModule\CampaignModule\TextFile1.txt");

            foreach (string line in lines)
            {
                string[] command = line.Split(' ');

                switch (command[0])
                {                    
                    case "create_product":
                        Console.WriteLine("Ürün Olusturuldu");
                        break;
                    case "create_campaign":
                        Console.WriteLine("Kampanya oluşturuldu");
                        break;
                    case "get_product_info":
                        Console.WriteLine("Ürün bilgisi  geldi");
                        break;
            }
            }

            System.Console.ReadKey();
        }
    }
}
