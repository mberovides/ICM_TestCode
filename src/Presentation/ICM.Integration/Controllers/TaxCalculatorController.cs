using AutoMapper;
using ICM.Integration.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ICM.Integration.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly ICM.Taxes.Calculator.Abstractions.ITaxServices _svc;
        private readonly IMapper _mapper;

        public TaxCalculatorController(
            ILogger<TaxCalculatorController> logger,
            ICM.Taxes.Calculator.Abstractions.ITaxServices svc,
            IMapper mapper)
        {
            _logger = logger;
            _svc = svc;
            _mapper = mapper;
        }

        [HttpGet("Rates/{zipcode}")]
        public async Task<ActionResult> GetTaxRatesForLocation(string zipcode)
        {
            if (String.IsNullOrEmpty(zipcode))
                return BadRequest(BadRequestMessage("Zip Code"));
            try
            {
                var rates = await _svc.TaxRatesForLocation(zipcode);

                if (rates == null)
                    return NotFound($"Rates unavailable for zipcode: {zipcode}");

                return Ok(rates);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, "System Error");
            }

        }


        [HttpPost("Calculate")]
        public async Task<ActionResult> Calculate([FromBody] Models.OrderInfo model)
        {
            if (!ModelState.IsValid)
                return BadRequest(BadRequestMessage(ModelState.ToString()));

            try
            {
                var result = await _svc.CalculateTaxOrder(_mapper.ToOrderInfo(model));
                if (result == null)
                    return NotFound("There is something wrong with the order data");

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500, "System Error");
            }

        }

        private string BadRequestMessage(string str)
        => $"Bad Request, param {str} is invalid";

    }
}

