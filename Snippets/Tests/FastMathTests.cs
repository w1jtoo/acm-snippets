using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Snippets;
using Snippets.Math;

namespace Tests
{
    [TestFixture]
    public class FastMathTests
    {
        [Test]
        public void FastIntPowTests()
        {
            for (var exp = 0; exp < 12; exp++)
            for (var pow = 0; pow < 8; pow++)
                FastMath.IntegerPow(exp, pow)
                    .Should().Be((int) Math.Pow(exp, pow));
        }

        [TestCase(1d, 1d, 5d)]
        [TestCase(2d, 10d, 600d)]
        [TestCase(10d, 6d, 100_000d)]
        [TestCase(10d, 4.5, 2000d)]
        public void FastApproximationPowTests(double exp, double pow, double prec)
        {
            var fast = FastMath.FastPow(exp, pow);
            var @default = Math.Pow(exp, pow);

            fast.Should().BeApproximately(@default - 1, prec);
        }

        [Test]
        public void SqrtTests()
        {
            for (var i = 1; i > 0; i += int.MaxValue / 1_000_000)
                i.IntSqrt().Should().BeCloseTo((int)((float) i).Sqrt2(), 100);
        }

        [Test]
        [Timeout(5_000)]
        public void Factorization_FactorsShouldProduceNumber()
        {
            for (var i = 0L; i < 100_000; i++) i.GetPrimeFactors().Aggregate((a, b) => a * b).Should().Be(i);
        }
    }
}