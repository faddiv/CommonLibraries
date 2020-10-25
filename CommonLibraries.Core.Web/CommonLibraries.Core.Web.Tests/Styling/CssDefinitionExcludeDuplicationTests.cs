using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Blazorify.Utilities.Styling
{
    public class CssDefinitionExcludeDuplicationTests
    {
        private CssBuilder cssBuilder = new CssBuilder(new CssBuilderOptions
        {
            ExcludeDuplication = true
        });

        private CssDefinition CreateCssDefinition(CssBuilderOptions options = null)
        {
            return cssBuilder.Create(options);
        }

        [Fact]
        public void Add_duplicates_by_default()
        {
            var result = CreateCssDefinition(new CssBuilderOptions())
                .Add("c1")
                .Add("c1")
                .ToString();

            result.Should().Be("c1 c1");
        }

        [Fact]
        public void AddMultiple_adds_a_class_only_single_time()
        {
            var result = CreateCssDefinition()
                .AddMultiple("c1", ("c1", true), new { c1 = true })
                .ToString();

            result.Should().Be("c1");
        }

        [Fact]
        public void Add_adds_a_class_only_single_time()
        {
            var result = CreateCssDefinition()
                .Add("c1")
                .Add(("c1", true))
                .Add(new { c1 = true })
                .ToString();

            result.Should().Be("c1");
        }

        [Fact]
        public void Add_adds_a_class_only_the_first_time()
        {
            var result = CreateCssDefinition()
                .Add("c1")
                .Add("c2")
                .Add("c1")
                .ToString();

            result.Should().Be("c1 c2");
        }

        [Fact]
        public void Add_considers_multi_css_in_string_with_condition()
        {
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add("c2 c3", true)
                .ToString();

            result.Should().Be("c1 c2 c3");
        }

        [Fact]
        public void Add_considers_multi_css_in_string_with_predicate()
        {
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add("c2 c3", () => true)
                .ToString();

            result.Should().Be("c1 c2 c3");
        }

        [Fact]
        public void Add_considers_multi_css_in_tuple_with_condition()
        {
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add(("c2 c3", true), ("c3 c4", true))
                .ToString();

            result.Should().Be("c1 c2 c3 c4");
        }

        [Fact]
        public void Add_considers_multi_css_in_enumerable()
        {
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add(new[] { "c2 c3", "c3 c4" })
                .ToString();

            result.Should().Be("c1 c2 c3 c4");
        }

        [Fact]
        public void Add_considers_multi_css_in_CssBuilder()
        {
            var other = CreateCssDefinition().Add("c2 c3");
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add(other)
                .ToString();

            result.Should().Be("c1 c2 c3");
        }

        [Fact]
        public void Add_considers_multi_css_in_tuple_with_predicate()
        {
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add(("c2 c3", () => true), ("c3 c4", () => true))
                .ToString();

            result.Should().Be("c1 c2 c3 c4");
        }

        [Fact]
        public void Add_considers_multi_css_in_Dictionary()
        {
            var dic = new Dictionary<string, object>
            {
                {"class", "c2 c3" }
            };
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add(dic)
                .ToString();

            result.Should().Be("c1 c2 c3");
        }

        [Fact]
        public void Add_considers_multi_css_in_AnonymousType()
        {
            var result = CreateCssDefinition()
                .Add("c1 c2")
                .Add(new { c2 = true, c3 = true })
                .ToString();

            result.Should().Be("c1 c2 c3");
        }

    }
}