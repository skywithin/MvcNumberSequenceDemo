using System;
using System.Collections;
using System.Collections.Generic;

namespace SequenceGenerator.SequenceStrategies
{
    public class PrimeNumberSequenceStrategy : BaseSequenceStrategy
    {
        private int _index;
        private List<int> _primes; 
        private readonly int InitialPrimesCount;

        public override SequenceType Type
        {
            get
            {
                return SequenceType.PrimeNumberSequence;
            }
        }

        // Constructor
        public PrimeNumberSequenceStrategy()
        {
            _index = 0;

            InitializePrimesList();

            InitialPrimesCount = _primes.Count;
        }

        private void InitializePrimesList()
        {
            _primes = new List<int>();

            // Add two inital primes
            _primes.Add(2);
            _primes.Add(3);
        }

        /// <summary>
        /// Returns a positive prime integer.
        /// </summary>
        /// <returns></returns>
        public override string Next()
        {
            // The first two primes are already populated
            if (_index < InitialPrimesCount)
            {
                var primeNumber = _primes[_index++];
                return primeNumber.ToString();
            }

            _index++;

            return GetNextPrime().ToString();
        }

        private int GetNextPrime()
        {
            int nextPrime = (_primes[_primes.Count - 1]) + 2;
            while (true)
            {
                bool isPrime = true;
                foreach (int n in _primes)
                {
                    if (nextPrime % n == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    break;
                }
                else
                {
                    nextPrime += 2;
                }
            }
            _primes.Add(nextPrime);

            return nextPrime;
        }
    }
}
