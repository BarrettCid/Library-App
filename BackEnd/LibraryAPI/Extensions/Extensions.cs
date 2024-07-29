using AutoMapper;

namespace LibraryAPI.Extensions
{
    public static class Extensions
    {
        public static void AddAutoMappers(this IServiceCollection services)
        {
            var appMappingConfig = new MapperConfiguration(x =>
            {
                x.AddMaps(new string[] { "LibraryMappers" });
            });

            var appMapper = appMappingConfig.CreateMapper();
            services.AddSingleton(appMapper);
        }
    }
}
