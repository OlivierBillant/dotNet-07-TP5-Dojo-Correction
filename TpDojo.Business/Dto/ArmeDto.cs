namespace TpDojo.Business.Dto;

using System;
using TpDojo.Dal.Entities;

public class ArmeDto
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Degats { get; set; }

    public string? ImageUrl { get; set; }

    public bool HasAssociatedSamourai { get; set; }

    internal static ArmeDto? FromArme(Arme? arme)
        => arme is null 
        ? null
        : new ArmeDto { 
            Id = arme.Id, 
            Nom = arme.Nom, 
            Degats = arme.Degats,
            ImageUrl = arme.ImageUrl,
            HasAssociatedSamourai = arme.Samourai != null
        };

    internal static List<ArmeDto> FromArmes(IEnumerable<Arme> armes)
        => armes.Select(FromArme).ToList();

    internal static Arme ToArme(ArmeDto armeDto) 
        => new() { 
            Id = armeDto.Id, 
            Nom = armeDto.Nom, 
            Degats = armeDto.Degats,
            ImageUrl = armeDto.ImageUrl
        };
}