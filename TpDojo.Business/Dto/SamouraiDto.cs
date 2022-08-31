
namespace TpDojo.Business.Dto;

using TpDojo.Dal.Entities;

public class SamouraiDto
{
    public int Id { get; set; }
    public int Force { get; set; }
    public string Nom { get; set; }
    public ArmeDto? Arme { get; set; }
    public List<ArtMartialDto> ArtMartiaux { get; set; } = new();

    internal static SamouraiDto FromSamourai(Samourai? samourai)
        => samourai is null
        ? new()
        : new SamouraiDto { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force, Arme = ArmeDto.FromArme(samourai.Arme), ArtMartiaux = ArtMartialDto.FromArtMartiaux(samourai.ArtMartiaux)};

    internal static List<SamouraiDto> FromSamourais(List<Samourai> samourais)
        => samourais.Select(FromSamourai).ToList();

    internal static Samourai ToSamourai(SamouraiDto samouraiDto)
        => new() { Id = samouraiDto.Id, Nom = samouraiDto.Nom, Force = samouraiDto.Force };

}
