namespace Domain;

/// <summary>
/// Event based record to handle match details, teams and invites
/// TODO
/// </summary>
public record Event
{

    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Location { get; private set; }
    public bool Private { get; private set; }
    public EventStatus Status { get; set; }

    public Event()
    {
    }

    #region overrides

    public override string? ToString()
    {
        return base.ToString();
        //return String.Format("Name:{0}, Type:{1}",Key,Type);
    }

    #endregion
}