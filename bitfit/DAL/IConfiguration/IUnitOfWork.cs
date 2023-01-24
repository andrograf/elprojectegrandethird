using System.Threading.Tasks;
using bitfit.DAL.IRepositories;

namespace bitfit.DAL.IConfiguration
{
    public interface IUnitOfWork
    {
        IRecipeRepository Recipes { get; }

        IFoodRepository Foods { get; }

        Task CompleteAsync();
    }
}
