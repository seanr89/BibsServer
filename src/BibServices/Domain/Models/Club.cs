namespace Domain;

public class Club : AuditableEntity
{

    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool Active { get; set; }
    public bool Private { get; set; }
    /// <summary>
    /// Collection of available members to pick
    /// </summary>
    /// <value></value>
    public ICollection<Member> Members { get; set; }

    public Club()
    {
    }

    #region overrides

    public override string? ToString()
    {
        return base.ToString();
    }

    #endregion
}