using System;
using System.Diagnostics;

namespace CustomContractImplementation
{
    public static class CustomContract
    {
        public static void Requires<TException>(bool condition, string userMessage)
            where TException : Exception, new()
        {
            if (!condition)
            {
                Debug.WriteLine(userMessage);
                throw new TException();
            }
        }
    }
}