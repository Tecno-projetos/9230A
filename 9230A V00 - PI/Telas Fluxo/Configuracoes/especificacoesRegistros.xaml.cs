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
    /// Interação lógica para especificacoesRegistros.xam
    /// </summary>
    public partial class especificacoesRegistros : UserControl
    {
        #region Variaveis

        Utilidades.messageBox inputDialog;

        private float floatPoint;

        #endregion

        public especificacoesRegistros()
        {
            InitializeComponent();
        }

        #region Write and Read

        private void readVariablesBuffer_AuxiliaresProcesso(int bufferPlc_Auxiliares)
        {
            //Controle Registro
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 32);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 36);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 40);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 44);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 48);
            Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 52);

        }

        public void writeVariables_AuxiliaresProcesso(int bufferPlc_Auxiliares)
        {

            //Controle Registro
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 32, Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo1);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 36, Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo1);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 40, Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo1);

            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 44, Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo2);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 48, Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo2);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 52, Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo2);


            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Write = true;

        }



        #endregion

        #region Events

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            keypad mainWindow = new keypad(false, 3);


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
                        //Verifica se o novo valor é menor que 100
                        if (newValue <= 100)
                        {
                            txtReceber.Text = Convert.ToString(newValue);
                        }
                        else
                        {
                            //Envia o oldValue pois o valor máximo ultrapassou o limite.
                            txtReceber.Text = Convert.ToString(oldValue);
                        }
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

        private void btSalvarInformacoes_Click(object sender, RoutedEventArgs e)
        {
            EscritaInformacoes(4);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LeituraInformacoes();
        }

        #endregion

        #region Funções


        private void LeituraInformacoes()
        {
            readVariablesBuffer_AuxiliaresProcesso(4);

            txtAberturaMaximaSilo1.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo1);

            txtFechamentoAntecipadoSilo1.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo1);

            txtInicioReducaoSilo1.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo1);



            txtAberturaMaximaSilo2.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo2);

            txtFechamentoAntecipadoSilo2.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo2);

            txtInicioReducaoSilo2.Text = Convert.ToString(Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo2);

        }

        private void EscritaInformacoes(int bufferPlc_Auxiliares)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Read = false;

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo1 = Convert.ToSingle(txtAberturaMaximaSilo1.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo1 = Convert.ToSingle(txtFechamentoAntecipadoSilo1.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo1 = Convert.ToSingle(txtInicioReducaoSilo1.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Abertura_Máxima_Silo2 = Convert.ToSingle(txtAberturaMaximaSilo2.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Fechamento_Antecipado_Silo2 = Convert.ToSingle(txtFechamentoAntecipadoSilo2.Text);

            Utilidades.VariaveisGlobais.auxiliaresProcesso.Inicio_Reducao_Silo2 = Convert.ToSingle(txtInicioReducaoSilo2.Text);

            writeVariables_AuxiliaresProcesso(4);

            inputDialog = new Utilidades.messageBox("Salvar", "Informações salvas com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

            inputDialog.ShowDialog();
        }

        #endregion


    }
}
