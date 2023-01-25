using System;
using System.Threading.Tasks;
using bitfit.DAL.IConfiguration;
using bitfit.DAL.IRepositories;
using bitfit.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace bitfit.DAL
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public IFoodRepository Foods { get; private set; }

        public IRecipeRepository Recipes { get; private set; }

        public IUserRepository Users { get; private set; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Foods = new FoodRepository(_context, _logger);
            Recipes = new RecipeRepository(_context, _logger);
            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
