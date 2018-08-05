using SequenceGenerator.Interfaces;
using System;

namespace SequenceGenerator.SequenceStrategies
{
    public abstract class BaseSequenceStrategy : ISequenceStrategy
    {
        public abstract SequenceType Type { get; }

        public abstract string Next();
        
    }
}
