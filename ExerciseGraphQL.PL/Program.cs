using AutoMapper;
using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Services;
using ExerciseGraphQL.DAL;
using ExerciseGraphQL.DAL.Interfaces;
using ExerciseGraphQL.DAL.Repositories;
using ExerciseGraphQL.PL.Configuration;
using ExerciseGraphQL.PL.Mutations;
using ExerciseGraphQL.PL.Queries;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")).EnableSensitiveDataLogging(), ServiceLifetime.Singleton);
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<AuthorQuery>()
    .AddMutationType<AuthorMutation>()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutation>();
    //.AddFiltering()
    //.AddSorting()
    //.AddProjections();

// Configura AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
