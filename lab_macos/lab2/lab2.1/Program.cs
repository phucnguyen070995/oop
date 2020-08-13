using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Dathuc
{
    class Program
    {
        //₫ịnh nghĩa kiểu miêu tả 1 số mũ
        private struct Sohang
        {
            public float heso; //hệ số
            public int somu; //số mũ
            public Sohang(float h, int s) { heso = h; somu = s; }
        };
        //hàm sắp xếp ₫a thức theo thứ tự số mũ giảm dần
        static void SortItems(Sohang[] dathuc, int soluong)
        {
            //₫ịnh nghĩa các biến cần dùng
            int i, j, max;
            Sohang temp;
            //Lặp xác ₫ịnh vị trí ₫úng cho từ số mũ
            for (i = 0; i < soluong - 1; i++)
            {
                //Tìm phần tử có số mũ lớn nhất từ vị trí i
                max = i;
                for (j = i + 1; j < soluong; j++)
                    if (dathuc[max].somu < dathuc[j].somu)
                        max = j;
                //hoán vị phần tử có số mũ lớn nhất về vị trí i
                temp = dathuc[i];
                dathuc[i] = dathuc[max];
                dathuc[max] = temp;
            }
        }
        //hàm chuẩn hóa ₫a thức, mỗi số mũ chỉ có 1 phần tử
        static int Chuanhoa(Sohang[] dathuc, int soluong)
        {
            //₫ịnh nghĩa các biến cần dùng
            int i, j;
            Sohang[] temp = new Sohang[soluong];
            //sắp xếp thự tự các phần tử trong ₫a thức
            SortItems(dathuc, soluong);
            //Lặp việc gộp các phần tử có số mũ giống nhau
            j = 0; temp[0] = dathuc[0];
            i = 1;
            while (i < soluong)
                if (temp[j].somu == dathuc[i].somu)
                {
                    temp[j].heso += dathuc[i].heso;
                    i++;
                }
                else
                {
                    j++;
                    temp[j] = dathuc[i];
                    i++;
                }
            //copy kết quả về dathuc gốc
            for (i = 0; i <= j; i++)
                dathuc[i] = temp[i];
            //return số phần tử trong ₫a thức chuẩn hóa
            return j + 1;
        }
        //hàm in ₫a thức ₫ể kiểm tra
        static void Indathuc(Sohang[] dathuc, int soluong)
        {
            int i;
            if (soluong == 0) return;
            //in phần tử ₫ầu tiên của ₫a thức
            Console.Write(dathuc[0].heso + "x^" + dathuc[0].somu + " ");
            //lặp in từng phần tử còn lại của ₫a thức
            for (i = 1; i < soluong; i++)
                if (dathuc[i].heso < 0)
                    Console.Write(dathuc[i].heso + "x^" + dathuc[i].somu + " ");
                else
                    Console.Write("+ " + dathuc[i].heso + "x^" + dathuc[i].somu + " ");
            //in ký tự xuống dòng
            Console.WriteLine();
        }
        //hàm nhân 2 ₫a thức
        static void Nhan(Sohang[] dathuc1, int soluong1, Sohang[] dathuc2, int soluong2, ref Sohang[]
        dathuc3, ref int soluong3)
        {
            //₫ịnh nghĩa các biến cần dùng
            int i, j, k;
            //cấp phát bộ nhớ chứa ₫a thức kết quả
            dathuc3 = new Sohang[soluong1 * soluong2];
            k = 0;
            //lặp nhân từng số hạng của ₫a thức 1
            for (i = 0; i < soluong1; i++)
                //với tất cả các số hạng của ₫a thức 2
                for (j = 0; j < soluong2; j++)
                {
                    dathuc3[k].somu = dathuc1[i].somu + dathuc2[j].somu;
                    dathuc3[k].heso = dathuc1[i].heso * dathuc2[j].heso;
                    k++;
                }
            //chuẩn hóa ₫a thức kết quả
            soluong3 = Chuanhoa(dathuc3, k);
        }

        //Nhap a thuc
        static void Nhapdathuc(ref Sohang[] dathuc, ref int soluong)
        {
            for (int i = 0; i < soluong; i++)
            {
                String buf_for_hs;
                String buf_for_mu;
                float hs; int mu;
                Console.WriteLine("Nhập hệ số cho số hạng thứ : " + Convert.ToString(i + 1)); buf_for_hs = Console.ReadLine();
                hs = float.Parse(buf_for_hs);
                Console.WriteLine("Nhập số mũ cho số hạng thứ : " + Convert.ToString(i + 1)); buf_for_mu = Console.ReadLine();
                mu = Int32.Parse(buf_for_mu);
                dathuc[i] = new Sohang(hs, mu);
            }
        }
        //chương trình chính thử dùng các hàm chức năng
        static void Main(string[] args)
        {
            String buf;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập số lượng phần tử cho đa thức 1 : "); buf = Console.ReadLine();
            int n1 = Int32.Parse(buf);
            Sohang[] dathuc1 = new Sohang[n1];
            Nhapdathuc(ref dathuc1, ref n1);
            Console.WriteLine("Đa thức bạn nhập là : ");
            Indathuc(dathuc1, n1);
            Console.Write("Bạn muốn làm gì tiếp theo (Nhấn 1 để sort, nhấn 2 để optimize, nhấn 3 để nhân đa thức khác : "); buf = Console.ReadLine();
            int require = Int32.Parse(buf);
            switch (require)
            {
                case 1:
                    SortItems(dathuc1, n1);
                    Console.WriteLine("Đa thức ₫ược sort là : ");
                    Indathuc(dathuc1, n1);
                    break;
                case 2:
                    int somu = Chuanhoa(dathuc1, n1);
                    Console.WriteLine("Đa thức ₫ược chuẩn hóa là : ");
                    Indathuc(dathuc1, somu);
                    break;
                case 3:
                    Console.WriteLine("Nhập số lượng phần tử cho đa thức 2 : "); buf = Console.ReadLine();
                    int n2 = Int32.Parse(buf);
                    Sohang[] dathuc2 = new Sohang[n2];
                    Nhapdathuc(ref dathuc2, ref n2);
                    Console.WriteLine("Đa thức bạn nhập là : ");
                    Indathuc(dathuc2, n2);
                    Sohang[] dathuc3 = new Sohang[1];
                    int soluong = 1;
                    Nhan(dathuc1, n1, dathuc2, n2, ref dathuc3, ref soluong);
                    Console.WriteLine("Đa thức kết quả là : ");
                    Indathuc(dathuc3, soluong);
                    break;
                default:
                    Console.WriteLine("Yêu của của bạn sai!");
                    break;
            }
            //4. chờ người dùng ấn Enter ₫ể ₫óng cửa sổ Console lại.
            Console.Write("Ấn Enter ₫ể dừng chương trình : ");
            Console.Read();
        }//hết hàm Main
    }//hết class Program
}//hết namespace