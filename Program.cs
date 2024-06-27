
using BookManagement.Contracts;
using BookManagement.Data;
using BookManagement.Repositories;
using BookManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace BookManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var ConnectionString = builder.Configuration.GetConnectionString("LibraryDbConnectionString");//this for connection


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();
            builder.Services.AddScoped<IBookCopyRepository, BookCopyRepository>();

            builder.Services.AddScoped<IStatusRepository, StatusRepository>();
            builder.Services.AddScoped<IBorrowingService, BorrowingService>();



            builder.Services.AddDbContext<LibraryDbContext>(options =>
            options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))); // this for connection
            builder.Services.AddAutoMapper(typeof(MappingProfile)); // for mapping

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
