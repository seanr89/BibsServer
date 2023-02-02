// using Domain;

namespace Bibs.API.DTOs;

public record CreateClubDTO
{
    public string Name { get; set; }
    public bool Active { get; set; }
    public bool Private { get; set; }


    public override string ToString()
    {
        return base.ToString();
    }

    #region Implicit DTO

    // public static implicit operator Club(CreateClubDTO dto)
    // {
    //     return new Club(dto.Name, dto.Active, dto.Private);
    // }

    #endregion
}