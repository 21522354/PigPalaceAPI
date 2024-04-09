using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PigPalaceAPI.Data;
using PigPalaceAPI.Repository.FarmRepo;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region configure Services
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PigPalaceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PigPalaceDB")));

builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();  
#endregion

#region configure JWT
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secterKeyByte = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // tự cấp token nên validate = false
            ValidateIssuer = false,
            ValidateAudience = false,
            // có thể sử dụng các dịch vụ cấp token như OAuth2

            // ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secterKeyByte),

            ClockSkew = TimeSpan.Zero
        };
    });
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
