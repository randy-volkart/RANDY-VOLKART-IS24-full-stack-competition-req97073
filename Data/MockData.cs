using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Security.Cryptography.X509Certificates;

namespace products.Data
{
    public static class MockData
    {
        public static readonly string FileName = $"{Environment.CurrentDirectory}\\data\\products.json";

        public static readonly string[] Products = new[]
        {
            "SOCKS",
            "SHOES",
            "CARDS",
            "SPOON",
            "CHALK",
            "KNIFE",
            "BREAD",
            "SPOON",
            "ZEBRA",
            "PHONE",
            "CHAIR",
            "STICK",
            "GLASS",
            "LIGHT",
            "HOUSE",
            "BENCH",
            "STICK",
            "SHAWL",
            "CLOCK",
            "SHEEP",
            "SHELF",
            "LADLE",
            "STONE",
            "TIGER",
            "SWORD",
            "SHELL",
            "ACORN",
            "BRUSH",
            "COUCH",
            "APPLE",
            "GLOBE",
            "SCREW",
            "SWORD",
            "PURSE",
            "SCARF",
            "SHIRT",
            "SHARK",
            "PURSE",
            "PANDA",
            "HOUSE"
        };

        public static readonly string[] FirstNames = new[]
        {
            "Thea",
            "Zain",
            "Azaan",
            "Maximilian",
            "Athena",
            "Adil",
            "Seth",
            "Mahnoor",
            "Melody",
            "Diego",
            "Meredith",
            "Kevin",
            "Oliwier",
            "Owen",
            "Gail",
            "Vera",
            "Juliette",
            "Claude",
            "Camilla",
            "Neha"
        };

        public static readonly string[] LastNames = new[]
        {
            "Houston",
            "Fischer",
            "John",
            "Roy",
            "Duffy",
            "Sykes",
            "Merritt",
            "Ballard",
            "Schroeder",
            "Aguilar",
            "Conway",
            "Durham",
            "Hogan",
            "Hancock",
            "Rocha",
            "Mayer",
            "Oneal",
            "Knowles",
            "Olson",
            "Kramer"
        };

        public static readonly string[] Methodology = new[]
{
            "Agile", "Waterfall"
        };

        public static string GenerateRandomObjectName()
        {
            return $"{Products[Random.Shared.Next(Products.Length)]}-{Products[Random.Shared.Next(Products.Length)]}";
        }
        public static string GenerateRandomName()
        {
            return $"{FirstNames[Random.Shared.Next(FirstNames.Length)]} {LastNames[Random.Shared.Next(LastNames.Length)]}";
        }

        public static List<string> GenerateRandomNameList(int max = 1)
        {
            List<string> names = new List<string>();

            for (int i = 0; i < Random.Shared.Next(1, max); i++)
            {
                names.Add(GenerateRandomName());
            }

            return names;
        }

        public static Products CreateProductsList(int count = 1)
        {
            Products ProductsList = new Products();
            int productNumberStart = Random.Shared.Next(100000, 900000);

            for (int i = 0; i < count; i++)
            {
                ProductsList.products.Add(new Product
                (
                    productNumberStart + i,
                    GenerateRandomObjectName(),
                    GenerateRandomName(),
                    GenerateRandomName(),
                    GenerateRandomNameList(5),
                    DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
                    Methodology[Random.Shared.Next(Methodology.Length)]
                ));
                ProductsList.count++;
            }

            return ProductsList;
        }
    }
}
