using EPiServer.Core;

namespace TimeProperty.AlloySample.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
