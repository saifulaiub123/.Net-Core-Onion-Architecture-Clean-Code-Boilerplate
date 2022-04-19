using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using RentGo.Domain.Model;

namespace RentGo.Application.Validator
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.MobileNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Mobile number must not be empty");
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .Length(4, 4)
                .WithMessage("Invalid length of code");
        }

        private void test()
        {
            
        }
    }
}
