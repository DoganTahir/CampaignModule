
using CampaignModuleApi.Data;
using CampaignModuleApi.Models;
using CampaignModuleApi.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CampaignModuleApi.Controllers
{
    public class CampaignController : ControllerBase
    {


        [SwaggerOperation(Summary = "Returns get by Id product", Tags = new[] { "Products" })]
        [HttpGet("/campaigns/name/{campaignName}")]
        [SwaggerResponse(200, "Success, specify id product are returned successfully", typeof(GetCampaignByNameResponse))]
        [SwaggerResponse(460, "Product is not found.", typeof(void))]
        public IActionResult Get([FromRoute] string campaignName)
        {
            try
            {
                GetCampaignByNameResponse returnValue = new GetCampaignByNameResponse();

                using (var db = new DataBaseContext())
                {
                    var campaign = db.Campaigns.Where(s =>
                        s.Name == campaignName).FirstOrDefault();
                    if (campaign == null)
                        return this.StatusCode(460, "Product is Not Found");

                    returnValue.Name = campaign.Name;
                    returnValue.ProductCode = campaign.ProductCode;
                    returnValue.ManipulationLimit = campaign.ManipulationLimit;
                    returnValue.TargetCount = campaign.TargetCount;
                    returnValue.TotalSales = campaign.TotalSales;
                    returnValue.CampaignStartDate = campaign.CampaignStartDate;
                    returnValue.CampaignFinishDate = campaign.CampaignFinishDate;
                    returnValue.Turnover = campaign.Turnover;
                    returnValue.CampaignStatus = campaign.CampaignStatus ==1 ? "Active" : "Closed" ;
                }
                return Ok(returnValue);
            }

            catch (Exception e)
            {
                return this.StatusCode(500, e.Message);
            }
        }




        [SwaggerOperation(Summary = "Adds new Campaign", Tags = new[] { "Campaign" })]
        [HttpPost("/campaigns")]
        [SwaggerResponse(200, "Success, Campaign is created successfully", typeof(void))]
        public IActionResult Post([FromBody] PostCampaignCreateRequest data)
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    db.Add(new Campaign
                    {
                        ProductCode = data.ProductCode,
                        Name = data.Name,
                        CampaignStartDate = data.CampaignStartDate,
                        CampaignFinishDate = data.CampaignFinishDate,
                        CampaignStatus = 1

                    });

                    db.SaveChanges();
                }


                return Ok();
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                 return this.StatusCode(500, e.Message);
            }

        }
    }
}
