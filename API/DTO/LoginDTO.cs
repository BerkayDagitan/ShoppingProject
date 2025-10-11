using System.ComponentModel.DataAnnotations;

public class LoginDTO
{
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
