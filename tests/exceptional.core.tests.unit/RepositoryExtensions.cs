using Rainbow.Exceptional;

namespace exceptional.core.tests.acceptance
{
    public static class RepositoryExtensions
    {
        public static Exceptional Configure(this Repository repos)
        {
            return new Exceptional();
        }
    }
}