using DoubleVPartners.Application.Interface;
using DoubleVPartners.Application.Main;
using DoubleVPartners.Domain.Core;
using DoubleVPartners.Domain.Interface;
using DoubleVPartners.InfraStructure.Data;
using DoubleVPartners.InfraStructure.Interface;
using DoubleVPartners.InfraStructure.Repository;
using DoubleVPartners.Services.WebAPIRest.Helpers;
using DoubleVPartners.Transversal.Common;
using DoubleVPartners.Transversal.Logging;
using DoubleVPartners.Transversal.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

//configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();

//Se especifican la vida útil de los servicios.
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

builder.Services.AddScoped<IPersonasApplication, PersonasApplication>();
builder.Services.AddScoped<IPersonasDomain, PersonasDomain>();
builder.Services.AddScoped<IPersonasRepository, PersonasRepository>();

builder.Services.AddScoped<IUsuariosApplication, UsuariosApplication>();
builder.Services.AddScoped<IUsuariosDomain, UsuariosDomain>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var IsSuer = appSettings.IsSuer;
var Audience = appSettings.Audience;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
