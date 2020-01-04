using System;
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
            string countryName;
            string countryCode;
            string continent;
            string populationText;

            switch (countriesInfo.Length)
            {
                case 4:
                    countryName = countriesInfo[0];
                    countryCode = countriesInfo[1];
                    continent = countriesInfo[2];
                    populationText = countriesInfo[3];
                    break;
                case 5:
                    countryName = countriesInfo[0] + ", " + countriesInfo[1];
                    countryName = countryName.Replace("\"", null).Trim();
                    countryCode = countriesInfo[2];
                    continent = countriesInfo[3];
                    populationText = countriesInfo[4];
                    break;
                default:
                    throw new Exception($"Not able to parse country from csv line: {csvLine}");
            }

            int population = ConvertPopulationTextToInt(populationText);

            return new Country(countryName, countryCode, continent, population);
        }

        private static int ConvertPopulationTextToInt(string populationText)
        {
            int.TryParse(populationText, out int population);
            return population;
        }
    }
}
