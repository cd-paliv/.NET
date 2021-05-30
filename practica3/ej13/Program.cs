using System;
using System.Collections;

namespace ej13
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "(()[])";
            Console.WriteLine($"Está balanceado? {estaBalanceado(s1)}");
        }

        static Boolean estaBalanceado(String st1){
            if (st1 == ""){
                return true;
            }else{
                char[] vector = st1.ToCharArray();
                if((vector[0] == ')') || (vector[0] == ']') || (vector[0] == '}')){
                    return false;
                }else return recorrerSt(vector);
            }
        }

        static Boolean recorrerSt(char[] v)
        {
            Stack pila = new Stack();
            pila.Push(v[0]);
            for(int i = 1; i < v.Length; i++){
                if((v[i] == '(') || (v[i] == '[') || (v[i] == '{')){
                    pila.Push(v[i]);
                }else if (pila.Count > 0)
                    {
                        if(v[i] == ')'){
                            if(! pila.Pop().Equals('(')){
                                return false;
                            }
                        }else if(v[i] == ']'){
                            if(! pila.Pop().Equals('[')){
                                return false;
                            }
                        }else if(v[i] == '}'){
                            if(! pila.Pop().Equals('{')){
                                return false;
                            }
                        }
                    }else return false;
            }
            return (pila.Count == 0);
        }
    }
}
