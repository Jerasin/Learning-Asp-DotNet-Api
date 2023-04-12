using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Services.UserService;
using Models.ApiDbContext;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

// https://stackoverflow.com/questions/66720614/cannot-convert-from-string-to-microsoft-entityframeworkcore-serverversion
builder.Services.AddDbContext<ApiDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));

var connection = new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // test connection Mysql
    try
    {
        connection.Open();
        connection.Close();
    }
    catch (MySqlException error)
    {
        Console.WriteLine(error);
    }


    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApiDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            Console.WriteLine("Database Migrate Running...");
            context.Database.Migrate();
        }
        else
        {
            Console.WriteLine("Not Have Migrate");
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


