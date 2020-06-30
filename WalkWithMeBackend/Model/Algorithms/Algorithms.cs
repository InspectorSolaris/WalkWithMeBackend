using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkWithMeBackend.Model.Algorithms.Genetic;
using WalkWithMeBackend.Model.Algorithms.Utilities;

namespace WalkWithMeBackend.Model.Algorithms
{
    public static class Algorithms
    {
        public static class Genetic
        {
            private static double CalculateLength(
               Genotype<int, double> genotype,
               List<List<double>> graph)
            {
                var length = 0.0;
                for (int i = 0; i < genotype.Genes.Count - 1; ++i)
                {
                    var a = genotype.Genes[i + 0];
                    var b = genotype.Genes[i + 1];

                    length += graph[a][b];
                }

                return length;
            }

            private static double CalculateInterest(
                Genotype<int, double> genotype,
                List<double> interest)
            {
                return genotype.Genes.Select(x => interest[x]).Sum();
            }

            public static List<int> Run(
                List<List<double>> graph,
                List<double> interest,
                double lengthDeviation = 0.2,
                int generationSize = 128,
                int generationNumber = 2048)
            {
                var genetic = new Genetic<int, double>();
                var verticesNumber = graph.Count;
                var fGene = 0;
                var lGene = graph.Count - 1;

                genetic.Generator = () =>
                {
                    var genes = new List<int>();
                    var genesPool = Enumerable.Range(fGene + 1, lGene - 1).ToList();
                    var size = (int)(genesPool.Count / 2.0, genesPool.Count / 8.0).NormalDistribution().ToRange(0, verticesNumber - 2);

                    for (int i = 0; i < size; ++i)
                    {
                        var gene = genesPool.RandBy();

                        genesPool.Remove(gene);
                        genes.Add(gene);
                    }

                    genes.Insert(0, fGene);
                    genes.Insert(genes.Count, lGene);

                    return new Genotype<int, double>(genes);
                };

                genetic.Fitness = (genotype) =>
                {
                    if (genotype.Fitness != 0)
                    {
                        return genotype;
                    }

                    var L = graph.First().Last();
                    var l = CalculateLength(genotype, graph);
                    var w = CalculateInterest(genotype, interest);

                    l = 0.0 + (l, L).Rel();
                    l = 1.0 + (l, lengthDeviation).Rel();

                    var fitness = 1.0 + w / l.Pow(2);

                    return new Genotype<int, double>(genotype.Genes, fitness);
                };

                genetic.BestOf = (genotypeA, genotypeB) =>
                {
                    return genotypeA.Fitness >= genotypeB.Fitness ? genotypeA : genotypeB;
                };

                genetic.Crossover = (genotypeA, genotypeB) =>
                {
                    var fa = genotypeA.Fitness;
                    var fb = genotypeB.Fitness;
                    var wa = (fa, fb).Percantage();
                    var wb = (fb, fa).Percantage();
                    var dic = new Dictionary<int, double>();

                    for (int i = 0; i < genotypeA.Genes.Count; ++i)
                    {
                        var gene = genotypeA.Genes.Count;
                        if (dic.ContainsKey(gene))
                        {
                            dic[gene] += wa * i;
                        }
                        else
                        {
                            dic.Add(gene, wa * i);
                        }
                    }
                    for (int i = 0; i < genotypeB.Genes.Count; ++i)
                    {
                        var gene = genotypeB.Genes.Count;
                        if (dic.ContainsKey(gene))
                        {
                            dic[gene] += wb * i;
                        }
                        else
                        {
                            dic.Add(gene, wb * i);
                        }
                    }

                    var min = (genotypeA.Genes.Count, genotypeB.Genes.Count).Min();
                    var max = (genotypeA.Genes.Count, genotypeB.Genes.Count).Max();
                    var size = (min, max).Rand();
                    var genes = new List<int>();

                    for (int i = 0; i < size; ++i)
                    {
                        var gene = dic.Min().Key;

                        genes.Add(gene);
                        dic.Remove(gene);
                    }

                    if (!genes.Contains(fGene)) { genes.Insert(0, fGene); }
                    if (!genes.Contains(lGene)) { genes.Insert(genes.Count, lGene); }

                    return new Genotype<int, double>(genes);
                };

                genetic.Mutate = (genotype) =>
                {
                    var genes = genotype.Genes.ToList();
                    var genesPool = Enumerable.Range(fGene, lGene - fGene + 1).ToList();

                    genes.ForEach(x => genesPool.Remove(x));

                    var pAdd = 0.3;
                    var pRemove = 0.3;
                    var pSwap = 0.8;
                    var iMax = 2 * genotype.Genes.Count;

                    var canAdd = new Func<bool>(() => pAdd.Success() && genesPool.Count > 0);
                    var canRemove = new Func<bool>(() => pRemove.Success() && genes.Count >= 3);
                    var canSwap = new Func<bool>(() => pSwap.Success() && genes.Count >= 4);

                    var changed = true;
                    var i = 0;

                    while (changed && i < iMax)
                    {
                        changed = false;
                        ++i;

                        if (canAdd())
                        {
                            var genesInd = (1, genes.Count).Rand();
                            var poolInd = (0, genesPool.Count).Rand();

                            genes.Insert(genesInd, genesPool[poolInd]);
                            genesPool.RemoveAt(poolInd);
                            changed = true;
                        }
                        if (canRemove())
                        {
                            var genesInd = (1, genes.Count - 1).Rand();

                            genesPool.Add(genes[genesInd]);
                            genes.RemoveAt(genesInd);
                            changed = true;
                        }
                        if (canSwap())
                        {
                            var li = (1, genes.Count - 1).Rand();
                            var ri = (1, genes.Count - 1).Rand();
                            var lv = genes[li];
                            var rv = genes[ri];

                            genes[li] = rv;
                            genes[ri] = lv;
                            changed = true;
                        }
                    }

                    return new Genotype<int, double>(genes);
                };

                genetic.SelectToCrossover = (genotypes) =>
                {
                    var selected = new List<(Genotype<int, double> GenotypeA, Genotype<int, double> GenotypeB)>();
                    var genotypesPool = genotypes.ToList();

                    while (selected.Count < generationSize / 4)
                    {
                        var genotypeA = genotypesPool.RandBy();
                        genotypesPool.Remove(genotypeA);

                        var genotypeB = genotypesPool.RandBy();
                        genotypesPool.Remove(genotypeB);

                        selected.Add((genotypeA, genotypeB));
                    }

                    return selected;
                };

                genetic.SelectToMutation = (genotypes) =>
                {
                    var selected = new List<Genotype<int, double>>();
                    var genotypesPool = genotypes.ToList();

                    while (selected.Count < generationSize / 4)
                    {
                        var genotype = genotypesPool.RandBy();
                        genotypesPool.Remove(genotype);

                        selected.Add(genotype);
                    }

                    return selected;
                };

                genetic.SelectToSelection = (genotypes) =>
                {
                    var selected = new List<Genotype<int, double>>();
                    var genotypesPool = genotypes.ToList();

                    while (selected.Count < generationSize)
                    {
                        var genotype = genotypesPool.RandBy(genotype => genotype.Fitness);
                        genotypesPool.Remove(genotype);

                        selected.Add(genotype);
                    }

                    return selected;
                };

                return genetic.Run(generationSize, generationNumber).Genes;
            }
        }
    }
}
