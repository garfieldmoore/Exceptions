using System;

namespace Rainbow.Exceptional
{
    public interface IOn
    {
        IOn On<T>(Action action);
        IOn When<T>(T func);
        IOn When(Func<object> func);
    }
}