using System;
using System.Globalization;
using System.Runtime.InteropServices;
using MyStudents;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace MyCompare
{
    class CompareTwoValue
    {

        public dynamic? key{set; get;} // thuoc tinh dong de luu nhung gia tri Enum de sap xep dua tren gtri do  
        public dynamic? order{set; get;}

        // constructor
        
        public CompareTwoValue() {}
        public CompareTwoValue(dynamic key,dynamic order) {this.key = key; this.order = order;}

        /**************************************************************************/
        // Phuong thuc so sanh 2 SinhVien dua tren 2 gia tri kieu double
        
        public bool Greater(double a, double b) => a > b;
        
        public bool Lower(double a, double b) => a < b;
        
        public bool Equal(double a, double b) => a == b;

        // Phuong thuc so sanh 2 SinhVien dua tren 2 gia tri kieu string
        public bool Greater(string str_1,string str_2) 
        {
            int i = 0;
            string a;
            string b;
            
            a = str_1.ToLower();
            b = str_2.ToLower();
            string substring,roofstring;
            if(a.Length > b.Length)
            {
                roofstring = b;
                substring = a.Substring(0,b.Length);
            }
            else {
                roofstring = a;
                substring = b.Substring(0,a.Length);
            }
            while(i < roofstring.Length && (int)a[i] == (int)b[i]) i++;

            if(i >= roofstring.Length) return false;
            else
            if((int)a[i] > (int)b[i]) 
            {
                return true; // a > b
            }
            else
                  return false; // a <= b
            // int i = 0;
            // StringBuilder a = new StringBuilder(); 
            // StringBuilder b = new StringBuilder();
            // a.Append(str_1.ToLower());
            // b.Append(str_2.ToLower());
            // while(i < a.Length-1 && i < b.Length-1 && (int)a[i] == (int)b[i]) i++;
            // if((int)a[i] > (int)b[i]) 
            // {
            //     return true; // a > b
            // }
            // else
            //       return false; // a <= b
            
        }
        public bool Lower(string str_1,string str_2) 
        {
            int i = 0;
            string a;
            string b;
            
            a = str_1.ToLower();
            b = str_2.ToLower();
            string substring,roofstring;
            if(a.Length > b.Length)
            {
                roofstring = b;
                substring = a.Substring(0,b.Length);
            }
            else {
                roofstring = a;
                substring = b.Substring(0,a.Length);
            }
            while(i < roofstring.Length && (int)a[i] == (int)b[i]) i++;

            if(i >= roofstring.Length) return false;
            else
            if((int)a[i] < (int)b[i]) 
            {
                return true; // a > b
            }
            else
                  return false; // a <= b
            
        }
        public bool Equal(string str_1, string str_2){
            int i = 0;
            string a;
            string b;
            
            a = str_1.ToLower();
            b = str_2.ToLower();
            string substring,roofstring;
            if(a.Length > b.Length)
            {
                roofstring = b;
                substring = a.Substring(0,b.Length);
            }
            else {
                roofstring = a;
                substring = b.Substring(0,a.Length);
            }
            while(i < roofstring.Length && (int)a[i] == (int)b[i]) i++;

            if(i >= roofstring.Length) return true;
            else return false;
        }
        
        
        // dua tren key ma so sanh 2 gia tri la double hay la string dung delegate Func
        public bool checkGreater(SinhVien a, SinhVien b)
        {
            bool checkgreater = false;
            var kq = (SinhVien x,SinhVien y) => {
                if(key == (int)MyEnum.Key.GPA)
                {
                    return Greater(x.GPA,y.GPA);
                }
                else if(key == (int)MyEnum.Key.Name)
                {
                    return Greater(x.Name,y.Name);
                }
                else if(key == (int)MyEnum.Key.MSSV)
                {
                    return Greater(x.MSSV,y.MSSV);
                }
                else return false;
                    
            };
            checkgreater = kq.Invoke(a,b); 
            return checkgreater;
        }
        public bool checkLower(SinhVien a, SinhVien b)
        {
            bool checklower = false;
            var kq = (SinhVien x,SinhVien y) => {
                if(key == (int)MyEnum.Key.GPA)
                {
                    return Lower(x.GPA,y.GPA);
                }
                else if(key == (int)MyEnum.Key.Name)
                {
                    return Lower(x.Name,y.Name);
                }
                else if(key == (int)MyEnum.Key.MSSV)
                {
                    return Lower(x.MSSV,y.MSSV);
                }
                else return false;
                    
            };
            checklower = kq.Invoke(a,b); 
            return checklower;
        }
        public bool checkEquals(SinhVien a, SinhVien b)
        {
            bool checkequals = false;
            
            var kq = (SinhVien x,SinhVien y) => {
                if(key == (int)MyEnum.Key.GPA)
                {
                    return Equal(x.GPA,y.GPA);
                }
                else if(key == (int)MyEnum.Key.Name)
                {
                    return Equal(x.Name,y.Name);
                }
                else if(key == (int)MyEnum.Key.MSSV)
                {
                    return Equal(x.MSSV,y.MSSV);
                }
                else return false;
                
            }; 
            checkequals = kq.Invoke(a,b); 
            return checkequals;
        }
        
        
   }
}

    


