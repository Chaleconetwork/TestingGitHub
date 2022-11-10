using ApiCrud.Data;
using ApiCrud.Interfaces;
using ApiCrud.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    string con = builder.Configuration.GetConnectionString("Connection");
    builder.Services.AddDbContext<Context>(options => options.UseMySql(con, ServerVersion.AutoDetect(con)));

    builder.Services.AddScoped<IUsuarioInterface, UsuarioRepository>();
}

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<Context>();
        context.Database.Migrate();
    }

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
