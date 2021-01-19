using System.Threading.Tasks;

namespace BE.Domain.Objects
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}