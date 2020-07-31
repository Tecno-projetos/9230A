using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _9230A_V00___PI
{
    /// <summary>
    /// Lógica interna para Fluxo.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {

        Telas_Fluxo.Fluxo fluxo = new Telas_Fluxo.Fluxo();


        public TelaInicial()
        {
            InitializeComponent();



            spInical.Children.Add(fluxo);

           
            //comment maycon





        }


        #region Clicks Menu

        private void btSair_Click(object sender, RoutedEventArgs e)
        {





            App.Current.Shutdown();
            Process proc = Process.GetCurrentProcess();
            proc.Kill();

        }


        private void btHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btProducao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btReceitas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btConfiguracoes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAlarmes_Click(object sender, RoutedEventArgs e)
        {

        }



        #endregion



    }
}
