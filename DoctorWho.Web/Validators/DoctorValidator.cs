using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorValidator : AbstractValidator<DoctorDTO>
    {
        public DoctorValidator() { 
            RuleFor(Doctor=> Doctor.DoctorName).NotEmpty().WithMessage("Doctor Name is required");
            RuleFor(Doctor => Doctor.DoctorNumber).NotEmpty().WithMessage("Doctor Number is required"); ;
            RuleFor(Doctor => Doctor.FirstEpisodeDate).NotNull().When(Doctor => Doctor.LastEpisodeDate.HasValue).WithMessage("First Episode date is required in this case");
            RuleFor(Doctor => Doctor.FirstEpisodeDate).LessThanOrEqualTo(Doctor=>Doctor.LastEpisodeDate).WithMessage("First Episode date can't be after the last Episode date");
        }    
    }
}
