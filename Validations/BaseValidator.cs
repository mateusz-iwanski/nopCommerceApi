using FluentValidation;
using nopCommerceApi.Models;
using nopCommerceApi.Models.Address;
using System.Reflection;
using System.Text.Json.Serialization;

namespace nopCommerceApi.Validations
{
    /// <summary>
    /// <c>BaseValidator</c> is a base class for DTO validators.
    /// 
    /// Checking if the input contains unexpected fields. If input contains unexpected fields, 
    /// it will return an error message with the unexpected fields and the expected fields.
    /// </summary>
    /// <typeparam name="T">Objects inherited from IBaseDto</typeparam>
    public class BaseValidator<T> : AbstractValidator<T> where T : IBaseDto
    {
        public BaseValidator()
        {
            // Validate empty properties

            RuleFor(x => x.UnexpectedProperties)
            .Must(dict => dict == null || dict.Count == 0)
            .WithMessage((dto, dict) =>
            {
                // Get expected properties by reflecting over the DTO type
                var expectedProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => !Attribute.IsDefined(p, typeof(JsonExtensionDataAttribute))) // Exclude the UnexpectedProperties dictionary
                    .Select(p => p.Name);

                // Construct the message
                var message = "The input contains unexpected fields.";
                if (dict != null && dict.Count > 0)
                {
                    message += $" Unexpected fields: {string.Join(", ", dict.Keys)}.";
                }
                message += $" Expected fields: {string.Join(", ", expectedProperties)}.";

                return message;
            });
        }
    }
}
