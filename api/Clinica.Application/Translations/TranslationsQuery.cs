using System.Globalization;
using Clinica.Application.Services;
using MediatR;

namespace Clinica.Application.Translations;

public record TranslationsQuery(CultureInfo culture): IRequest<IDictionary<string, string>>;
internal class TranslationsQueryHandler(ITranslationService translationService) : IRequestHandler<TranslationsQuery, IDictionary<string, string>>
{
    public async Task<IDictionary<string, string>> Handle(TranslationsQuery request, CancellationToken cancellationToken)
    {
        return translationService.GetAll(request.culture);
    }
}
