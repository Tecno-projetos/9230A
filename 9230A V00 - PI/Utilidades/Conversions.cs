using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.Utilidades
{
    public class Conversions
    {

        public static void Dword_To_Bit(UInt32 Dword, ref bool[] Bits, bool Swap)
        {

            UInt32 value = 1;

            if (Swap)
            {
                //Swap de bytes na High word e Low word
                Dword = ((Dword >> 8) & 0x00FF00FF) | ((Dword << 8) & 0xFF00FF00);

                //Swap de word na dword
                Dword = ((Dword >> 16) & 0x0000FFFF) | ((Dword << 16) & 0xFFFF0000);
            }

            for (int i = 0; i <= 31; i++)
            {
                if ((Dword & value) == value)
                {
                    Bits[i] = true;
                }
                else
                {
                    Bits[i] = false;
                }

                value = value * 2;
            }

        }


        public static UInt32 Bit_To_Dword(ref bool[] Bits, bool Swap)
        {

            UInt32 value = 1;
            UInt32 Dword = 0;

            for (int i = 0; i <= 31; i++)
            {
                if (Bits[i])
                {
                    Dword += value;
                }

                value = value * 2;
            }

            if (Swap)
            {
                //Swap de bytes na High word e Low word
                Dword = ((Dword >> 8) & 0x00FF00FF) | ((Dword << 8) & 0xFF00FF00);

                //Swap de word na dword
                Dword = ((Dword >> 16) & 0x0000FFFF) | ((Dword << 16) & 0xFFFF0000);
            }

            return Dword;
        }
    }
}
