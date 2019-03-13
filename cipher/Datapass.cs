using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    class Datapass
    {
        public static int N;
        public static int n;
        public static int M;
        public static int Grade;
        public static ArrayList sign = new ArrayList();
        public static char[] signall = new char[5] {'+','-', '*', '/', '%' };
        public static int wrong ;
        public static int right ;
        public static ArrayList Mistake_Number = new ArrayList();
        public static ArrayList Mistake_Equation = new ArrayList();
        public static ArrayList Mistake_Youranswer = new ArrayList();
        public static ArrayList Mistake_Rightanswer = new ArrayList();
        public static string time;
    }
}
