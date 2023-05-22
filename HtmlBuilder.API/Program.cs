using Chat.API.Extensions;
using HtmlBuilder.API.Extensions;
using HtmlBuilder.API;
using HtmlBuilder.API.Mapper;
using IdentityExample.Web.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using HtmlBuilder.API.Infrastructure.Mail;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// appsetttings.json dosyasý için gelen modeller.
builder.Services.AddCustomConfigs(config: builder.Configuration);

// MediatR
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AppDbContext>());

// DbContext ayarlarý.
builder.Services.AddDbConfiguration(config: builder.Configuration);

// Microsoft Identity ayarlarý.
builder.Services.AddIdentityExtension();

// JWT ayarlarý.
builder.Services.AddJwtConfiguration(config: builder.Configuration);

builder.Services.AddHttpContextAccessor();

// Auto Mapper.
builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
