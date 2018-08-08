using MvcNumberSequenceDemo.Entities.Constants;

namespace MvcNumberSequenceDemo.Interfaces.Interfaces
{
    public interface ISequenceStrategy
    {
        SequenceType Type { get; }

        /// <summary>
        /// Generate next element.
        /// </summary>
        /// <returns>Next element in sequence.</returns>
        string Next();
    }
}
