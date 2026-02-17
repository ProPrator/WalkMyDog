namespace WalkMyDog.Api.DTOs;

using System.ComponentModel.DataAnnotations;

public record SumRequestDto([Range(-1000, 1000)] int A, [Range(-1000, 1000)] int B);
