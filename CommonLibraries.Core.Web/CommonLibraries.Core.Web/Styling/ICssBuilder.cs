using System;

namespace Blazorify.Utilities.Styling
{
    public interface ICssBuilder
    {
        /// <summary>
        /// Starts a new empty CssDefinition. It can be finished with .ToString(). In razor ToString is not neccessary.
        /// </summary>
        /// <param name="options">Modifies how the css class names is generated. If it is not given the the default used from the CssBuilder.</param>
        /// <returns>An empty css definition.</returns>
        CssList Create(CssBuilderOptions options = null);


        /// <summary>
        /// Starts a new CssDefinition and adds all the as classes.
        /// This is the main way to generate css classes in the razor pages.
        /// The result created by .ToString() but it can be skipped in razor.
        /// Example: class="@Css["class1", new { class2 = condition }]".
        /// </summary>
        /// <param name="arguments">
        /// One or more argument that can be converted to css class.
        /// Possible types: string, enum, anonymous type with only bool properties,
        /// ValueTuple where first parameter is string, the second is bool or Func&lt;bool&gt;,
        /// IEnumerable&lt;string&gt;, another CssDefinition or a IReadOnlyDictionary&lt;string, object&gt; with a class key.</param>
        /// <returns>
        /// A <see cref="CssList"/> that contains the processed css classes, and can be used in the class attribute directly.
        /// </returns>
        /// <example>
        ///     &lt;div class="@Css["class1", ("class2", true), new { class3 = true}]&gt;...&lt;/div&gt;
        /// </example>
        CssList this[params object[] arguments] { get; }

        /// <summary>
        /// Starts a new CssDefinition and adds all the as classes.
        /// This is the main way to generate css classes in the razor pages.
        /// The result created by .ToString() but it can be skipped in razor.
        /// Example: class="@Css["class1", ("class2", () =&gt; condition)]".
        /// </summary>
        /// <param name="cssClasses">Default classes to add. If it is null or empty then skipped.</param>
        /// <param name="tuple">List of tuple values that evaulated and added conditionally.</param>
        /// <returns>
        /// A <see cref="CssList"/> that contains the processed css classes, and can be used in the class attribute directly.
        /// </returns>
        /// <remarks>
        /// This variant created so Func&lt;bool&gt; also can be used on this call without writing out the Func.
        /// </remarks>
        CssList this[string cssClasses, params (string, Func<bool>)[] tuple] { get; }
    }
}
