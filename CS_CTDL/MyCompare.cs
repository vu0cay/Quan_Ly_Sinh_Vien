using System;
using System.Globalization;
using System.Runtime.InteropServices;
using MyStudents;
using System.Text;
using System.Security.Cryptography;
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
        public bool Lower(string str_1,string str_2) 
        {
            int i = 0;
            StringBuilder a = new StringBuilder(); 
            StringBuilder b = new StringBuilder();
            a.Append(str_1.ToLower());
            b.Append(str_2.ToLower());
            while(i < a.Length-1 && i < b.Length-1 && (int)a[i] == (int)b[i]) i++;

            
            if((int)a[i] < (int)b[i]) 
            {
                return true; // a > b
            }
            else
                  return false; // a <= b
            
        }
        public bool Equal(string str_1, string str_2) => str_1.Equals(str_2);
        
        
        // dua tren key ma so sanh 2 gia tri la double hay la string dung delegate Func
        public bool checkGreater(SinhVien a, SinhVien b)
        {
            bool checkgreater = false;
            if(key == (int)MyEnum.Key.GPA) {
                // delegate tra ve kieu bool ss dua tren 2 gia tri double
                Func<double,double,bool> func = Greater; 
                checkgreater = func.Invoke(a.GPA,b.GPA);
            }
            else if(key == (int)MyEnum.Key.Name){
                // delegate tra ve kieu bool ss dua tren 2 gia tri string
                Func<string,string,bool> func = Greater;
                checkgreater = func.Invoke(a.Name,b.Name);
            }
            else if(key == (int)MyEnum.Key.MSSV){
                // tuong tu Name
                Func<string,string,bool> func = Greater;
                checkgreater = func.Invoke(a.MSSV,b.MSSV);
            }
            return checkgreater;
        }
        public bool checkLower(SinhVien a, SinhVien b)
        {
            bool checklower = false;
            if(key == (int)MyEnum.Key.GPA) {
                // delegate tra ve kieu bool ss dua tren 2 gia tri double
                Func<double,double,bool> func = Lower; 
                checklower = func.Invoke(a.GPA,b.GPA);
            }
            else if(key == (int)MyEnum.Key.Name){
                // delegate tra ve kieu bool ss dua tren 2 gia tri string
                Func<string,string,bool> func = Lower;
                checklower = func.Invoke(a.Name,b.Name);
            }
            else if(key == (int)MyEnum.Key.MSSV){
                // tuong tu Name
                Func<string,string,bool> func = Lower;
                checklower = func.Invoke(a.MSSV,b.MSSV);
            }
            return checklower;
        }
        public bool checkEquals(SinhVien a, SinhVien b)
        {
            bool checkequals = false;
            if(key == (int)MyEnum.Key.GPA) {
                // delegate tra ve kieu bool ss dua tren 2 gia tri double
                Func<double,double,bool> func = Equal; 
                checkequals = func.Invoke(a.GPA,b.GPA);
            }
            else if(key == (int)MyEnum.Key.Name){
                // delegate tra ve kieu bool ss dua tren 2 gia tri string
                Func<string,string,bool> func = Equal;
                checkequals = func.Invoke(a.Name,b.Name);
            }
            else if(key == (int)MyEnum.Key.MSSV){
                // tuong tu Name
                Func<string,string,bool> func = Equal;
                checkequals = func.Invoke(a.MSSV,b.MSSV);
            }
            return checkequals;
        }
        
        
   }
}

    


