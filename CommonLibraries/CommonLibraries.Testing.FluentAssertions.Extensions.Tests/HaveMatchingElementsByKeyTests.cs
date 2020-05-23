using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace PocketTools.Testing.FluentAssertions.Extensions
{
    public class HaveMatchingElementsByKeyTests
    {
        int countSubject = 1;
        int countMatched = 1;

        [Fact]
        public void HaveMatchingElementsByKey_matches_count_pass()
        {
            var subject = NewSubjectTemps(3);
            var match = NewMatchedTemps(3);
            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id);
            }).Should().NotThrow();
        }

        [Fact]
        public void HaveMatchingElementsByKey_matches_count_fail()
        {
            var subject = NewSubjectTemps(3);
            var match = NewMatchedTemps(2);
            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id);
            }).Should().Throw<XunitException>().WithMessage("Expected subject to have 2 item(s), but found 3.");
        }

        [Fact]
        public void HaveMatchingElementsByKey_key_mismatch_fail()
        {
            var subject = NewSubjectTemps(3);
            var match = NewMatchedTemps(3);
            match[2].Id = 4;

            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id);
            }).Should().Throw<XunitException>().WithMessage(@"Expected subject to have element with key 3 but not found. Checked element: 

PocketTools.Testing.FluentAssertions.Extensions.SubjectTemp
{
   Id = 3
   Name = ""Val 3""
}");
        }

        [Fact]
        public void Statisfying_executes_action_with_the_matched_pairs_success()
        {
            var subject = NewSubjectTemps(3, "Example");
            var match = NewMatchedTemps(3, "Example");
            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id)
                    .Statisfying((item, matched) =>
                    {
                        item.Name.Should().Be(matched.Value);
                    });
            }).Should().NotThrow();
        }

        [Fact]
        public void Statisfying_executes_action_with_the_matched_pairs_fail()
        {
            var subject = NewSubjectTemps(3, "Example");
            var match = NewMatchedTemps(3, "Temp");
            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id)
                    .Statisfying((item, matched) =>
                    {
                        item.Name.Should().Be(matched.Value);
                    });
            }).Should().Throw<XunitException>().WithMessage(@"In the subject the 0. item didn't statisfyed all the condition on the matched element.
Item: 

PocketTools.Testing.FluentAssertions.Extensions.SubjectTemp
{
   Id = 1
   Name = ""Example""
}
MatchedElement: 

PocketTools.Testing.FluentAssertions.Extensions.MatchedTemp
{
   Id = 1
   Value = ""Temp""
}
Failures:
Expected item.Name to be ""Temp"" with a length of 4, but ""Example"" has a length of 7, differs near ""Exa"" (index 0).
");
        }

        [Fact]
        public void Statisfying_collect_the_exception_and_reports_it()
        {
            var subject = NewSubjectTemps(3, "Example");
            var match = NewMatchedTemps(3, "Temp");

            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id)
                    .Statisfying((item, matched) =>
                    {
                        throw new NullReferenceException();
                    });
            }).Should().Throw<XunitException>().WithMessage(@"*Failures:
Exception thrown: System.NullReferenceException with message ""Object reference not set to an instance of an object.""
     at *");
        }

        private static Action Fun(Action action)
        {
            return action;
        }

        public List<SubjectTemp> NewSubjectTemps(int count, string name = null)
        {
            return Enumerable.Range(0, count).Select(e => NewSubjectTemp(name)).ToList();
        }

        public List<MatchedTemp> NewMatchedTemps(int count, string name = null)
        {
            return Enumerable.Range(0, count).Select(e => NewMatchedTemp(name)).ToList();
        }

        public SubjectTemp NewSubjectTemp(string name = null)
        {
            var count = countSubject++;
            return new SubjectTemp
            {
                Id = count,
                Name = name ?? $"{name ?? "Val"} {count}"
            };
        }

        public MatchedTemp NewMatchedTemp(string value = null)
        {
            var count = countMatched++;
            return new MatchedTemp
            {
                Id = count,
                Value = value ?? $"{value ?? "Val"} {count}"
            };
        }
    }
    public class SubjectTemp
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MatchedTemp
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
