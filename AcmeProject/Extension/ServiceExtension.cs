using Acme.BusinessLayer.Abstract;
using Acme.BusinessLayer.Concrete;
using Acme.DataAccessLayer.Abstract;
using Acme.DataAccessLayer.Concrete.Repositories;

namespace AcmeProject.Extention
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExamService,ExamService>();
            services.AddScoped<IQuestionExamService,QuestionExamService>();
            services.AddScoped<IQuestionService,QuestionService>(); 
            services.AddScoped<IUserService,UserService>(); 
            services.AddScoped<IValueService,ValueService>();   
            services.AddScoped<IValueService,ValueService>();   
            services.AddScoped<IQuestionValueService,QuestionValueService>();   
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IValueRepository, ValueRepository>();
            services.AddScoped<IQuestionExamRepository, QuestionExamRepository>();
            services.AddScoped<IQuestionValueRepository, QuestionValueRepository>();
            return services;           
        }
    }
}
