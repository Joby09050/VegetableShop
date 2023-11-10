using GreenValley.Services.Contracters;
using GreenValley.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GreenValley.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetableController : ControllerBase
    {
        private readonly IVegDetailsService _vegDetailsService;
        public VegetableController(IVegDetailsService vegDetailsService)
        {
            _vegDetailsService = vegDetailsService;
        }

        [HttpGet]
        public IActionResult GetVegetables()
        {
           
            ResponseApi<List<VegResponse>> response =new ResponseApi<List<VegResponse>>();
            try
            {
                List<VegResponse> veglist = _vegDetailsService.GetVegData();
                response = new ResponseApi<List<VegResponse>> { Msg = "ok", Value = veglist };
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                response = new ResponseApi<List<VegResponse>> { Msg = ex.Message};
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
