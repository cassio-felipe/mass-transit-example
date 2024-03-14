using MassTransit;

namespace mass_transit;

public class CurrentTimeConsumer : IConsumer<CurrentTime>
{
    private readonly ILogger<CurrentTimeConsumer> _logger;

    public CurrentTimeConsumer(ILogger<CurrentTimeConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CurrentTime> context)
    {
        _logger.LogInformation("{consumer}: {message}", nameof(CurrentTimeConsumer), context.Message.Value);
        
        return Task.CompletedTask;
    }
}