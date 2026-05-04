using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ZooApi.Data;

var builder = WebApplication.CreateBuilder(args);

//  Add Controllers and configure JSON
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

//  Configure SQLite
builder.Services.AddDbContext<ZooContext>(opt =>
    opt.UseSqlite("Data Source=zoo.db"));

// Configure CORS for Angular
builder.Services.AddCors(opt => {
    opt.AddPolicy("ZooPolicy", p => p
            .AllowAnyOrigin()
            .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

//  Use CORS
app.UseCors("ZooPolicy");

app.UseAuthorization();
app.MapControllers();

//  Auto-create (and reset) database on start
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ZooContext>();

    //db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

app.Run();
