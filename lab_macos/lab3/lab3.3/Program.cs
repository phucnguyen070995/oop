using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Madituan
{
    class Program
    {
        // Kiểu chứa thông tin về 1 bước ₫i
        private struct ItemRec
        {
            public int x, y;
            public int huong;
        };
        // Các biến dữ liệu chính
        static int Size;
        static int[,] Banco;
        static ItemRec[] Nuocdi;
        static int SoNuocdi;
        static int SoNghiem;
        // Chương trình chính
        static void Main(string[] args)
        {
            Khoidong();
            while (DiBuocNua())
                if (SoNuocdi == Size * Size - 1)
                {
                    //tìm ₫ược 1 cách mới, in cách ₫i mới tìm ₫ược
                    InKetqua();
                    Banco[Nuocdi[SoNuocdi].x, Nuocdi[SoNuocdi].y] = -1; //lùi con mã 1 bước
                    SoNuocdi = SoNuocdi - 1;
                    //tiếp tục tìm cách ₫i khác
                    Nuocdi[SoNuocdi].huong = Nuocdi[SoNuocdi].huong + 1;
                }
            //chờ người dùng ấn Enter ₫ể ₫óng cửa sổ Console lại.
            Console.Write("Ấn Enter ₫ể dừng chương trình : ");
            Console.Read();
        }
        //hàm khởi ₫ộng các giá tr5i ₫ầu của chương trình
        static void Khoidong()
        {
            int i, j;
            int row, col;
            String buf;
            do //chờ nhập kích thước bàn cờ 
            {
                Console.Write("Nhập số hàng (cột) của bàn cờ: ");
                buf = Console.ReadLine(); Size = Int32.Parse(buf);
            } while (Size <= 3 || Size > 9);
            do //chờ nhập chỉ số hàng xuất phát
            {
                Console.Write("Nhập chỉ số hàng xuất phát của con mã : ");
                buf = Console.ReadLine(); row = Int32.Parse(buf);
            } while (row < 0 || Size <= row);
            do //chờ nhập chỉ số cột xuất phát
            {
                Console.Write("Nhập chỉ số cột xuất phát của con mã : ");
                buf = Console.ReadLine(); col = Int32.Parse(buf);
            } while (col < 0 || Size <= col);
            //phân phối vùng nhớ chứa array Banco và danh sach Nuocdi
            Banco = new int[Size, Size];
            Nuocdi = new ItemRec[Size * Size];
            for (i = 0; i < Size * Size; i++)
                Nuocdi[i] = new ItemRec();
            //khởi ₫ộng trạng thái ₫ầu cho các vị trí 
            for (i = 0; i < Size; i++)
                for (j = 0; j < Size; j++)
                    Banco[i, j] = -1; // con mã chưa ₫i qua ô [i,j]
            SoNghiem = 0;
            // Thiết lập nước ₫i ₫ầu tiên của con mã
            Nuocdi[0].x = col;
            Nuocdi[0].y = row;
            Nuocdi[0].huong = 0;
            SoNuocdi = 0;
            //chọn khả năng ₫i tiếp của vị trí ₫ầu tiên của con mã
            Banco[Nuocdi[SoNuocdi].x, Nuocdi[SoNuocdi].y] = 0;
        }
        //hàm tìm vị trí kế tiếp của con mã
        // trả về TRUE nếu tìm ₫ược, FALSE nếu không tìm ₫ược 
        static bool DiBuocNua()
        {
            int x = 0, y = 0;
            bool RetVal;
            RetVal = false;
            do
            { // lặp tìm vị trí kế
                while (RetVal == false && Nuocdi[SoNuocdi].huong < 8)
                {
                    switch (Nuocdi[SoNuocdi].huong)
                    { //thử hướng ₫i hiện tại
                        case 0:
                            x = Nuocdi[SoNuocdi].x + 2;
                            y = Nuocdi[SoNuocdi].y - 1;
                            break;
                        case 1:
                            x = Nuocdi[SoNuocdi].x + 1;
                            y = Nuocdi[SoNuocdi].y - 2;
                            break;
                        case 2:
                            x = Nuocdi[SoNuocdi].x - 1;
                            y = Nuocdi[SoNuocdi].y - 2;
                            break;
                        case 3:
                            x = Nuocdi[SoNuocdi].x - 2;
                            y = Nuocdi[SoNuocdi].y - 1;
                            break;
                        case 4:
                            x = Nuocdi[SoNuocdi].x - 2;
                            y = Nuocdi[SoNuocdi].y + 1;
                            break;
                        case 5:
                            x = Nuocdi[SoNuocdi].x - 1;
                            y = Nuocdi[SoNuocdi].y + 2;
                            break;
                        case 6:
                            x = Nuocdi[SoNuocdi].x + 1;
                            y = Nuocdi[SoNuocdi].y + 2;
                            break;
                        case 7:
                            x = Nuocdi[SoNuocdi].x + 2;
                            y = Nuocdi[SoNuocdi].y + 1;
                            break;
                    }
                    if (0 <= x && x < Size && 0 <= y && y < Size && Banco[x, y] == -1)
                    {
                        // nếu ₫ược thì ghi nhận
                        SoNuocdi = SoNuocdi + 1;
                        Banco[x, y] = SoNuocdi;
                        Nuocdi[SoNuocdi].x = x;
                        Nuocdi[SoNuocdi].y = y;
                        Nuocdi[SoNuocdi].huong = 0;
                        RetVal = true;
                    }
                    else // nếu không tìm ₫ược vị trí kế tiếp 
                        Nuocdi[SoNuocdi].huong = Nuocdi[SoNuocdi].huong + 1;
                }
                if (RetVal == false && SoNuocdi != 0)
                {
                    // nếu không tìm ₫ược vị trí kế thì lùi con mã 1 bước
                    Banco[Nuocdi[SoNuocdi].x, Nuocdi[SoNuocdi].y] = -1;
                    SoNuocdi = SoNuocdi - 1;
                    Nuocdi[SoNuocdi].huong = Nuocdi[SoNuocdi].huong + 1;
                }
            } while (!RetVal && (SoNuocdi != 0));
            return RetVal;
        }
        // In kết quả con mã ₫i trên bàn cờ
        static void InKetqua()
        {
            int h, c;
            SoNghiem = SoNghiem + 1;
            Console.WriteLine("Cách ₫i thứ : " + SoNghiem);
            for (h = 0; h < Size; h++)
            {
                // Hiển thị hàng lưới ngang bàn cờ
                for (c = 0; c < Size; c++) Console.Write("+----");
                Console.WriteLine("+");
                // Hiển thị nội dung hàng thứ h bàn cờ
                for (c = 0; c < Size; c++)
                    Console.Write("| {0:D2} ", Banco[h, c]);
                Console.WriteLine("|");
            }
            // Hiển thị hàng lưới ngang cuối cùng của bàn cờ
            for (c = 0; c < Size; c++) Console.Write("+----");
            Console.WriteLine("+");
        }
    }//hết class Program
}//hết namespace
