namespace Store.Mock.Data.Utils;

using Bogus;

public class MockStoreHelper
{
    public static string GenerateStoreId(Faker faker, string countryCode, string state, string retailStoreName)
    {
        string uniqueIdentifier = faker.Random.AlphaNumeric(6);
        string uniqueStoreId = $"{countryCode}_{state}_{retailStoreName}";
        return uniqueStoreId;
    }

    public static string GetRandomSelector(List<string> selectors, string country = "")
    {
        Random random = new Random();
        int randomIndex = random.Next(selectors.Count);
        return selectors[randomIndex];
    }
}
