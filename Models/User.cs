using System.ComponentModel.DataAnnotations;

namespace UserApi.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
