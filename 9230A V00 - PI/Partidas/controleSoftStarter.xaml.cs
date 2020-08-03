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
using System.Windows.Shapes;

namespace _9230A_V00___PI.Partidas
{
    /// <summary>
    /// Lógica interna para controleSoftStarter.xaml
    /// </summary>
    public partial class controleSoftStarter : Window
    {
        public event EventHandler atualizarCorrenteVazio;
        public event EventHandler atualizarTempoReversao;

        public event EventHandler Bt_Ligar_Click;
        public event EventHandler Bt_Reset_Click;
        public event EventHandler Bt_Libera_Click;
        public event EventHandler Bt_Inverte_Click;
        public event EventHandler Bt_Manutencao_Click;
        public event EventHandler Bt_Manual_Click;
        public event EventHandler Bt_Fechar_Click;

        public controleSoftStarter()
        {
            InitializeComponent();
        }

        #region Get/Sets

        public string statusMotor_GS
        {
            get => lbStatusMotor.Content.ToString();

            set
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = value; });
            }
        }

        public string correnteAtual_GS
        {
            get => lbCorrenteAtual.Content.ToString();

            set
            {
                lbCorrenteAtual.Dispatcher.Invoke(delegate { lbCorrenteAtual.Content = value; });
            }
        }

        public string tempoReversao_GS
        {
            get => lbTempoReversao.Content.ToString();

            set
            {
                lbTempoReversao.Dispatcher.Invoke(delegate { lbTempoReversao.Content = value; });
            }
        }

        public string sentidoGiro_GS
        {
            get => lbSentidoGiro.Content.ToString();

            set
            {
                lbSentidoGiro.Dispatcher.Invoke(delegate { lbSentidoGiro.Content = value; });
            }
        }
        #endregion

        private void btLigar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Ligar_Click != null)
                this.Bt_Ligar_Click(this, e);
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Reset_Click != null)
                this.Bt_Reset_Click(this, e);
        }

        private void btLibera_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Libera_Click != null)
                this.Bt_Libera_Click(this, e);
        }

        private void btInverte_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Inverte_Click != null)
                this.Bt_Inverte_Click(this, e);
        }

        private void btManutencao_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Manutencao_Click != null)
                this.Bt_Manutencao_Click(this, e);
        }

        private void btManual_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Manual_Click != null)
                this.Bt_Manual_Click(this, e);
        }

        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Fechar_Click != null)
                this.Bt_Fechar_Click(this, e);
        }

        private void tbCorrenteVazio_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            keypad mainWindow = new keypad(this, true, 3);
            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                int oldValue = Convert.ToInt16(tbCorrenteVazio.Text);
                //Recebe o novo valor digitado no Keypad
                int newValue = Convert.ToInt16(mainWindow.Result);


                //Verifica se o novo valor é diferente do valor anterior para que atualize a váriavel no CLP
                if (oldValue != newValue)
                {
        
                    tbCorrenteVazio.Text = Convert.ToString(newValue);

                    //Retira o foco do textbox.
                    Keyboard.ClearFocus();

                    //Dispara o evento de atualizar a váriavel no CLP.
                    if (this.atualizarCorrenteVazio != null)
                        this.atualizarCorrenteVazio(this, e);

                }

            }
        }

        private void tbReversao_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            keypad mainWindow = new keypad(this, true, 3);
            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                int oldValue = Convert.ToInt16(tbReversao.Text);
                //Recebe o novo valor digitado no Keypad
                int newValue = Convert.ToInt16(mainWindow.Result);


                //Verifica se o novo valor é diferente do valor anterior para que atualize a váriavel no CLP
                if (oldValue != newValue)
                {

                    tbReversao.Text = Convert.ToString(newValue);

                    //Retira o foco do textbox.
                    Keyboard.ClearFocus();

                    //Dispara o evento de atualizar a váriavel no CLP.
                    if (this.atualizarTempoReversao != null)
                        this.atualizarTempoReversao(this, e);

                }

            }
        }
    }
}
