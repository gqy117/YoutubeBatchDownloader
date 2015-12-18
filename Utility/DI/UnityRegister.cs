namespace Utility.UnityRegister
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Practices.Unity;
    using System.Configuration;
    using AngleSharp.Parser.Html;

    public class UnityRegister
    {
        private static IList<string> ListRegisteredAssemblies = new List<string>() 
        { 
             "Utility",
             "YoutubeBatchDownloader.Service",
             "YoutubeBatchDownloader.Service.ThunderVBS",
        };

        public static void RegisterTypes(IUnityContainer container)
        {
            var types = AllClasses.FromLoadedAssemblies().Where(t => ListRegisteredAssemblies.Contains(t.Namespace));
            container.RegisterType<HtmlParser>(new InjectionConstructor());

            container.RegisterTypes(types);
        }
    }
}