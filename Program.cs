
using AssetManagementSystem_WebApi_MidExam.Models;
using AssetManagementSystem_WebApi_MidExam.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace AssetManagementSystem_WebApi_MidExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Register a JWT authentication schema
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };



                });

            //0.Json Format
            builder.Services.AddControllersWithViews()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.PropertyNamingPolicy = null;
                   //pretty

                   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                   //Indentation 
                   options.JsonSerializerOptions.WriteIndented = true;
               });

            //1.ConnectionString as Middleware
            builder.Services.AddDbContext<AssetManagementSystemDbWebApiContext>(options =>

                options.UseSqlServer(builder.Configuration.GetConnectionString("PropelJuneConnection")));

            //2.Repository as Middleware
            builder.Services.AddScoped<ILoginRepository, LoginRepositoryImple>();
            builder.Services.AddScoped<IUserRepository, UserRepositoryImple>();
            builder.Services.AddScoped<IAssetRepository, AssetRepositoryImple>();


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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
