
namespace Bibs.API.Extensions;

public class PostgreSettings
{
    public string ConnectionString { get; set; }
    public bool Migrate { get; set; }
    public bool SeedData { get; set; }
}