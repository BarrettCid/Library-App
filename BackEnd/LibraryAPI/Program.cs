using AutoMapper;
using LibraryAPI.Extensions;
using LibraryAPI.Filters;
using LibraryModel.Context;
using LibraryServices.Interfaces;
using LibraryServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using LibraryMappers;
using LibraryModel.Model;
using Microsoft.Extensions.FileProviders;
using System;

var policyName = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = configBuilder.Build();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                          
                      });
});

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryAPI", Version = "v1" });
    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Scheme = "bearer"
    });
    c.OperationFilter<AuthenticationRequirementsOperationFilter>();
});

builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings")["LibraryApiConnectionString"]));

builder.Services.AddIdentityApiEndpoints<LibraryUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryDbContext>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new LibraryUserMapper());
    mc.AddProfile(new BookMapper());
    mc.AddProfile(new ReviewMapper());

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

var app = builder.Build();

app.MapIdentityApi<LibraryUser>();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    db.Database.Migrate();
}

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Assets\CoverImages")),
    RequestPath = new PathString("/assets/coverimages")
});

app.UseHttpsRedirection();

app.UseCors(policyName);

app.MapControllers();

app.Run();
