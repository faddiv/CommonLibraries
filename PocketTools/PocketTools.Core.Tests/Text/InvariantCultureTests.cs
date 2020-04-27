using Faddiv.DotNet.Text.TestHelpers;
using System;
using Xunit;

namespace Faddiv.DotNet.Text
{
    public class InvariantCultureTests : StringNaturalComparerCommonTests
    {
        public InvariantCultureTests()
            : base(StringNaturalComparer.InvariantCulture,
                  StringComparer.InvariantCulture)
        {
        }

        [Theory]
        [InlineData("F_", "FA")]
        [InlineData("ᵣ", "ʀ")]
        public void Non_equal_cases(string left, string right)
        {
            var expected = OrigComparer.Compare(left, right);
            Comparer.Should().ResultWithSignFor(left, right, expected);
        }
    }
}
