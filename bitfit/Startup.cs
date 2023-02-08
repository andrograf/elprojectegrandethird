using bitfit.DAL;
using bitfit.DAL.IRepositories;
using bitfit.DAL.IServices;
using bitfit.DAL.Repositories;
using bitfit.DAL.Servies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace bitfit
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void RunSqlAtStart(string file, IConfiguration Configuration)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string commandText = File.ReadAllText($@".\Migrations\{file}");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // Add All Transients here
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IFoodService, FoodService>();
            services.AddTransient<IUserService, UserService>();

            // Target react proxy as frontend
            services.AddTransient<IChallengeService, ChallengeService>();

            services.AddCors(options =>
            {
                var frontEndURL = Configuration.GetValue<string>("FrontEndUrl");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontEndURL).AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddMvc().AddControllersAsServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
            }
            //RunSqlAtStart("20230124213442_bitfit.sql", Configuration);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors();
            

            app.UseRouting();

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
