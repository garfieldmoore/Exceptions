namespace Rainbow.Exceptional
{
    public static class ExceptionExtensions
    {
        public static IHandle Configure(this object target)
        {
            return new ExceptionHandler();
        }
    }
}
