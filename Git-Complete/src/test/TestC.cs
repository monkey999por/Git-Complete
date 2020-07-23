using Git_Complete.src.entity;
using System;

namespace Git_Complete.src.props
{
    class TestC : TestA
    {
        public override void A()
        {
            Console.WriteLine("over ride C");
        }
        public void C()
        {
            Console.WriteLine("C");

        }

    }
}
