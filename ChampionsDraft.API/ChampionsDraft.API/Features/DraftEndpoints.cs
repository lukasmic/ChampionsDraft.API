using API.DTOs;
using Application.Interfaces;

namespace API.Features;

public static class DraftEndpoints
{
    public static WebApplication MapDraftEndpoints(this WebApplication app)
    {
        var draftRoute = app.MapGroup("/draft")
            .WithTags("Draft")
            .WithOpenApi();
        MapEndpoints(draftRoute);

        return app;
    }

    private static void MapEndpoints(RouteGroupBuilder draftRoute)
    {
        draftRoute.MapPost("/", async (IDraftService draftService, CreateDraftDTO createDraftDTO) =>
        {
            if (createDraftDTO == null)
            {
                return Results.BadRequest("Draft data cannot be null.");
            }

            var session = await draftService.CreateDraftSessionAsync(
                createDraftDTO.Hero,
                createDraftDTO.Aspects,
                createDraftDTO.DraftRules ?? []
            );

            return Results.Created($"/draft/{session.Id}", session.Id);
        })
            .WithName("CreateDraftSession")
            .WithSummary("Create a draft session");

        draftRoute.MapGet("/{sessionId}", async (IDraftService draftService, Guid sessionId) =>
        {
            var session = await draftService.GetDraftSessionAsync(sessionId);

            if (session == null)
            {
                return Results.NotFound("Draft session with not found.");
            }

            return Results.Ok(GetSessionDTO.FromSession(session));
        })
            .WithName("GetDraftSession")
            .WithSummary("Get a draft session by ID");

        draftRoute.MapGet("/{sessionId}/offer", async (IDraftService draftService, Guid sessionId, int count) =>
        {
            // Uncomment and implement this method when needed
            var offer = await draftService.GetDraftOfferAsync(sessionId, count);
            return Results.Ok(offer);
        })
            .WithName("GetDraftOffer")
            .WithSummary("Get a draft offer for a session");
    }
}
