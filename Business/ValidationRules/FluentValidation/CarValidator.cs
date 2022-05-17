using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Descriptions).MinimumLength(4);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0).When(c => c.ColorId == 1);
            RuleFor(c => c.ModelYear).Must(StartWithA).WithMessage("1980'den daha yuksek bir yil olmalı");

        }

        private bool StartWithA(string letter)
        {
            return letter.StartsWith("A");
        }
    }
}
