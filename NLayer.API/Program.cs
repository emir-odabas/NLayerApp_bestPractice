using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLayer.API.Filters;
using NLayer.API.Middlewares;
using NLayer.API.Modules;
using NLayer.Repository;
using NLayer.Service.Mapping;
using NLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Configuration
// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); }).AddFluentValidation(x =>
x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Yukarýdaki kodda “SuppressModelStateInvalidFilter” true olarak atanmýþtýr, bunun anlamý “Filterlarý Sen Kontrol Etme, Ben kontrol edeceðim”.



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web API",
        Description = "An ASP.NET Core Web API for managing WebAPI items",
        Contact = new OpenApiContact
        {
            Name ="Emir ODABAÞ",
            Email = string.Format("emir.odabas@infinidium.com.tr"),
            Url = new Uri("https://github.com/emir-odabas")

        },
        License = new OpenApiLicense
        {
            Name= "License",
            Url = new Uri("https://infinidium.com.tr/")
        }
    });
});
builder.Services.AddMemoryCache();



builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});



builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerbuiler => containerbuiler.RegisterModule(new RepoServiceModule()));

builder.WebHost.UseUrls("http://*:5000", "https://*:5001");


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
