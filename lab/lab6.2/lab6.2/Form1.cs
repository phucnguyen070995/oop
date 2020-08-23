using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6._2
{
    public partial class Form1 : Form
    {
        //₫ịnh nghĩa cặp Label + TextBox phục vụ nhập a
        private Label Label1;
        private TextBox txtA;
        //₫ịnh nghĩa cặp Label + TextBox phục vụ nhập b
        private Label Label2;
        private TextBox txtB;
        //₫ịnh nghĩa cặp Label + TextBox phục vụ nhập c
        private Label Label3;
        private TextBox txtC;
        //₫ịnh nghĩa Button thực hiện giải phương trình
        private Button btnStart;
        //₫ịnh nghĩa 3 Label hiển thị kết quả giải phương trình
        private Label lblKetqua;
        private Label lblX1;
        private Label lblX2;
        //₫ịnh nghĩa các biến cần dùng
        double a, b, c;
        double delta;
        double x1, x2;
        //₫ịnh nghĩa hàm nhập 3 thông số a,b,c của phương trình bậc 2
        void NhapABC()
        {
            a = Double.Parse(txtA.Text);
            b = Double.Parse(txtB.Text);
            c = Double.Parse(txtC.Text);
        }
        //₫ịnh nghĩa hàm tính nghiệm của phương trình bậc 2
        void GiaiPT()
        {
            if (a != 0)
            {
                //tính biệt số delta của phương trình
                delta = b * b - 4 * a * c;
                if (delta >= 0) //nếu có nghiệm thực
                {
                    x1 = (-b + Math.Sqrt(delta)) / 2 / a;
                    x2 = (-b - Math.Sqrt(delta)) / 2 / a;
                }
            }
            else if (b != 0)
            {
                x1 = -1.0 * c / b;
            }
        }
        //₫ịnh nghĩa hàm xuất kết quả
        void XuatKetqua()
        {
            if (a != 0)
            {
                if (delta < 0)
                {
                    //báo vô nghiệm
                    lblKetqua.Text = "Phương trình vô nghiệm";
                    lblX1.Text = "";
                    lblX2.Text = "";
                }
                else //báo có 2 nghiệm
                {
                    lblKetqua.Text = "Phương trình có 2 nghiệm thực : ";
                    lblX1.Text = "X1 = " + x1.ToString();
                    lblX2.Text = "X2 = " + x2.ToString();
                }
            }
            else if (b != 0)
            {
                lblKetqua.Text = "Phương trình có 1 nghiệm thực : ";
                lblX1.Text = "X = " + x1.ToString();
                lblX2.Text = "";
            }
            else if (b == 0 && c == 0)
            {
                lblKetqua.Text = "Phương trình có vô số nghiệm thực!";
                lblX1.Text = "";
                lblX2.Text = "";
            }
            else
            {
                lblKetqua.Text = "Phương trình vô nghiệm!";
                lblX1.Text = "";
                lblX2.Text = "";
            }
        }
        //₫ịnh nghĩa hàm xử lý Click trên button "Bắt ₫ầu giải"
        private void btnStart_Click(object sender, EventArgs e)
        {
            NhapABC(); //nhập a,b,c
            GiaiPT(); //giải phương trình
            XuatKetqua(); //xuất kết quả
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Tạo Label Label1
            Label1 = new Label();
            Label1.Name = "Label1";
            Label1.AutoSize = true;
            Label1.Location = new Point(13, 11);
            Label1.Size = new Size(62, 17);
            Label1.TabIndex = 0;
            Label1.Text = "Nhập a :";
            Controls.Add(Label1); //add Label vào Form
                                  //Tạo TextBox txtA
            txtA = new TextBox();
            txtA.Name = "txtA";
            txtA.Location = new Point(96, 11);
            txtA.Size = new Size(239, 22);
            txtA.TabIndex = 1;
            Controls.Add(txtA); //add TextBox vào Form
                                //Tạo Label Label2
            Label2 = new Label();
            Label2.Name = "Label2";
            Label2.AutoSize = true;
            Label2.Location = new Point(13, 51);
            Label2.Size = new Size(62, 17);
            Label2.TabIndex = 2;
            Label2.Text = "Nhập b :";
            Controls.Add(Label2); //add Label vào Form
                                  //Tạo TextBox txtB
            txtB = new TextBox();
            txtB.Name = "txtB";
            txtB.Location = new Point(96, 51);
            txtB.Size = new Size(239, 22);
            txtB.TabIndex = 3;
            Controls.Add(txtB); //add TextBox vào Form
                                //Tạo Label Label3
            Label3 = new Label();
            Label3.Name = "Label3";
            Label3.AutoSize = true;
            Label3.Location = new Point(13, 90);
            Label3.Size = new Size(61, 17);
            Label3.TabIndex = 4;
            Label3.Text = "Nhập c :";
            Controls.Add(Label3); //add Label vào Form
                                  //Tạo TextBox txtC
            txtC = new TextBox();
            txtC.Name = "txtC";
            txtC.Location = new Point(96, 90);
            txtC.Size = new Size(239, 22);
            txtC.TabIndex = 5;
            Controls.Add(txtC); //add TextBox vào Form
                                //Tạo button Start
            btnStart = new Button();
            btnStart.Name = "txtStart";
            btnStart.Location = new Point(81, 126);
            btnStart.Size = new Size(164, 25);
            btnStart.TabIndex = 6;
            btnStart.Text = "Bắt ₫ầu giải";
            btnStart.UseVisualStyleBackColor = true;
            Controls.Add(btnStart); //add Button vào Form
                                    //kết hợp hàm xử lý Click chuột
            btnStart.Click += new EventHandler(btnStart_Click);
            //Tạo Label lblKetqua
            lblKetqua = new Label();
            lblKetqua.Name = "lblKetqua";
            lblKetqua.AutoSize = true;
            lblKetqua.Location = new Point(15, 165);
            lblKetqua.Size = new Size(51, 17);
            lblKetqua.TabIndex = 7;
            lblKetqua.Text = "";
            Controls.Add(lblKetqua); //add Label vào Form
                                     //Tạo Label lblX1
            lblX1 = new Label();
            lblX1.Name = "lblX1";
            lblX1.AutoSize = true;
            lblX1.Location = new Point(15, 193);
            lblX1.Size = new Size(51, 17);
            lblX1.TabIndex = 8;
            lblX1.Text = "";
            Controls.Add(lblX1); //add Label vào Form
                                 //Tạo Label lblX2
            lblX2 = new Label();
            lblX2.Name = "lblX2";
            lblX2.AutoSize = true;
            lblX2.Location = new Point(15, 223);
            lblX2.Size = new Size(51, 17);
            lblX2.TabIndex = 9;
            lblX2.Text = "";
            Controls.Add(lblX2); //add Label vào Form
                                 //Thiết lập 1 số thuộc tính cho Form1
            ClientSize = new Size(348, 255);
            Name = "Form1";
            Text = "Giải phương trình bậc 2 ";
        }
    }
}

