using ElAlAIR.API.Profiles;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.BusinessLogic.Profiles;
using ElAlAIR.BusinessLogic.Services;
using ElAlAIR.DataAccess.DataContext;
using ElAlAIR.DataAccess.Interfaces;
using ElAlAIR.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        // Allow any domain- *  or only specific domain-http://localhost:3000
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

byte[] key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAutoMapper(
    typeof(UserProfile).Assembly,
    typeof(ClientUserProfile).Assembly,
    typeof(DestinationProfile).Assembly,
    typeof(ClientDestinationProfile).Assembly,
    typeof(ContinentProfile).Assembly,
    typeof(ClientContinentProfile).Assembly,
    typeof(OrderProfile).Assembly,
    typeof(ClientOrderProfile).Assembly
);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IContinentService, ContinentService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IContinentRepository, ContinentRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddDbContext<ElalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


