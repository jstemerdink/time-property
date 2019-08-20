To use TimeProperty you need to add BackingType attribute to your model.
For example:

[ContentType(GUID = "9CCC8A41-5C8C-4BE0-8E73-520FF3DE8267")]
public class TestPage : PageData
{
    [BackingType(typeof(AdvancedCms.TimeProperty.TimeProperty))]
    public virtual TimeSpan? Time1 { get; set; }
}