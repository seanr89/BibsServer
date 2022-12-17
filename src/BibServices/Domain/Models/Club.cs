namespace Domain;

public class Club
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public bool Private { get; set; }

    public Club()
    {
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}