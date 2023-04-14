namespace Domain;

public record Invite
{
    public string Email { get; set; }
    public string UniqueCode { get; set; }
}