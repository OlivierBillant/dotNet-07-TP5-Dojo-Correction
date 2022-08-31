namespace TpDojo.Business.Dto;

using System.Collections.Generic;
using TpDojo.Dal.Entities;

public class ArtMartialDto
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public List<SamouraiDto> Samourais { get; set; }

    internal static ArtMartialDto? FromArtMartial(ArtMartial? artMartial)
    => artMartial is null
    ? null
    : new ()
    {
        Id = artMartial.Id,
        Nom = artMartial.Nom
    };

    internal static List<ArtMartialDto> FromArtMartiaux(IEnumerable<ArtMartial> artMartiaux)
        => artMartiaux.Select(FromArtMartial).ToList();

    internal static ArtMartial ToArtMartial(ArtMartialDto artMartialDto)
        => new()
        {
            Id = artMartialDto.Id,
            Nom = artMartialDto.Nom
        };

}
