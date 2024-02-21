﻿using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal sealed class BookingRepository(AppDbContext appDbContext) : Repository<Booking>(appDbContext), IBookingRepository {
    private static readonly BookingStatus[] ActiveBookingStatuses = {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default) {
        return await appDbContext.Set<Booking>().AnyAsync(
            booking => booking.ApartmentId == apartment.Id &&
                       booking.Duration.Start <= duration.End &&
                       booking.Duration.End >= duration.Start &&
                       ActiveBookingStatuses.Contains(booking.Status), cancellationToken
        );
    }
}