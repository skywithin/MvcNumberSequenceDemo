using System;

namespace SequenceGenerator.SequenceStrategies
{
    public class EvenNumberSequenceStrategy : BaseSequenceStrategy
    {
        private int _evenNumber;
        private readonly int InitialOffset = -2;

        public override SequenceType Type
        {
            get
            {
                return SequenceType.EvenNumberSequence;
            }
        }

        // Constructor
        public EvenNumberSequenceStrategy()
        {
            _evenNumber = InitialOffset;
        }

        /// <summary>
        /// Returns an even number.
        /// </summary>
        /// <returns></returns>
        public override string Next()
        {
            _evenNumber += 2;
            return _evenNumber.ToString();
        }
    }
}
