﻿namespace TpDojo.Dal.Abstractions;

using System.Collections.Generic;
using System.Threading.Tasks;
using TpDojo.Dal.Entities;

public interface IArmeAccessLayer
{
    Task AddAsync(Arme arme);
    Task<bool> ExistsAsync(int id);
    Task<List<Arme>> GetAllAsync();
    Task<List<Arme>> GetArmesWithoutSamouraiAsync();
    Task<Arme?> GetByIdAsync(int? id);
    Task<bool> HasSamouraiAssociated(int id);
    Task RemoveAsync(int id);
    Task UpdateAsync(Arme arme);
}