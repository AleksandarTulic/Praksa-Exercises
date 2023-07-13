using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = true;
});

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<StudentContext>(option => option.UseNpgsql(builder.Configuration.GetSection(nameof(PostgreSQL)).Get<PostgreSQL>().ConnectionString));

builder.Services.AddControllers(options => {
    options.SuppressAsyncSuffixInActionNames = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
