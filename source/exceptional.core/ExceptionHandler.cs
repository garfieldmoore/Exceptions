using System;
using System.Collections.Generic;

namespace Rainbow.Exceptional
{
    public delegate void TestDelegate();

    public class ExceptionHandler : IHandle
    {
        private readonly Dictionary<Type, Action> _exceptions;

        internal ExceptionHandler(Dictionary<Type, Action> exceptions)
        {
            _exceptions = exceptions;
        }

        public ExceptionHandler()
            : this(new Dictionary<Type, Action>())
        {
        }

        public virtual IHandle On<T>(Action action)
        {

            _exceptions.Add(typeof(T), action);

            return this;
        }

        public virtual T When<T>(Func<T> func)
        {
            try
            {
                 return func.Invoke();
            }
            catch (Exception e)
            {
                if (_exceptions.ContainsKey(e.GetType()))
                {
                    var handler = _exceptions[e.GetType()];
                    handler.Invoke();
                }
                else
                {
                    throw;
                }
            }

            return default(T);
        }

        public virtual void When(TestDelegate func)
        {
            try
            {
                func.Invoke();
            }
            catch (Exception e)
            {
                if (_exceptions.ContainsKey(e.GetType()))
                {
                    var handler = _exceptions[e.GetType()];
                    handler.Invoke();
                }
                else
                {
                    throw;
                }
            }
        }
    }
}