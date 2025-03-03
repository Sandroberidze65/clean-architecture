using Bookify.Application.Abstraction.Clock;

namespace Bookify.Infrastructure.Clock;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
