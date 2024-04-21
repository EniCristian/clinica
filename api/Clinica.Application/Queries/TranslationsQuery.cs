using System.Globalization;
using Clinica.Application.Services;
using MediatR;

namespace Clinica.Application.Queries;

public record TranslationsQuery(CultureInfo culture): IRequest<IDictionary<string, string>>;
internal class TranslationsQueryHandler : IRequestHandler<TranslationsQuery, IDictionary<string, string>>
{
    private readonly ITranslationService _translationService;

    public TranslationsQueryHandler(ITranslationService translationService)
    {
        _translationService = translationService;
    }

    public async Task<IDictionary<string, string>> Handle(TranslationsQuery request, CancellationToken cancellationToken)
    {
        return _translationService.GetAll(request.culture);
    }
}
