using System.ComponentModel.DataAnnotations;

namespace DotnetStockAPI.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, ErrorMessage = "Username is too long")] //ไม่เกิน 50 ตัว
    [MinLength(3, ErrorMessage = "Username is too short")] //ไม่ต่ำกว่า 3 ตัว
    public required string Username { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password is too short")] //ไม่ต่ำกว่า 3 ตัว
    public required string Password { get; set; }
}