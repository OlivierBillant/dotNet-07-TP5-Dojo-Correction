namespace TpDojo.Blazor.ViewModels;

using System.ComponentModel.DataAnnotations;
using TpDojo.Business.Dto;
using TpDojo.Dal.Entities;

public class ArmeViewModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Degats { get; set; }

    [Display(Name = "Image")]
    public string? ImageUrl { get; set; }


    public string Display => $"{this.Nom} ({this.Degats})";

    public bool CanDelete { get; set; }

    internal static ArmeViewModel? FromArmeDto(ArmeDto? arme)
        => arme is null
        ? null
        : new ArmeViewModel
        {
            Id = arme.Id,
            Nom = arme.Nom,
            Degats = arme.Degats,
            ImageUrl = arme.ImageUrl,
            CanDelete = !arme.HasAssociatedSamourai
        };

    internal static List<ArmeViewModel> FromArmes(List<ArmeDto> armeDtos)
        => armeDtos.Select(FromArmeDto).ToList();

    internal static ArmeDto ToArmeDto(ArmeViewModel armeViewModel)
        => new()
        {
            Id = armeViewModel.Id,
            Nom = armeViewModel.Nom,
            Degats = armeViewModel.Degats,
            ImageUrl = armeViewModel.ImageUrl,
        };

}