namespace Store.Mock.Data.CountryMetaData;

using Newtonsoft.Json;

public class CountryDataService : ICountryDataService
{
    private List<Country> countries = new List<Country>();

    public CountryDataService()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CountryMetaData", "iso_country_codes.json");
        string jsonString = File.ReadAllText(filePath);
        countries = JsonConvert.DeserializeObject<List<Country>>(jsonString)!;
    }

    public List<string> GetAllCountryNames()
    {
        return countries.Select(c => c.CountryName).ToList();
    }

    public List<string> GetAllCountriesIso31662()
    {
        return countries.Select(c => c.Iso31662).ToList();
    }

    public List<string> GetAllCountriesIso31663()
    {
        return countries.Select(c => c.Iso31663).ToList();
    }

    public Country GetCountryByIso31662(string iso31662)
    {
        return countries.FirstOrDefault(c => c.Iso31662 == iso31662)!;
    }

    public Country GetCountryByIso31663(string iso31663)
    {
        return countries!.FirstOrDefault(c => c.Iso31663 == iso31663)!;
    }

    public List<string> GetSubdivisionNamesByIso31662(string iso31662)
    {
        var country = countries.FirstOrDefault(c => c.Iso31662 == iso31662);
        return country?.Subdivisions?.Keys.ToList() ?? new List<string> { iso31662 };
    }

    public List<string> GetSubdivisionNamesByIso31663(string iso31663)
    {
        var country = countries.FirstOrDefault(c => c.Iso31663 == iso31663);
        return country?.Subdivisions?.Keys.ToList() ?? new List<string> { iso31663 };
    }
}
