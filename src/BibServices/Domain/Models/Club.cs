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

    /// <summary>
    /// Supports single member addition
    /// </summary>
    /// <param name="member">Single Member object</param>
    public void AddMember(Member member)
    {
        if (member != null && CheckForDuplicateMember(member) == false)
            this.Members.Add(member);
    }

    #endregion

    #region overrides

    public override string? ToString()
    {
        return base.ToString();
    }

    #endregion

    #region private helpers

    /// <summary>
    /// Simple private operation to check if the record already matches one in the list
    /// </summary>
    /// <param name="mem">Member object to search</param>
    /// <returns>True if member with email already exists
    /// False if not</returns>
    bool CheckForDuplicateMember(Member mem)
    {
        return this.Members.Any(m => m.Email == mem.Email);
    }

    #endregion
}