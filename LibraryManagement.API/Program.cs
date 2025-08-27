using Autofac;
using Autofac.Extensions.DependencyInjection;
using LibraryManagement.Business.DependencyResolvers.Autofac;
using LibraryManagement.Core.DependencyResolvers;
using LibraryManagement.Core.Extensions;
using LibraryManagement.Core.Utilities.IoC;
using LibraryManagement.Core.Utilities.Security.Encryption;
using LibraryManagement.Core.Utilities.Security.JWT;
using LibraryManagement.DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<LibDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions!.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
            //ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha512 },
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = ctx =>
            {
                Console.WriteLine("AUTH FAILED: " + ctx.Exception?.Message);
                System.Diagnostics.Debug.WriteLine("AUTH FAILED: " + ctx.Exception?.Message);

                return Task.CompletedTask;
            },
            OnTokenValidated = ctx =>
            {
                Console.WriteLine("AUTH SUCCESS: Token validated!");
                System.Diagnostics.Debug.WriteLine("AUTH SUCCESS: Token validated!");

                foreach (var claim in ctx.Principal!.Claims)
                {
                    Console.WriteLine($"Claim: {claim.Type} = {claim.Value}");
                    System.Diagnostics.Debug.WriteLine($"Claim: {claim.Type} = {claim.Value}");

                }
                return Task.CompletedTask;
            },
            OnMessageReceived = ctx =>
            {
                Console.WriteLine("TOKEN RECEIVED: " + ctx.Token);
                System.Diagnostics.Debug.WriteLine("TOKEN RECEIVED: " + ctx.Token);

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[] {
new CoreModule()
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});




// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<LibraryManagement.Core.Extensions.ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
