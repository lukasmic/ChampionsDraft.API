using Domain;

namespace API.DTOs;

public class GetSessionDTO
{
    public required string SessionId { get; set; }
    public required string Hero { get; set; }

    public static GetSessionDTO FromSession(Session session)
    {
        return new GetSessionDTO
        {
            SessionId = session.Id.ToString(),
            Hero = session.Hero
        };
    }
}
