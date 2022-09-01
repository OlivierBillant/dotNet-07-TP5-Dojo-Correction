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

namespace TpDojo.Blazor.Pages.Samourais
{
    public partial class DetailsSamourais
    {
        [Inject]
        public SamouraiService samouraiService { get; set; } = null !;
        [Parameter]
        public int SamouraiId { get; set; }

        private SamouraiViewModel samourai = new();
        protected override async Task OnInitializedAsync()
        {
            var samouraiDto = await this.samouraiService.GetSamouraiByIdAsync(SamouraiId);
            this.samourai = SamouraiViewModel.FromSamouraiDto(samouraiDto);
        }
    }
}