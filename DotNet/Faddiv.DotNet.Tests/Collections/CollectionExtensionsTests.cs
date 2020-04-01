using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Faddiv.DotNet.Collections
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
            var result = list.AddElements(1,2);

            // Assert
            result.Should().BeSameAs(list);
        }
    }
}
