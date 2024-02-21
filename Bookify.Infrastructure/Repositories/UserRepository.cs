using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository(AppDbContext appDbContext) : Repository<User>(appDbContext), IUserRepository {
    
}