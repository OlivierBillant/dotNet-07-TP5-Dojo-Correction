namespace TpDojo.Web.Models;

using TpDojo.Business.Dto;

public class SamouraiFormViewModel
{
    public int Id { get; set; }
    public int Force { get; set; }
    public string Nom { get; set; }
    public int? ArmeId { get; set; }

    public static SamouraiFormViewModel FromSamouraiDto(SamouraiDto samouraiDto)
        => new()
        {
            Id = samouraiDto.Id,
            Force = samouraiDto.Force,
            Nom = samouraiDto.Nom,
            ArmeId = samouraiDto.ArmeDto.Id
        };

    internal static SamouraiDto ToSamouraiDto(SamouraiFormViewModel samouraiFormViewModel)
       => new() { Id = samouraiFormViewModel.Id, Nom = samouraiFormViewModel.Nom, Force = samouraiFormViewModel.Force };
}
