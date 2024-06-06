using Hangfire;
using SocialMediaManager.Api;
using SocialMediaManager.Application;
using SocialMediaManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddControllers();

builder.Services.AddHangfire((sp, config) =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddHangfireServer();

builder.Services.AddSingleton<HttpClient>();

builder.Services.AddDb(builder.Configuration);
builder.Services.AddIdentityAndEntityFrameworkStores();
builder.Services.AddAuthenticationAndJwtBearer(builder.Configuration);

builder.Services.AddServices();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();