using System.Threading.Tasks;

namespace SOModule.Domain.Core.Interfaces.Services
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}