namespace YoutubeBatchDownloader.Service.DI
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnityRegister
    {
        private static IList<string> ListRegisteredAssemblie = new List<string>() 
        { 
             "YoutubeBatchDownloader.Service",
             "YoutubeBatchDownloader.Service.ThunderVBS",
        };

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(t => ListRegisteredAssemblie.Contains(t.Namespace)));
        }
    }
}
