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

            Dictionary<string, Country> countries = csvReader.ReadAllCountries();

            Console.WriteLine("Which county do you want to look up?");
            string countryToBeSearched = Console.ReadLine();

            bool countryExists = countries.TryGetValue(countryToBeSearched, out Country country);

            if (!countryExists)
            {
                Console.WriteLine($"Sorry, there is no country with code: {countryToBeSearched}");
            }
            else
            {
                Console.WriteLine($"{country.Name} has population of: {country.Population}");
            }

        }
    }
}
