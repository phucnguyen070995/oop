using System;
using System.Collections.Generic;
using System.Text;

namespace UseObject
{
    class ClassA : IA
    {
        private int i;
        protected double d;
        //contructor 0 tham số
        public ClassA() : base()
        {
            i = 1; d = 1.1416;
            Console.WriteLine("Constructor for ClassA() is running...");
        }
        //contructor 2 tham số
        public ClassA(int i, double d) : base()
        {
            this.i = i; this.d = d;
            Console.WriteLine("Constructor for ClassA(i,d) is running...");
        }
        //destructor
        ~ClassA()
        {
            Console.WriteLine("Destructor for ClassA is running...");
        }
        //hàm func1 không thể bị override
        public int func1()
        {
            Console.WriteLine("Ham ClassA::func1 chay.");
            return 1;
        }
        //hàm func2 có thể bị override
        virtual public void func2()
        {
            Console.WriteLine("Ham ClassA::func2 chay.");
        }
        //hàm func3 không thể bị override
        private void func3()
        {
            Console.WriteLine("Ham ClassA::func3 chay.");
        }
        //hàm func4 không thể bị override
        public void func4()
        {
            Console.WriteLine("Ham ClassA::func4 chay.");
            func1(); //lien ket tinh --> khong da xa
            func2(); //lien ket dong --> da xa
        }
    }
}