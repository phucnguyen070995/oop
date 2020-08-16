using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TaoTu
{
    class Program
    {
        //₫ịnh nghĩa các thuộc tính dữ liệu
        const int MAXLEN = 20; //số ký tự max cần dùng ₫ể tạo từ static 
        String srcstr; //chuỗi các ký tự khác nhau ₫ể tạo từ
        static int sotu; //số từ ₫ã tìm ₫ược
        static int[] chiso = new int[MAXLEN + 1]; //danh sách chỉ số ký tự ₫ã thử trong từng cột 
        static int sokytu; //số ký tự gốc ₫ược dùng ₫ể tạo từ
        static int c; //vị trị cột ₫ang sắp
                      //Điểm nhập của chương trình
        static void Main(string[] args)
        {
            //nhập chuỗi ký tự dùng ₫ể tạo từ
            do
            {
                Console.Write("Hãy nhập chuỗi các ký tự cần dùng : ");
                srcstr = Console.ReadLine();
                //xác ₫ịnh số ký tự ₫ược dùng
                sokytu = srcstr.Length;
            } while (sokytu >= MAXLEN);
            // khởi ₫ộng trạng thái xuất phát
            for (c = 0; c < sokytu; c++) chiso[c] = -1;
            //bắt ₫ầu ₫ặt ký tự chỉ số 0 vào cột ₫ầu (cột 0) của từ cần xây dựng 
            chiso[0] = 0;
            //bắt ₫ầu tìm ký tự cho cột thứ 2 (chỉ số là 1) của từ cần xây dựng 
            c = 1;
            while (Tim1cach())
            {
                // tìm ₫ược 1 từ mới
                InKetqua();
                //lùi lại cột trước ₫ể tiếp tục tìm cách sắp khác
                c--;
            }
            // hết cách --> dừng chương trình
            Console.WriteLine("Số từ xây dựng ₫ược là " + sotu);
            //chờ người dùng ấn Enter ₫ể ₫óng cửa sổ Console lại. 
            Console.Write("Ấn Enter ₫ể dừng chương trình : ");
            Console.Read();
            return;
        }
        //cố gắng tìm 1 phương án sắp các ký tự thành 1 tự mới theo yêu cầu
        static bool Tim1cach()
        {
            int h;
            while (c < sokytu)
            {
                // tìm chỉ số ký tự cho ký tự cột c
                h = timkytu(c);
                if (h >= 0)
                { //tìm ₫ược ==>lưu chỉ số vào danh sách kết quả rồi tăng chỉ số cột ₫ể tiếp tục
                    chiso[c++] = h;
                    continue;
                }
                //trường hợp không tìm ₫ược ký tự ở cột c
                if (c > 0)
                {
                    //cột c chưa phải là cột ₫ầu tiên =>xét lại cột c từ ký tự ₫ầu rồi lùi cột c
                    chiso[c--] = -1;
                    continue;
                }
                //hết cách
                return false;
            }
            return true;
        }//hết hàm Tim1cach
         //hàm tìm chỉ số hàng cho con hậu ở cột c
        static int timkytu(int c)
        {
            int h, hmin = chiso[c] + 1;
            for (h = hmin; h < sokytu; h++)
                if (duocphep(h, c)) return h;
            return -1;
        }
        // thử ký tự chỉ số h
        // Kiểm tra xem có thể xếp ký tự thứ h vào vị trí thứ c trong từ cần xây dựng
        static bool duocphep(int h, int c)
        {
            int k;
            for (k = 0; k < c; k++)
                if (chiso[k] == h) return false;
            return true;
        }
        //Kiểm tra từ, nếu có nghĩa thì trả về TRUE, nếu không trả về FALSE
        static bool conghia(String str)
        {
            // Bạn viết lại hàm này theo yêu cầu riêng //ở ₫ây ta coi mọi từ ₫ều có nghĩa
            return true;
        }
        //hàm in từ mới tìm theo yêu cầu
        static void InKetqua()
        {
            String desstr;
            int k;
            //Xây dựng từ mới tìm ₫ược
            desstr = "";
            for (k = 0; k < sokytu; k++)
                desstr += srcstr[chiso[k]];
            if (conghia(desstr)) //kiểm tra từ có nghĩa trước khi in 
            {
                Console.WriteLine("Từ thứ " + (++sotu) + " : " + desstr);
            }
        }
    }//hết class Program 
}//hết namespace