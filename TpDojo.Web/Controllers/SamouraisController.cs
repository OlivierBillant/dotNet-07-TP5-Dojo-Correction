namespace TpDojo.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TpDojo.Business;
using TpDojo.Business.Dto;
using TpDojo.Web.Models;

public class SamouraisController : Controller
{
    private readonly SamouraiService samouraiService;
    private readonly ArmeService armeService;

    public SamouraisController(SamouraiService samouraiService, ArmeService armeService)
    {
        this.samouraiService = samouraiService;
        this.armeService = armeService;
    }

    // GET: Samourais
    public async Task<IActionResult> Index()
    {
        var samouraiDtos = await this.samouraiService.GetSamouraisAsync();
        var armes = SamouraiViewModel.FromSamourais(samouraiDtos);
        return this.View(armes);
    }

    // GET: Samourais/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var samouraiDto = await this.samouraiService.GetSamouraiByIdAsync(id);
        if (samouraiDto == null)
        {
            return this.NotFound();
        }

        return this.View(SamouraiViewModel.FromSamouraiDto(samouraiDto));
    }

    // GET: Samourais/Create
    public async Task<IActionResult> CreateAsync()
    {
        this.ViewData["armes"] = ArmeViewModel.FromArmes(await armeService.GetArmesAsync());
        return this.View();
    }

    // POST: Samourais/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SamouraiFormViewModel samouraiFormViewModel)
    {
        if (this.ModelState.IsValid)
        {
            var samouraiDto = SamouraiFormViewModel.ToSamouraiDto(samouraiFormViewModel);

            await this.samouraiService.AddSamouraiAsync(samouraiDto, samouraiFormViewModel.ArmeId);
            return this.RedirectToAction(nameof(Index));
        }
        return this.View(samouraiFormViewModel);
    }

    // GET: Samourais/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        this.ViewData["armes"] = ArmeViewModel.FromArmes(await armeService.GetArmesAsync());
        var samouraiDto = await this.samouraiService.GetSamouraiByIdAsync(id);
        if (samouraiDto == null)
        {
            return this.NotFound();
        }
        return this.View(SamouraiFormViewModel.FromSamouraiDto(samouraiDto));
    }

    // POST: Samourais/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SamouraiFormViewModel samourai)
    {
        if (id != samourai.Id)
        {
            return this.NotFound();
        }

        if (this.ModelState.IsValid)
        {
            try
            {
                await this.samouraiService.UpdateSamouraiAsync(SamouraiFormViewModel.ToSamouraiDto(samourai), samourai.ArmeId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.SamouraiExists(samourai.Id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }
            return this.RedirectToAction(nameof(Index));
        }
        return this.View(samourai);
    }

    // GET: Samourais/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var samourai = await this.samouraiService.GetSamouraiByIdAsync(id);
        if (samourai == null)
        {
            return this.NotFound();
        }

        return this.View(samourai);
    }

    // POST: Samourais/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await this.samouraiService.RemoveSamouraiAsync(id);
        return this.RedirectToAction(nameof(Index));
    }

    private async Task<bool> SamouraiExists(int id)
    {
        return await this.samouraiService.SamouraiExistsAsync(id);
    }
}
