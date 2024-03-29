using Domain;

namespace Bibs.API.DTOs;

public record MemberDTO
{
    public Guid Id { get; private set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
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

    public static implicit operator Member(MemberDTO model)
    {
        return new Member(
            model.Email,
            model.Name,
            model.Active,
            model.BaseRating);
    }

    #endregion
}