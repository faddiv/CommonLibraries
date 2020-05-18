namespace PocketTools.Testing.FluentAssertions.Extensions
{
    public class EnumerableElementAssertions<TSubject, CSubject>
    {
        public EnumerableElementAssertions(TSubject subject, CSubject matchedElement)
        {
            Subject = subject;
            MatchedElement = matchedElement;
        }

        public TSubject Subject { get; }
        public CSubject MatchedElement { get; }
    }
}
