namespace TpDojo.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TpDojo.Business;
using TpDojo.Business.Dto;
using TpDojo.Web.Models;

public class ArtMartiauxController : Controller
{
    private readonly ArtMartialService artMartialService;

    public ArtMartiauxController(ArtMartialService artMartialService)
    {
        this.artMartialService = artMartialService;
    }


    // GET: ArtMartiauxController
    public async Task<ActionResult> Index()
    {
        var artMartiaux = await this.artMartialService.GetArtMartiauxAsync();
        return this.View(ArtMartialViewModel.FromArtMartiaux(artMartiaux));
    }

    // GET: ArtMartiauxController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var artMartial = await this.artMartialService.GetArtMartialAsync(id);
        return this.View(ArtMartialViewModel.FromArtMartialDto(artMartial));
    }

    // GET: ArtMartiauxController/Create
    public ActionResult Create()
    {
        return this.View();
    }

    // POST: ArtMartiauxController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ArtMartialViewModel artMartialViewModel)
    {
        try
        {
            var artMartialToCreate = ArtMartialViewModel.ToArtMartialDto(artMartialViewModel);
            await this.artMartialService.AddArtMartialAsync(artMartialToCreate);
            return this.RedirectToAction(nameof(Index));
        }
        catch
        {
            return this.View();
        }
    }

    // GET: ArtMartiauxController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var artMartial = await this.artMartialService.GetArtMartialAsync(id);
        return this.View(ArtMartialViewModel.FromArtMartialDto(artMartial));
    }

    // POST: ArtMartiauxController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, ArtMartialViewModel artMartialViewModel)
    {
        try
        {
            var artMartialToUpdate = ArtMartialViewModel.ToArtMartialDto(artMartialViewModel);
            await this.artMartialService.UpdateArtMartialAsync(artMartialToUpdate);
            return this.RedirectToAction(nameof(Index));
        }
        catch
        {
            return this.View();
        }
    }

    // GET: ArtMartiauxController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var artMartial = await this.artMartialService.GetArtMartialAsync(id);
        return this.View(ArtMartialViewModel.FromArtMartialDto(artMartial));
    }

    // POST: ArtMartiauxController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection collection)
    {
        try
        {
            await this.artMartialService.RemoveArtMartialAsync(id);
            return this.RedirectToAction(nameof(Index));
        }
        catch
        {
            return this.View();
        }
    }
}
