using System;
using MyStudents;
using MyCompare;
using ElementType = MyStudents.SinhVien; 
using ListType = System.Collections.Generic.List<MyStudents.SinhVien>;
namespace MySearch
{
    class BinSearch : CompareTwoValue
    {
        public BinSearch() {}
        public BinSearch(dynamic key) {this.key = key;}               
        public int Upperbound(List<ElementType> ds, int l,int r,ElementType x)
        {
            while(r-l>1)
            {
                int mid = l - (l-r)/2;
                if(checkEquals(ds[mid],x)) l = mid;
                else if(checkGreater(x,ds[mid])) l = mid + 1;
                else if(checkLower(x,ds[mid])) r = mid - 1;
            }
            if(checkEquals(ds[l],x)) {
                if(checkEquals(ds[l],ds[r])) return r;
                else return l;
            }
            else if(checkEquals(ds[r],x)) return r;
            else return -1;
        }
        public int Lowerbound(List<ElementType> ds, int l,int r,ElementType x)
        {
            while(r-l>1)
            {
                int mid = l - (l-r)/2;
                if(checkEquals(ds[mid],x)) r = mid;
                else if(checkGreater(x,ds[mid])) l = mid + 1;
                else if(checkLower(x,ds[mid])) r = mid - 1;
            }
            if(checkEquals(ds[l],x)) return l;
            else if(checkEquals(ds[r],x)) {
                if(checkEquals(ds[l],ds[r])) return l;
                else return r;
            }
            else return -1;
        }
       
    }
}