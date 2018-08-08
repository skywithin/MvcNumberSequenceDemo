using MvcNumberSequenceDemo.Entities.Constants;

namespace MvcNumberSequenceDemo.Services.SequenceStrategies
{
    public class BasicNumericSequenceStrategy : BaseSequenceStrategy
    {
        private int _number;
        private readonly int InitialOffset = -1;

        public override SequenceType Type
        {
            get
            {
                return SequenceType.BasicNumericSequence;
            }
        }

        // Constructor
        public BasicNumericSequenceStrategy()
        {
            _number = InitialOffset;
        }

        /// <summary>
        /// Returns a sequential number.
        /// </summary>
        /// <returns></returns>
        public override string Next()
        {
            _number++;
            return _number.ToString();
        }
    }
}
