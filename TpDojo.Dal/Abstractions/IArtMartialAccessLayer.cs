namespace TpDojo.Dal.Abstractions;

using System.Collections.Generic;
using System.Threading.Tasks;
using TpDojo.Dal.Entities;

public interface IArtMartialAccessLayer
{
    Task AddAsync(ArtMartial arme);
    Task<bool> ExistsAsync(int id);
    Task<List<ArtMartial>> GetAllAsync();
    Task<ArtMartial?> GetByIdAsync(int? id);
    Task RemoveAsync(int id);
    Task UpdateAsync(ArtMartial arme);
}