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
using TpDojo.Blazor;
using TpDojo.Blazor.Shared;
using TpDojo.Blazor.ViewModels;
using TpDojo.Business;

namespace TpDojo.Blazor.Pages.Armes
{
    public partial class DetailsArmes
    {
        [Inject]
        public ArmeService armeService { get; set; } = null !;
        [Parameter]
        public int ArmeId { get; set; }

        private ArmeViewModel arme = new();
        protected override async Task OnInitializedAsync()
        {
            var armeDto = await this.armeService.GetArmeByIdAsync(ArmeId);
            this.arme = ArmeViewModel.FromArmeDto(armeDto);
        }
    }
}