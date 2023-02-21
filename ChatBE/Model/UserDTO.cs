namespace ChatBE.Model
{
    public  class LoginUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        public string UserName { get; set; }
    }
}
