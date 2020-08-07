using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interação lógica para informacoesSistema.xam
    /// </summary>
    public partial class informacoesSistema : UserControl
    {

        private DispatcherTimer timer = new DispatcherTimer();

        private PerformanceCounter cpuCounter = new PerformanceCounter();

        public string getCurrentCpuUsage;

        public informacoesSistema()
        {
            InitializeComponent();


            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            usoMemoria();

            GetCpuUsage();

            timer.Start();

        }


        private void GetCpuUsage()
        {
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            getCurrentCpuUsage = cpuCounter.NextValue() + "%".ToString();

            lbUseCPU.Content = "Uso do CPU: " + getCurrentCpuUsage.ToString();
        }


        private void usoMemoria()
        {
            try
            {
                ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
                ManagementObjectCollection results = searcher.Get();

                foreach (ManagementObject result in results)
                {
                    long TotalVisibleMemorySize = Convert.ToInt64(result["TotalVisibleMemorySize"]) / 1000;
                    long FreePhysicalMemory = Convert.ToInt64(result["TotalVisibleMemorySize"]) / 1000;
                    long TotalVirtualMemorySize = Convert.ToInt64(result["TotalVirtualMemorySize"]) / 1000;
                    long FreeVirtualMemory = Convert.ToInt64(result["FreeVirtualMemory"]) / 1000;

                    lbTotal.Content = "Total Visible Memory: {0} Mb " + TotalVisibleMemorySize;
                    lbFree.Content = "Free Physical Memory: {0} Mb " + FreePhysicalMemory;
                    lbVirtual.Content = "Total Virtual Memory: {0} Mb " + TotalVirtualMemorySize;
                    lbFreeVirtual.Content = "Free Virtual Memory: {0} Mb " + FreeVirtualMemory;

                }
            }
            catch (Exception)
            {

            }
        }


    }
}
