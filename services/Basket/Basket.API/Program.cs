using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Core.Repositories;
using Basket.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

  // Add services to the container.

  builder.Services.AddControllers();
  // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
  builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(BasketMappingProfile).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetExecutingAssembly(),
    Assembly.GetAssembly(typeof(CreateShoppingCartCommand))));

builder.Services.AddScoped<IBasketRepository, BasketRepository>();


builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Basket API",
        Version = "v1",
        Description = "This API For Basket Microservices in ecommerce application",
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "Abdelrahman Mohamed",
            Email = "abdelrahmanmo1534@gmail.com",
            Url = new Uri("https://yourwebsite.eg")
        }
    });
});

//redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});



var app = builder.Build();

app.MapDefaultEndpoints();

 // Configure the HTTP request pipeline.
 if (app.Environment.IsDevelopment())
 {
     app.MapOpenApi();
     app.UseDeveloperExceptionPage();
     app.UseSwagger();
     app.UseSwaggerUI();
}

 app.UseAuthorization();


 app.MapControllers();

 app.Run();
