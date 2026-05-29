namespace ChampionsDraft.Shared.Models;

public enum ErrorType
{
    BadRequest,
    NotFound,
    Conflict
}

public record Error(string Description, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, ErrorType.BadRequest);
}
