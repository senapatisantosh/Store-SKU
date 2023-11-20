namespace Store.Mock.Data.CountryMetaData;

public interface ICountryDataService
{
    List<string> GetAllCountryNames();
    List<string> GetAllCountriesIso31662();
    List<string> GetAllCountriesIso31663();
    Country GetCountryByIso31662(string iso31662);
    Country GetCountryByIso31663(string iso31663);
    List<string> GetSubdivisionNamesByIso31662(string iso31662);
    List<string> GetSubdivisionNamesByIso31663(string iso31663);
}
