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
using System.Windows.Threading;

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

        #region Dispacher Timers

        DispatcherTimer timer50ms = new DispatcherTimer();

        #endregion

        #region Equipamentos

        Utilidades.EquipsControl Motor_22 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Bifurcada_23 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Atuador_26_Silo_1 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Atuador_26_Silo_2 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_29 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_30 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_42 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_43 = new Utilidades.EquipsControl(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV);
        Utilidades.EquipsControl Motor_44 = new Utilidades.EquipsControl(Utilidades.typeEquip.SS, Utilidades.typeCommand.SS);
        Utilidades.EquipsControl Motor_45 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_46 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_48 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        Utilidades.EquipsControl Motor_49 = new Utilidades.EquipsControl(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Digital);
        Utilidades.EquipsControl Motor_62 = new Utilidades.EquipsControl(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV);
        Utilidades.EquipsControl Motor_65 = new Utilidades.EquipsControl(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV);


        #endregion


        public TelaInicial()
        {
            InitializeComponent();


            spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            #region Equipamentos

            //Atribuição dos valores para cada equipamento
            //Motor_22.Command_GS.Name = "EXAUSTORES SECADOR";
            //Motor_22.Tag = "EX1-2-3-4SC";

            //Motor_22.TempoCompensadora = true;

            //Motor_22.HabilitaBloqueioExterno = true;

            //Atualiza informações de cada motor




            #endregion

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

            #region Configuração Dispatcher

            timer50ms.Interval = TimeSpan.FromMilliseconds(50);
            timer50ms.Tick += timer_Tick;
            timer50ms.Start();

            #endregion



        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();

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

































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































        //-----------------------------------------------------------------------
        //Emanuel
       #region Clicks Menu

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
            Process proc = Process.GetCurrentProcess();
            proc.Kill();

        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            }
        }

        private void btProducao_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

            }
        }

        private void btReceitas_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.receitas);

            }
        }

        private void btConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.configuracoes);

            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.relatorios);

            }
        }

        private void btAlarmes_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.alarmes);

            }
        }


        private void txtUser_LostFocus(object sender, RoutedEventArgs e)
        {
            Process[] tabtip = Process.GetProcessesByName("TabTip");

            if (null != tabtip)
            {
                tabtip.ToList().ForEach(a => { if (null != a) { a.Kill(); } });

            }
        }


        private void txtUser_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
                {
                    TextBox tb = (TextBox)e.OriginalSource;
                    tb.Dispatcher.BeginInvoke(
                        new Action(delegate
                        {
                            tb.SelectAll();
                        }), System.Windows.Threading.DispatcherPriority.Input);

                    Teclados.keyboard.openKeyboard();
                }
            }
            catch (Exception ex)
            {
                Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
            }
        }

        #endregion

        private void btConfiguracoesUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {

                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.controleUsuario);

            }
        }
    }

}
