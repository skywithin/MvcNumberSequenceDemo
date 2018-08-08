using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNumberSequenceDemo.Interfaces.Interfaces;
using MvcNumberSequenceDemo.Services.SequenceStrategies;

namespace MvcNumberSequenceDemo.Services.Tests
{
    

    [TestClass]
    public class BasicNumberSequenceStrategyTests
    {
        private ISequenceService Service { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            Service = new SequenceService();
        }

        [TestMethod]
        public void BasicNumberSequenceStrategy_GivenValidNumberOfItemsToGenerate_GeneratesCorrectSequence()
        {
            var strategy = new BasicNumericSequenceStrategy();
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
                Assert.IsTrue(
                    sequence.ElementAt(i).Equals(i.ToString()),
                    string.Format(
                        $"Sequence item at index {i} has unexpected value '{sequence.ElementAt(i)}'"));
            }
        }
    }
}
