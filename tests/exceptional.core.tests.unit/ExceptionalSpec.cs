using NUnit.Framework;
using Rainbow.Exceptions;
using Shouldly;

namespace exceptional.core.tests.unit
{
    [TestFixture]
    public class ExceptionalSpec
    {
        [Test]
        public void Configure_returns_handler()
        {
            Exceptional.Handle().ShouldBeTypeOf<IHandle>();
        }
    }
}