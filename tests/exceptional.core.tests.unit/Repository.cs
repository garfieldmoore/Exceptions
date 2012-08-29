using System;

namespace exceptional.core.tests.acceptance
{
    public class Repository
    {
        public string Do()
        {
            throw new Exception();
        }

        public void DoNothing()
        {
            
        }
    }
}