using Bookify.Domain.Apartments;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository(AppDbContext appDbContext) : Repository<Apartment>(appDbContext), IApartmentRepository {
    
}