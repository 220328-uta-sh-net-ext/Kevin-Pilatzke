using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestaurantAPI.JWTRepo;
using RestaurantBL;
using RestaurantDL;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Config = builder.Configuration;
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("D:/Documents/Work/Programming Info/220328utashnetext/Kevin-Pilatzke/Projects/Restaurant(P1)/RestaurantAPI/JWTRepo/Logger.xml")
    .CreateLogger();



builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(o => {
    var key = Encoding.UTF8.GetBytes(Config["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = Config["JWT:Issuer"],
        ValidAudience = Config["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddMemoryCache();
builder.Services.AddControllers(options =>
    options.RespectBrowserAcceptHeader = true
    )
    .AddXmlSerializerFormatters();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "JWT Auth using Bearer token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            Array.Empty<string>()
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
    
builder.Services.AddScoped<IRepo>(repo => new SqlRepo(Config.GetConnectionString("Database")));
builder.Services.AddScoped<IAccountLogic, AccountLogic>();
builder.Services.AddScoped<IJWTRepo, JWTRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantAPI"); 
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css"); //Thank you Amoenus Dev!
    });
}

app.UseHttpsRedirection();
app.Logger.LogInformation("App Started");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.Run();
