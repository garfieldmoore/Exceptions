using System;
using NUnit.Framework;
using Rainbow.Exceptions;
using Shouldly;
using exceptional.core.tests.unit;

namespace exceptional.core.tests.acceptance
{
    [TestFixture]
    public class ExceptionalAcceptanceTests
    {
        [Test]
        public void Should_catch_exception()
        {
            var repository = new Repository();
            repository.Configure().On<NotImplementedException>(() => { Console.WriteLine("Caught exception"); }).When(() => { throw new NotImplementedException(); });
        }

        [Test]
        public void Returns_result_if_no_exception()
        {
            var repository = new Repository();
            int result = repository.Configure().On<Exception>(() => Console.WriteLine("caught")).When(() => 1 + 2);
            result.ShouldBe(3);
        }
    }
}
