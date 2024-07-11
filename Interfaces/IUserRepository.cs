using WebApi.Entities.Models;

namespace WebApi.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //bool Validate(User entity);
        
    }
}
