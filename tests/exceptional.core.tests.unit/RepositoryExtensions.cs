using Rainbow.Exceptional;

namespace exceptional.core.tests.acceptance
{
    public static class RepositoryExtensions
    {
        public static ExceptionHandler Configure(this Repository repos)
        {
            return new ExceptionHandler();
        }
    }
}