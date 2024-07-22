using Basic.Webapi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionStringSqlServer = builder.Configuration.GetConnectionString("DockerConnection")!;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddHttpClient("DummyJSON", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://dummyjson.com");
});
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionStringSqlServer);
});

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
app.MapHealthChecks("/health");

app.Run();
