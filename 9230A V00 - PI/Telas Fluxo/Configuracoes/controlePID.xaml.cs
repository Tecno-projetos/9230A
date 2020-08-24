using _9230A_V00___PI.Teclados;
using _9230A_V00___PI.Utilidades;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9230A_V00___PI.Telas_Fluxo.Configuracoes
{
    /// <summary>
    /// Interação lógica para controlePID.xam
    /// </summary>
    public partial class controlePID : UserControl
    {

        #region Variaveis

        Utilidades.messageBox inputDialog;
        private float floatPoint;


        private VariaveisGlobais.PID dummyPID = new VariaveisGlobais.PID();

        #endregion
        public controlePID()
        {
            InitializeComponent();
        }

        private void readVariablesBuffer(int bufferPlc_Auxiliares)
        {

            VariaveisGlobais.controlePID.SetPoint = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 78);
            VariaveisGlobais.controlePID.kp  = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 82);
            VariaveisGlobais.controlePID.Ki = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 86);
            VariaveisGlobais.controlePID.kd = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 90);
            VariaveisGlobais.controlePID.limiteMaximo = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 94);
            VariaveisGlobais.controlePID.limiteMinimo = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 98);

            Utilidades.VariaveisGlobais.controlePID = Move_Bits.ByteToPID(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 76), Utilidades.VariaveisGlobais.controlePID);

        }

        public void writeVariables_AuxiliaresProcesso(int bufferPlc_Auxiliares)
        {

            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 78, VariaveisGlobais.controlePID.SetPoint);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 82, VariaveisGlobais.controlePID.kp);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 86, VariaveisGlobais.controlePID.Ki);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 90, VariaveisGlobais.controlePID.kd);

            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 94, VariaveisGlobais.controlePID.limiteMaximo);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 98, VariaveisGlobais.controlePID.limiteMinimo);

            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Write = true;

        }

        private void btSalvarInformacoes_Click(object sender, RoutedEventArgs e)
        {
            EscritaInformacoes(4);
        }

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.floatingKeypad(txtReceber.Text,6).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();

        }

        private void TB_GotFocus(object sender, RoutedEventArgs e)
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
                Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LeituraInformacoes();
        }


        #region Funções

        private void LeituraInformacoes()
        {
            readVariablesBuffer(4);

            txtSP.Text = Convert.ToString(Utilidades.VariaveisGlobais.controlePID.SetPoint);

            txtKp.Text = Convert.ToString(Utilidades.VariaveisGlobais.controlePID.kp);

            txtKi.Text = Convert.ToString(Utilidades.VariaveisGlobais.controlePID.Ki);

            txtKd.Text = Convert.ToString(Utilidades.VariaveisGlobais.controlePID.kd);

            txtMax.Text = Convert.ToString(Utilidades.VariaveisGlobais.controlePID.limiteMaximo);

            txtMin.Text = Convert.ToString(Utilidades.VariaveisGlobais.controlePID.limiteMinimo);

            dummyPID = Utilidades.VariaveisGlobais.controlePID;

            if (dummyPID.Habilita_PID)
            {
                lbTextButton1.Text = "Desabilitar PID";
                lbTextButton1.Foreground = new SolidColorBrush(Colors.Black);
                btHabilita.Background = new SolidColorBrush(Colors.Green);
                pckIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckBold;

            }
            else
            {
                lbTextButton1.Text = "Habilitar PID";
                lbTextButton1.Foreground = new SolidColorBrush(Colors.White);
                btHabilita.Background = new SolidColorBrush(Colors.Red);
                pckIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
            }


        }

        private void EscritaInformacoes(int bufferPlc_Auxiliares)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Read = false;

            Utilidades.VariaveisGlobais.controlePID.SetPoint = Convert.ToSingle(txtSP.Text);

            Utilidades.VariaveisGlobais.controlePID.kp = Convert.ToSingle(txtKp.Text);

            Utilidades.VariaveisGlobais.controlePID.Ki = Convert.ToSingle(txtKi.Text);

            Utilidades.VariaveisGlobais.controlePID.kd = Convert.ToSingle(txtKd.Text);

            Utilidades.VariaveisGlobais.controlePID.limiteMaximo = Convert.ToSingle(txtMax.Text);

            Utilidades.VariaveisGlobais.controlePID.limiteMinimo = Convert.ToSingle(txtMin.Text);


            writeVariables_AuxiliaresProcesso(4);

            inputDialog = new Utilidades.messageBox("Salvar", "Informações salvas com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

            inputDialog.ShowDialog();
        }




        #endregion

        public void AtualizaValoresAtuais() 
        {
            lbAmper.Content = Utilidades.VariaveisGlobais.Fluxo.Motor_44.Equip_GS.Command_Get.SS.Corrente_Atual + " (A)";
            lbRPM.Content = Utilidades.VariaveisGlobais.Fluxo.Motor_43.Equip_GS.Command_Get.INV.Velocidade_Automatica_Solicita + " RPM";

        }

        private void btHabilita_Click(object sender, RoutedEventArgs e)
        {
            atualizaPID();

            if (VariaveisGlobais.controlePID.Habilita_PID)
            {
                lbTextButton1.Text = "Desabilitar PID";
                lbTextButton1.Foreground = new SolidColorBrush(Colors.Black);
                btHabilita.Background = new SolidColorBrush(Colors.Green);
                pckIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckBold;


            }
            else
            {
                lbTextButton1.Text = "Habilitar PID";
                lbTextButton1.Foreground = new SolidColorBrush(Colors.White);
                btHabilita.Background = new SolidColorBrush(Colors.Red);
                pckIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Close;
            }

        }

        public void atualizaPID() 
        {
            VariaveisGlobais.Buffer_PLC[4].Enable_Read = false;

            dummyPID = VariaveisGlobais.controlePID;

            if (dummyPID.Habilita_PID)
            {
                dummyPID.Habilita_PID = false;

            }
            else
            {
                dummyPID.Habilita_PID = true;

            }

            VariaveisGlobais.controlePID = dummyPID;
            Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[4].Buffer, 76, Move_Bits.PIDToByte(VariaveisGlobais.controlePID)); //Atualiza os Bits do command

            VariaveisGlobais.Buffer_PLC[4].Enable_Write = true;

        }
    }
}
