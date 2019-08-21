To use TimeProperty you need to add BackingType attribute to your model.
For example:

[ContentType(GUID = "9CCC8A41-5C8C-4BE0-8E73-520FF3DE8267")]
public class TestPage : PageData
{
    [BackingType(typeof(AdvancedCms.TimeProperty.TimeProperty))]
    public virtual TimeSpan? Time1 { get; set; }
}

To render property in view mode you can use PropertyFor with TimeSpan tag:

@Html.PropertyFor(x => x.CurrentPage.Time1, new { Tag = "TimeSpan" })

More configuration options can be found in the documentation: https://github.com/advanced-cms/time-property
