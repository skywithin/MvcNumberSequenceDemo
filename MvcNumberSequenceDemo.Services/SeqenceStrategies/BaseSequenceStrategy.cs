using MvcNumberSequenceDemo.Entities.Constants;
using MvcNumberSequenceDemo.Interfaces.Interfaces;

namespace MvcNumberSequenceDemo.Services.SequenceStrategies
{
    public abstract class BaseSequenceStrategy : ISequenceStrategy
    {
        public abstract SequenceType Type { get; }

        public abstract string Next();
        
    }
}
