using Shaker.WebAPI.Configurations;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace GreenChoice.WebApi;
public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        //builder.Services.AddSwaggerGen(options =>
        //{
        //    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        //    {
        //        In = ParameterLocation.Header,
        //        Name = "Authorization",
        //        Type = SecuritySchemeType.ApiKey
        //    });
        //    options.OperationFilter<SecurityRequirementsOperationFilter>();
        //});

        //builder.Services.AddAuthentication().AddJwtBearer(opt =>
        //{
        //    opt.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        //                builder.Configuration.GetSection("Jwt:Token").Value!))
        //    };
        //});

        builder.Services.JwtServiceCollections();
        builder.Services.ApplicationServiceConfigurations();

        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("http://localhost:3001")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors();

        app.UseSwagger();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}