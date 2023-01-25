using bitfit.DAL.IRepositories;
using bitfit.Model.Entities;

namespace bitfit.DAL.IServices
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByGuid(Guid id);
    }
}
