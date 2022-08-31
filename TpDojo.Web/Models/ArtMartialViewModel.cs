namespace TpDojo.Web.Models;

using System.Collections.Generic;
using TpDojo.Business.Dto;

public class ArtMartialViewModel
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public List<SamouraiViewModel> Samourais { get; set; } = new();

    internal static ArtMartialViewModel? FromArtMartialDto(ArtMartialDto? artMartial)
    => artMartial is null
    ? null
    : new ArtMartialViewModel
    {
        Id = artMartial.Id,
        Nom = artMartial.Nom
    };

    internal static List<ArtMartialViewModel> FromArtMartiaux(List<ArtMartialDto> artMartiauxDtos)
        => artMartiauxDtos.Select(FromArtMartialDto).ToList();

    internal static ArtMartialDto ToArtMartialDto(ArtMartialViewModel artMartialViewModel)
        => new()
        {
            Id = artMartialViewModel.Id,
            Nom = artMartialViewModel.Nom
        };

}
