namespace TpDojo.Business;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TpDojo.Business.Dto;
using TpDojo.Dal.Abstractions;

public class ArmeService
{
    private readonly IArmeAccessLayer armeAccessLayer;
    private readonly ISamouraiAccessLayer samouraiAccessLayer;

    public ArmeService(IArmeAccessLayer armeAccessLayer, ISamouraiAccessLayer samouraiAccessLayer)
    {
        this.armeAccessLayer = armeAccessLayer;
        this.samouraiAccessLayer = samouraiAccessLayer;
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

    public async Task<bool> RemoveArmeAsync(int id)
    {
        var hasSamouraiAssociated = await this.armeAccessLayer.HasSamouraiAssociated(id);

        if (hasSamouraiAssociated)
        {
            return false;
        }

        await this.armeAccessLayer.RemoveAsync(id);
        return true;

    }

    public async Task<List<ArmeDto>> GetArmesWithoutSamouraiAsync()
    {
        return ArmeDto.FromArmes(await this.armeAccessLayer.GetAllAsync());
    }

    public async Task<List<ArmeDto>> GetArmesWithoutSamouraiAsync2()
    {
        var samourais = await this.samouraiAccessLayer.GetAllAsync();
        var armes = await this.armeAccessLayer.GetAllAsync();

        var armeWithoutSamourai = armes.Where(a => samourais.All(s => s.Arme?.Id != a.Id));

        return ArmeDto.FromArmes(armeWithoutSamourai);
    }

    public async Task<bool> HasAssociatedSamourai(int id)
        => await this.armeAccessLayer.HasSamouraiAssociated(id);
}
