using WebApi.Interfaces;
using WebApi.Entities.Models;
namespace WebApi.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApiContext context) : base(context)
        {
           
        }

    }
}
