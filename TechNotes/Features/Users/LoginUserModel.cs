using System.ComponentModel.DataAnnotations;

namespace TechNotes.Features.Users;

public class LoginUserModel
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Password { get; set; } = string.Empty;
}
