using System;

namespace TopTenCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"/Users/vasilisdimitriou/Documents/population.csv";

            CsvReader csvReader = new CsvReader(filePath);

            Country[] countries = csvReader.ReadFirstNCoutries(10);

            foreach (Country country in countries)
            {
                Console.WriteLine($"Population: {country.Population}, Country Name: {country.Name}");
            }
        }
    }
}
