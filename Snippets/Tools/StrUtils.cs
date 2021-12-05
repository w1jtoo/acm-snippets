using System.Collections.Generic;

namespace Snippets
{
    public static class StrUtils
    {
        public static IEnumerable<int> GetDigitsReversed(this int number)
        {
            var currentNumber = number;
            while (currentNumber > 0)
            {
                yield return currentNumber % 10;
                currentNumber /= 10;
            }
        }
    }
}