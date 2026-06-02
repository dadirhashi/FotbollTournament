using FluentValidation;
using FotbollTournament.Application.Commands.Games;

namespace FotbollTournament.Application.Validators;

public class CreateGameValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameValidator()
    {
        RuleFor(x => x.HomeTeamId).GreaterThan(0);
        RuleFor(x => x.AwayTeamId).GreaterThan(0).NotEqual(x => x.HomeTeamId)
            .WithMessage("A team cannot play itself.");
        RuleFor(x => x.KickOff).NotEmpty();
    }
}