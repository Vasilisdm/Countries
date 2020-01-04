using System;
using System.Collections.Generic;

namespace CountriesPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"/Users/vasilisdimitriou/Documents/population.csv";

            CsvReader csvReader = new CsvReader(filePath);

            List<Country> countries = csvReader.ReadAllCountries();

            foreach (Country country in countries)
            {
                Console.WriteLine($"Population: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}, Country Name: {country.Name}");
            }
        }
    }
}
