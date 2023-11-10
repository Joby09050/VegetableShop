using GreenValley.Models;
using GreenValley.Services.Contracters;
using GreenValley.Utility;
using Microsoft.EntityFrameworkCore;

namespace GreenValley.Services.Implimentation
{
    public class CustomerService : ICustomerService
    {

        private readonly VegetableHubContext    _context;
         public CustomerService  (VegetableHubContext context)
        {
            _context = context;
        }
        public List<CustomerResponse> getCustomerDetails()
        {

            try
            {
                List<CustomerDetail> CustList = _context.CustomerDetails .Include(x => x.User) .Include(x => x.Veg) .ToList();

                var responses = new List<CustomerResponse>();
                foreach (var CustomerDetail in CustList)
                {
                    var response = new CustomerResponse();
                    response.CustId=CustomerDetail.CustId;
                    response.UserId=CustomerDetail.UserId;
                    response.UserName = CustomerDetail.User?.UserName ?? "";
                    response.VegId=CustomerDetail.VegId;
                    response.VgPrice=CustomerDetail.VgPrice;
                    responses.Add(response);
                }
                return responses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PriceResponse postPrice(PriceResponse priceResponse)
        {
            try
            {

                var newPrice = new CustomerDetail()
                {
                    VgPrice = priceResponse.VgPrice,
                };
                _context.CustomerDetails.Add(newPrice);
                _context.SaveChanges();
                 return priceResponse;
            }

    
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}
