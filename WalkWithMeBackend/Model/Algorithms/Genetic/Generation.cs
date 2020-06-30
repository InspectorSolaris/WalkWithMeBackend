using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.Algorithms.Genetic
{
    public class Generation<T, V>
    {
        public Generation(
            Func<Genotype<T, V>> generator,
            Func<Genotype<T, V>, Genotype<T, V>> fitness,
            Func<Genotype<T, V>, Genotype<T, V>, Genotype<T, V>> bestOf,
            Func<Genotype<T, V>, Genotype<T, V>, Genotype<T, V>> crossover,
            Func<Genotype<T, V>, Genotype<T, V>> mutate,
            Func<List<Genotype<T, V>>, List<(Genotype<T, V> GenotypeA, Genotype<T, V> GenotypeB)>> selectToCrossover,
            Func<List<Genotype<T, V>>, List<Genotype<T, V>>> selectToMutation,
            Func<List<Genotype<T, V>>, List<Genotype<T, V>>> selectToSelection)
        {
            this.Genertor = generator;
            this.Fitness = fitness;
            this.BestOf = bestOf;
            this.Crossover = crossover;
            this.Mutate = mutate;
            this.SelectToCrossover = selectToCrossover;
            this.SelectToMutation = selectToMutation;
            this.SelectToSelection = selectToSelection;
        }

        private Func<Genotype<T, V>> Genertor { get; }

        private Func<Genotype<T, V>, Genotype<T, V>> Fitness { get; }

        private Func<Genotype<T, V>, Genotype<T, V>, Genotype<T, V>> BestOf { get; }

        private Func<Genotype<T, V>, Genotype<T, V>, Genotype<T, V>> Crossover { get; }

        private Func<Genotype<T, V>, Genotype<T, V>> Mutate { get; }

        private Func<List<Genotype<T, V>>, List<(Genotype<T, V> GenotypeA, Genotype<T, V> GenotypeB)>> SelectToCrossover { get; }

        private Func<List<Genotype<T, V>>, List<Genotype<T, V>>> SelectToMutation { get; }

        private Func<List<Genotype<T, V>>, List<Genotype<T, V>>> SelectToSelection { get; }

        private List<Genotype<T, V>> Genotypes { get; set; } = new List<Genotype<T, V>>();

        public Genotype<T, V> Best { get; private set; } = new Genotype<T, V>();
        
        public void GenerateNew(int size)
        {
            Genotypes.Clear();

            for (int i = 0; i < size; ++i)
            {
                var genotype = Fitness(Genertor());
                
                Genotypes.Add(genotype);
                Best = BestOf(genotype, Best);
            }
        }

        public void Update()
        {
            CrossoverStage();
            MutationStage();
            SelectionStage();
        }

        private void CrossoverStage()
        {
            SelectToCrossover(Genotypes).ForEach(genotypes =>
            {
                var a = genotypes.GenotypeA;
                var b = genotypes.GenotypeB;
                var genotype = Fitness(Crossover(a, b));

                Genotypes.Add(genotype);
                Best = BestOf(genotype, Best);
            });
        }

        private void MutationStage()
        {
            SelectToMutation(Genotypes).ForEach(genotype =>
            {
                genotype = Fitness(Mutate(genotype));

                Best = BestOf(genotype, Best);
            });
        }

        private void SelectionStage()
        {
            Genotypes = SelectToSelection(Genotypes);
        }
    }
}
