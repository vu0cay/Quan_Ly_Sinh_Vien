using System;
using System.Globalization;
using System.Runtime.InteropServices;
using MyStudents;
using System.Text;
using MyInterFace;
namespace SortList
{
    class SortAlgorithm
    {

        public dynamic? key{set; get;} // thuoc tinh dong de luu nhung gia tri Enum de sap xep dua tren gtri do  
        public dynamic? order{set; get;}

        // constructor
        
        public SortAlgorithm() {}
        public SortAlgorithm(dynamic key,dynamic order) {this.key = key; this.order = order;}

   }
   class SortBubble : SortAlgorithm, CompareMethod
   {
        // constructor
        public SortBubble() {}
        public SortBubble(dynamic key,dynamic order)
        {
            base.key = key;
            base.order = order;
        }

        // Phuong thuc so sanh 2 SinhVien dua tren 2 gia tri kieu double
        public bool Great(double a, double b) 
        {
            return a > b;
        }
        // Phuong thuc so sanh 2 SinhVien dua tren 2 gia tri kieu string
        public bool Great(string str_1,string str_2) 
        {
            int i = 0;
            StringBuilder a = new StringBuilder(); 
            StringBuilder b = new StringBuilder();
            a.Append(str_1.ToLower());
            b.Append(str_2.ToLower());
            while(i < a.Length-1 && i < b.Length-1 && (int)a[i] == (int)b[i]) i++;

            
            if((int)a[i] > (int)b[i]) 
            {
                return true; // a > b
            }
            else
                  return false; // a <= b
            
        }
        
        /* BUBBLE SORT */
        public bool checkcompare(List<SinhVien> ds, int i, int j)
        {
            bool checkifAGreaterThanB = false;
            if(key == (int)MyEnum.Key.GPA) {
                // delegate tra ve kieu bool ss dua tren 2 gia tri double
                Func<double,double,bool> func = Great; 
                checkifAGreaterThanB = func.Invoke(ds[i].GPA,ds[j].GPA);
            }
            else if(key == (int)MyEnum.Key.Name){
            // delegate tra ve kieu bool ss dua tren 2 gia tri string
                Func<string,string,bool> func = Great;
                checkifAGreaterThanB = func.Invoke(ds[i].Name,ds[j].Name);
            }
            else if(key == (int)MyEnum.Key.MSSV){
            // tuong tu Name
                Func<string,string,bool> func = Great;
                checkifAGreaterThanB = func.Invoke(ds[i].MSSV,ds[j].MSSV);
            }
            return checkifAGreaterThanB;
        }
        public void BubbleSort(List<SinhVien> ds)
        {
            
                int size = ds.Count; // kich thuoc danh sach
            
                for(int i = 0; i<size-1; i++)
                {
                    for(int j = i+1; j<size; j++)
                    {
                        bool checkifAGreaterThanB = checkcompare(ds,i,j); // kiem tra gtri so sanh giua A va B neu A > B = true
                        
                        // thuc hien viec kiem tra va hoan doi 2 SV dua tren gia tri so sanh "key"
                        if(order == (int)ThuTuSapXep.ThuTu.AZ)
                        {
                            if(checkifAGreaterThanB)
                            {
                                var tmp = ds[i];
                                ds[i] = ds[j];
                                ds[j] = tmp;
                            }
                        } else {
                            if(!checkifAGreaterThanB)
                            {
                                var tmp = ds[i];
                                ds[i] = ds[j];
                                ds[j] = tmp;
                            }
                        }
                        
                    }
                }
            
            
        }    

   }
/*
    partial class SortAlgorithm
    {
        int Partition(List<SinhVien> a,int l,int r,SinhVien pivot){
            int i = l;
            int j = r;
            
            while(i<j){
                while(a[i] < pivot) i++;
                while(a[j] >= pivot) j--;
                if(i<j) {
                    var tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
            }
            
            return i;
        }
        int findpivot(List<SinhVien> a,int l,int r){
            SinhVien firstkey = a[l];
            int i = l+1;
            while(i<=r && a[i] == firstkey) i++;
            if(i>r) return -1;
            else {
                if(a[l] > a[i]) return l;
                else return i;
            }
        }
        void Quicksort(List<SinhVien> a,int l,int r){
            int k,pivotindex;
            SinhVien pivot;
            pivotindex = findpivot(a,l,r);
            if(pivotindex!=-1){
                pivot = a[pivotindex];
                k = Partition(a,l,r,pivot);
                Quicksort(a,l,k-1);
                Quicksort(a,k,r);
            }
        }

    }

*/
}

