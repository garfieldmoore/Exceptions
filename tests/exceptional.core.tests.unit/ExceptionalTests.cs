using System;
using NUnit.Framework;

namespace exceptional.core.tests.acceptance
{
    [TestFixture]
    public class ExceptionalTests
    {
        [Test]
        public void Should_catch_exception()
        {
            var repository = new Repository();

            repository.Configure().On<NotImplementedException>(() => { Console.WriteLine("Caught exception"); }).When(() => { throw new NotImplementedException(); });
            
        }

        [Test]
        public void Should_catch_exception_for_void_methods()
        {
            var repository = new Repository();

            repository.Configure().On<NotImplementedException>(() => { Console.WriteLine("Caught exception"); }).When(() => repository.DoNothing());
        }

        [Test]
        public void When_return_result_if_no_exception()
        {

        }


    }
}
