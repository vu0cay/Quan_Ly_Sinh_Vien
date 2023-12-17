using System;
using System.Globalization;
using System.Runtime.InteropServices;
using MyStudents;
using System.Text;
using System.Security.Cryptography;
using MyCompare;
namespace SortBubble
{
    class SortBubble : CompareTwoValue
    {
        // constructor
        public SortBubble() {}
        public SortBubble(dynamic key,dynamic order)
        {
            base.key = key;
            base.order = order;
        }

        public void BubbleSort(List<SinhVien> ds)
        {
            
                int size = ds.Count; // kich thuoc danh sach
            
                for(int i = 0; i<size-1; i++)
                {
                    for(int j = i+1; j<size; j++)
                    {
                        // thuc hien viec kiem tra va hoan doi 2 SV dua tren gia tri so sanh "key"
                        if(order == (int)ThuTuSapXep.ThuTu.AZ)
                        {
                            if(checkGreater(ds[i],ds[j]))
                            {
                                var tmp = ds[i];
                                ds[i] = ds[j];
                                ds[j] = tmp;
                            }
                        } else {
                            if(checkLower(ds[i],ds[j]))
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
}