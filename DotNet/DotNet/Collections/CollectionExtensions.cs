using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faddiv.DotNet.Collections
{
    public static class CollectionExtensions
    {
        /// <summary>
        ///     Adds the elements of the specified collection to the end of 
        ///     the <see cref="ICollection{TElement}"/>. The collection has to 
        ///     support <see cref="ICollection{TElement}.Add(TElement)">Add(TElement)</see>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the list.</typeparam>
        /// <typeparam name="TElement">The type of elements in the list.</typeparam>
        /// <param name="collection">
        ///     The collection where the elements should be added. It has to support <see cref="ICollection{T}.Add"/>.
        /// </param>
        /// <param name="elements">
        ///     The collection whose elements should be added to the end of 
        ///     the <see cref="ICollection{TElement}"/>. The collection itself cannot 
        ///     be null, but it can contain elements that are null, if type TElement
        ///     is a reference type.
        /// </param>
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
        ///     Adds the elements of the specified collection to the end of 
        ///     the <see cref="ICollection{TElement}"/>. The collection has to 
        ///     support <see cref="ICollection{TElement}.Add(TElement)">Add(TElement)</see>.
        /// </summary>
        /// <typeparam name="TCollection">The type of the list.</typeparam>
        /// <typeparam name="TElement">The type of elements in the list.</typeparam>
        /// <param name="collection">
        ///     The collection where the elements should be added. It has to support <see cref="ICollection{T}.Add"/>.
        /// </param>
        /// <param name="elements">
        ///     The invidual elements that should be added to the end of 
        ///     the <see cref="ICollection{TElement}"/>. The collection itself cannot 
        ///     be null, but it can contain elements that are null, if type TElement
        ///     is a reference type.
        /// </param>
        public static TCollection AddElements<TCollection, TElement>(this TCollection collection, params TElement[] elements)
            where TCollection : class, ICollection<TElement>
        {
            return collection.AddRange(elements.AsEnumerable());
        }
    }
}
