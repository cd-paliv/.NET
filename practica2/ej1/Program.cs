using System;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            char c;
            char? c2;
            string st;
            c = "";
            c = '';
            c = null;
            c2 = null;
            c2 = (65 as char?);
            st = "";
            st = '';
            st = null;
            st = (char)65;
            st = (string)65;
            st = 47.89.ToString();
        }
    }
}
