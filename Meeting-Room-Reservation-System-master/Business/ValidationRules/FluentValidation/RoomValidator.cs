
using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(p=>p.RoomName).NotEmpty();
            RuleFor(p=>p.Capasity).NotEmpty();
            RuleFor(p=>p.RoomId).NotEmpty();
        }
    }
}
