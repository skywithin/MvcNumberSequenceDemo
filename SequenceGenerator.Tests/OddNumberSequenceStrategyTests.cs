using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceGenerator.Interfaces;
using SequenceGenerator.SequenceStrategies;

namespace SequenceGenerator.Tests
{
    [TestClass]
    public class OddNumberSequenceStrategyTests
    {
        private ISequenceService Service { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            Service = new SequenceService();
        }

        [TestMethod]
        public void OddNumberSequenceStrategy_GivenValidNumberOfItemsToGenerate_GeneratesCorrectSequence()
        {
            var strategy = new OddNumberSequenceStrategy();
            var numberOfItemsToGenerate = 5;

            var sequence = Service.GenerateSequence(strategy, numberOfItemsToGenerate);

            Assert.IsNotNull(sequence);
            Assert.IsTrue(
                sequence.Any(), 
                "Sequence contains no elements.");

            Assert.IsTrue(
                sequence.Count() == numberOfItemsToGenerate, 
                $"Number of generated elements should be {numberOfItemsToGenerate}");

            for (int i = 0; i < numberOfItemsToGenerate; i++)
            {
                var expectedNum = (i * 2) + 1;

                Assert.IsTrue(
                    sequence.ElementAt(i).Equals(expectedNum.ToString()),
                    string.Format(
                        $"Sequence item at index {i} has unexpected value '{sequence.ElementAt(i)}'"));
            }
        }
    }
}
