using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings;

public record BookingRejectedDomainEvent(Guid Id) : IDomainEvent;