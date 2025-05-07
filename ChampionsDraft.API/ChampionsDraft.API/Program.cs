using API;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi()
                .AddCustomizableSocketsHttpHandler()
                .AddInfrastructureServices()
                .AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/cardLibrary", async (ICardLibraryService cardDataService) =>
{
    await cardDataService.AddCardsInBatch();
    return Results.Created();
})
.WithName("Create card library");

app.MapPost("/card", async (ICardLibraryService cardDataService) =>
{
    await cardDataService.CreateCard();
    return Results.Created();
})
.WithName("Create card");

app.Run();
