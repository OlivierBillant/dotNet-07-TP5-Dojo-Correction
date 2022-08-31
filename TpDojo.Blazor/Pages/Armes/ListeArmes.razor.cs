namespace TpDojo.Blazor.Pages.Armes;

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TpDojo.Blazor.ViewModels;
using TpDojo.Business;

public partial class ListeArmes
{
    [Inject]
    public ArmeService ArmeService { get; set; } = null!;

    private List<ArmeViewModel> armes = new();

    protected override async Task OnInitializedAsync()
    {
        var armesDtos = await this.ArmeService.GetArmesAsync();
        this.armes = ArmeViewModel.FromArmes(armesDtos);
    }
}
