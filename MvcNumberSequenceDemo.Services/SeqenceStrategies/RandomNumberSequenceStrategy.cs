using MvcNumberSequenceDemo.Entities.Constants;
using System;

namespace MvcNumberSequenceDemo.Services.SequenceStrategies
{
    public class RandomNumberSequenceStrategy : BaseSequenceStrategy
    {
        Random rnd;

        public override SequenceType Type
        {
            get
            {
                return SequenceType.RandomNumberSequence;
            }
        }

        // Constructor
        public RandomNumberSequenceStrategy()
        {
            rnd = new Random();
        }

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns></returns>
        public override string Next()
        {
            return rnd.Next().ToString();
        }
    }
}
