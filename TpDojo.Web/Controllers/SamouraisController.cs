namespace TpDojo.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TpDojo.Business;
using TpDojo.Web.Models;

public class SamouraisController : Controller
{
    private readonly SamouraiService samouraiService;

    public SamouraisController(SamouraiService samouraiService)
    {
        this.samouraiService = samouraiService;
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

        var samourai = await this.samouraiService.GetSamouraiByIdAsync(id);
        if (samourai == null)
        {
            return this.NotFound();
        }

        return this.View(samourai);
    }

    // GET: Samourais/Create
    public IActionResult Create()
    {
        return this.View();
    }

    // POST: Samourais/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SamouraiViewModel samourai)
    {
        if (this.ModelState.IsValid)
        {
            await this.samouraiService.AddSamouraiAsync(SamouraiViewModel.ToSamouraiDto(samourai));
            return this.RedirectToAction(nameof(Index));
        }
        return this.View(samourai);
    }

    // GET: Samourais/Edit/5
    public async Task<IActionResult> Edit(int? id)
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

    // POST: Samourais/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SamouraiViewModel samourai)
    {
        if (id != samourai.Id)
        {
            return this.NotFound();
        }

        if (this.ModelState.IsValid)
        {
            try
            {
                await this.samouraiService.UpdateSamouraiAsync(SamouraiViewModel.ToSamouraiDto(samourai));
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
