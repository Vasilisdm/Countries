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

            Country lilliput = new Country("Lilliput", "LIL", "SomeWhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(c=>c.Population < 2_000_000);
            countries.Insert(lilliputIndex, lilliput);

            foreach (Country country in countries)
            {
                Console.WriteLine($"Population: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}, Country Name: {country.Name}");
            }

            Console.WriteLine($"Total countries: {countries.Count}");
        }
    }
}
