namespace TpDojo.Web.Models;

using TpDojo.Business.Dto;
using TpDojo.Dal.Entities;

public class ArmeViewModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Degats { get; set; }
    public string Display => $"{this.Nom} ({this.Degats})";

    internal static ArmeViewModel? FromArmeDto(ArmeDto? arme)
        => arme is null
        ? null
        : new ArmeViewModel { Id = arme.Id, Nom = arme.Nom, Degats = arme.Degats };

    internal static List<ArmeViewModel> FromArmes(List<ArmeDto> armeDtos)
        => armeDtos.Select(FromArmeDto).ToList();

    internal static ArmeDto ToArmeDto(ArmeViewModel armeViewModel)
        => new() { Id = armeViewModel.Id, Nom = armeViewModel.Nom, Degats = armeViewModel.Degats };

}