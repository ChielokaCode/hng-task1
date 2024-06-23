global using hng_task1.Model;
global using hng_task1.Controllers;
global using hng_task1.Service;
global using hng_task1.ServiceImpl;
using Microsoft.AspNetCore.HttpOverrides; // Add this line for ForwardedHeaders

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ILogger<UserController>, Logger<UserController>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIpService, IpService>();
// Configure the forwarded headers middleware to read the correct client IP address
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable forwarded headers middleware in the request pipeline
app.UseForwardedHeaders();

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
