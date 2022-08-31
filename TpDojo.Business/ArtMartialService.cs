namespace TpDojo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Business.Dto;
using TpDojo.Dal.Abstractions;

public class ArtMartialService
{
    private readonly IArtMartialAccessLayer artMartialAccessLayer;

    public ArtMartialService(IArtMartialAccessLayer artMartialAccessLayer)
    {
        this.artMartialAccessLayer = artMartialAccessLayer;
    }

    public async Task AddArtMartialAsync(ArtMartialDto artMartialToCreate)
    {
        var artMartial = ArtMartialDto.ToArtMartial(artMartialToCreate);
        await this.artMartialAccessLayer.AddAsync(artMartial);
    }

    public async Task<ArtMartialDto?> GetArtMartialAsync(int id)
    {
        var artMartial = await this.artMartialAccessLayer.GetByIdAsync(id);
        return ArtMartialDto.FromArtMartial(artMartial);
    }

    public async Task<List<ArtMartialDto>> GetArtMartiauxAsync()
    {
        var artMartiaux = await this.artMartialAccessLayer.GetAllAsync();
        return ArtMartialDto.FromArtMartiaux(artMartiaux);
    }

    public async Task RemoveArtMartialAsync(int id)
    {
        await this.artMartialAccessLayer.RemoveAsync(id);
    }

    public async Task UpdateArtMartialAsync(ArtMartialDto artMartialToUpdate)
    {
        var artMartial = ArtMartialDto.ToArtMartial(artMartialToUpdate);
        await this.artMartialAccessLayer.UpdateAsync(artMartial);
    }
}
