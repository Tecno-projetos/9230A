using _9230A_V00___PI.Teclados;
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
    /// Interação lógica para configuracoesINV.xam
    /// </summary>
    public partial class configuracoesINV : UserControl
    {

        Int32 n;

        float floatPoint;

        public event EventHandler resetTotal_Click;
        public event EventHandler resetParcial_Click;
        public event EventHandler atualizaSPManutencao_Click;
        public event EventHandler atualizaSPLimpeza_Click;
        public event EventHandler atualizaSPMotorVazio_Click;

        public configuracoesINV()
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
            keypad mainWindow = new keypad(true, 4);
            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                int oldValue = Convert.ToInt32(TB_SPMantencao.Text);
                //Recebe o novo valor digitado no Keypad
                int newValue = Convert.ToInt32(mainWindow.Result);

                bool isNumeric = int.TryParse(TB_SPMantencao.Text, out n);

                if (isNumeric)
                {
                    if (oldValue != newValue)
                    {
                        TB_SPMantencao.Text = Convert.ToString(newValue);


                        //Retira o foco do textbox.
                        Keyboard.ClearFocus();

                        //Dispara o evento de atualizar a váriavel no CLP.
                        if (this.atualizaSPManutencao_Click != null)
                            this.atualizaSPManutencao_Click(this, e);

                    }
                }
                else
                {
                    //Envia o oldValue pois o valor máximo ultrapassou o limite.
                    TB_SPMantencao.Text = Convert.ToString(oldValue);
                }

            }
        }

        private void TB_SPLimpeza_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            keypad mainWindow = new keypad(true, 1);
            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                int oldValue = Convert.ToInt32(TB_SPLimpeza.Text);
                //Recebe o novo valor digitado no Keypad
                int newValue = Convert.ToInt32(mainWindow.Result);

                bool isNumeric = int.TryParse(TB_SPLimpeza.Text, out n);

                if (isNumeric)
                {
                    if (oldValue != newValue)
                    {
                        TB_SPLimpeza.Text = Convert.ToString(newValue);


                        //Retira o foco do textbox.
                        Keyboard.ClearFocus();

                        //Dispara o evento de atualizar a váriavel no CLP.
                        if (this.atualizaSPLimpeza_Click != null)
                            this.atualizaSPLimpeza_Click(this, e);

                    }
                }
                else
                {
                    //Envia o oldValue pois o valor máximo ultrapassou o limite.
                    TB_SPLimpeza.Text = Convert.ToString(oldValue);
                }

            }
        }

        private void tbMotorVazio_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            keypad mainWindow = new keypad(false,5);
            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                double oldValue = Convert.ToDouble(tbMotorVazio.Text);
                //Recebe o novo valor digitado no Keypad
                
                
                double newValue = Convert.ToDouble(mainWindow.Result.Replace('.', ','));


                bool isNumeric = float.TryParse(tbMotorVazio.Text, out floatPoint);

                if (isNumeric)
                {
                    if (oldValue != newValue)
                    {
                        tbMotorVazio.Text = Convert.ToString(newValue);


                        //Retira o foco do textbox.
                        Keyboard.ClearFocus();

                        //Dispara o evento de atualizar a váriavel no CLP.
                        if (this.atualizaSPMotorVazio_Click != null)
                            this.atualizaSPMotorVazio_Click(this, e);

                    }
                }
                else
                {
                    //Envia o oldValue pois o valor máximo ultrapassou o limite.
                    tbMotorVazio.Text = Convert.ToString(oldValue);
                }

            }
        }
    }
}
