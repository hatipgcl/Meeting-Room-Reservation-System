
using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(p => p.LocationName).NotEmpty();
            RuleFor(p => p.Adress).NotEmpty();
            RuleFor(p => p.LocationId).NotEmpty();
            RuleFor(p=>p.RoomCount).NotEmpty();

        }
    }
}
