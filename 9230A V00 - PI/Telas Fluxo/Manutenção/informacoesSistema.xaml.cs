using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// 


    public partial class informacoesSistema : UserControl
    {
       
       private PerformanceCounter ramCounter;
       private PerformanceCounter cpuCounter;

        public string getCurrentCpuUsage;

        public informacoesSistema()
        {
            InitializeComponent();

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            cpuCounter = new PerformanceCounter();

        }

        public void atualizaSistema()
        {


            usoMemoria();

            GetCpuUsage();

            getDiskInformation();



        }

        private void getDiskInformation() 
        {

        
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                //Console.WriteLine("Drive {0}", d.Name);
                //Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (drive.Name.Contains("C:"))
                {
                    if (drive.IsReady == true)
                    {
                        
                        const double BytesInGB = 1073741824;

                        double totalDisco = Math.Round(drive.TotalSize / BytesInGB,1);
                        double AvailableFreeSpace = Math.Round((drive.TotalFreeSpace) / BytesInGB,1);
                        double percentual = Math.Round((drive.AvailableFreeSpace / (double)drive.TotalSize) * 100,1);



                        lbTotalDisco.Content = "Tamanho disco:  " + totalDisco + " GB";

                        lbFreedisco.Content = "Espaço disponível Disco: " + AvailableFreeSpace + " GB" + "  (" + percentual + " %)";

                    }
                }
            }
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
                ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);

                lbFree.Content = "Memória Ram dispinível: " + Convert.ToInt32(ramCounter.NextValue()).ToString() + "Mb";

            }
            catch (Exception)
            {

            }
        }


    }


}
