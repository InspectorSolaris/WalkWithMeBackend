using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.Algorithms.Genetic
{
    public class Genetic<T, V>
    {
        public Func<Genotype<T, V>> Generator { get; set; }

        public Func<Genotype<T, V>, Genotype<T, V>> Fitness { get; set; }

        public Func<Genotype<T, V>, Genotype<T, V>, Genotype<T, V>> BestOf { get; set; }

        public Func<Genotype<T, V>, Genotype<T, V>, Genotype<T, V>> Crossover { get; set; }

        public Func<Genotype<T, V>, Genotype<T, V>> Mutate { get; set; }

        public Func<List<Genotype<T, V>>, List<(Genotype<T, V> GenotypeA, Genotype<T, V> GenotypeB)>> SelectToCrossover { get; set; }

        public Func<List<Genotype<T, V>>, List<Genotype<T, V>>> SelectToMutation { get; set; }

        public Func<List<Genotype<T, V>>, List<Genotype<T, V>>> SelectToSelection { get; set; }

        public Genotype<T, V> Run(
            int generationSize,
            int generationNumber)
        {
            if (Fitness is null ||
                BestOf is null ||
                Crossover is null ||
                Mutate is null ||
                SelectToCrossover is null ||
                SelectToMutation is null ||
                SelectToSelection is null)
            {
                return new Genotype<T, V>();
            }

            var generation = new Generation<T, V>(
                Generator,
                Fitness,
                BestOf,
                Crossover,
                Mutate,
                SelectToCrossover,
                SelectToMutation,
                SelectToSelection);

            generation.GenerateNew(generationSize);

            for (int i = 0; i < generationNumber; ++i)
            {
                generation.Update();
            }

            return generation.Best;
        }
    }
}
