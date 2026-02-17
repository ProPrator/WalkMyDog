using System.ComponentModel.DataAnnotations;

namespace WalkMyDog.Api.DTOs;

public record RegisterRequestDto(
    [Required, EmailAddress] string Email,
    [Required, MinLength(6)] string Password,
    [Required] string FullName
); 
