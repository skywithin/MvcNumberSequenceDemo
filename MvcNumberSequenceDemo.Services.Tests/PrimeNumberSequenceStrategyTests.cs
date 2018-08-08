using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNumberSequenceDemo.Interfaces.Interfaces;
using MvcNumberSequenceDemo.Services.SequenceStrategies;

namespace MvcNumberSequenceDemo.Services.Tests
{
    [TestClass]
    public class PrimeNumberSequenceStrategyTests
    {
        private ISequenceService Service { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            Service = new SequenceService();
        }

        [TestMethod]
        public void PrimeNumberSequenceStrategy_GivenValidNumberOfItemsToGenerate_GeneratesCorrectSequence()
        {
            var strategy = new PrimeNumberSequenceStrategy();
            var numberOfItemsToGenerate = 10;

            var sequence = Service.GenerateSequence(strategy, numberOfItemsToGenerate);

            Assert.IsNotNull(sequence);
            Assert.IsTrue(
                sequence.Any(), 
                "Sequence contains no elements.");

            Assert.IsTrue(
                sequence.Count() == numberOfItemsToGenerate, 
                $"Number of generated elements should be {numberOfItemsToGenerate}");

            Assert.IsTrue(sequence.ElementAt(0).Equals("2"));
            Assert.IsTrue(sequence.ElementAt(1).Equals("3"));
            Assert.IsTrue(sequence.ElementAt(2).Equals("5"));
            Assert.IsTrue(sequence.ElementAt(3).Equals("7"));
            Assert.IsTrue(sequence.ElementAt(4).Equals("11"));
            Assert.IsTrue(sequence.ElementAt(5).Equals("13"));
            Assert.IsTrue(sequence.ElementAt(6).Equals("17"));
            Assert.IsTrue(sequence.ElementAt(7).Equals("19"));
            Assert.IsTrue(sequence.ElementAt(8).Equals("23"));
            Assert.IsTrue(sequence.ElementAt(9).Equals("29"));
        }
    }
}
