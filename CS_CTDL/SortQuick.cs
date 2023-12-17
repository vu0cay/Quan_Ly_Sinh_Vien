using System;
using System.Globalization;
using System.Runtime.InteropServices;
using MyStudents;
using System.Text;
using System.Security.Cryptography;
using MyCompare;
namespace MySortQuick
{
    class SortQuick : CompareTwoValue
    {

        // constructor 
        public SortQuick(int keysort, int order)
        {
            this.key = keysort;
            this.order = order;
        }
        public int Partition(List<SinhVien> ds,int l,int r,SinhVien pivot){
            int i = l;
            int j = r;       
            
            while(i<j){
                
                if(order == (int)ThuTuSapXep.ThuTu.AZ)
                {
                    while(checkLower(ds[i],pivot) == true)  i++;
                    while(checkEquals(ds[j],pivot)==true || checkGreater(ds[j],pivot)==true) j--;
                } else {
                    while(checkGreater(ds[i],pivot) == true)  i++;
                    while(checkEquals(ds[j],pivot)==true || checkLower(ds[j],pivot)==true) j--;
                }
                
                
                if(i<j) {
                    var tmp = ds[i];
                    ds[i] = ds[j];
                    ds[j] = tmp;
                    i++;
                    j--;
                }
            }
            return i;
        }
        public int findpivot(List<SinhVien> ds,int l,int r){
            SinhVien firstkey = ds[l];
            int i = l+1;
            
            while(i<=r && checkEquals(ds[i],firstkey)) i++;
            if(i>r) return -1;
            else {
                if(order == (int)ThuTuSapXep.ThuTu.AZ)
                {
                    if(checkGreater(ds[l],ds[i])) return l;
                    else return i;
                } else {
                    if(checkLower(ds[l],ds[i])) return l;
                    else return i;
                }
            }
        }
        public void Quicksort(List<SinhVien> ds,int l,int r){
            int k,pivotindex;
            SinhVien pivot;
            pivotindex = findpivot(ds,l,r);
            if(pivotindex!=-1){
                pivot = ds[pivotindex];
                k = Partition(ds,l,r,pivot);
                Quicksort(ds,l,k-1);
                Quicksort(ds,k,r);
            }
        }

    }
}