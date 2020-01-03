using System;
using System.IO;

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

            using (StreamReader streamReader = new StreamReader(_csvFilePath))
            {
                // Read pass the header line of the csv file
                streamReader.ReadLine();

                for (int i = 0; i < nCountries; i++)
                {
                    string csvLine = streamReader.ReadLine();
                    countries[i] = ReadCountryFromCsvFile(csvLine);
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
