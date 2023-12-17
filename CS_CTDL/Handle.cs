
using MyStudents;

namespace MyHandle
{
    class Handle
    {
        public static string inPut()
        {
            string? ma = Console.ReadLine();
            if(ma ==  null) throw new Exception("chuoi khong duoc de trong");   
            return ma;
        }
        public static void outPut(List<SinhVien> ds,int first, int end)
        {
                     
            for(int i = first; i<=end; i++)
            {
                System.Console.Write($"STT: {i+1,-5},");
                ds[i].Info(); // in thong tin
            }           
        }
        public static void ReadData(List<SinhVien> ds, string fileName, string pathStream)
        {
            using var stream = new FileStream(pathStream,FileMode.Create);
            {
                string[] danhsach = File.ReadAllLines(fileName);
                foreach(var sv in danhsach)
                {
                    string[] info = sv.Split(',');
                    SinhVien sinhvien = new SinhVien(info[0],info[1],double.Parse(info[2]));
                    ds.Add(sinhvien);
                    sinhvien.Save(stream);
                }
            }
            
            //stream.Close();
        }
        
    }
}