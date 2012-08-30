namespace Rainbow.Exceptions
{
    /// <summary>
    /// Helper class to create exception handlers
    /// </summary>
    public static class Exceptional
    {
        public static IHandle Handle()
        {
            return new ExceptionHandler();
        }
    }
}