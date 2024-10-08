namespace FirstProjectKebab.Contracts;

public record KebabsResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price);
