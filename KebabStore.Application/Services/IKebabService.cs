using KebabStore.Core.Models;

namespace KebabStore.Application.Services;

public interface IKebabService // Должен быть в Core-Abstractions
{
    Task<Guid> CreateKebab(Kebab kebab);
    Task<Guid> DeleteKebab(Guid id);
    Task<List<Kebab>> GetAllKebabs();
    Task<Guid> UpdateKebab(Guid id, string name, string description, decimal price);
}