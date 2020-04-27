using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PocketTools.Core.Collections
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void AddRange_adds_multiple_elements()
        {
            // Arrange
            ICollection<int> list = Enumerable.Range(0, 3).ToList();
            var newElements = Enumerable.Range(3, 3);
            var expected = Enumerable.Range(0, 6).ToList();

            // Act
            list.AddRange(newElements);

            // Assert
            list.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AddRange_requires_the_list()
        {
            // Arrange
            ICollection<int> list = null;
            var newElements = Enumerable.Range(3, 3);
            Action action = () => list.AddRange(newElements);

            // Act
            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddRange_requires_the_collection()
        {
            // Arrange
            ICollection<int> list = Enumerable.Range(3, 3).ToList();
            IEnumerable<int> newElements = null;
            Action action = () => list.AddRange(newElements);

            // Act
            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddRange_returns_the_collection()
        {
            // Arrange
            ICollection<int> list = Enumerable.Range(0, 3).ToList();
            var newElements = Enumerable.Range(3, 3);

            // Act
            var result = list.AddRange(newElements);

            // Assert
            result.Should().BeSameAs(list);
        }

        [Fact]
        public void AddElements_adds_multiple_elements()
        {
            // Arrange
            ICollection<int> list = Enumerable.Range(0, 3).ToList();
            var expected = Enumerable.Range(0, 6).ToList();

            // Act
            list.AddElements(3, 4, 5);

            // Assert
            list.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AddElements_requires_the_list()
        {
            // Arrange
            ICollection<int> list = null;
            var newElements = Enumerable.Range(3, 3).ToArray();
            Action action = () => list.AddElements(newElements);

            // Act
            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddElements_requires_the_collection()
        {
            // Arrange
            ICollection<int> list = Enumerable.Range(3, 3).ToList();
            int[] newElements = null;
            Action action = () => list.AddElements(newElements);

            // Act
            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddElements_returns_the_collection()
        {
            // Arrange
            ICollection<int> list = Enumerable.Range(0, 3).ToList();

            // Act
            var result = list.AddElements(1, 2);

            // Assert
            result.Should().BeSameAs(list);
        }

        [Fact]
        public void FindAndRemove_finds_the_element_by_match_function()
        {
            // Arrange
            var elements = new List<int> { 1, 2, 3 };

            // Act
            var result = elements.FindAndRemove(e => e == 2);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void FindAndRemove_returns_default_if_not_found()
        {
            // Arrange
            var elements = new List<int> { 1, 2, 3 };

            // Act
            var result = elements.FindAndRemove(e => e == 4);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void FindAndRemove_removes_the_element_from_the_list()
        {
            // Arrange
            var elements = new List<int> { 1, 2, 3 };

            // Act
            elements.FindAndRemove(e => e == 2);

            // Assert
            elements.Should().NotContain(2);
        }

        [Fact]
        public void FindAndRemove_removes_the_element_from_the_collection()
        {
            // Arrange
            var elements = new Dictionary<int, string> {
                { 1, "a"},
                { 2, "b"},
                { 3, "c"}
            };

            // Act
            elements.FindAndRemove(e => e.Key == 2);

            // Assert
            elements.Should().NotContainKey(2);
        }

        [Fact]
        public void FindAndRemove_requires_the_collection()
        {
            // Arrange
            ICollection<int> elements = null;

            // Act
            Func<int> func = () => elements.FindAndRemove(e => e == 2);

            // Assert
            func.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FindAndRemove_requires_the_match()
        {
            // Arrange
            var elements = new List<int> { 1 };

            // Act
            Func<int> func = () => elements.FindAndRemove(null);

            // Assert
            func.Should().Throw<ArgumentNullException>();
        }
    }
}
