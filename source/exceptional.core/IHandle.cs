using System;

namespace Rainbow.Exceptional
{
    public interface IHandle
    {
        IHandle On<T>(Action action);
        T When<T>(Func<T> func);
        void When(TestDelegate func);
    }
}