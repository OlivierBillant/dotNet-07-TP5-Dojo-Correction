namespace TpDojo.Dal.AccessLayer;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Dal.Abstractions;
using TpDojo.Dal.Entities;

internal class SamouraiAccessLayer : ISamouraiAccessLayer
{
    private readonly TpDojoContext context;

    public SamouraiAccessLayer(TpDojoContext context)
    {
        this.context = context;
    }

    public async Task<List<Samourai>> GetAllAsync()
        => await this.context.Samourai.Include(s => s.Arme).ToListAsync();

    public async Task<bool> ExistsAsync(int id)
        => await this.context.Samourai.AnyAsync(a => a.Id == id);

    public async Task<Samourai?> GetByIdAsync(int? id)
    => await this.context.Samourai.Include(s => s.Arme).FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Samourai arme)
    {
        this.context.Samourai.Add(arme);
        await this.context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Samourai samourai)
    {
        var samouraiToUpdate = await this.GetByIdAsync(samourai.Id);

        if (samouraiToUpdate is null)
            return;

        samouraiToUpdate.Nom = samourai.Nom;
        samouraiToUpdate.Force = samourai.Force;

        this.context.Update(samouraiToUpdate);
        await this.context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var samourai = await this.GetByIdAsync(id);
        if (samourai != null)
        {
            this.context.Samourai.Remove(samourai);
        }

        await this.context.SaveChangesAsync();
    }

}
