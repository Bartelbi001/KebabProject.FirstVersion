namespace KebabStore.Core.Models;

public class Kebab
{
    public const int MAX_NAME_LENGTH = 32;
    public const int MAX_DESCRIPTION_LENGTH = 100;

    private Kebab(Guid id, string name, string description, decimal price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
    }

    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public decimal Price { get; }

    public static (Kebab Kebab, string Error) Create(Guid id, string name, string description, decimal price)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
        {
            error = $"Name can't be empty or longer then {MAX_NAME_LENGTH} symbols";
        }
        if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
        {
            error = $"Description can't be empty or longer then {MAX_DESCRIPTION_LENGTH} symbols";
        }
        if (price < 0)
        {
            error = "Price can't de less then 0";
        }

        var kebab = new Kebab(id, name, description, price);

        return (kebab, error);
    }
}
