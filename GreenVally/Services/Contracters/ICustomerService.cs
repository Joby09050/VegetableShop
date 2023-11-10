using GreenValley.Utility;

namespace GreenValley.Services.Contracters
{
    public interface ICustomerService
    {
        public List<CustomerResponse> getCustomerDetails();
        public PriceResponse postPrice(PriceResponse priceResponse);

    }
}
