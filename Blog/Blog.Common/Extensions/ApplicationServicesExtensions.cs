using Blog.Database.Repositories;
using Blog.Services;
using Blog.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Common.Extensions
{
    public static class ApplicationServicesExtensions
    {
        /// <summary>
        /// Add application services
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddServices();
            services.AddRepositories();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<ICommentService, CommentService>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }
    }
}
