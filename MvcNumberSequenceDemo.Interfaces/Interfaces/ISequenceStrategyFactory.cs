using MvcNumberSequenceDemo.Entities.Constants;

namespace MvcNumberSequenceDemo.Interfaces.Interfaces
{
    public interface ISequenceStrategyFactory
    {
        ISequenceStrategy CreateSequenceStrategy(SequenceType type);
    }
}
