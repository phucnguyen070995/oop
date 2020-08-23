using System;
using System.Collections.Generic;
using System.Text;

namespace UseObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lenh ClassA ca = new ClassA(); chay. Hay quan sat trinh tu cac constructor.");
            ClassA ca = new ClassA();
            Console.WriteLine();
            Console.WriteLine("Lenh ca.func1(); chay. Hay quan sat ham cu the nao chay");
            ca.func1();
            Console.WriteLine();
            Console.WriteLine("Lenh ca.func2(); chay. Hay quan sat ham cu the nao chay");
            ca.func2();
            Console.WriteLine();
            Console.WriteLine("Lenh ca = new ClassB (); chay. Hay quan sat trinh tu cac constructor.");
            ca = new ClassB();
            Console.WriteLine();
            Console.WriteLine("Lenh ca.func1(); chay. Hay quan sat ham cu the nao chay");
            ca.func1();
            Console.WriteLine();
            Console.WriteLine("Lenh ca.func2(); chay. Hay quan sat ham cu the nao chay");
            ca.func2();
            Console.WriteLine();
            Console.WriteLine("Lenh ca = new ClassC (1,2); chay. Hay quan sat trinh tu cac constructor.");
            ca = new ClassC(1, 2);
            Console.WriteLine();
            Console.WriteLine("Lenh ca.func1(); chay. Hay quan sat ham cu the nao chay");
            ca.func1();
            Console.WriteLine();
            Console.WriteLine("Lenh ca.func2(); chay. Hay quan sat ham cu the nao chay");
            ca.func2();
            Console.WriteLine();
            Console.WriteLine("Lenh cc.func3(); chay. Hay quan sat ham cu the nao chay");
            //cc.func3(); //bi loi vi func3 la ham private
            Console.WriteLine();
            Console.WriteLine("Lenh cc.func4(); chay. Hay quan sat ham cu the nao chay");
            ca.func4();
            Console.WriteLine();
            Console.Write("Ấn Enter ₫ể dừng chương trình : ");
            Console.Read();
        }
    } //kết thúc class
} //kết thúc namespace