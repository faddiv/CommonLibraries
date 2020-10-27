using System;

namespace Blazorify.Utilities.Styling
{
    /// <summary>
    /// Implementation of the ICssBuilder. Use this class thorught the interface.
    /// </summary>
    public class CssBuilder : ICssBuilder
    {
        private readonly CssBuilderOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="CssBuilder"/> class.
        /// </summary>
        /// <param name="options">An options object which modifies class name generation and other things.</param>
        public CssBuilder(CssBuilderOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public CssList this[params object[] arguments]
        {
            get
            {
                return Create().AddMultiple(arguments);
            }
        }

        /// <inheritdoc />
        public CssList this[string cssClass, params (string, Func<bool>)[] tuple]
        {
            get
            {
                return Create().Add(cssClass).Add(tuple);
            }
        }

        /// <inheritdoc />
        public CssList Create(CssBuilderOptions options = null)
        {
            return new CssList(options ?? _options);
        }

    }
}
