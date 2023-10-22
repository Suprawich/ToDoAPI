using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "ToDoApp",
        ValidAudience = "public",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Program.SecurityKey))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(Options => Options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // check ว่ามีแค่เราที่เรียก API นี้

app.UseAuthentication(); // check ว่ามีแค่เราที่เรียก API นี้

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program {

     // random string (length = 32)
    public static string SecurityKey = "WKVFab9FQhIH1MPVWKVFab9FQhIH1MPV";

    public static string Thai(DateTime dt) {
        return dt.ToString();
    }
}