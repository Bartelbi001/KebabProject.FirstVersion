using KebabStore.Core.Models;

namespace KebabStore.DataAccess.Repositories
{
    public interface IKebabsRepository
    {
        Task<Guid> Create(Kebab kebab);
        Task<Guid> Delete(Guid id);
        Task<List<Kebab>> Get();
        Task<Guid> Update(Guid id, string name, string description, decimal price);
    }
}