using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9230A_V00___PI.Telas_Fluxo
{
    /// <summary>
    /// Interação lógica para configuracoes.xam
    /// </summary>
    public partial class configuracoes : UserControl
    {
        public configuracoes()
        {
            InitializeComponent();

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("Total Visible Memory: {0} KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0} KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0} KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0} KB", result["FreeVirtualMemory"]);
            }

        }
    }
}
