namespace TpDojo.Business;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TpDojo.Business.Dto;
using TpDojo.Dal.Abstractions;

public class ArmeService
{
    private readonly IArmeAccessLayer armeAccessLayer;

    public ArmeService(IArmeAccessLayer armeAccessLayer)
    {
        this.armeAccessLayer = armeAccessLayer;
    }

    public async Task<List<ArmeDto>> GetArmesAsync()
    {
        var armes = await this.armeAccessLayer.GetAllAsync();
        return ArmeDto.FromArmes(armes);
    }

    public async Task<bool> ArmeExistsAsync(int id)
        => await this.armeAccessLayer.ExistsAsync(id);

    public async Task<ArmeDto> GetArmeByIdAsync(int? id)
    {
        var arme = await this.armeAccessLayer.GetByIdAsync(id);
        return ArmeDto.FromArme(arme);
    }

    public async Task AddArmeAsync(ArmeDto armeDto)
    {
        var arme = ArmeDto.ToArme(armeDto);
        await this.armeAccessLayer.AddAsync(arme);
    }

    public async Task UpdateArmeAsync(ArmeDto armeDto)
    {
        var arme = ArmeDto.ToArme(armeDto);
        await this.armeAccessLayer.UpdateAsync(arme);
    }

    public async Task RemoveArmeAsync(int id)
    {
        await this.armeAccessLayer.RemoveAsync(id);
    }
}
