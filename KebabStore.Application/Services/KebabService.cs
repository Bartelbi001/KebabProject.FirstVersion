using KebabStore.Core.Models;
using KebabStore.DataAccess.Repositories;

namespace KebabStore.Application.Services;

public class KebabService : IKebabsService
{
    private readonly IKebabsRepository _kebabsRepository;

    public KebabService(IKebabsRepository kebabsRepository)
    {
        _kebabsRepository = kebabsRepository;
    }

    public async Task<List<Kebab>> GetAllKebabs()
    {
        return await _kebabsRepository.Get();
    }

    public async Task<Guid> CreateKebab(Kebab kebab)
    {
        return await _kebabsRepository.Create(kebab);
    }

    public async Task<Guid> UpdateKebab(Guid id, string name, string description, decimal price)
    {
        return await _kebabsRepository.Update(id, name, description, price);
    }

    public async Task<Guid> DeleteKebab(Guid id)
    {
        return await _kebabsRepository.Delete(id);
    }
}