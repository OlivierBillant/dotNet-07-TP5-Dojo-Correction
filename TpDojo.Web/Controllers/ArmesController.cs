namespace TpDojo.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TpDojo.Business;
using TpDojo.Web.Models;

public class ArmesController : Controller
{
    private readonly ArmeService armeService;

    public ArmesController(ArmeService armeService) => this.armeService = armeService;

    // GET: Armes
    public async Task<IActionResult> Index()
    {
        var armeDtos = await this.armeService.GetArmesAsync();
        var armes = ArmeViewModel.FromArmes(armeDtos);
        return this.View(armes);
    }

    // GET: Armes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var arme = await this.armeService.GetArmeByIdAsync(id);
        if (arme == null)
        {
            return this.NotFound();
        }

        return this.View(ArmeViewModel.FromArmeDto(arme));
    }

    // GET: Armes/Create
    public IActionResult Create()
    {
        return this.View();
    }

    // POST: Armes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArmeViewModel arme)
    {
        if (this.ModelState.IsValid)
        {
            await this.armeService.AddArmeAsync(ArmeViewModel.ToArmeDto(arme));
            return this.RedirectToAction(nameof(Index));
        }
        return this.View(arme);
    }

    // GET: Armes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var arme = await this.armeService.GetArmeByIdAsync(id);
        if (arme == null)
        {
            return this.NotFound();
        }
        return this.View(ArmeViewModel.FromArmeDto(arme));
    }

    // POST: Armes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ArmeViewModel arme)
    {
        if (id != arme.Id)
        {
            return this.NotFound();
        }

        if (this.ModelState.IsValid)
        {
            try
            {

                var armeDto = ArmeViewModel.ToArmeDto(arme);
                await this.armeService.UpdateArmeAsync(armeDto);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.ArmeExistsAsync(arme.Id))
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
        return this.View(arme);
    }

    // GET: Armes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return this.NotFound();
        }

        var arme = await this.armeService.GetArmeByIdAsync(id);
        if (arme == null)
        {
            return this.NotFound();
        }

        return this.View(ArmeViewModel.FromArmeDto(arme));
    }

    // POST: Armes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await this.armeService.RemoveArmeAsync(id);
        if (!result)
        {
            this.ModelState.AddModelError("", "L'arme est associée à un samourai, veuillez supprimer la relation");
            var arme = await this.armeService.GetArmeByIdAsync(id);

            return this.View(ArmeViewModel.FromArmeDto(arme));
        }
        return this.RedirectToAction(nameof(Index));
    }

    private async Task<bool> ArmeExistsAsync(int id)
    {
        return await this.armeService.ArmeExistsAsync(id);
    }
}
