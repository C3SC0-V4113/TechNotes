using System.ComponentModel.DataAnnotations;

namespace TechNotes.Features.Users;

public class RegisterUserModel
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
