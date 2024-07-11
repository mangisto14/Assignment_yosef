namespace WebApi.Entities.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
