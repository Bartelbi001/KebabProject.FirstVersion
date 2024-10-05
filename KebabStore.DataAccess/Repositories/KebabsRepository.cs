using KebabStore.Core.Models;
using KebabStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KebabStore.DataAccess.Repositories;

public class KebabsRepository : IKebabsRepository
{
    private readonly KebabStoreDbContext _context;

    public KebabsRepository(KebabStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Kebab>> Get()
    {
        var kebabsEntities = await _context.Kebabs
            .AsNoTracking()
            .ToListAsync();

        var kebabs = kebabsEntities
            .Select(k => Kebab.Create(k.Id, k.Name, k.Description, k.Price).Kebab)
            .ToList();

        return kebabs;
    }

    public async Task<Guid> Create(Kebab kebab)
    {
        var kebabEntity = new KebabEntity
        {
            Id = kebab.Id,
            Name = kebab.Name,
            Description = kebab.Description,
            Price = kebab.Price
        };

        await _context.Kebabs.AddAsync(kebabEntity);
        await _context.SaveChangesAsync();

        return kebabEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, string description, decimal price)
    {
        await _context.Kebabs
            .Where(k => k.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(k => k.Name, k => name)
                .SetProperty(k => k.Description, k => description)
                .SetProperty(k => k.Price, k => price));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Kebabs
            .Where(k => k.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}
