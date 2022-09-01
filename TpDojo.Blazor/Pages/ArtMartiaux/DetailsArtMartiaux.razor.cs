using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using TpDojo.Blazor.Shared;
using TpDojo.Blazor.ViewModels;
using TpDojo.Business;

namespace TpDojo.Blazor.Pages.ArtMartiaux
{
    public partial class DetailsArtMartiaux
    {
        [Inject]
        public ArtMartialService artMartialService { get; set; } = null!;
        [Parameter]
        public int ArtMartialId { get; set; }

        private ArtMartialViewModel artMartial = new();
        protected override async Task OnInitializedAsync()
        {
            var artMartialDto = await artMartialService.GetArtMartialAsync(ArtMartialId);
            artMartial = ArtMartialViewModel.FromArtMartialDto(artMartialDto);
        }
    }
}