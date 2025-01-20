using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public record PricingDetails(
     Money priceForPeriod,
     Money cleanigfee,
     Money amenitiesUpCharge,
     Money totalPrice
);