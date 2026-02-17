using WalkMyDog.Api.DTOs;

namespace WalkMyDog.Api.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterRequestDto request);
}