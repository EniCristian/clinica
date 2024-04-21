using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Clinica.Common.Resources;

namespace Clinica.Application.Services;

public interface ITranslationService
{
    Dictionary<string, string> GetAll(CultureInfo culture);
}

internal class TranslationService : ITranslationService
{
    private const string ResourceKeyFormat = "{0}_{1}";
    private readonly Dictionary<CultureInfo, Dictionary<string, string>> _cultureTranslations = new();

    public TranslationService()
    {
        LoadTranslations();
    }

    public Dictionary<string, string> GetAll(CultureInfo culture)
    {
        return _cultureTranslations.TryGetValue(culture, out var translation)
            ? translation
            : new Dictionary<string, string>();
    }

    private IEnumerable<Type> GetResourceFiles()
    {
        var resourcesNamespace = typeof(Qualities).Namespace;
        var resourceFiles = typeof(Qualities).Assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.Equals(resourcesNamespace));

        return resourceFiles;
    }

    private bool IsResourceValid(IDictionaryEnumerator enumerator)
    {
        return enumerator.Value != null;
    }


    private ResourceSet GetResourceSetFromFile(Type resourceFile, CultureInfo culture)
    {
        var resourceManager = new ResourceManager(resourceFile);

        if (resourceManager == null)
        {
            throw new Exception("Resource manager is null");
        }
        var set = resourceManager.GetResourceSet(culture, true, true);

        if (set == null)
        {
            throw new Exception("Resource set is null");
        }

        return set;
    }

    private void LoadTranslations()
    {
        foreach (var supportedCulture in TranslationConstants.SupportedCultures)
        {
            var cultureInfo = new CultureInfo(supportedCulture);
            var translations = this.LoadTranslationsForCulture(cultureInfo);
            this._cultureTranslations.Add(cultureInfo, translations);
        }
    }

    private Dictionary<string, string> LoadTranslationsForCulture(CultureInfo culture)
    {
        var translations = new Dictionary<string, string>();
        var resourceFiles = GetResourceFiles();

        foreach (var resFile in resourceFiles)
        {
            using ResourceSet resourceSet = GetResourceSetFromFile(resFile, culture);
            var enumerator = resourceSet.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (IsResourceValid(enumerator))
                {
                    translations.Add(string.Format(ResourceKeyFormat, resFile.Name.ToLower(), enumerator.Key),
                        enumerator.Value.ToString());
                }
            }
        }

        return translations;
    }
}

public static class TranslationConstants
{
    #region Public Fields
    public const string DefaultCulture = "ro-RO";
    public static readonly string[] SupportedCultures = {"ro-RO","en-US", "ru-RU" };

    #endregion Public Fields
}