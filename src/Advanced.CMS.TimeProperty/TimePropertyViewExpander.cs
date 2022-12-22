using System.Collections.Generic;
using EPiServer.Web;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Advanced.CMS.TimeProperty
{
    internal class TimePropertyViewExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var viewLocation in viewLocations)
            {
                yield return viewLocation;
                yield return VirtualPathUtilityEx.Combine("/TimeProperty/", viewLocation);
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context) { }
    }
}
