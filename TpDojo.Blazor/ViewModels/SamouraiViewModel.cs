namespace TpDojo.Blazor.ViewModels;

using System.ComponentModel.DataAnnotations;
using TpDojo.Business.Dto;

public class SamouraiViewModel
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public int Force { get; set; }

    public ArmeViewModel? Arme { get; set; }

    [Display(Name = "Art martiaux maitrisés")]
    public List<ArtMartialViewModel> ArtMartiaux { get; set; } = new();

    [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
    public int Potentiel 
        => (this.Force + (this.Arme?.Degats ?? 0)) * this.ArtMartiaux.Count + 1;

    public string ArmeDisplay => this.Arme switch
    {
        null => "Aucune arme",
        { Degats: < 30 } => "Arme inutile",
        _ => this.Arme.Display
    };

    public string ArtMartiauxDisplay => $"{string.Join(", ", this.ArtMartiaux.Take(10).Select(am => am.Nom))} {this.ArtMartiauxSurplu}";
    private string ArtMartiauxSurplu => this.ArtMartiaux.Count > 10 ? $"({this.ArtMartiaux.Count - 10} autre(s))" : string.Empty;
    
    internal static SamouraiViewModel FromSamouraiDto(SamouraiDto? samourai)
        => samourai is null
        ? new()
        : new SamouraiViewModel { Id = samourai.Id, Nom = samourai.Nom, Force = samourai.Force, Arme = ArmeViewModel.FromArmeDto(samourai.Arme), ArtMartiaux = ArtMartialViewModel.FromArtMartiaux(samourai.ArtMartiaux) };

    internal static List<SamouraiViewModel> FromSamourais(List<SamouraiDto> samouraiDtos)
        => samouraiDtos.Select(FromSamouraiDto).ToList();

    internal static SamouraiDto ToSamouraiDto(SamouraiViewModel samouraiViewModel)
        => new() { Id = samouraiViewModel.Id, Nom = samouraiViewModel.Nom, Force = samouraiViewModel.Force };

}
