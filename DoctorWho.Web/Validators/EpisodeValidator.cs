namespace DoctorWho.Web.Validators
{
    using DoctorWho.Domain.Entities;
    using FluentValidation;

    public class EpisodeValidator : AbstractValidator<Episode>
    {
        public EpisodeValidator()
        {
            RuleFor(e => e.AuthorId).NotEmpty();
            RuleFor(e => e.DoctorId).NotEmpty();
            RuleFor(e => e.SeriesNumber.ToString()).Length(10);
            RuleFor(e => e.EpisodeNumber).GreaterThan(0);
        }
    }
}
