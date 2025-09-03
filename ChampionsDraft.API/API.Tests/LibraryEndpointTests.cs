using AutoFixture;
using Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;

namespace API.Tests;

public class LibraryEndpointTests
{
    Fixture fixture = new();

    [Fact]
    public async void CreateLibrary_HandleAsync_ReturnsCards()
    {
        // Arrange
        var mockLibraryService = Substitute.For<Application.Interfaces.ILibraryService>();
        var card = fixture.Create<Card>();
        mockLibraryService.CreateLibraryAsync().Returns([card]);

        // Act
        var result = await Features.Library.CreateLibrary.HandleAsync(mockLibraryService);

        // Assert
        var okResult = Assert.IsType<Ok<IEnumerable<Card>>>(result);
        var cards = okResult.Value;
        Assert.Single(cards);
        Assert.Equal(card.Name, cards.First().Name);

    }
}
