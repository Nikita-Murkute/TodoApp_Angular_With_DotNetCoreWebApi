
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoApp.Data;

namespace TodoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConn"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            //app.UseCors(Options => Options.WithOrigins("/*http://localhost:4200*/").AllowAnyMethod().AllowAnyHeader());

           
            app.UseCors(policy => policy
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                     .AllowAnyHeader());


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
