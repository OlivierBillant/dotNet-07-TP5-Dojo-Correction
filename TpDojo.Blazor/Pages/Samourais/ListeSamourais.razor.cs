namespace TpDojo.Blazor.Pages.Samourais;

using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TpDojo.Blazor.ViewModels;
using TpDojo.Business;

public partial class ListeSamourais
{
    [Inject]
    public SamouraiService SamouraiService { get; set; } = null!;

    private List<SamouraiViewModel> samourais = new();

    protected override async Task OnInitializedAsync()
    {
        var samouraiDtos = await this.SamouraiService.GetSamouraisAsync();
        this.samourais = SamouraiViewModel.FromSamourais(samouraiDtos);
    }
}
