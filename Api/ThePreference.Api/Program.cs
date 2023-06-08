using AutoMapper;
using ThePreference.Application;
using ThePreference.Infrastructure.Repository.DependencyResolution;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterApplicationServices();
builder.Services.RegisterInfrastructureServices(builder.Configuration);

//We initialize the automapper in RegisterApplicationServices and use Assembly.GetExecutingAssembly() to get the assembly where the profiles are located
//if we want to use the automapper in a different assembly we can use the following code
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Swagger registration 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//app.ConfigureMiddleware();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();