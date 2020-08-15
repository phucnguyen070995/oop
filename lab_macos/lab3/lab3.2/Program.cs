using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sap8Conhau
{
    class Program
    {
        //₫ịnh nghĩa các thuộc tính dữ liệu
        const int MAX = 7; //chỉ số max của hàng và cột 
        static int cachso = 0; //số cách sắp ₫ã tìm ₫ược
        static int[] hang = new int[MAX + 1]; //danh sách chỉ số hàng ₫ã thử trong từng cột 
        static int c; //vị trị cột ₫ang sắp
        //Điểm nhập của chương trình
        static void Main(string[] args)
        {
            // khởi ₫ộng trạng thái xuất phát
            for (c = 0; c <= MAX; c++) hang[c] = -1;
            cachso = 0;
            //bắt ₫ầu ₫ặt con hậu ở cột 0 vào hàng 0 
            hang[0] = 0;
            //bắt ₫ầu tìm hàng cho con hậu ở cột thứ 2 (chỉ số là 1)
            c = 1;
            while (Tim1cach())
            {
                // tìm ₫ược cách sắp 8 con hậu
                InKetqua();
                //lùi lại cột trước ₫ể tiếp tục tìm cách sắp khác
                c--;
            }
            // hết cách --> dừng chương trình
            Console.WriteLine("Số nghiệm là " + cachso);
            //chờ người dùng ấn Enter ₫ể ₫óng cửa sổ Console lại. 
            Console.Write("Ấn Enter ₫ể dừng chương trình : ");
            Console.Read();
            return;
        }
        //cố gắng tìm 1 phương án sắp 8 con hậu
        static bool Tim1cach()
        {
            int h;
            while (c <= MAX)
            {
                // tìm chỉ số hàng cho con hậu ở cột c
                h = timhang(c); if (h >= 0)
                { //nếu tìm ₫ược
                  //lưu hàng vào danh sách kết quả rồi tăng chỉ số cột ₫ể tiếp tục
                    hang[c++] = h;
                    continue;
                }
                //trường hợp không tìm ₫ược hàng cho con hậu ở cột c
                if (c > 0)
                {
                    //nếu cột c không phải là cột ₫ầu tiên thì : 
                    //xét lại cột c từ hàng ₫ầu rồi lùi cột c 
                    hang[c--] = -1;
                    continue;
                }
                //hết cách
                return false;
            }
            return true;
        }//hết hàm Tim1cach
         //hàm cố gắng tìm chỉ số hàng cho con hậu ở cột c 
         //trả về chỉ số hàng tìm ₫ược hay -1 ₫ể báo sai 
        static int timhang(int c)
        {
            int h, hmin = hang[c] + 1;
            for (h = hmin; h <= MAX; h++) //thửhàngh
                if (testvitri(h, c))
                    return h;
            return -1;
        }
        //hàm kiểm tra xem có thể ₫ặt con hậu ở vị trí h,c ? //trả về TRUE nếu ₫ược, FALSE nếu không
        static bool testvitri(int h, int c)
        {
            int c1, h1;
            //cột c ₫ang kiểm tra nên chưa có con hậu nào 
            // xem có con hậu nào nằm ở hàng h ?
            for (c1 = 0; c1 < c; c1++)
                if (hang[c1] == h) return false;
            // xem có con hậu nào nằm trên ₫ường chéo trên trái - dưới phải 
            c1 = c-1; h1 = h-1;
            while (c1 >= 0 && h1 >= 0)
            {
                if (hang[c1] == h1) return false;
                h1--; c1--;
            }
            // xem có con hậu nào nằm trên ₫ường chéo trên phải - dưới trái
            c1 = c - 1; h1 = h + 1;
            while (c1 >= 0 && h1 <= MAX)
            {
                if (hang[c1] == h1) return false;
                h1++; c1--;
            }
            return true;
        }
        //hàm in kết quả 1 cách sắp 8 con hậu theo yêu cầu
        static void InKetqua()
        {
            int h, c;
            Console.WriteLine("Cách sắp thứ : " + (++cachso));
            for (h = 0; h <= MAX; h++)
            {
                // Hiển thị hàng lưới ngang của bàn cờ
                for (c = 0; c <= MAX; c++) Console.Write("+---");
                Console.WriteLine("+");
                // Hiển thị nội dung hàng thứ h của bàn cờ
                for (c = 0; c <= MAX; c++)
                    if (hang[c] == h) Console.Write("| x ");
                    else Console.Write("| ");
                Console.WriteLine("|");
            }
            // Hiển thị hàng lưới ngang cuối cùng của bàn cờ
            for (c = 0; c <= MAX; c++) Console.Write("+---");
            Console.WriteLine("+");
        }
    }//hết class Program 
}//hết namespace