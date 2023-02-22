namespace ChatBE.Model
{
    public  class LoginUserDTO
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> Roles { get; set; }

    }
}
