namespace WebApi.Entities.DataTransferObjects
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
