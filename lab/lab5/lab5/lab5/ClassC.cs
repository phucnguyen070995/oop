using System;
using System.Collections.Generic;
using System.Text;

namespace UseObject
{
    class ClassC : ClassB
    {
        //contructor 0 tham số
        public ClassC() : base()
        {
            Console.WriteLine("Constructor for ClassC() is running...");
        }
        //contructor 2 tham số
        public ClassC(int i, double d) : base(i, d)
        {
            Console.WriteLine("Constructor for ClassC(i,d) is running...");
        }
        //destructor
        ~ClassC()
        {
            Console.WriteLine("Destructor for ClassC is running...");
            Console.Write("Ấn Enter ₫ể chạy tiếp : ");
            Console.Read();
        }
        /* không cho phép override hàm func1
        public override int func1() {
        Console.WriteLine("Ham ClassC::func1 chay.");
        return 1;
        }*/
        //override hàm func2
        public override void func2()
        {
            Console.WriteLine("Ham ClassC::func2 chay.");
        }
    }
}