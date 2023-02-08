using bitfit.DAL.IRepositories;
using bitfit.Model.Entities;

namespace bitfit.DAL.IServices
{
    public interface IChallengeService : IService<Challenge>
    {
        Challenge GenerateChart(ChallengeSettings settings);
    }
}
