namespace Domain;

public class Club : AuditableEntity
{

    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public bool Active { get; private set; }
    public bool Private { get; private set; }
    /// <summary>
    /// Collection of available members to pick
    /// </summary>
    /// <value></value>
    public ICollection<Member> Members { get; set; }

    public Club()
    {
    }

    public Club(string name, bool isActive, bool isPrivate)
    {
        Name = name;
        Active = isActive;
        Private = isPrivate;
    }

    #region setters

    public void Activate() => this.Active = true;
    public void DeActivate() => this.Active = false;

    #endregion

    #region overrides

    public override string? ToString()
    {
        return base.ToString();
    }

    #endregion
}