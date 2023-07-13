using BookStore.Controllers;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using MyRepository.PostgreSQL.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<BookStoreContext>(option => option.UseNpgsql(builder.Configuration.GetSection(nameof(PostgreSQLSettings)).Get<PostgreSQLSettings>()!.ConnectionString));

builder.Services.AddControllers( options => {
    options.SuppressAsyncSuffixInActionNames = false;
}).AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
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
