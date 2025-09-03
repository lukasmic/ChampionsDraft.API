using Application.Interfaces;

namespace API.Features.Draft;

public class GetDraftOffer : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder draftRoute)
    {
        draftRoute.MapGet("/{draftId}/offer", HandleAsync)
            .WithName("GetDraftOffer")
            .WithSummary("Get a draft offer");
    }

    private static async Task<IResult> HandleAsync(IDraftService draftService, Guid draftId, int count)
    {
        // Uncomment and implement this method when needed
        var offer = await draftService.GetOfferAsync(draftId, count);
        return Results.Ok(offer.Select(x => x.Card));
    }
}
