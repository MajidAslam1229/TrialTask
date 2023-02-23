using TrialTask.Entities;
using Microsoft.EntityFrameworkCore;
using TiralTask.Repository.Services;
using System.Text.Json.Serialization;

namespace TrialTask.API
{
    public static class ServiceIntegrations
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            /// Database Services
            /// 
            services.AddDbContext<TrialTaskDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TrialTaskDBContext"),
                b => b.MigrationsAssembly(typeof(TrialTaskDbContext).Assembly.FullName)));

            ///// Json Services
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


            /// Custom Services
            services.AddTransient<IQuiz, QuizService>();
            services.AddTransient<IQuizResult, QuizResultService>();

            return services;
        }
    }
}
