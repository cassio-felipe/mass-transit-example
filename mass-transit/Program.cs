using mass_transit;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<CurrentTimeConsumer>();
    busConfigurator.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
});

builder.Services.AddHostedService<MessagePublisher>();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();