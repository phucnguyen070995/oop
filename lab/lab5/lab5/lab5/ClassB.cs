using System;
using System.Collections.Generic;
using System.Text;

namespace UseObject
{
    class ClassB : ClassA
    {
        //contructor 0 tham số
        public ClassB() : base()
        {
            Console.WriteLine("Constructor for ClassB() is running...");
        }
        //contructor 2 tham số
        public ClassB(int i, double d) : base(i, d)
        {
            Console.WriteLine("Constructor for ClassB(i,d) is running...");
        }
        //destructor
        ~ClassB()
        {
            Console.WriteLine("Destructor for ClassB is running...");
        }
        /* không cho phép override hàm func1
        public override int func1() {
        Console.WriteLine("Ham ClassB::func1 chay.");
        return 1;
        } */
        //override hàm func2
        public override void func2()
        {
            Console.WriteLine("Ham ClassB::func2 chay.");
        }
    }
}