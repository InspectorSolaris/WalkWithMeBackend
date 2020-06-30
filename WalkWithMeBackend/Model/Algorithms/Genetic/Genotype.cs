using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.Algorithms.Genetic
{
    public class Genotype<T, V>
    {
        public Genotype(
            List<T> genes,
            V fitness)
        {
            this.Genes = genes;
            this.Fitness = fitness;
        }

        public Genotype(
            List<T> genes)
        {
            this.Genes = genes;
        }

        public Genotype()
        {
        }

        public List<T> Genes { get; } = new List<T>();

        public V Fitness { get; } = default;
    }
}
