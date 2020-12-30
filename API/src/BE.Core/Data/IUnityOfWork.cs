using System.Threading.Tasks;

namespace BE.Core.DomainObjects
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}