using BuilderPatternAPI.Models;

namespace BuilderPatternAPI.Builders
{
    public class ProductSearchRequestBuilder : IProductSearchRequestBuilder
    {
        private readonly ProductSearchRequest _request;

        public ProductSearchRequestBuilder()
        {
            _request = new ProductSearchRequest();
        }

        public void SetCategory(string category)
        {
            _request.Category = category;
        }

        public void SetMinPrice(decimal minPrice)
        {
            _request.MinPrice = minPrice;
        }

        public void SetMaxPrice(decimal maxPrice)
        {
            _request.MaxPrice = maxPrice;
        }

        public ProductSearchRequest GetResult()
        {
            return _request;
        }
    }

}
