using CadastroProdutorRural.Data;
using CadastroProdutorRural.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Adicionar a pol�tica de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:3000") // Substitua pela URL do frontend (React, Angular)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Adiciona o contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o do JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = jwtSettings["Key"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});

// Registra os servi�os
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ProdutorRuralService>();
builder.Services.AddScoped<FazendaService>();
builder.Services.AddScoped<CulturaService>();
builder.Services.AddScoped<FazendaCulturaService>();
builder.Services.AddScoped<DashBoardService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Adiciona os servi�os de controlador
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Cadastro de Produtor Rural",
        Version = "v1",
        Description = "API para Cadastro de Produtores Rurais.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Maur�cio Dias de Carvalho Oliveira",
            Email = "mauridf@gmail.com",
        },
    });
});

var app = builder.Build();

// Configure o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use a pol�tica de CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication(); // Deve vir antes do UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
