using nopCommerceApi.Models.ProductAttribute;

namespace nopCommerceApi.Validations.ProductAttribute
{
    public class ProductAttributeDtoBaseValidator<T> : BaseValidator<T> where T : ProductAttributeDto
    {
    }
}
