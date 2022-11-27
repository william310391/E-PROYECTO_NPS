using AppNet6.Infrestructuras.Filters;
using AppNet6.Negocios.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
IConfiguration Configuration = provider.GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers(option =>
{
    option.Filters.Add<GlobalExceptionFilter>();
}).AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
})
.ConfigureApiBehaviorOptions(option =>
{
    option.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddOptions(Configuration);
builder.Services.AddDbContexts(Configuration);
builder.Services.AddServices();
builder.Services.AddJWTAuthentication(Configuration);
builder.Services.AddMvc(option =>
{
    option.Filters.Add<ValidationFilter>();
});

builder.Services.AddFluentValidation(option =>
{
    option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(doc =>
{
    doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});


builder.Services.AddCors(options =>
{
    var frontend = Configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontend).AllowAnyMethod().AllowAnyHeader();
    });
});

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:3000");
//                      });
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
