using System;
using System.Collections.Generic;

namespace Faddiv.DotNet.Collections
{
    public static class CollectionExtensions
    {
        /// <summary>
        ///     Adds the elements of the specified collection to the end of the <see cref="ICollection{T}"/>. 
        ///     The collection has to support <see cref="ICollection{T}.Add(T)">Add(TElement)</see>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the list.</typeparam>
        /// <typeparam name="TElement">The type of elements in the list.</typeparam>
        /// <param name="collection">
        ///     The collection where the elements should be added. It has to support <see cref="ICollection{T}.Add"/>.
        /// </param>
        /// <param name="elements">
        ///     The collection whose elements should be added to the end of the <see cref="ICollection{T}"/>. 
        ///     The collection itself cannot be null, but it can contain elements that are null, if type TElement
        ///     is a reference type.
        /// </param>
        /// <returns>
        ///     The collection parameter. So it can be chained.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Collection or elements is null.
        /// </exception>
        public static TCollection AddRange<TCollection, TElement>(this TCollection collection, IEnumerable<TElement> elements)
            where TCollection : class, ICollection<TElement>
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            if (elements is null)
                throw new ArgumentNullException(nameof(elements));

            foreach (var item in elements)
            {
                collection.Add(item);
            }
            return collection;
        }

        /// <summary>
        ///     Adds the elements of the specified collection to the end of the <see cref="ICollection{T}"/>. 
        ///     The collection has to support <see cref="ICollection{T}.Add(T)">Add(T)</see>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the list.</typeparam>
        /// <typeparam name="TElement">The type of elements in the list.</typeparam>
        /// <param name="collection">
        ///     The collection where the elements should be added. It has to support <see cref="ICollection{T}.Add"/>.
        /// </param>
        /// <param name="elements">
        ///     The invidual elements that should be added to the end of the <see cref="ICollection{T}"/>. 
        ///     The collection itself cannot be null, but it can contain elements that are null, if 
        ///     type TElement is a reference type.
        /// </param>
        /// <returns>
        ///     The collection parameter. So it can be chained.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Collection or elements is null.
        /// </exception>
        public static TCollection AddElements<TCollection, TElement>(this TCollection collection, params TElement[] elements)
            where TCollection : class, ICollection<TElement>
        {
            return collection.AddRange(elements);
        }

        /// <summary>
        ///     Searches for the first occurrence of an element that matches the conditions defined by 
        ///     the specified predicate. If found it is removed from the <see cref="ICollection{T}"/> and returned.
        /// </summary>
        /// <typeparam name="TElement">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection which searched.</param>
        /// <param name="match">
        ///     The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>
        ///     The element that matches the condition or default if not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     The collection or the match is null.
        /// </exception>
        public static TElement FindAndRemove<TElement>(this ICollection<TElement> collection, Predicate<TElement> match)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            if (match is null)
                throw new ArgumentNullException(nameof(match));

            if (collection is IList<TElement> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    if (match(item))
                    {
                        list.RemoveAt(i);
                        return item;
                    }
                }
            }
            else
            {
                foreach (var item in collection)
                {
                    if (match(item))
                    {
                        collection.Remove(item);
                    }
                }
            }
            return default;
        }
    }
}
