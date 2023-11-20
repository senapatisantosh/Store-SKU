namespace Store.Mock.Data;

using Bogus;
using Store.Mock.Data.CountryMetaData;
using Store.Mock.Data.MockDataGenerator;
using Store.Mock.Data.Utils;
using Store.Mock.Data.ValueObjects;

internal class Program
{
    static void Main(string[] args)
    {
        ICountryDataService countryDataService = new CountryDataService();
        var storeIdFaker = new Faker();
        int numberOfCountries = 2;
        int minStoresPerCountry = 2;
        int maxStoresPerCountry = 10;
        string outputDirectory = "MockStorData";

        for (int i = 0; i < numberOfCountries; i++)
        {
            string countryCode = storeIdFaker.Address.CountryCode();
            string country = countryDataService.GetCountryByIso31662(countryCode).CountryName;
            string state = MockStoreHelper.GetRandomSelector(countryDataService.GetSubdivisionNamesByIso31662(countryCode), country);
            int numberOfStores = storeIdFaker.Random.Number(minStoresPerCountry, maxStoresPerCountry);

            for (int j = 0; j < numberOfStores; j++)
            {
                var retailStores = new List<string> { "Walmart", "Decathalon", "Amazon Retail" };
                var noOfRrtailStoreDataFetch = new Random().Next(10, 20);
                for (int k = 0; k < noOfRrtailStoreDataFetch; k++)
                {
                    var retaiilStore = MockStoreHelper.GetRandomSelector(retailStores);
                    var uniqueStoreId = MockStoreHelper.GenerateStoreId(storeIdFaker, countryCode, state, retaiilStore);
                    var numberOfRows = new Random().Next(20, 51);
                    var apperalAndFootWearFaker = ApperalAndFootWear.GetApperalMockDataConfiguration();
                    var apperalAndFootWearData = apperalAndFootWearFaker.Generate(numberOfRows);
                    var mockStoreSkuData = apperalAndFootWearData.Select(inventory => new StoreSkuModel()
                    {
                        StoreId = uniqueStoreId,
                        ProductSku = inventory.SKU,
                        ProductName = $"{inventory.Brand}_{inventory.Model}",
                        ProductDescription = inventory.ProductDescription,
                        Pricing = inventory.Price,
                        DateTimestamp = inventory.Timestamp,
                    });

                    string dropLoacation = Path.Combine(outputDirectory, country, state, retaiilStore);
                    WriteDataToCsv.WriteStoreSkuDataToCsv(dropLoacation, uniqueStoreId, mockStoreSkuData);
                }
            }
        }
    }
}
