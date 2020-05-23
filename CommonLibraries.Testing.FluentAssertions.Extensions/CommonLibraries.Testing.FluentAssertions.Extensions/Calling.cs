using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibraries.Testing.FluentAssertions.Extensions
{
    public static class Calling
    {
        public static Action Method(Action action)
        {
            return action;
        }

        public static Func<T> Function<T>(Func<T> func)
        {
            return func;
        }
    }
}
