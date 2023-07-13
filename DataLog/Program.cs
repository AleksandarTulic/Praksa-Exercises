using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddWatchDogServices(options => {
    options.IsAutoClear = false;
    //options.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
    options.SetExternalDbConnString = builder.Configuration.GetConnectionString(name: "SampleDbConnection");
    options.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.PostgreSql;
});

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

app.UseAuthorization();

app.MapControllers();

//inject into the middleware
app.UseWatchDogExceptionLogger();

//https://localhost:7188/watchdog
app.UseWatchDog(options => {
    options.WatchPagePassword = "123456789";
    options.WatchPageUsername = "admin";
});

app.Run();
