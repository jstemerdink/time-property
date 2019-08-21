using System.Collections.Concurrent;
using System.Web.Hosting;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Modules.Internal;

namespace AdvancedCms.TimeProperty
{
    /// <summary>
    /// Initializable module used to ad custom view engine
    /// </summary>
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class TimeViewEngineUIInitialization : IInitializableModule
    {
        private CustomUtilViewEngine _viewEngine;

        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                _viewEngine = new CustomUtilViewEngine();
                lock ((ViewEngines.Engines as System.Collections.ICollection).SyncRoot)
                {
                    ViewEngines.Engines.Add(_viewEngine);
                }
            }
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
            if (this._viewEngine == null)
                return;
            ViewEngines.Engines.Remove((IViewEngine)this._viewEngine);
        }
    }

    /// <summary>
    /// Custom view engine used to register path to TimeSpan.ascx view
    /// </summary>
    internal class CustomUtilViewEngine : WebFormViewEngine
    {
        private ConcurrentDictionary<string, bool> _cache = new ConcurrentDictionary<string, bool>();

        internal CustomUtilViewEngine()
        {
            this.ViewLocationCache = (IViewLocationCache)new DefaultViewLocationCache();

            const string url = "Views/Shared/DisplayTemplates/TimeSpan.ascx";
            if (ModuleResourceResolver.Instance.TryResolvePath(typeof(CustomUtilViewEngine).Assembly, url,
                out var resolvedPath))
            {
                this.PartialViewLocationFormats = new string[]
                {
                    resolvedPath.Replace("DisplayTemplates/TimeSpan", "{0}")
                };
            }
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            if (controllerContext.HttpContext != null && !controllerContext.HttpContext.IsDebuggingEnabled)
            {
                return _cache.GetOrAdd(virtualPath, p => HostingEnvironment.VirtualPathProvider.FileExists(virtualPath));
            }
            else
            {
                return HostingEnvironment.VirtualPathProvider.FileExists(virtualPath);
            }
        }
    }
}