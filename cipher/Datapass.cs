using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cipher
{
    class Datapass
    {
		public static int x1 = 1;
		public static int x2 = 1;
		public static int x3 = 1;
		public static int x4 = 1;
		public static int x5 = 1;
		public static int y1 = 0;

		public static int practice = 1;
		public static int N=3;
		public static int n=6;
		public static int M=5;
		public static int Grade;
		public static ArrayList sign = new ArrayList();
		public static char[] signall = new char[5] { '+', '-', '*', '/', '%' };
		public static int wrong;
		public static int right;
		public static ArrayList Mistake_Number = new ArrayList();
		public static ArrayList Mistake_Equation = new ArrayList();
		public static ArrayList Mistake_Youranswer = new ArrayList();
		public static ArrayList Mistake_Rightanswer = new ArrayList();
		public static string time;
	}
}
