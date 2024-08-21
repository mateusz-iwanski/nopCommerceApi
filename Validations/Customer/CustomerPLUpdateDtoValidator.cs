using FluentValidation;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Validations.Customer
{
    public class CustomerPLUpdateDtoValidator : BaseValidator<CustomerPLUpdateDto>
    {
        private readonly NopCommerceContext _context;

        public CustomerPLUpdateDtoValidator(NopCommerceContext context) 
        {
            _context = context;
            
            RuleFor(x => x)
                .Must(obj =>
                {
                    var customer = _context.Customers.ToList();
                    var filtered = customer.Where(c => c.Email == obj.Email && c.Id != obj.Id).ToList();

                    return filtered.Count == 0 ? true : false;
                })
                .WithMessage("The Email already exists in the database.");

            RuleFor(x => x)
                .Must(obj =>
                {
                    var customer = _context.Customers.ToList();
                    var filtered = customer.Where(c => c.Username == obj.Username && c.Id != obj.Id).ToList();

                    return filtered.Count == 0 ? true : false;
                })
                .WithMessage("The username already exists in the database. You can use your email address as a username.");

        }
    }
}
