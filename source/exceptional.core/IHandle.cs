namespace Rainbow.Exceptions
{
    using System;

    /// <summary>
    /// Defines interface for fluent exception handlers
    /// </summary>
    public interface IHandle
    {
        IHandle On<T>(Action action);
        T When<T>(Func<T> func);
        void When(TestDelegate func);
    }
}