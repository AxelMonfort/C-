using IniciarSesion;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BarContext>(
    opciones =>
    {
        opciones.UseSqlServer(builder.Configuration.GetConnectionString("BarConnection"));
    });

var app = builder.Build();


using (var scope = app.Services.CreateScope())  //Nos permite acceder a las funciones de la clase
{
//    //SqlConnection miConexionSql;
      var dataContext = scope.ServiceProvider.GetRequiredService<BarContext>();
      dataContext.Database.Migrate();
//    //miConexionSql = new SqlConnection(dataContext);
}





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