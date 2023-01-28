namespace Domain;

/// <summary>
/// New planned match record
/// TODO
/// </summary>
public record Match
{

    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }

    public Match()
    {
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}