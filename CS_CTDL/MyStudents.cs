using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using EnumXepLoai;
using MyEnum;

namespace MyStudents
{
    class SinhVien 
    {
        // du lieu
        // thuoc tinh
        public double GPA
        {
            set; get;
        }
        public string Name{
            set; get;
        }
        public string MSSV{
            set; get;
        }
        
        // constructor
        public SinhVien(){this.GPA = 0.0; this.Name ="rong"; this.MSSV="rong";}
        public SinhVien(string MSSV, string Name, double GPA)
        {
            this.Name = Name;
            this.MSSV = MSSV;
            this.GPA = GPA;
        }
        // Method
        // Save and Restore Database by using FileStream
        public void Save(Stream stream)
        {
            // doc do dai chuoi MSSV vao stream
            byte[] bytes_lengms = BitConverter.GetBytes(MSSV.Length);
            stream.Write(bytes_lengms,0,4);

            // doc chuoi MSSV
            byte[] bytes_MSSV = Encoding.UTF8.GetBytes(MSSV,0,MSSV.Length);
            stream.Write(bytes_MSSV,0,MSSV.Length);

            // doc do dai chuoi Name vao stream
            byte[] bytes_lengname = BitConverter.GetBytes(Name.Length);
            stream.Write(bytes_lengname,0,4);

            // doc chuoi Name vao stream
            byte[] bytes_Name = Encoding.UTF8.GetBytes(Name,0,Name.Length);
            stream.Write(bytes_Name,0,Name.Length);

            // doc GPA double = 8bytes

            byte[] bytes_gpa = BitConverter.GetBytes(GPA);
            stream.Write(bytes_gpa,0,8);

        }
        public int Restore(Stream stream)
        {
            // Read stream MSSV
            byte[] buffer_lengms = new byte[4]; // tao bo dem luu do dai chuoi int = 4byte
            int numstream = stream.Read(buffer_lengms,0,4);
            int leng_ms = BitConverter.ToInt32(buffer_lengms);
            if(numstream == 0) return numstream; // buoc dung doc stream

            byte[] buffer_ms = new byte[leng_ms];
            stream.Read(buffer_ms,0,leng_ms);
            MSSV = Encoding.UTF8.GetString(buffer_ms);
        
            // Read stream name
            byte[] buffer_lengname = new byte[4]; // tao bo dem luu do dai chuoi int = 4byte
            stream.Read(buffer_lengname,0,4);
            int leng_name = BitConverter.ToInt32(buffer_lengname);

            byte[] buffer_name = new byte[leng_name];
            stream.Read(buffer_name,0,leng_name);
            Name = Encoding.UTF8.GetString(buffer_name);

            // Read stream GPA
            byte[] buffer_gpa = new byte[8];
            stream.Read(buffer_gpa,0,8);
            GPA = BitConverter.ToDouble(buffer_gpa);

            return numstream;
        }

        // xet loai hoc ki
        public string getLoai(dynamic e)
        {
            if(e == XepLoai.XuatSac) return "Xuat Sac";
            else if(e == XepLoai.Gioi) return "Gioi";
            else if(e == XepLoai.Kha) return "Kha";
            else if(e == XepLoai.TB) return "Trung Binh";
            else if(e == XepLoai.Yeu) return "Yeu";
            else return "Kem";
            
        }
        public string DKXepLoai()
        {
            dynamic e = GPA >= 3.60 ? XepLoai.XuatSac : GPA >= 3.20 ? XepLoai.Gioi 
            : GPA >= 2.50 ? XepLoai.Kha : GPA >= 2.0 ? XepLoai.TB 
            : GPA >= 1.0 ? XepLoai.Yeu : XepLoai.Kem;

            return getLoai(e);
        }

       // thong tin Sinh Vien 
        public void Info() {
            if(DKXepLoai() == "Kem") 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"MSSV:\t{MSSV,-5}, name:\t{Name,-30}, DTB:\t{GPA,-10}, Xep Loai:\t{DKXepLoai(),-10}");
                Console.ResetColor();
            }
            else System.Console.WriteLine($"MSSV:\t{MSSV,-5}, name:\t{Name,-30}, DTB:\t{GPA,-10}, Xep Loai:\t{DKXepLoai(),-10}");
        } 
    }
    

    

}