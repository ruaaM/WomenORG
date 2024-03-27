namespace WomenORG.DTOs
{
    public class RegisterDTO
    {
        public String Email { get; set; } = null!;
        public String Password { get; set; } = null!;
        public String ConfirmPassword { get; set; } = null!;
    }
}
