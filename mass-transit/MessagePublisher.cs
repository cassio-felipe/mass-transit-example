using MassTransit;

namespace mass_transit;

public class MessagePublisher : BackgroundService
{
    private readonly IBus _bus;

    public MessagePublisher(IBus bus)
    {
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish(
                new CurrentTime
                {
                    Value = $"The current time is {DateTime.UtcNow}"
                },
                stoppingToken);

            await Task.Delay(1000, stoppingToken);
        }
    }
}