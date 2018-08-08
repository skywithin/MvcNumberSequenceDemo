using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcNumberSequenceDemo.Interfaces.Interfaces;

namespace MvcNumberSequenceDemo.Services.Tests
{
    [TestClass]
    public class CustomSequenceStrategy
    {
        private ISequenceService Service { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            Service = new SequenceService();
        }

        [TestMethod]
        public void CustomSequenceStrategy_GivenValidNumberOfItemsToGenerate_GeneratesCorrectSequence()
        {
            var strategy = new SequenceStrategies.CustomSequenceStrategy();
            var numberOfItemsToGenerate = 15;

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
                int num = i + 1;
                string expectedVal = num.ToString();

                if (num % 2 == 0 && num % 3 == 0)
                {
                    expectedVal = "C";
                }
                else if (num % 2 == 0)
                {
                    expectedVal = "A";
                }
                else if (num % 3 == 0)
                {
                    expectedVal = "B";
                }

                Assert.IsTrue(
                    sequence.ElementAt(i).Equals(expectedVal),
                    string.Format(
                        $"Sequence item at index {i} has unexpected value '{sequence.ElementAt(i)}'"));
            }
        }
    }
}
