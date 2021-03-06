﻿using _9230A_V00___PI.Teclados;
using _9230A_V00___PI.Utilidades;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace _9230A_V00___PI.Telas_Fluxo.Controle_Produção
{
    /// <summary>
    /// Lógica interna para controleBalanca.xaml
    /// </summary>
    public partial class controleBalanca : Window
    {

        #region Variaveis

        Utilidades.VariaveisGlobais.IndicadorPesagem dummyIndicador = new Utilidades.VariaveisGlobais.IndicadorPesagem();

        Utilidades.messageBox inputDialog;

        int bufferClp;

        int Offset;

        private event EventHandler atualizaPalavradeComando;
        private event EventHandler atualizaReais;
        
        #endregion

        public controleBalanca(int bufferCLP, int Offset)
        {
            InitializeComponent();

            this.bufferClp = bufferCLP;
            this.Offset = Offset;

            atualizaPalavradeComando += ControleBalanca_atualizaPalavradeComando;
            atualizaReais += ControleBalanca_atualizaReais;
        }

        #region Escrita váriaveis

        private void ControleBalanca_atualizaReais(object sender, EventArgs e)
        {
            VariaveisGlobais.Buffer_PLC[bufferClp].Enable_Read = false;

            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset + 4, Convert.ToSingle(txtAutomatico.Text));
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset + 8, Convert.ToSingle(txtManual.Text));

            VariaveisGlobais.Buffer_PLC[bufferClp].Enable_Write = true;

        }

        private void ControleBalanca_atualizaPalavradeComando(object sender, EventArgs e)
        {
            VariaveisGlobais.Buffer_PLC[bufferClp].Enable_Read = false;

            Utilidades.VariaveisGlobais.indicadorPesagem = dummyIndicador;

            Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset + 12, Move_Bits.IndicadorPesagemToByte(Utilidades.VariaveisGlobais.indicadorPesagem)); //Atualiza os Bits do command

            VariaveisGlobais.Buffer_PLC[bufferClp].Enable_Write = true;


        }

        #endregion

        #region Funções

        public void atualiza_Balanca()
        {

            Utilidades.VariaveisGlobais.indicadorPesagem.Valor_Atual_Indicador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset);

            Utilidades.VariaveisGlobais.indicadorPesagem = Move_Bits.ByteToIndicadorPesagem(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset+12), Utilidades.VariaveisGlobais.indicadorPesagem);

            lbPesoBalnca.Content = Utilidades.VariaveisGlobais.indicadorPesagem.Valor_Atual_Indicador.ToString("N", CultureInfo.GetCultureInfo("pt-BR")) + " kg";


            if (Utilidades.VariaveisGlobais.indicadorPesagem.Erro_Leitura)
            {
                lbStatusMotor.Content = "Balança com erro";
                lbStatusMotor.Background = new SolidColorBrush(Colors.Red);
                lbStatusMotor.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                lbStatusMotor.Content = "Balança em operação";
                lbStatusMotor.Background = new SolidColorBrush(Colors.Green);
                lbStatusMotor.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        public void atualizaTela()
        {
            Utilidades.VariaveisGlobais.indicadorPesagem.Percentual_Habilita_Balanca_Vazia_Automatica = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset+4);

            Utilidades.VariaveisGlobais.indicadorPesagem.Percentual_Habilita_Balanca_Vazia_Manual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferClp].Buffer, Offset+8);

            txtAutomatico.Text = Convert.ToString(Utilidades.VariaveisGlobais.indicadorPesagem.Percentual_Habilita_Balanca_Vazia_Automatica);
            txtManual.Text = Convert.ToString(Utilidades.VariaveisGlobais.indicadorPesagem.Percentual_Habilita_Balanca_Vazia_Manual);


            if (Utilidades.VariaveisGlobais.indicadorPesagem.Balanca_Vazia_Manual)
            {
                txtManual1.Text = "Automático";
            }
            else
            {
                txtManual1.Text = "Manual";
            }

        }
        
        #endregion

        #region Clicks

        private void btComandoZero_Click(object sender, RoutedEventArgs e)
        {

            dummyIndicador = Utilidades.VariaveisGlobais.indicadorPesagem;
            if (dummyIndicador.Comando_Zero)
            {
                dummyIndicador.Comando_Zero = false;
            }
            else
            {
                dummyIndicador.Comando_Zero = true;
            }


            if (this.atualizaPalavradeComando != null)
                this.atualizaPalavradeComando(this, e);


        }

        private void btComandoTara_Click(object sender, RoutedEventArgs e)
        {
            dummyIndicador = Utilidades.VariaveisGlobais.indicadorPesagem;

            if (dummyIndicador.Comando_Tara)
            {
                dummyIndicador.Comando_Tara = false;
            }
            else
            {
                dummyIndicador.Comando_Tara = true;
            }


            if (this.atualizaPalavradeComando != null)
                this.atualizaPalavradeComando(this, e);
        }

        private void btManualAuotmatico_Click(object sender, RoutedEventArgs e)
        {
            dummyIndicador = Utilidades.VariaveisGlobais.indicadorPesagem;

            if (dummyIndicador.Balanca_Vazia_Manual)
            {
                dummyIndicador.Balanca_Vazia_Manual = false;

                txtManual1.Text = "Manual";

            }
            else
            {
                dummyIndicador.Balanca_Vazia_Manual = true;


                txtManual1.Text = "Automático";
            }


            if (this.atualizaPalavradeComando != null)
                this.atualizaPalavradeComando(this, e);
        }

        private void btBalancaVazia_Click(object sender, RoutedEventArgs e)
        {

            dummyIndicador = Utilidades.VariaveisGlobais.indicadorPesagem;

            if (Utilidades.VariaveisGlobais.indicadorPesagem.Habilita_Setar_Balanca_Vazia)
            {
                if (dummyIndicador.Seta_Balanca_Vazia)
                {
                    dummyIndicador.Seta_Balanca_Vazia = false;
                }
                else
                {
                    dummyIndicador.Seta_Balanca_Vazia = true;
                }


                if (this.atualizaPalavradeComando != null)
                    this.atualizaPalavradeComando(this, e);
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Aguarde", "A balança não está habilitada para setar!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

                inputDialog.ShowDialog();
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

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.floatingKeypad(txtReceber.Text, 3).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();

            if (this.atualizaReais != null)
                this.atualizaReais(this, e);


        }
        #endregion

    }
}
