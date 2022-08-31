namespace TpDojo.Dal.AccessLayer;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Dal.Abstractions;
using TpDojo.Dal.Entities;

internal class ArmeAccessLayer : IArmeAccessLayer
{
    private readonly TpDojoContext context;

    public ArmeAccessLayer(TpDojoContext context) => this.context = context;

    public async Task<List<Arme>> GetAllAsync()
        => await this.context.Arme.Include(a => a.Samourai).ToListAsync();

    public async Task<bool> ExistsAsync(int id)
        => await this.context.Arme.AnyAsync(a => a.Id == id);

    public async Task<Arme?> GetByIdAsync(int? id)
    => await this.context.Arme.FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Arme arme)
    {
        this.context.Add(arme);
        await this.context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Arme arme)
    {
        var armeToUpdate = await this.GetByIdAsync(arme.Id);

        if (armeToUpdate is null)
            return;
        
        armeToUpdate.Nom = arme.Nom;
        armeToUpdate.Degats = arme.Degats;
        armeToUpdate.ImageUrl = arme.ImageUrl;

        this.context.Update(armeToUpdate);
        await this.context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var arme = await this.GetByIdAsync(id);
        if (arme != null)
        {
            this.context.Arme.Remove(arme);
        }

        await this.context.SaveChangesAsync();
    }

    public async Task<List<Arme>> GetArmesWithoutSamouraiAsync()
        => await this.context.Arme.Where(a => a.Samourai == null).ToListAsync();

    public async Task<bool> HasSamouraiAssociated(int id)
        => await this.context.Arme.AnyAsync(a => a.Id == id && a.Samourai != null);
}
