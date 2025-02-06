using Bookify.Application.Abstraction.Data;
using Bookify.Application.Abstraction.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            Select
                id as Id,
                apartment_id as ApartmentId,
                user_id as UserId,
                status as Status,
                price_for_period_amount as PriceAmount,
                price_for_period_currecny as PriceCurrency,
                cleaning_fee_amount as CleaningFeeAmount,
                cleaning_fee_currency as CleaningFeeCurrency,
                amenities_up_charge_amount as AmenitiesUpChargeAmount,
                amenities_up_charge_currency as AmenitiesUpChargeCurrency,
                total_price_amount as TotalPriceAmount,
                total_price_currency as TotalPriceCurrency,
                duration_start as DurationStart,
                duration_end as DurationEnd,
                created_on_utc as CreatedOnUtc
            From bookings
            Where id = @BookingId
            """;

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new
            {
                request.BookingId
            });
        return booking;
    }
}
