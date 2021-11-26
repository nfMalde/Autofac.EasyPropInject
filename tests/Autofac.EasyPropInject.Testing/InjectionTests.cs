using Autofac.EasyPropInject.Testing.mocks;
using NUnit.Framework;

namespace Autofac.EasyPropInject.Testing
{
    /// <summary>
    /// Test for easy Property Injections
    /// </summary>
    public class InjectionTests
    {
        /// <summary>
        /// The container
        /// </summary>
        private IContainer container;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ContainerBuilder builder = new ContainerBuilder().AddEasyPropInject();
            builder.Register<Mock1>(x => new Mock1()).As<IMock1>();
            builder.Register<Mock2>(x => new Mock2()).As<IMock2>();
            builder.Register<Mock3>(x => new Mock3()).As<IMock3>();
            builder.Register<Mock4>(x => new Mock4()).As<IMock4>();
            builder.RegisterType<MockPrivate>().As<IMockPrivate>();
            builder.RegisterType<MockProtected>().As<IMockProtected>();

            this.container = builder.Build();
        }

        /// <summary>
        /// Tests if all instances are resolved correctly
        /// </summary>
        [Test]
        public void ItShouldInjectPropertiesOfInstanceAndChildInstances()
        {
            var m1 = this.container.Resolve<IMock1>();

            Assert.NotNull(m1.Mock2Property);
            Assert.NotNull(m1.Mock2Property.Mock3Property);
            Assert.NotNull(m1.Mock2Property.Mock3Property.Mock4ResolvedAsMainType);
        }

        [Test]
        public void ItShouldResolvePrivateProperties()
        {
            var mPrivate = this.container.Resolve<IMockPrivate>();

            Assert.NotNull(mPrivate.Mock1Test());
        }

        [Test]
        public void ItShouldResolveProtectedProperties()
        {
            var mPrivate = this.container.Resolve<IMockProtected>();

            Assert.NotNull(mPrivate.GetMockPrivate());
            Assert.NotNull(mPrivate.GetMockPrivate().Mock1Test());
        }
    }
}