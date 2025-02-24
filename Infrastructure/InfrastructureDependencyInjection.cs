using Application.Authentication.Implementation;
using Application.Authentication.Interfaces;
using Application.Utilization.Implementation;
using Application.Utilization.Interfaces;
using Domain;
using Domain.IRepos;
using Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region repository config
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<IAccountMembershipRepo, AccountMembershipRepo>();
            services.AddScoped<IMembershipPlanRepo, MembershipPlanRepo>();
            services.AddScoped<IPaymentMethodRepo,PaymentMethodRepo>();
            services.AddScoped<IBlogBookmarkRepo, BlogBookmarkRepo>();
            services.AddScoped<IBlogLikeRepo, BlogLikeRepo>();
            services.AddScoped<IBlogPostRepo, BlogPostRepo>();
            services.AddScoped<ICommentRepo, CommentRepo>();
            services.AddScoped<IFetusRepo, FetusRepo>();
            services.AddScoped<IFetusRecordRepo, FetusRecordRepo>();
            services.AddScoped<IMediaRepo, MediaRepo>();
            services.AddScoped<IPregnancyRepo, PregnancyRepo>();
            services.AddScoped<IPregnancyStandardRepo, PregnancyStandardRepo>();
            services.AddScoped<IScheduleTemplateRepo, ScheduleTemplateRepo>();
            services.AddScoped<IScheduleUserRepo, ScheduleUserRepo>();
            #endregion


            #region service config
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            #endregion

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("MNYT_DB")));

            return services;

        }
    }
}
