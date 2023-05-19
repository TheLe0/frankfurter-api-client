using Frankfurter.API.Client;
using Frankfurter.API.Client.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFrankfurterApiClient();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/currencies", (IFrankfurterClient client) 
        => client.GetAllAvaliableCurrenciesAsync())
.WithName("Currencies")
.WithOpenApi();
