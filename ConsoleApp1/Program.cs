using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int populationSize = 10;

            Console.WriteLine("Please write a phrase as the target.");
            var target = Console.ReadLine();

            List<Monkey> population = new List<Monkey>();

            // Initalize population.
            for (int i = 0; i < populationSize; i++)
            {
                var newString = string.Empty;
                for (int y = 0; y < target.Length; y++)
                    newString += Helpers.GenerateRandomCharacter().ToString();

                population.Add(new Monkey(target, newString));
            }

            while (true)
            {
                foreach (var item in population)
                    Console.WriteLine(string.Format("Genes: {0} - Fitness: {1}", item.Genes, item.Fitness));

                Helpers.Wait(2);
                Console.Clear();

                List<Monkey> breedingPool = new List<Monkey>();

                foreach (var item in population)
                    for (int i = 0; i < item.Fitness; i++)
                        breedingPool.Add(item);

                population.Clear();
                for (int i = 0; i < populationSize; i++)
                {

                    var primeParent = breedingPool[Helpers.Random.Next(breedingPool.Count())];

                    var breedingPartners = breedingPool.Where(x => x != primeParent).ToList();
                    var secondParent = breedingPartners[Helpers.Random.Next(breedingPartners.Count())];

                    population.Add(primeParent.HaveOffspring(secondParent));
                }
            }



        }


    }
}
