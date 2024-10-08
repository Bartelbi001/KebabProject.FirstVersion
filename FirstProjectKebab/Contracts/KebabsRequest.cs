namespace FirstProjectKebab.Contracts;

public record KebabsRequest(
    string Name,
    string Description,
    decimal Price);