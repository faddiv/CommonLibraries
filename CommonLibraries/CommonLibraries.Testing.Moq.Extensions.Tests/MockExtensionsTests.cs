using FluentAssertions;
using Moq;
using Xunit;

namespace CommonLibraries.Testing.Moq.Extensions.Tests
{
    public class MockExtensionsTests
    {
        [Fact]
        public void LastCall_when_function_called_returns_its_parameters()
        {
            var mock = new Mock<IMockedInterface>();
            mock.Setup(e => e.Function1(It.IsAny<string>())).Returns(1);
            mock.Object.Function1("test");

            mock.GetLastInvocationArguments(mock.Object.Function1,
                out string actual1);

            actual1.Should().Be("test");
        }

        [Fact]
        public void LastCall_when_function_called_returns_its_parameters2()
        {
            var mock = new Mock<IMockedInterface>();
            mock.Setup(e => e.Function2(It.IsAny<string>(), It.IsAny<int>())).Returns(1);
            mock.Object.Function2("test", 10);

            mock.GetLastInvocationArguments(mock.Object.Function2,
                out string actual1,
                out int actual2);

            actual1.Should().Be("test");
            actual2.Should().Be(10);
        }

        [Fact]
        public void LastCall_when_action_called_returns_its_parameters()
        {
            var mock = new Mock<IMockedInterface>();
            mock.Object.Action1("test");

            mock.GetLastInvocationArguments(mock.Object.Action1,
                out string actual1);

            actual1.Should().Be("test");
        }

        [Fact]
        public void LastCall_when_action_called_returns_its_parameters2()
        {
            var mock = new Mock<IMockedInterface>();
            mock.Object.Action2("test", 10);

            mock.GetLastInvocationArguments(mock.Object.Action2,
                out string actual1,
                out int actual2);

            actual1.Should().Be("test");
            actual2.Should().Be(10);
        }
    }

    public interface IMockedInterface
    {
        int Function1(string val1);

        int Function2(string val1, int val2);

        void Action1(string val1);

        void Action2(string val1, int val2);
    }
}
