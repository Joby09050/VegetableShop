using GreenValley.Services.Contracters;
using GreenValley.Services.Implimentation;
using GreenValley.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenValley.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _custom;
        public CustomerController(ICustomerService custom)
        {
            _custom = custom;
        }

       

        [HttpGet]
        public IActionResult GetCustomers()
        {

            ResponseApi<List<CustomerResponse>> response = new ResponseApi<List<CustomerResponse>>();
            try
            {
                List<CustomerResponse> custlist = _custom.getCustomerDetails();
                response = new ResponseApi<List<CustomerResponse>> { Msg = "ok", Value =custlist };
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                response = new ResponseApi<List<CustomerResponse>> { Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpPost("price")]
        public IActionResult AddNewPrice(PriceResponse priceResponse)
        {
            ResponseApi<PriceResponse> response = new ResponseApi<PriceResponse>();
            try
            {
                PriceResponse newprice =_custom.postPrice(priceResponse);
                response = new ResponseApi<PriceResponse> { Msg = "Price Added", Status = true, Value = newprice};
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response = new ResponseApi<PriceResponse> { Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
