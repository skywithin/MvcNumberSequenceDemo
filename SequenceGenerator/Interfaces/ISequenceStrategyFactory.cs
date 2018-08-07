using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceGenerator.Interfaces
{
    public interface ISequenceStrategyFactory
    {
        ISequenceStrategy CreateSequenceStrategy(SequenceType type);
    }
}
