using Rainbow.Exceptions;

namespace exceptional.core.tests.unit
{
    /// <summary>
    /// An example of how to use exceptional extensions rather than through thes static class
    /// </summary>
    public static class ExceptionExtensions
    {
        public static IHandle Configure(this object target)
        {
            return new ExceptionHandler();
        }
    }
}
