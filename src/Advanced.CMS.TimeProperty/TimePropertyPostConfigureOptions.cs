using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

namespace Advanced.CMS.TimeProperty
{
    internal class TimePropertyPostConfigureOptions : IPostConfigureOptions<RazorViewEngineOptions>
    {
        public void PostConfigure(string name, RazorViewEngineOptions options) => options.ViewLocationExpanders.Add(new TimePropertyViewExpander());
    }
}
