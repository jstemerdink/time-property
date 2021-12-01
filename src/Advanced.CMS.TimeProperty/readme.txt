Advanced.CMS.TimeProperty


Installation
============


In order to start using TimeProperty you need to add it explicitly to your site.
Please add the following statement to your Startup.cs


public class Startup
{
    ...
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddTimeProperty();
        ...
    }
    ...
}

To use TimeProperty you need to add BackingType attribute to your model.
For example:

[ContentType(GUID = "9CCC8A41-5C8C-4BE0-8E73-520FF3DE8267")]
public class TestPage : PageData
{
    [BackingType(typeof(Advanced.CMS.TimeProperty.TimeProperty))]
    public virtual TimeSpan? Time1 { get; set; }
}

Full documentation can be found here: https://github.com/advanced-cms/time-property
