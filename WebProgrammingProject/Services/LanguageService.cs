using Microsoft.Extensions.Localization;
using System.Reflection;

namespace WebProgrammingProject.Services
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {

            var type = typeof(SharedResource);
            //var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            var assemblyName = type.Assembly.FullName;

            _localizer = factory.Create(nameof(SharedResource),assemblyName);
        }
        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
