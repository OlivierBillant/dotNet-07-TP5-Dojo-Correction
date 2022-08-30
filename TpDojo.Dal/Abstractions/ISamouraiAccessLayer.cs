namespace TpDojo.Dal.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpDojo.Dal.Entities;

public interface ISamouraiAccessLayer
{
    Task AddAsync(Samourai arme);
    Task<bool> ExistsAsync(int id);
    Task<List<Samourai>> GetAllAsync();
    Task<Samourai?> GetByIdAsync(int? id);
    Task RemoveAsync(int id);
    Task UpdateAsync(Samourai arme);

}
