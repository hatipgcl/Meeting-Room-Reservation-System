using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolves.Autofac;
using Core.DependencyResolves;
using Core.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Entities.Concrete;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());//////////////
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());/////////////////
});
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7143/").AllowAnyHeader().AllowAnyOrigin();
                      });
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();   ////////////////
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDependencyResolves(new ICoreModule[] { new CoreModule() });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
