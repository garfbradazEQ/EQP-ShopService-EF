namespace ShopService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ShopService.Data;
    using ShopService.Data.EF;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("shop")]
    public class ShopController : ControllerBase
    {
        private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            List<SampleResponse> items;
            // Do not use this code as its just an example of how to get items from the EF context
            using (var shopContext = new ShopContext())
            {
                items = shopContext.Items.Select(x => new SampleResponse
                {
                    Name = x.Name,
                    Description = x.Description,
                    Type = x.Type.Name,
                    Price = x.Baseprice
                }).ToList();
            }

            return Ok(items);
        }
    }
}
