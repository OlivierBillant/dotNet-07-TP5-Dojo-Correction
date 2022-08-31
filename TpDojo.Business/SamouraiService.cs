namespace TpDojo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Business.Dto;
using TpDojo.Dal.Abstractions;
using TpDojo.Dal.Entities;

public class SamouraiService
{
    private readonly ISamouraiAccessLayer samouraiAccessLayer;
    private readonly IArmeAccessLayer armeAccessLayer;
    private readonly IArtMartialAccessLayer artMartialAccessLayer;

    public SamouraiService(ISamouraiAccessLayer samouraiAccessLayer, IArmeAccessLayer armeAccessLayer, IArtMartialAccessLayer artMartialAccessLayer)
    {
        this.samouraiAccessLayer = samouraiAccessLayer;
        this.armeAccessLayer = armeAccessLayer;
        this.artMartialAccessLayer = artMartialAccessLayer;
    }

    public async Task<List<SamouraiDto>> GetSamouraisAsync()
    {
        var samourais = await this.samouraiAccessLayer.GetAllAsync();
        return SamouraiDto.FromSamourais(samourais);
    }

    public async Task<bool> SamouraiExistsAsync(int id)
        => await this.samouraiAccessLayer.ExistsAsync(id);

    public async Task<SamouraiDto> GetSamouraiByIdAsync(int? id)
    {
        var arme = await this.samouraiAccessLayer.GetByIdAsync(id);
        return SamouraiDto.FromSamourai(arme);
    }

    public async Task AddSamouraiAsync(SamouraiDto samouraiDto, int? armeId, List<int> artMartiauxIds)
    {        
        var samourai = SamouraiDto.ToSamourai(samouraiDto);
        
        // Recherche de l'arme correspondant à l'id.
        var arme = await this.armeAccessLayer.GetByIdAsync(armeId);

        if (arme is not null)
            samourai.Arme = arme;

        foreach (var artMartialId in artMartiauxIds)
        {
            var am = await this.artMartialAccessLayer.GetByIdAsync(artMartialId);
            if (am is not null)
                samourai.ArtMartiaux.Add(am);
        }


        await this.samouraiAccessLayer.AddAsync(samourai);
    }

    public async Task UpdateSamouraiAsync(SamouraiDto armeDto, int? id, List<int> artMartiauxIds)
    {
        var samourai = SamouraiDto.ToSamourai(armeDto);

        // Recherche de l'arme correspondant à l'id.
        var arme = await this.armeAccessLayer.GetByIdAsync(id);

        if (arme is not null)
            samourai.Arme = arme;

        foreach (var artMartialId in artMartiauxIds)
        {
            var am = await this.artMartialAccessLayer.GetByIdAsync(artMartialId);
            if (am is not null)
                samourai.ArtMartiaux.Add(am);
        }

        await this.samouraiAccessLayer.UpdateAsync(samourai);
    }

    public async Task RemoveSamouraiAsync(int id)
    {
        await this.samouraiAccessLayer.RemoveAsync(id);
    }

}
