using GreenValley.Models;
using GreenValley.Services.Contracters;
using GreenValley.Utility;
using Microsoft.EntityFrameworkCore;

namespace GreenValley.Services.Implimentation
{
    public class VegDetailService : IVegDetailsService
    {
        private readonly VegetableHubContext _context;
        public VegDetailService(VegetableHubContext context)
        {
            _context = context;
        }

        public List<VegResponse> GetVegData()
        {
            try
            {
                List<VegetableDetail> vegList = _context.VegetableDetails.Include(x => x.User).ToList();
                var responses = new List<VegResponse>();
                foreach( var vegtableDetails in vegList)
                {
                    var response = new VegResponse();
                    response.UserId = vegtableDetails.UserId;
                    response.UserName = vegtableDetails.User?.UserName ?? "";
                    response.VegId = vegtableDetails.VegId;
                    response.VegName = vegtableDetails.VegName;
                    responses.Add(response);
                }
                return responses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
