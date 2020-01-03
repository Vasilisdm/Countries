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
    }
}
