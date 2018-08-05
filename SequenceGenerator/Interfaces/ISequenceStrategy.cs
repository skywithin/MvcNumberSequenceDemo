using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceGenerator.Interfaces
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
