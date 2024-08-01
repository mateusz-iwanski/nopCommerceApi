using nopCommerceApi.Models.ProductAttribute;
using nopCommerceApi.Models.ProductAttributeValue;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class ProductAttributeDtoBaseValidator<T> : BaseValidator<T> where T : ProductAttributeDto
    {
    }
}
