using System;
namespace TopTenCountries
{
    public class CsvReader
    {
        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        private string _csvFilePath;

        public Country[] ReadFirstNCoutries(int nCountries)
        {
            Country[] countries = new Country[nCountries];
            return countries;
        }

        public Country ReadCountryFromCsvFile(string csvLine)
        {
            string[] countriesInfo = csvLine.Split(',');

            string countryName = countriesInfo[0];
            string countryCode = countriesInfo[1];
            string continent = countriesInfo[2];
            int population = int.Parse(countriesInfo[3]);

            return new Country(countryName, countryCode, continent, population);
        }
    }
}
