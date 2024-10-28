using BuilderPatternAPI.Models;

namespace BuilderPatternAPI.Builders
{
    public interface IProductSearchRequestBuilder
    {
        void SetCategory(string category);
        void SetMinPrice(decimal minPrice);
        void SetMaxPrice(decimal maxPrice);
        ProductSearchRequest GetResult();
    }
}
