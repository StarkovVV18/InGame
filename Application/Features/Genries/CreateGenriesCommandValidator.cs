using Application.Interfaces.Repositories;
using FluentValidation;

namespace Application.Features.Genries
{
    public class CreateGenriesCommandValidator : AbstractValidator<CreateGenriesCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenriesCommandValidator(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
    }
}
