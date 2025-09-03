using Application.Interfaces;

namespace API.Features.Library;

public class DeleteLibrary : IMinimalEndpoint
{
    public static void MapEndpoint(RouteGroupBuilder heroRoute)
    {
        heroRoute.MapDelete("/", HandleAsync)
            .WithName("Delete")
            .WithSummary("Delete all data in the library");
    }

    internal static async Task<IResult> HandleAsync(ILibraryService cardDataService)
    {
        await cardDataService.DeleteAllData();
        return Results.NoContent();
    }
}
