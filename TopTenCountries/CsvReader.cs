using System.Collections.Generic;
using System.IO;

namespace CountriesPopulation
{
    public class CsvReader
    {
        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        private string _csvFilePath;

        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (StreamReader streamReader = new StreamReader(_csvFilePath))
            {
                // Read pass the header line of the csv file
                streamReader.ReadLine();

                string csvLine;
                while ((csvLine = streamReader.ReadLine()) != null)
                {
                    countries.Add(ReadCountryFromCsvFile(csvLine));
                }
            }

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
