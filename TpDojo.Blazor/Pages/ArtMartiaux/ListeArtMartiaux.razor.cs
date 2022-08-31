namespace TpDojo.Blazor.Pages.ArtMartiaux;

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TpDojo.Blazor.ViewModels;
using TpDojo.Business;

public partial class ListeArtMartiaux
{
    [Inject]
    public ArtMartialService ArtMartialService { get; set; } = null!;

    private List<ArtMartialViewModel> artMartiaux = new();

    protected override async Task OnInitializedAsync()
    {
        var artMartiauxDtos = await this.ArtMartialService.GetArtMartiauxAsync();
        this.artMartiaux = ArtMartialViewModel.FromArtMartiaux(artMartiauxDtos);
    }

    public void ToRowEdit(int artMartialId)
    {
        artMartiaux.First(am => am.Id == artMartialId).Editing = true;
    }
    public async Task ValidateRowAsync(int artMartialId)
    {
        var artMartialViewModel = artMartiaux.First(am => am.Id == artMartialId);
        artMartialViewModel.Editing = false;

        await this.ArtMartialService.UpdateArtMartialAsync(ArtMartialViewModel.ToArtMartialDto(artMartialViewModel));

    }
}
