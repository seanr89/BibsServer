namespace Domain;
/// <summary>
/// Domain for pre-selectable Club member selection
/// So that manual player entry does not need to occur
/// /// </summary>
public class Member : AuditableEntity
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public Club Club { get; private set; }
    public double BaseRating { get; set; }

    #region Constructors

    private Member(){}

    public Member(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("record must contain an email!");
        this.Email = email;
    }

    public Member(string email, string name) : this(email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("record must contain a name!");
        this.Name = name;
    }

    public Member(string email, string name, bool active) : this(email, name)
    {
        this.Active = active;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="csvLine">id,name,email,active,baserating</param>
    /// <returns></returns>
    public static Member FromCsv(string csvLine)
    {
        Member rec = new Member();
        string[] values = csvLine.Split(',');
        rec.Name = values[1];
        rec.Email = values[2];
        rec.Active = Convert.ToBoolean(values[3]);
        rec.BaseRating = Convert.ToDouble(values[4]);
        return rec;
    }

    #endregion

    #region Setters

    /// <summary>
    /// Provides the updating of a members name
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="System.ArgumentException">Thrown when name is null or whitespace</exception>
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name must not be null or whitespace");
        this.Name = name;
    }

    /// <summary>
    /// Provides the updating of a members email
    /// </summary>
    /// <param name="email"></param>
    /// <exception cref="System.ArgumentException">Thrown when email is null or whitespace</exception>
    public void UpdateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("email must not be null or whitespace");
        this.Email = email;
    }

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