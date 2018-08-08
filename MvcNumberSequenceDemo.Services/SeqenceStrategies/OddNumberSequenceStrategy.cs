using MvcNumberSequenceDemo.Entities.Constants;

namespace MvcNumberSequenceDemo.Services.SequenceStrategies
{
    public class OddNumberSequenceStrategy : BaseSequenceStrategy
    {
        private int _evenNumber;
        private readonly int InitialOffset = -1;

        public override SequenceType Type
        {
            get
            {
                return SequenceType.OddNumberSequence;
            }
        }

        // Constructor
        public OddNumberSequenceStrategy()
        {
            _evenNumber = InitialOffset;
        }

        /// <summary>
        /// Returns an odd number.
        /// </summary>
        /// <returns></returns>
        public override string Next()
        {
            _evenNumber += 2;
            return _evenNumber.ToString();
        }
    }
}
