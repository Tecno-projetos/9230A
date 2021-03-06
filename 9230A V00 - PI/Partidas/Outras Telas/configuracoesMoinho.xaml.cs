﻿using _9230A_V00___PI.Teclados;
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

namespace _9230A_V00___PI.Partidas.Outras_Telas
{
    /// <summary>
    /// Interação lógica para configuracoesMoinho.xam
    /// </summary>
    public partial class configuracoesMoinho : UserControl
    {

        Int32 n;

        float floatPoint;

        public event EventHandler resetTotal_Click;
        public event EventHandler resetParcial_Click;
        public event EventHandler atualizaSPManutencao_Click;
        public event EventHandler atualizaSPLimpeza_Click;
        public event EventHandler atualizaSPMotorVazio_Click;
        public event EventHandler atualizaSPTempoReversao_Click;

        public configuracoesMoinho()
        {
            InitializeComponent();
        }

        #region Encapsulate Fields

        public string SpManutencao
        {
            set
            {
                TB_SPMantencao.Dispatcher.Invoke(delegate { TB_SPMantencao.Text = value; });

            }
            get
            {
                return TB_SPMantencao.Text;
            }
        }

        public string SpLimpeza
        {
            set
            {
                TB_SPLimpeza.Dispatcher.Invoke(delegate { TB_SPLimpeza.Text = value; });

            }
            get
            {
                return TB_SPLimpeza.Text;
            }
        }


        public string SpMotorVazio
        {
            set
            {
                tbMotorVazio.Dispatcher.Invoke(delegate { tbMotorVazio.Text = value; });

            }
            get
            {
                return tbMotorVazio.Text;
            }
        }

        #endregion

        private void btResetTotal_Click(object sender, RoutedEventArgs e)
        {
            if (this.resetTotal_Click != null)
                this.resetTotal_Click(this, e);
        }

        private void btResetParcial_Click(object sender, RoutedEventArgs e)
        {
            if (this.resetParcial_Click != null)
                this.resetParcial_Click(this, e);
        }
        public void actualize_UI(Utilidades.VariaveisGlobais.type_All Command)
        {
            TB_Total_Horas.Text = Convert.ToString(Command.PD.HorimetroTotal);
            TB_Horas.Text = Convert.ToString(Command.PD.HorimetroParcial);

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

        private void TB_SPMantencao_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.IntergerKeypad(txtReceber.Text, 4,99999).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();

            //Dispara o evento de atualizar a váriavel no CLP.
            if (this.atualizaSPManutencao_Click != null)
                this.atualizaSPManutencao_Click(this, e);
        }

        private void TB_SPLimpeza_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.IntergerKeypad(txtReceber.Text, 1, 99).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();

            //Dispara o evento de atualizar a váriavel no CLP.
            if (this.atualizaSPLimpeza_Click != null)
            this.atualizaSPLimpeza_Click(this, e);


        }

        private void tbMotorVazio_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.floatingKeypad(txtReceber.Text, 6).ToString();

            //Dispara o evento de atualizar a váriavel no CLP.
            if (this.atualizaSPMotorVazio_Click != null)
                this.atualizaSPMotorVazio_Click(this, e);

          
        }

        private void tbTempoReversao_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.IntergerKeypad(txtReceber.Text, 4, 9999).ToString();

            //Dispara o evento de atualizar a váriavel no CLP.
            if (this.atualizaSPTempoReversao_Click != null)
                this.atualizaSPTempoReversao_Click(this, e);

        }
    }
}
