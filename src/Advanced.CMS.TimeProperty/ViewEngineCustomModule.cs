using System.Collections.Concurrent;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Modules.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;

namespace Advanced.CMS.TimeProperty
{
    //TODO NETCORE
    /// <summary>
    /// Custom view engine used to register path to TimeSpan.ascx view
    /// </summary>
    // internal class CustomUtilViewEngine : CompositeViewEngine
    // {
    //     private ConcurrentDictionary<string, bool> _cache = new ConcurrentDictionary<string, bool>();
    //
    //     public CustomUtilViewEngine(IOptions<MvcViewOptions> optionsAccessor) : base(optionsAccessor)
    //     {
    //         const string url = "Views/Shared/DisplayTemplates/TimeSpan.ascx";
    //         if (ModuleResourceResolver.Instance.TryResolvePath(typeof(CustomUtilViewEngine).Assembly, url,
    //             out var resolvedPath))
    //         {
    //             this.PartialViewLocationFormats = new string[]
    //             {
    //                 resolvedPath.Replace("DisplayTemplates/TimeSpan", "{0}")
    //             };
    //         }
    //     }
    //
    //     protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
    //     {
    //         if (controllerContext.HttpContext != null && !controllerContext.HttpContext.IsDebuggingEnabled)
    //         {
    //             return _cache.GetOrAdd(virtualPath, p => HostingEnvironment.VirtualPathProvider.FileExists(virtualPath));
    //         }
    //         else
    //         {
    //             return HostingEnvironment.VirtualPathProvider.FileExists(virtualPath);
    //         }
    //     }
    // }
}
