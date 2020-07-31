using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        #region Varivaies

        //Cria comunicação com CLP
        Comunicacao.CallCommunicationPLC CommunicationPLC = new Comunicacao.CallCommunicationPLC(0, 10);

        #endregion

        #region Threads

        System.Threading.Thread ReadWritePLCThread;

        #endregion


        Telas_Fluxo.Fluxo fluxo = new Telas_Fluxo.Fluxo();


        public TelaInicial()
        {
            InitializeComponent();


            spInical.Children.Add(fluxo);

            #region Configuração Buffers PLC

            Utilidades.VariaveisGlobais.Buffer_PLC[0].Name = "DB Controle Todos Equipamentos";
            Utilidades.VariaveisGlobais.Buffer_PLC[0].DBNumber = 2;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Size = 392;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Write = false;

            for (int i = 0; i < Utilidades.VariaveisGlobais.Buffer_PLC.Length; i++)
            {
                Utilidades.VariaveisGlobais.Buffer_PLC[i].Buffer = new byte[Utilidades.VariaveisGlobais.Buffer_PLC[i].Size];
                Utilidades.VariaveisGlobais.Buffer_PLC[i].Result = 99999;
            }

            #endregion

            #region Configuração Threads

            //Leitura e escrita PLC
            //====================================================================
            ReadWritePLCThread = new System.Threading.Thread(ReadWritePLC);
            ReadWritePLCThread.Name = "Actualize Screen";
            ReadWritePLCThread.Start();

            #endregion
        }

        private void ReadWritePLC()
        {
            while (true)
            {
                CommunicationPLC.readBuffersPLC(); //Chama a leitura no PLC



                
                CommunicationPLC.writeBufferPLC();//Chama a escrita no PLC

                Thread.Sleep(100);
            }

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


        private void txtUser_GotFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                TextBox tb = (TextBox)e.OriginalSource;
                tb.Dispatcher.BeginInvoke(
                    new Action(delegate
                    {
                        tb.SelectAll();
                    }), System.Windows.Threading.DispatcherPriority.Input);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}
