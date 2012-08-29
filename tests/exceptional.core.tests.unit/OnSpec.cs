using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Shouldly;

namespace exceptional.core.tests.unit
{
    [TestFixture]
    public class OnSpec
    {
        [Test]
        public void On_Exception_adds_exception_and_target_invocation()
        {
            var exceptions = new Dictionary<Type, Action>();
            var exception = new Rainbow.Exceptional.Exceptional(exceptions);
            Action action = () => Console.WriteLine("caught");

            exception.On<Exception>(action);

            exceptions.ContainsKey(typeof(Exception));
            exceptions.ContainsValue(action);
            exceptions.Count.ShouldBe(1);
        }

        [Test]
        public void When_invokes_target()
        {
            var exceptions = new Dictionary<Type, Action>();
            var exception = new Rainbow.Exceptional.Exceptional(exceptions);
            int invoke = 0;
            Action action = () => Console.WriteLine("caught");

            exception.On<Exception>(action).When(() => invoke++);
            invoke.ShouldBe(1);
        }

        [Test]
        public void When_invokes_exception_handler_on_exception()
        {
            var exceptions = new Dictionary<Type, Action>();
            var exception = new Rainbow.Exceptional.Exceptional(exceptions);
            int invoke = 0;
            Action action = () => invoke++;

            exception.On<NotImplementedException>(action).When(() => { throw new NotImplementedException(); });

            invoke.ShouldBe(1);
        }

        [Test]
        public void When_rethrows_if_no_handler()
        {
            var exceptions = new Dictionary<Type, Action>();
            var exception = new Rainbow.Exceptional.Exceptional(exceptions);
            int invoke = 0;
            Action action = () => invoke++;

            Assert.Throws<NotImplementedException>(() => exception.On<AbandonedMutexException>(action).When(() => { throw new NotImplementedException(); }));
        }

        //public delegate void TestDelegate();
    }
}