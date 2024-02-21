using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    Guid ApartmendId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate
    ) : ICommand<Guid>;