using Moq;
using System;
using Xunit;

namespace Faddiv.DotNet.Cleanup
{
    public class DisposabeContainerExtensionsTests
    {

        [Fact]
        public void AddCleanupAction_adds_CleanupAction_to_the_DisposableContainer()
        {
            var container = new DisposableContainer();
            var mock1 = new Mock<Action>();

            container.AddCleanupAction(mock1.Object);
            container.Dispose();

            mock1.Verify(d => d(), Times.Once);
        }

        [Fact]
        public void AddEventSubscription_adds_delegate_to_the_DisposableContainer()
        {

            var container = new DisposableContainer();
            var instanceMock = new Mock<IDummyObserver>();
            var source = new DummyEventSource();
            var args = new EventArgs();

            container.AddEventSubscription(source, nameof(source.InstanceHandler1), new EventHandler(instanceMock.Object.EventHandler));
            source.InvokeInstanceHandler1(args);
            container.Dispose();
            source.InvokeInstanceHandler1(args);

            instanceMock.Verify(d => d.EventHandler(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }

        [Fact]
        public void AddEventSubscription_adds_Action_to_the_DisposableContainer()
        {

            var container = new DisposableContainer();
            var instanceMock = new Mock<IDummyObserver>();
            var source = new DummyEventSource();
            var args = new EventArgs();

            container.AddEventSubscription<object, EventArgs>(source, nameof(source.InstanceHandler1), instanceMock.Object.EventHandler);
            source.InvokeInstanceHandler1(args);
            container.Dispose();
            source.InvokeInstanceHandler1(args);

            instanceMock.Verify(d => d.EventHandler(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }
    }
}
