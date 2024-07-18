using FluentValidation;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Address;
using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Validations
{
    public class CreateBaseCustomerPLDtoValidator : BaseValidator<CreateBaseCustomerPLDto>
    {
        private readonly NopCommerceContext _context;

        public CreateBaseCustomerPLDtoValidator(NopCommerceContext context)
        {
            _context = context;

            // Validate if the email already exists in the database, has to be unique
            RuleFor(x => x.Email)
                .Must(email =>
                {
                    var customer = _context.Customers.ToList();
                    var filtered = customer.Where(c => c.Email == email).ToList();

                    return filtered.Count == 0 ? true : false;
                })
                .WithMessage("The Email already exists in the database.");

            RuleFor(x => x.Username)
                .Must(username =>
                {
                    var customer = _context.Customers.ToList();
                    var filtered = customer.Where(c => c.Username == username).ToList();

                    return filtered.Count == 0 ? true : false;
                })
                .WithMessage("The username already exists in the database. You can use your email address as a username.");
        }
    }
}
