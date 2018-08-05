using System;
using System.Collections.Generic;

namespace SequenceGenerator.Interfaces
{
    public interface ISequenceService
    {
        /// <summary>
        /// Generate a sequence of items.
        /// </summary>
        /// <param name="strategy">Sequence generation strategy.</param>
        /// <param name="numberOfItems">Number of items to generate.</param>
        /// <returns>Sequence of generated items.</returns>
        IEnumerable<string> GenerateSequence(ISequenceStrategy strategy, int numberOfItems);

        ISequenceStrategy GetSequenceStrategy(SequenceType type);

        IEnumerable<SequenceTypeSummary> GetAvailableSequenceTypesInfo();
    }
}
