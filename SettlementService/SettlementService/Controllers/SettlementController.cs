using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;

namespace SettlementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettlementController : ControllerBase
    {
        private readonly IService _service;
        public SettlementController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Request request)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult("Please enter valid request details");

            (bool, string) response = await _service.BookForSettlement(request);

            if (response.Item1)
                return new OkObjectResult(new Response() { BookingId = response.Item2 });
            else if (String.Equals(response.Item2, "Request is already in process for settlement", StringComparison.OrdinalIgnoreCase))
                return new ConflictObjectResult(response.Item2);
            else
                return new BadRequestObjectResult(response.Item2);
        }
    }
}
