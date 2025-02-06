
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsOverlapingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken);
    void Add(Booking booking);
}
