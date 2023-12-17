using System;
using MyStudents;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using MyCompare;
using MyEnum;
using System.Text;
using SortBubble;
using MySortQuick;
using System.Reflection.Metadata;
using MySearch;
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program : MyHandle.Handle
    {
        static void Main(string[] args)
        {
            // Input
            // lay du lieu sinh vien tu file
            List<SinhVien> ds = new List<SinhVien>();
            string fileName = "ThongTinSinhVien.txt";
            string pathStream = "students.dat";
            ReadData(ds,fileName,pathStream);
          
            // Handle          
            bool loop = true;
            do
            {
                System.Console.WriteLine("0. De thoat");
                System.Console.WriteLine("1. ds ban dau");            
                System.Console.WriteLine("2. De Sap xep");            
                System.Console.WriteLine("3. De Tim Kiem");   
                
                int Handle = int.Parse(inPut());
                switch(Handle)
                {
                    
                    case 1:
                    /*******************************RESTORE DU LIEU BAN DAU************************************/
                        Console.Clear();
                        var streamopen = new FileStream(pathStream, FileMode.Open);  // mo file stream luu du lieu duoi dang mang bytes
                        
                        int numstream = 1;
                        while(numstream!=0)
                        {
                            foreach(var pt in ds)
                            {
                                numstream = pt.Restore(streamopen); // phuong thuc restore duyet stream va tra ve 0 neu cuoi stream
                            }
                        }            
                        // in danh sach
                        System.Console.WriteLine("danh sach ban dau: ");   
                        outPut(ds,0,ds.Count-1);
                        
                        streamopen.Close(); // dong file stream
                    break;
                    case 2:
                        // Yeu cau nguoi dung nhap cac gia tri {1,2,3} tuong ung voi lop "MyEnum.Key"
                        // 1 = MSSV, 2 = Name, 3 = GPA
                        // Tiep den la thu tu sap xep Enum "ThuTuSapXep.ThuTu" ------ A-Z = 1, Z-A = 2
                        Console.Clear();
                        int keysort, order;
                        do{
                            System.Console.WriteLine("sap xep danh sach theo thu tu");
                            System.Console.WriteLine("1. Sap xep theo MSSV");
                            System.Console.WriteLine("2. Sap xep theo Name");
                            System.Console.WriteLine("3. Sap xep theo GPA");
                            
                            System.Console.Write("Moi ban nhap: ");
                            keysort = Convert.ToInt32(inPut());
                            System.Console.WriteLine("1. Sap xep tu A-Z");
                            System.Console.WriteLine("2. Sap xep tu Z-A");
                            System.Console.Write("Moi ban nhap: ");
                            order = Convert.ToInt32(inPut());

                        } while(keysort <1 && keysort > 3 && order <1 && order > 2 );
                        
                        //  SortBubble sort = new SortBubble(keysort,order);   
                        //  sort.BubbleSort(ds);
                        
                        // sortQuick se sort dua tren viec so sanh cac keysort, va theo thu tu la order 
                        // vi tri bat dau la 0 ket thuc la length-1
                        SortQuick sort = new SortQuick(keysort,order); 
                        sort.Quicksort(ds,0,ds.Count-1);
                        
                        /*********************************************************************************/    

                        //in danh sach
                        System.Console.WriteLine("danh sach sap xep: ");   
                        outPut(ds,0,ds.Count-1);
                        
                        /*********************************************************************************/     

                    break;
                    case 3:
                        Console.Clear();
                        int keysearch;
                        do{
                            System.Console.WriteLine("sap xep danh sach theo thu tu");
                            System.Console.WriteLine("1. Tim Kiem theo MSSV");
                            System.Console.WriteLine("2. Tim Kiem theo Name");
                            System.Console.WriteLine("3. Tim Kiem theo GPA");

                            System.Console.Write("Moi ban nhap gia tri can tim: ");
                            
                            keysearch = Convert.ToInt32(inPut());

                        } while(keysearch <1 && keysearch > 3);
                        SinhVien svmoi = new SinhVien();
                        switch(keysearch)
                        {
                            case 1: 
                                
                                System.Console.Write("Moi ban nhap MSSV can tim: ");
                                svmoi.MSSV = inPut();
                            
                            break;
                            case 2:
                               
                                System.Console.Write("Moi ban nhap Ten SV can tim: ");
                                
                                svmoi.Name = inPut();
                           
                            break;
                            case 3:
                               
                                System.Console.Write("Moi ban nhap GPA SV can tim: ");
                                svmoi.GPA = double.Parse(inPut());
                           
                            break;
                        }
                        // sxep trc de tim kiem nhi phan theo thu tu A-Z
                        SortQuick sort1 = new SortQuick(keysearch,1);
                        sort1.Quicksort(ds,0,ds.Count-1);
                        /***********************************************/
                        BinSearch bin = new BinSearch(keysearch);
                        
                        int upper = bin.Upperbound(ds,0,ds.Count-1,svmoi);
                        int lower = bin.Lowerbound(ds,0,ds.Count-1,svmoi);
                        if(upper == -1 && lower == -1) System.Console.WriteLine("Ko tim thay");
                        else if(upper == -1) 
                        {
                            ds[lower].Info();
                        }
                        else if(lower == -1) ds[upper].Info();
                        else 
                        {
                            outPut(ds,lower,upper);
                        }
                    break;
                    case 0:
                        System.Console.WriteLine("Chuong Trinh Ket Thuc");
                        loop = false;
                    break;
                    default:
                        System.Console.WriteLine("Nhap lai key 1: Sap Xep, 2: danh sach ban dau, 3: Tim Kiem");
                    break;
                }
            } while (loop == true);
        }
    }
}
