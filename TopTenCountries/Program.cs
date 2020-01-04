using System;
using System.Collections.Generic;
using System.Linq;

namespace CountriesPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"/Users/vasilisdimitriou/Documents/population.csv";

            CsvReader csvReader = new CsvReader(filePath);

            Dictionary<string, List<Country>> countries = csvReader.ReadAllCountries();

            Console.WriteLine($"Available regions\n");
            foreach (string region in countries.Keys)
            {
                Console.WriteLine(region);
            }

            Console.WriteLine("\nChoose one of the above regions to see its countries and their population.");
            string chosenRegion = Console.ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                {
                    Console.WriteLine($"Population: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid region");
            }
        }
    }
}
