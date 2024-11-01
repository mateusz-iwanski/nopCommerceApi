﻿using FluentValidation;
using nopCommerceApi.Config;
using nopCommerceApi.Entities;
using nopCommerceApi.Models.Customer;

namespace nopCommerceApi.Validations.Customer
{
    public class CustomerPLCreateDtoValidator : BaseValidator<CustomerPLCreateBaseDto>
    {
        private readonly NopCommerceContext _context;   

        public CustomerPLCreateDtoValidator(NopCommerceContext context, IMySettings settings) 
        {
            _context = context;

            //password has to be at least 6 characters long
            RuleFor(x => x.Password)
                .MinimumLength(settings.PasswordMinLength)
                .WithMessage($"Password must be at least {settings.PasswordMinLength} characters long.");

            // password has max length
            RuleFor(x => x.Password)
                .MaximumLength(settings.PasswordMaxLength)
                .WithMessage($"Password must be at most {settings.PasswordMaxLength} characters long.");

            //password is required
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");

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
