using bitfit.Model.Entities;

namespace bitfit.DAL.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByGuid(Guid id);
    }
}
