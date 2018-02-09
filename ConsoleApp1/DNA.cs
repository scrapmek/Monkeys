using System;

namespace ConsoleApp1
{
    internal class Monkey
    {
        public string Genes { get; set; }
        public int Fitness { get => getFitness(); }
        public decimal MutationFactor { get => 0.01m; }

        private string target;

        public Monkey(string target) => this.target = target;

        public Monkey(string target, string genes)
        {
            this.target = target;
            this.Genes = genes;
        }

        public Monkey HaveOffspring(Monkey partner)
        {
            string childGenes = string.Empty;
            string longestParent;
            string shortestParent;

            if (this.Genes.Length >= partner.Genes.Length)
            {
                longestParent = this.Genes;
                shortestParent = partner.Genes;
            }
            else
            {
                longestParent = partner.Genes;
                shortestParent = this.Genes;
            }

            //Combine genes.

            for (int i = 0; i < longestParent.Length; i++)
            {
                if (Helpers.FlipCoin())
                    childGenes += longestParent[i];
                else
                {
                    if (shortestParent.Length >= i + 1)
                        childGenes += shortestParent[i];
                    else
                        childGenes += " ";

                }
            }

            // Mutate.

            for (int i = 0; i < childGenes.Length; i++)
            {
                if (((decimal)Helpers.Random.Next(100)) / 100 < this.MutationFactor)
                    childGenes = childGenes.Remove(i).Insert(i, Helpers.GenerateRandomCharacter().ToString());
            }

            if (((decimal)Helpers.Random.Next(100)) / 100 < this.MutationFactor)
                childGenes += Helpers.GenerateRandomCharacter();

            return new Monkey(this.target, childGenes);
        }

        private int getFitness()
        {
            int fitness = 0;
            for (int i = 0; i < Genes.Length; i++)
            {
                if (target.Length >= i + 1)
                    if (Genes[i] == target[i])
                        fitness++;
            }

            if (Genes.Length > target.Length)
                fitness -= Genes.Length - target.Length;

            fitness = (int)(fitness * 1.5);

            return fitness;
        }
    }
}