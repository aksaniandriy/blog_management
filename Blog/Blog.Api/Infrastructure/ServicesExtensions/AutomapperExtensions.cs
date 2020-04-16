using Blog.Common.Bootstrap;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Api.Infrastructure.ServicesExtensions
{
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Adds AutoMapper configuration to services
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new AutoMapperProfile());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
