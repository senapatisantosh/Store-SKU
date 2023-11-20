using Bogus;
using Store.Mock.Data.Utils;
using Store.Mock.Data.ValueObjects;

namespace Store.Mock.Data.MockDataGenerator;

public class ApperalAndFootWear
{
    public static Faker<Inventory>  GetApperalMockDataConfiguration()
    {
        var faker = new Faker<Inventory>()
                    .RuleFor(p => p.Category, f => f.PickRandom("Top Wear", "Bottom Wear", "Foot Wear"))
                    .RuleFor(p => p.Brand, f => f.PickRandom("Nike", "Adidas", "Puma", "Reebok", "Gucci"))
                    .RuleFor(p => p.Model, (f, p) => GetModelNameBasedOnCategory(f, p.Category))
                    .RuleFor(p => p.Color, f => f.Commerce.Color())
                    .RuleFor(p => p.Size, f => f.PickRandom("XS", "S", "M", "L", "XL", "XXL", "XXXL"))
                    .RuleFor(p => p.Size, (f, p) => GetSizeBasedOnCategory(f, p.Category))
                    .RuleFor(p => p.SKU, (f, p) => GenerateSKU(p.Category, p.Brand, p.Model, p.Color, p.Size))
                    .RuleFor(p => p.Price, f => f.Commerce.Price())
                    .RuleFor(p => p.Timestamp, f => f.Date.Past(1))
                    .RuleFor(p => p.ProductDescription, (f, p) => GenerateProductDescription(p.Brand, p.Model));
        return faker!;
    }

    private static string GetModelNameBasedOnCategory(Faker f, string category)
    {
        string categoryInitial = new string(category.Split(' ').Select(word => word[0]).ToArray());
        return categoryInitial switch
        {
            "TW" => f.PickRandom("T-Shirt", "Long Sleeve", "Polo", "Hoodie", "Tank Top"),
            "BW" => f.PickRandom("Jeans", "Chinos", "Shorts", "Joggers"),
            "FW" => f.PickRandom("Sneaker", "Boot", "Sandals", "Loafer", "High Heels"),
            _ => "Other"
        };
    }

    private static string GetSizeBasedOnCategory(Faker f, string category)
    {
        string categoryInitial = new string(category.Split(' ').Select(word => word[0]).ToArray());
        return categoryInitial switch
        {
            "TW" => f.Random.Number(36, 44).ToString(),
            "BW" => f.Random.Number(28, 44).ToString(),
            "FW" => f.Random.Number(5, 13).ToString("D2"),
            _ => "00"
        };
    }

    private static string GenerateSKU(string category, string brand, string model, string color, string size)
    {
        Random random = new Random();
        var leftover = random.Next(0, 999);
        string categoryInitial = new string(category.Split(' ').Select(word => word[0]).ToArray());

        // Combine categoryInitial, brand, model, color, size, and sequence number to create SKU
        return $"{categoryInitial}_{brand.Substring(0, 3).ToUpper()}_{model.Substring(0, 3).ToUpper()}_{color.Substring(0, 3).ToUpper()}_{size.ToUpper()}_{leftover.ToString("D3")}";
    }

    private static string GenerateProductDescription(string brand, string model)
    {
        List<string> phrases = GetPhrasesForModel(model);
        return $"{brand} {model}: {phrases[new Random().Next(phrases.Count)]}";
    }

    private static List<string> GetPhrasesForModel(string model)
    {
        return model switch
        {
            "T-Shirt" => new List<string>
                {
                    "Classic and comfortable for everyday wear.",
                    "Our signature T-shirt for a casual look.",
                    "Versatile and stylish, perfect for any occasion."
                },
            "Long Sleeve" => new List<string>
                {
                    "Stay warm and trendy with our long sleeve shirts.",
                    "Casual and cool for those chilly days.",
                    "Elevate your style with our fashionable long sleeves."
                },
            "Polo" => new List<string>
                {
                    "Timeless polo design for a sporty yet refined look.",
                    "Perfect blend of comfort and sophistication.",
                    "Our polo shirts redefine casual elegance."
                },
            "Hoodie" => new List<string>
                {
                    "Cozy up with our comfortable and stylish hoodies.",
                    "Casual and warm, the perfect combination for fall.",
                    "Stay on-trend with our fashionable hoodie collection."
                },
            "Tank Top" => new List<string>
                {
                    "Cool and comfortable tank tops for a laid-back style.",
                    "Ideal for warm weather and active lifestyles.",
                    "Show off those muscles with our trendy tank tops."
                },
            "Jeans" => new List<string>
                {
                    "Classic and comfortable for everyday wear.",
                    "Our signature jeans for a stylish look.",
                    "Versatile and trendy, perfect for any occasion."
                },
            "Chinos" => new List<string>
                {
                    "Stay classy and comfortable with our chinos.",
                    "Casual and cool for those laid-back days.",
                    "Elevate your style with our fashionable chinos."
                },
            "Shorts" => new List<string>
                {
                    "Cool and comfortable shorts for a relaxed style.",
                    "Ideal for warm weather and outdoor activities.",
                    "Stay on-trend with our fashionable shorts collection."
                },
            "Joggers" => new List<string>
                {
                    "Cozy up with our comfortable and stylish joggers.",
                    "Casual and perfect for your active lifestyle.",
                    "Stay on-trend with our fashionable joggers collection."
                },
            "Sneaker" => new List<string>
                {
                    "Innovative design for the modern athlete.",
                    "Elevate your performance with our latest technology.",
                    "Comfort and style combined for your active lifestyle."
                },
            "Boot" => new List<string>
                {
                    "Step out in style with our fashionable boots.",
                    "Durable and ready for any adventure.",
                    "All-weather boots crafted for durability and comfort."
                },
            "Sandals" => new List<string>
                {
                    "Relax in our comfortable sandals.",
                    "Perfect for a day at the beach or a casual stroll.",
                    "Adjustable straps for a personalized fit."
                },
            "Loafer" => new List<string>
                {
                    "Classic loafers for a timeless look.",
                    "Versatile design for both casual and formal occasions.",
                    "Step into sophistication with our loafers."
                },
            "High Heels" => new List<string>
                {
                    "Elegant high heels to make a statement.",
                    "Sleek and modern design for a chic appearance.",
                    "Dress up your outfit with our stylish high heels."
                },
            _ => new List<string> { $"Generic description for any {model}." }
        };
    }
}

