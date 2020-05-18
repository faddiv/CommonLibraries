using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using FluentAssertions.Collections;
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
                Console.WriteLine("");
            }).Should().Throw<XunitException>();
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
                Console.WriteLine("");
            }).Should().Throw<XunitException>();
        }

        [Fact]
        public void Statisfying_executes_action_with_the_matched_pairs_success()
        {
            var subject = NewSubjectTemps(3, "Example");
            var match = NewMatchedTemps(3, "Example");
            Fun(() =>
            {
                subject.Should().HaveMatchingElementsByKey(match, e => e.Id, e => e.Id)
                    .Statisfying((subject, matched) =>
                    {
                        subject.Name.Should().Be(matched.Value);
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
                    .Statisfying((subject, matched) =>
                    {
                        subject.Name.Should().Be(matched.Value);
                    });
            }).Should().Throw<XunitException>();
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
