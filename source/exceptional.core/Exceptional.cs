using System;
using System.Collections.Generic;

namespace Rainbow.Exceptional
{
    public delegate void TestDelegate();

    public class Exceptional : IOn
    {
        private readonly Dictionary<Type, Action> _exceptions;

        internal Exceptional(Dictionary<Type, Action> exceptions)
        {
            _exceptions = exceptions;
        }

        public Exceptional()
            : this(new Dictionary<Type, Action>())
        {
        }

        public IOn On<T>(Action action)
        {

            _exceptions.Add(typeof(T), action);

            return this;
        }

        public IOn When<T>(T func)
        {
            When(func);

            return this;
        }

        public IOn When(Func<object> func)
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

            return this;
        }

        public IOn When(TestDelegate func)
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

            return this;
        }
    }
}