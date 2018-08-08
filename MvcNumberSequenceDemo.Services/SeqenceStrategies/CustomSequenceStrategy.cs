using MvcNumberSequenceDemo.Entities.Constants;
using System.Collections.Generic;

namespace MvcNumberSequenceDemo.Services.SequenceStrategies
{
    public class CustomSequenceStrategy : BaseSequenceStrategy
    {
        private int _number;
        private List<string> _sequence;

        public override SequenceType Type
        {
            get
            {
                return SequenceType.CustomSequence;
            }
        }

        // Constructor
        public CustomSequenceStrategy()
        {
            _number = 1;
            _sequence = new List<string>();

        }

        /// <summary>
        /// If number is devisible by 2 - return "A"
        /// If number is devisible by 3 - return "B"
        /// If number is devisible by both 2 & 3 - return "C"
        /// </summary>
        /// <returns></returns>
        public override string Next()
        {
            return Transform(_number++);
        }

        private string Transform(int numberToTransform)
        {
            if (IsDevisibleBy(numberToTransform, 2, 3))
            {
                return "C";
            }

            if (IsDevisibleBy(numberToTransform, 2))
            {
                return "A";
            }

            if (IsDevisibleBy(numberToTransform, 3))
            {
                return "B";
            }

            return numberToTransform.ToString();
        }


        /// <summary>
        /// Check if a given number is devisible by ALL divisors
        /// </summary>
        /// <param name="numberToCheck"></param>
        /// <param name="divisors"></param>
        /// <returns></returns>
        private bool IsDevisibleBy(int numberToCheck, params int[] divisors)
        {
            foreach(int d in divisors)
            {
                if (numberToCheck % d != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
