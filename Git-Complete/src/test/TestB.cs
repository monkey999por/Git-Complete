using Git_Complete.src.entity;
using System;

namespace Git_Complete.src.props
{
    class TestB : TestA
    {
        public override void A()
        {
            Console.WriteLine("over ride B");
        }
        public void B()
        {
            Console.WriteLine("B");

        }

    }
}
