using EFAssignment2.Application.Interfaces;
using EFAssignment2.Application.MappingProfiles;
using EFAssignment2.Application.Services;
using EFAssignment2.Core.Interfaces;
using EFAssignment2.Infrastructure.Data;
using EFAssignment2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

namespace EFAssignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    "Data Source=database.db",
                    b => b.MigrationsAssembly("EFAssignment2.Infrastructure")
                )
            );

            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();

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
        }
    }
}
