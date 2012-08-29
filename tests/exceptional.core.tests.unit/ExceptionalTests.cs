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
            //repository.Configure().On<NotImplementedException>(() => { Console.WriteLine("Caught exception"); }).When(repository.DoNothing);

            //repository.On<Exception>();
        }
    }
}
