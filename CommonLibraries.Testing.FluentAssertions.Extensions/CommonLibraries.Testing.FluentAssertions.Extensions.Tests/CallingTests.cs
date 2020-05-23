using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace CommonLibraries.Testing.FluentAssertions.Extensions
{
    public class CallingTests
    {
        [Fact]
        public void Calling_Method_Returns_right_message()
        {
            Action action = () =>
            {
                Calling.Method(() =>
                {
                    throw new Exception("x");
                }).Should().NotThrow();
            };
            action.Should().Throw<XunitException>();
        }


        [Fact]
        public void Calling_Function_Returns_right_message()
        {
            var i = 1;
            Action action = () =>
            {
                Calling.Function(() =>
                {
                    if(i > 0)
                    {
                        throw new Exception("x");
                    }
                    return 0;
                }).Should().NotThrow();
            };
            action.Should().Throw<XunitException>();
        }
    }
}
