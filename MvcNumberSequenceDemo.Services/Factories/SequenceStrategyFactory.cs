using MvcNumberSequenceDemo.Entities.Constants;
using MvcNumberSequenceDemo.Interfaces.Interfaces;
using MvcNumberSequenceDemo.Services.SequenceStrategies;
using System;

namespace MvcNumberSequenceDemo.Services.Factories
{
    public class SequenceStrategyFactory : ISequenceStrategyFactory
    {
        /// <summary>
        /// Returns a strategy for generating specified sequence.
        /// </summary>
        /// <param name="type">Type of required sequence.</param>
        /// <returns>Sequence strategy</returns>
        public ISequenceStrategy CreateSequenceStrategy(SequenceType type)
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
    }
}
