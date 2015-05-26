using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollySpike
{
    class Program
    {
        static void Main(string[] args)
        {
            //new TimeSpanTests().TimeSpan_RetriesAndThrows();
            new CircutBreakerTests().CircuitBreaker();
        }
    }

}
