namespace TpDojo.Web.Models;

using TpDojo.Business.Dto;

public class SamouraiViewModel
{
    public int Id { get; set; }
    public int Force { get; set; }
    public string Nom { get; set; }
    public virtual ArmeViewModel? Arme { get; set; }
    public string ArmeDisplay => this.Arme switch
    {
        null => "Aucune arme",
        _ => this.Arme.Display
    };

    internal static SamouraiViewModel FromSamouraiDto(SamouraiDto? samourai)
        => samourai is null
        ? new()
        : new SamouraiViewModel { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force, Arme = ArmeViewModel.FromArmeDto(samourai.ArmeDto) };

    internal static List<SamouraiViewModel> FromSamourais(List<SamouraiDto> samouraiDtos)
        => samouraiDtos.Select(FromSamouraiDto).ToList();

    internal static SamouraiDto ToSamouraiDto(SamouraiViewModel samouraiViewModel)
        => new() { Id = samouraiViewModel.Id, Nom = samouraiViewModel.Nom, Force = samouraiViewModel.Force };

}
