namespace ChatBE.Model
{
    public  class LoginUserDTO
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return (FirstName + LastName); } } 
        public bool IsOnline { get; set; }
        public ICollection<string> Roles { get; set; }

    }
}
