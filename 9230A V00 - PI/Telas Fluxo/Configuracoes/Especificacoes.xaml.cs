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
    /// Interaction logic for Especificacoes.xaml
    /// </summary>
    public partial class Especificacoes : UserControl
    {
        #region Variaveis

        Utilidades.messageBox inputDialog;
        private float floatPoint;
        private Int32 intPoint;

        #endregion

        public Especificacoes()
        {
            InitializeComponent();
        }

        #region Leitura e Escrita

        public void writeVariables_AuxiliaresProcesso(int bufferPlc_Auxiliares)
        {

            //Controle Máquinas
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 0, Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Silo1_2);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 4, Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Balanca);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 8, Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pre_Misturador);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 12, Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pos_Misturador);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 16, Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Silo1_2);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 20, Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Balanca);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 24, Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pre_Misturador);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 28, Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pos_Misturador);
            Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 70, Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPreMisturador);
            Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 74, Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPosMisturador);

            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Write = true;

        }

        private void readVariablesBuffer_AuxiliaresProcesso(int bufferPlc_Auxiliares)
        {
            //Controle Máquinas
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Silo1_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 0);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Balanca = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 4);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pre_Misturador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 8);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pos_Misturador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 12);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Silo1_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 16);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Balanca = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 20);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pre_Misturador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 24);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pos_Misturador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 28);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPreMisturador = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 70);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPosMisturador = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 74);

        }



        #endregion

        #region Events
        private void btSalvarInformacoes_Click(object sender, RoutedEventArgs e)
        {
            EscritaInformacoes(4);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LeituraInformacoes();
        }

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            keypad mainWindow = new keypad(false, 10);


            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                double oldValue = Convert.ToDouble(txtReceber.Text);
                //Recebe o novo valor digitado no Keypad


                double newValue = Convert.ToDouble(mainWindow.Result.Replace('.', ','));


                bool isNumeric = float.TryParse(txtReceber.Text, out floatPoint);

                if (isNumeric)
                {
                    if (oldValue != newValue)
                    {
                        txtReceber.Text = Convert.ToString(newValue);

                        //Retira o foco do textbox.
                        Keyboard.ClearFocus();

                    }
                }
                else
                {
                    //Envia o oldValue pois o valor máximo ultrapassou o limite.
                    txtReceber.Text = Convert.ToString(oldValue);
                }

            }
        }

        private void IntergerPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            keypad mainWindow = new keypad(true, 6);


            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                double oldValue = Convert.ToInt32(txtReceber.Text);
                //Recebe o novo valor digitado no Keypad


                double newValue = Convert.ToInt32(mainWindow.Result.Replace('.', ','));


                bool isNumeric = Int32.TryParse(txtReceber.Text, out intPoint);

                if (isNumeric)
                {
                    if (oldValue != newValue)
                    {
                        txtReceber.Text = Convert.ToString(newValue);

                        //Retira o foco do textbox.
                        Keyboard.ClearFocus();

                    }
                }
                else
                {
                    //Envia o oldValue pois o valor máximo ultrapassou o limite.
                    txtReceber.Text = Convert.ToString(oldValue);
                }

            }
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

        #endregion

        #region Funções

        private void LeituraInformacoes()
        {
            readVariablesBuffer_AuxiliaresProcesso(4);

            txtVolumeSilo1_2.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Silo1_2);

            txtVolumeBalanca.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Balanca);

            txtVolumePreMisturador.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pre_Misturador);

            txtVolumePosMisturador.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pos_Misturador);

            txtPesoBalanca.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Balanca);

            txtPesoPreMisturador.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pre_Misturador);

            txtPesoPosMisturador.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pos_Misturador);

            txtTempoPreMistura.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPreMisturador);

            txtTempoPosMistura.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPosMisturador);


        }

        private void EscritaInformacoes(int bufferPlc_Auxiliares)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Read = false;

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Silo1_2 = Convert.ToSingle(txtVolumeSilo1_2.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Balanca = Convert.ToSingle(txtVolumeBalanca.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pre_Misturador = Convert.ToSingle(txtVolumePreMisturador.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Volume_Maximo_Pos_Misturador = Convert.ToSingle(txtVolumePosMisturador.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Balanca = Convert.ToSingle(txtPesoBalanca.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pre_Misturador = Convert.ToSingle(txtPesoPreMisturador.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Peso_Maximo_Pos_Misturador = Convert.ToSingle(txtPesoPosMisturador.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPreMisturador = Convert.ToInt32(txtTempoPreMistura.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.TempoPosMisturador = Convert.ToInt32(txtTempoPosMistura.Text);

            writeVariables_AuxiliaresProcesso(4);

            inputDialog = new Utilidades.messageBox("Salvar", "Informações salvas com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

            inputDialog.ShowDialog();
        }

        #endregion

    }
}
