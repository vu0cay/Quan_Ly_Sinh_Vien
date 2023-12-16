using System;
using MyStudents;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using SortList;
using MyEnum;
using System.Text;

namespace MyApp // Note: actual namespace depends on the project name.
{
    
    internal class Program
    {

        static void Main(string[] args)
        {
            
            
            List<SinhVien> ds = new List<SinhVien>();
            
            // Input
            // lay du lieu sinh vien tu file
            string fileName = "ThongTinSinhVien.txt";
            string[] danhsach = File.ReadAllLines(fileName);
            string pathStream = "students.dat";
            var stream = new FileStream(pathStream,FileMode.Create);
            
            foreach(var sv in danhsach)
            {
                string[] info = sv.Split(',');
                SinhVien sinhvien = new SinhVien(info[0],info[1],double.Parse(info[2]));
                ds.Add(sinhvien);
                sinhvien.Save(stream);
            }
            stream.Close();
          
            bool loop = true;
            do
            {
                System.Console.WriteLine("0. De thoat");
                System.Console.WriteLine("1. ds ban dau");            
                System.Console.WriteLine("2. De Sap xep");            
                
                
                
                string? s = Console.ReadLine();
                int Handle = Convert.ToInt32(s);
                switch(Handle)
                {
                    case 2:
                        // Yeu cau nguoi dung nhap cac gia tri {1,2,3} 
                        // Tuong ung 1 = MSSV, 2 = Name, 3 = GPA
                        // Tiep den la thu tu sap xep thu thap den cao A-Z = 1, cao den thap Z-A = 2
                        Console.Clear();
                        int keysort, order;
                        do{
                            System.Console.WriteLine("sap xep danh sach theo thu tu");
                            System.Console.WriteLine("1. Sap xep theo MSSV");
                            System.Console.WriteLine("2. Sap xep theo Name");
                            System.Console.WriteLine("3. Sap xep theo GPA");
                            string? s1 = Console.ReadLine();
                            keysort = Convert.ToInt32(s1);
                            System.Console.WriteLine("1. Sap xep tu A-Z");
                            System.Console.WriteLine("2. Sap xep tu Z-A");
                            
                            string? s2 = Console.ReadLine();
                            order = Convert.ToInt32(s2);

                        } while(keysort <1 && keysort > 3 && order <1 && order > 2 );
                        
                        SortBubble sort = new SortBubble(keysort,order);   // luu gia tri can so sanh vao 
                        
                        sort.BubbleSort(ds);
                        /*********************************************************************************/    

                        //OutPut
                        System.Console.WriteLine("danh sach sap xep: ");            
                        for(int i = 0; i<ds.Count; i++)
                        {
                            System.Console.Write($"STT: {i+1,-5},");
                            ds[i].Info(); // in thong tin
                        }
                        /*********************************************************************************/     

                        break;
                    case 1:
                    /*******************************RESTORE DU LIEU BAN DAU************************************/
                        Console.Clear();
                        System.Console.WriteLine("danh sach ban dau");
                        var streamopen = new FileStream(pathStream, FileMode.Open);
                        int numstream = 1;
                        while(numstream!=0)
                        {
                            foreach(var pt in ds)
                            {
                                numstream = pt.Restore(streamopen);
                            }
                        }            
            
                        for(int i = 0; i<ds.Count; i++)
                        {
                            System.Console.Write($"STT: {i+1,-5},");
                            ds[i].Info(); // in thong tin
                        }
                        streamopen.Close();
                        break;
                    case 0:
                        System.Console.WriteLine("Chuong Trinh Ket Thuc");
                        loop = false;
                        break;
                    default:
                        System.Console.WriteLine("Nhap lai key 1: Sap Xep,............");
                    break;
                }
            } while (loop == true);
               


        }
    }
}
