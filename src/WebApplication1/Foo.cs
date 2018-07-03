using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Foo:IFoo
    {
        public void Test()
        {
            Console.WriteLine("foo");
        }
    }
}
