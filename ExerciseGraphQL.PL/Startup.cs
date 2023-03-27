using AutoMapper;
using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Services;
using ExerciseGraphQL.DAL;
using ExerciseGraphQL.DAL.Interfaces;
using ExerciseGraphQL.DAL.Repositories;
using ExerciseGraphQL.PL.Configuration;
using ExerciseGraphQL.PL.Queries;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace ExerciseGraphQL.PL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("LibraryDB")));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();

            services.AddGraphQLServer()
                .AddQueryType<AuthorQuery>();

            // Configura AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UsePathBase("/api/graphql");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/api/graphql");
            });

            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthorization();
        }
    }
}
