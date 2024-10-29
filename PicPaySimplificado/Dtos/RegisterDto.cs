using PicPaySimplificado.Enums;

namespace PicPaySimplificado.Dtos;

public record RegisterDto(string FirstName, string LastName, string Document, string Email, int Password, UserType UserType);