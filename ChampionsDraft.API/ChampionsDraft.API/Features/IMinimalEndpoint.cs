namespace API.Features;

public interface IMinimalEndpoint
{
    static abstract void MapEndpoint(RouteGroupBuilder heroRoute);
}