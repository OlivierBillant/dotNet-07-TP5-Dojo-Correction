namespace TpDojo.Dal.AccessLayer;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Dal.Abstractions;
using TpDojo.Dal.Entities;

internal class ArtMartialAccessLayer : IArtMartialAccessLayer
{
    private readonly TpDojoContext context;

    public ArtMartialAccessLayer(TpDojoContext context)
        => this.context = context;

    public async Task<List<ArtMartial>> GetAllAsync()
        => await this.context.ArtMartiaux.Include(a => a.Samourais).ToListAsync();

    public async Task<bool> ExistsAsync(int id)
        => await this.context.ArtMartiaux.AnyAsync(a => a.Id == id);

    public async Task<ArtMartial?> GetByIdAsync(int? id)
    => await this.context.ArtMartiaux.FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(ArtMartial artMartial)
    {
        this.context.Add(artMartial);
        await this.context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ArtMartial artMartial)
    {
        var artMartialToUpdate = await this.GetByIdAsync(artMartial.Id);

        if (artMartialToUpdate is null)
            return;
        
        artMartialToUpdate.Nom = artMartial.Nom;

        this.context.Update(artMartialToUpdate);
        await this.context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var artMartial = await this.GetByIdAsync(id);
        if (artMartial != null)
        {
            this.context.ArtMartiaux.Remove(artMartial);
        }

        await this.context.SaveChangesAsync();
    }

}
