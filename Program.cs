using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowerCommunicator
{
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                //int a = 11;
                //int* b = &a;
                //Console.WriteLine((int)b);
                //Console.WriteLine(sizeof(uint));
                int a = 1;
                uint b = 0;
                ushort[] c;
                Console.WriteLine(RowerMethods.tkcmdsetUSB_find_devices(&a,&b,&c));
            }
            Console.ReadKey();
        }

        public unsafe static int* Test()
        {
            int int_data = 22;
            int* pointer = &int_data;

            return pointer;
        }
    }
}
