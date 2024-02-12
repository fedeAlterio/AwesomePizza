using System.ComponentModel;
using System.Net;
using AwesomePizza.Application.DependenciesInstallers;
using AwesomePizza.Application.Events.Startup;
using AwesomePizza.Infrastructure.DependenciesInstallers;
using AwesomePizza.Web.DependenciesInstallers;
using AwesomePizza.Web.Endpoints;
using AwesomePizza.Web.Hubs;
using AwesomePizza.Web.Middlewares;
using AwesomePizza.Web.Swagger;
using MediatR;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c => c.AddCustomSchemaOptions());

services.AddFluentValidation();
services.AddMediatRDependencies();
services.AddApplicationServices();
services.AddInfrastructureServices(builder.Configuration);
services.AddFluentValidationRulesToSwagger();
services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(GlobalExceptionHandler.Handle);
app.UseHttpsRedirection();
app.MapEndpoints();
app.MapHub<NotificationHub>("/notifications");

using (var scope = app.Services.CreateScope())
{
    var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();
    await publisher.Publish(new StartupEvent());
}

app.Run();