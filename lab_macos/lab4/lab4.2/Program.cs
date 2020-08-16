namespace DefAndUseObject
{
    class Program
    {
        //₫ịnh nghĩa 1 hàm dịch vụ
        static void button2_Click(object sender, System.EventArgs e)
        {
            Console.WriteLine("Ham xu lý Click cua class Program chay");
        }
        //₫iểm nhập của chương trình
        static void Main(string[] args)
        {
            //1. tạo ₫ối tượng thuộc class MyClass
            MyClass obj = new MyClass();
            //2. thử truy xuất các thành phần private và protected //quan sát phản ứng của chương trình dịch
            obj.m_x = 5;
            obj.arr[1] = 10;
            //3. truy xuất thuộc tính giao tiếp
            obj.x = 5;
            //4. gởi thông ₫iệp chạy tác vụ chức năng
            obj.func2();
            //5. tạo sự kiện Click ₫ể xem hàm nào chạy
            Object sender = new Object();
            EventArgs e = new EventArgs();
            obj.OnClick(sender, e);
            //6. thiết lập lại hàm xử lý sự kiện Click
            obj.Click -= new MyClass.EventHandler(obj.button1_Click);
            obj.Click += new MyClass.EventHandler(button2_Click); //7. tạo sự kiện Click ₫ể xem hàm nào chạy obj.OnClick(sender, e);
                                                                  //8. dùng ₫ối tượng như danh sách các số nguyên
            int i;
            //chứa 10 số nguyên từ 0-9 vào danh sách
            for (i = 0; i < 10; i++) obj[i] = i;
            //₫ọc lại các số nguyên trong danh sách và hiển thị for (i= 0; i < 10; i++)
            Console.WriteLine("phan tu " + i + " = " + obj[i]); //9.chờ người dùng ấn phím ₫ể ₫óng cửa sổ Console.Write("Hay an phim Enter de dung chuong trinh : "); Console.Read();
        }
    } //kết thúc class
} //kết thúc namespace