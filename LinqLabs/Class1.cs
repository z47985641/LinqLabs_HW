using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLabs
{
    public class Cls_try
    {
        internal static void Swap(ref int N1, ref int N2)
        {
            int temp = N1;
            N1 = N2;
            N2 = temp;
        }
        internal static void Swap(ref string S1, ref string S2)
        {
            string temp = S1;
            S1 = S2;
            S2 = temp;
        }
        internal static void AnyTypeSwap<T>(ref T S1, ref T S2)//泛行通用型態
        {
            T temp = S1;
            S1 = S2;
            S2 = temp;
        }
    }
}
