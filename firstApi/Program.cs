using firstApi.RepositoryLayer;
using firstApi.ServiceLayer;
using firstApi.ServiceLayer.jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependencies injection

builder.Services.AddScoped<IApiRL, ApiRL>();
builder.Services.AddScoped<IApiSL, ApiSL>();
builder.Services.AddSingleton<IJwtS, JwtS>();

#endregion

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
