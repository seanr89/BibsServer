

using Domain;

namespace Bibs.API.DTOs;

public class MemberDTO
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public double BaseRating { get; set; }

    #region Implicit DTO Mapping

    public static implicit operator MemberDTO(Member model)
    {
        return new MemberDTO(){
            Name = model.Name,
            Email = model.Email,
            Active = model.Active,
            BaseRating = model.BaseRating
        };
    }

    #endregion
}