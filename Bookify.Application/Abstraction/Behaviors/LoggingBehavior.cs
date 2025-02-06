using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstraction.Behaviors;

public class LoggingBehavior<Trequest, Tresponse> : IPipelineBehavior<Trequest, Tresponse> where Trequest : IBaseRequest
{
    private readonly ILogger<Trequest> _logger;

    public LoggingBehavior(ILogger<Trequest> logger)
    {
        _logger = logger;
    }

    public async Task<Tresponse> Handle(Trequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;
        try
        {
            _logger.LogInformation("Executing command {command}", name);
            var result = await next();
            _logger.LogInformation("Command {Command} processed successfully", name);

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Command {Command} processing failed", name);
            throw;
        }
    }
}
