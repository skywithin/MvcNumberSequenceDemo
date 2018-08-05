using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceGenerator.Interfaces;
using SequenceGenerator.SequenceStrategies;

namespace SequenceGenerator.Tests
{
    [TestClass]
    public class RandomNumberSequenceStrategyTests
    {
        private ISequenceService Service { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            Service = new SequenceService();
        }

        [TestMethod]
        public void RandomNumberSequenceStrategy_GivenValidNumberOfItemsToGenerate_GeneratesCorrectSequence()
        {
            var strategy = new RandomNumberSequenceStrategy();
            var numberOfItemsToGenerate = 5;

            var sequence1 = Service.GenerateSequence(strategy, numberOfItemsToGenerate);
            var sequence2 = Service.GenerateSequence(strategy, numberOfItemsToGenerate);

            Assert.IsNotNull(sequence1);
            Assert.IsTrue(
                sequence1.Any(),
                "Sequence contains no elements.");

            Assert.IsNotNull(sequence2);
            Assert.IsTrue(
                sequence2.Any(),
                "Sequence contains no elements.");

            Assert.IsTrue(
                sequence1.Count() == numberOfItemsToGenerate,
                $"Number of generated elements should be {numberOfItemsToGenerate}");

            var sequence1Str = GetString(sequence1);
            var sequence2Str = GetString(sequence2);

            Assert.IsFalse(sequence1Str.Equals(sequence2Str));
        }

        private string GetString(IEnumerable<string> items)
        {
            var sb = new StringBuilder();
            
            foreach (var item in items)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
