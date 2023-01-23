using Domain;

namespace Bibs.API.DTOs;

public record ClubDTO
{
    public string Name { get; set; }
    public bool Active { get; set; }
    public bool Private { get; set; }

    // public override string ToString()
    // {
    //     return base.ToString();
    // }

    #region Implicit DTO Mapping

    public static implicit operator ClubDTO(Club model)
    {
        return new ClubDTO(){
            Name = model.Name,
            Active = model.Active,
            Private = model.Private
        };
    }

    #endregion
}