using System.Collections.Generic;

namespace Snippets
{
    public static class StrUtils
    {
        public static IEnumerable<long> GetDigitsReversed(this long number)
        {
            if (number == 0) yield return 0;
            var currentNumber = number;
            while (currentNumber != 0)
            {
                yield return currentNumber % 10;
                currentNumber /= 10;
            }
        }
    }
}