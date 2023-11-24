using System.Xml.Linq;

namespace P03.P_rates
{
    internal class Program
    {
        class City
        {
            public City(string name, int population, int gold)
            {
                Name = name;
                Population = population;
                Gold = gold;
            }

            public string Name { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }
        }
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] data = input.Split("||");
                string name = data[0];
                int population = int.Parse(data[1]);
                int gold = int.Parse(data[2]);

                City foundCity = cities.FirstOrDefault(city => city.Name == name);
                if (foundCity == null)
                {
                    City city = new City(name, population, gold);
                    cities.Add(city);
                }
                else
                {
                    foundCity.Population += population;
                    foundCity.Gold += gold;

                }
            }

            string events;
            while ((events = Console.ReadLine()) != "End")
            {
                string[] instructions = events.Split("=>");
                string command = instructions[0];

                if (command == "Plunder")
                {
                    string town = instructions[1];
                    int people = int.Parse(instructions[2]);
                    int gold = int.Parse(instructions[3]);

                    City foundCity = cities.FirstOrDefault(city => city.Name == town);
                    foundCity.Population -= people;
                    foundCity.Gold -= gold;
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (foundCity.Population == 0 || foundCity.Gold == 0)
                    {
                        cities.Remove(foundCity);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (command == "Prosper")
                {
                    string town = instructions[1];
                    int gold = int.Parse(instructions[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        City foundCity = cities.FirstOrDefault(city => city.Name == town);
                        foundCity.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {foundCity.Gold} gold.");
                    }
                }
            }

            if (cities.Count == 0) 
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach ( City city in cities )
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
        }
    }
}