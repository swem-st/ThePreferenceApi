using Microsoft.EntityFrameworkCore;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.DependencyResolution;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=TestTEst;User Id=SA;Password=Qwerty211;"));

var app = builder.Build();

app.Run();

// using Microsoft.EntityFrameworkCore;
// using ThePreference.Application;
// using ThePreference.Infrastructure.DataAccess;
// //using ThePreference.Infrastructure.DependencyResolution;
//
// var builder = WebApplication.CreateBuilder(args);
// // builder.Services.RegisterApplicationServices();
// // builder.Services.RegisterInfrastructureServices(builder.Configuration);
// //
//
// // builder.Services.AddDbContext<AppDbContext>(options =>
// //     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// //
//
// builder.Services.AddDbContext<PeopleContext>(options =>
//     options.UseSqlServer("Server=localhost,1433;Database=TestTEst;User Id=SA;Password=Qwerty211;TrustServerCertificate=True;"));
//
// // //Swagger registration 
// builder.Services.AddEndpointsApiExplorer();
//  builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
// // if (app.Environment.IsDevelopment())
// // {
// //     app.UseSwagger();
// //     app.UseSwaggerUI();
// // }
// //
// // app.UseSwaggerUI(options =>
// // {
// //     options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
// //     options.RoutePrefix = string.Empty;
// // });
//
// //app.ConfigureMiddleware();
//
// //app.MapGet("/", () => "Hello World!");
//
// app.Run();
