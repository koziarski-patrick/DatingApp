using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration); // This will add the application services to the services container.
builder.Services.AddIdentityService(builder.Configuration); // This will add the identity service to the services container.

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

app.UseMiddleware<ExceptionMiddleware>(); // This will add the exception middleware to the HTTP request pipeline.

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200")); 

// app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS.

app.UseAuthentication(); // Add the authentication middleware to the HTTP request pipeline.

app.UseAuthorization(); // Add the authorization middleware to the HTTP request pipeline.

app.MapControllers();

app.Run();
