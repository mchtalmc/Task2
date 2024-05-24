
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using ToDoList.BussinessLayer;
using ToDoList.DataLayer;
using ToDoList.DataLayer.Abstract;
using ToDoList.DataLayer.Concrete;
using ToDoList.DataLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessServies();

builder.Services.AddDataAccessService(builder.Configuration);

//AddTransient: Her kullanýmda yeni bir nesne (kýsa ömürlü).
//AddScoped: Her HTTP isteðinde yeni bir nesne, istek boyunca ayný nesne (orta ömürlü).
//Nesnelerinin olusturulmasindan , yok edilmesine kadar olan sureci kontrol ederler
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<ITokenRepository,TokenRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Token:ValidIssuer"],
        ValidAudience = builder.Configuration["Token:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Token:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});//Kimlik dogrulama islemi icin





builder.Services.AddAuthorization(); // Yetkilendirme islemi icin 


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name:JwtBearerDefaults.AuthenticationScheme,
        securityScheme:new OpenApiSecurityScheme
        {
            Name="Authorization",
            Description="Enter the Bearer Authprization : `Bearer Genreated-JWT-Token`",
            In=ParameterLocation.Header,
            Type=SecuritySchemeType.ApiKey,
            Scheme= "Bearer"
        });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference= new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id=JwtBearerDefaults.AuthenticationScheme,
            }
        },new string[]{}
        }
    });
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

app.Run();
