using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketTools.Testing.FluentAssertions.Extensions
{
    public static class EnumerableAssertionsExtension
    {
        /// <summary>
        /// Expects the current collection to contain the specified elements in any order.
        /// Elements are compared using their key selected by key selector.
        /// </summary>
        /// <typeparam name="T">Type of the subject.</typeparam>
        /// <typeparam name="C">Type of the matching elements.</typeparam>
        /// <typeparam name="TKey">Type of the key which are used to match te elements.</typeparam>
        /// <param name="assertion">Result of the .Should() on a generic collection.</param>
        /// <param name="otherCollection">An <see cref="System.Collections.IEnumerable{T}"/> with the expected elements.</param>
        /// <param name="keySelector1">Key selector for the subject collection.</param>
        /// <param name="keySelector2">Key selector for the matching collection.</param>
        /// <param name="because">
        /// An optional formatted phrase as is supported by <see cref="string.Format(string,object[])"/>
        /// explaining why the assertion is needed. If the phrase does not start with the
        /// word because, it is prepended automatically.</param>
        /// <param name="becauseArgs">
        /// Zero or more objects to format using the placeholders in because.
        /// </param>
        /// <returns></returns>
        [CustomAssertion]
        public static IEnumerable<EnumerableElementAssertions<T, C>> HaveMatchingElementsByKey<T, C, TKey>(
            this GenericCollectionAssertions<T> assertion,
            IEnumerable<C> otherCollection,
            Func<T, TKey> keySelector1,
            Func<C, TKey> keySelector2,
            string because = "", params object[] becauseArgs)
            where T : class
            where C : class
        {
            assertion.HaveSameCount(otherCollection, because, becauseArgs);
            var list = new List<EnumerableElementAssertions<T, C>>();
            foreach (var element in assertion.Subject)
            {
                var key = keySelector1(element);
                var otherElement = otherCollection.FirstOrDefault(e => Equals(keySelector2(e), key));
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .ForCondition(otherElement != null)
                    .FailWith("Expected {context} to have element with key {0} but not found. Checked element: {1}", key, element);
                list.Add(new EnumerableElementAssertions<T, C>(element, otherElement));
            }
            return list;
        }

        /// <summary>
        /// Runs the given assertions for every matched elements in the collection.
        /// </summary>
        /// <typeparam name="T">Type of the subject.</typeparam>
        /// <typeparam name="C">Type of the matched elements.</typeparam>
        /// <param name="assertions">List of the matched element pairs.</param>
        /// <param name="predicate">An action containing the element assertions.</param>
        [CustomAssertion]
        public static void Statisfying<T, C>(this IEnumerable<EnumerableElementAssertions<T, C>> assertions,
            Action<T, C> predicate)
        {
            foreach (var item in assertions)
            {
                predicate(item.Subject, item.MatchedElement);
            }
        }
    }
}
