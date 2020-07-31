using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.Teclados
{
    public class keyboard
    {
       /// <summary>
       /// Abre teclado virtual para digitação
       /// </summary>
        public void openKeyboard() 
        {
            string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";
            Process.Start(touchKeyboardPath);

        }

        /// <summary>
        /// Fecha Teclado Virtual
        /// </summary>
        public void closeKeyboard() 
        {
        
        }

    }
}
