using CampaignModuleApi.Data;
using CampaignModuleApi.Models;
using CampaignModuleApi.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CampaignModuleApi.Controllers
{
    [Route("Product/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [SwaggerOperation(Summary = "Returns get by Id product",Tags = new[] { "Products" })]
        [HttpGet("/products/id/{productCode}")]
        [SwaggerResponse(200, "Success, specify id product are returned successfully", typeof(GetProductByIdResponse))]
        [SwaggerResponse(460, "Product is not found.", typeof(void))]
        public IActionResult Get([FromRoute] string productCode)
        {
            try
            {
                GetProductByIdResponse returnValue = new GetProductByIdResponse();

                using (var db = new DataBaseContext())
                {
                    var product = db.Products.Where(s =>
                        s.ProductCode == productCode).FirstOrDefault();
                    if (product == null)
                        return this.StatusCode(460, "Product is Not Found");

                    returnValue.ProductCode = product.ProductCode;
                    returnValue.Price = product.Price;
                    returnValue.Stock = product.Stock;
                }
                return Ok(returnValue);
            }

            catch (Exception e)
            {
                return this.StatusCode(500, e.Message);
            }
        }



        [SwaggerOperation( Summary = "Adds new Product",Tags = new[] { "Product" } )]
        [HttpPost("/products")]
        [SwaggerResponse(200, "Success, sources is created successfully", typeof(void))]
        public IActionResult Post([FromBody] PostProductCreateRequest data)
        {
            using (var db = new DataBaseContext())
            {
                db.Add(new Product
                {
                    ProductCode = data.ProductCode,
                    Price = data.Price,
                    Stock = data.Stock,
    
                });

                db.SaveChanges();
            }


            return Ok();
        }

    }
}
