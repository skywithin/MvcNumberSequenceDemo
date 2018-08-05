using SequenceGenerator.Interfaces;
using SequenceGenerator.SequenceStrategies;
using System;
using System.Collections.Generic;

namespace SequenceGenerator
{
    public class SequenceService : ISequenceService 
    {
        /// <summary>
        /// Generate a sequence of items.
        /// </summary>
        /// <param name="strategy">Sequence generation strategy.</param>
        /// <param name="numberOfItems">Number of items to generate.</param>
        /// <returns>Sequence of generated items.</returns>
        public IEnumerable<string> GenerateSequence(ISequenceStrategy strategy, int numberOfItems)
        {
            if(numberOfItems < 0)
            {
                throw new ArgumentException(message: "Invalid number of items requested");
            }

            var sequence = new string[numberOfItems];

            for (int i = 0; i < numberOfItems; i++)
            {
                sequence[i] = strategy.Next();
            }

            return sequence;
        }

        /// <summary>
        /// Returns a strategy for generating specified sequence.
        /// </summary>
        /// <param name="type">Type of required sequence.</param>
        /// <returns>Sequence strategy</returns>
        public ISequenceStrategy GetSequenceStrategy(SequenceType type)
        {
            switch (type)
            {
                case SequenceType.BasicNumericSequence:
                    return new BasicNumericSequenceStrategy();

                case SequenceType.EvenNumberSequence:
                    return new EvenNumberSequenceStrategy();

                case SequenceType.OddNumberSequence:
                    return new OddNumberSequenceStrategy();

                case SequenceType.RandomNumberSequence:
                    return new RandomNumberSequenceStrategy();

                case SequenceType.PrimeNumberSequence:
                    return new PrimeNumberSequenceStrategy();

                case SequenceType.CustomSequence:
                    return new CustomSequenceStrategy();

                default:
                    throw new NotImplementedException(
                        string.Format($"Sequence strategy is not implemented for '{type}'"));
            }
        }


        public IEnumerable<SequenceTypeSummary> GetAvailableSequenceTypesInfo()
        {
            // This would usually be stored in a database

            return 
                new List<SequenceTypeSummary>
                {
                    new SequenceTypeSummary {
                        Type = SequenceType.BasicNumericSequence,
                        DisplayName = "Numeric sequence",
                        Description = "Sequence of positive numbers"},

                    new SequenceTypeSummary {
                        Type = SequenceType.EvenNumberSequence,
                        DisplayName = "Even numbers",
                        Description = "Sequence of positive even numbers"},

                    new SequenceTypeSummary {
                        Type = SequenceType.OddNumberSequence,
                        DisplayName = "Odd numbers",
                        Description = "Sequence of positive odd numbers"},

                    new SequenceTypeSummary {
                        Type = SequenceType.RandomNumberSequence,
                        DisplayName = "Random numbers",
                        Description = "Sequence of positive random numbers"},

                    new SequenceTypeSummary {
                        Type = SequenceType.PrimeNumberSequence,
                        DisplayName = "Prime numbers",
                        Description = "Sequence of positive prime numbers"},

                    new SequenceTypeSummary {
                        Type = SequenceType.CustomSequence,
                        DisplayName = "Custom number sequence",
                        Description = "Custom sequence. " 
                                    + "If number is devisible by 2 = 'A'. " 
                                    + "If number is devisible by 3 = 'B'. "
                                    + "If number is devisible by both 2 & 3 = 'C'"},
                };
        }
    }
}
