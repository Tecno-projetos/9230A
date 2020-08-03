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
    /// Lógica interna para controleInversor.xaml
    /// </summary>
    public partial class controleInversor : Window
    {


        public event EventHandler atualizarVelocidade;
        public event EventHandler Bt_Ligar_Click;
        public event EventHandler Bt_Reset_Click;
        public event EventHandler Bt_Libera_Click;
        public event EventHandler Bt_Manutencao_Click;
        public event EventHandler Bt_Manual_Click;
        public event EventHandler Bt_Fechar_Click;


        public controleInversor()
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

        public string velocidadeAtual_GS
        {
            get => lbVelocidadeAtual.Content.ToString();

            set
            {
                lbVelocidadeAtual.Dispatcher.Invoke(delegate { lbVelocidadeAtual.Content = value; });
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

        public string codigoFalha_GS
        {
            get => lbCodigoFalha.Content.ToString();

            set
            {
                lbCodigoFalha.Dispatcher.Invoke(delegate { lbCodigoFalha.Content = value; });
            }
        }

        public string codigoAlarme_GS
        {
            get => lbCodigoAlarme.Content.ToString();

            set
            {
                lbCodigoAlarme.Dispatcher.Invoke(delegate { lbCodigoAlarme.Content = value; });
            }
        }
        #endregion

        #region Keypad + Atualizar posição solicitada.

        private void tbPosicaoSolicitada_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            keypad mainWindow = new keypad(this, true, 2);
            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                int oldValue = Convert.ToInt16(tbVelocidadeSolicitada.Text);
                //Recebe o novo valor digitado no Keypad
                int newValue = Convert.ToInt16(mainWindow.Result);


                //Verifica se o novo valor é diferente do valor anterior para que atualize a váriavel no CLP
                if (oldValue != newValue)
                {
                    //Verifica se o novo valor é menor que 100
                    if (newValue <= 100)
                    {
                        tbVelocidadeSolicitada.Text = Convert.ToString(newValue);
                    }
                    else
                    {
                        //Envia o oldValue pois o valor máximo ultrapassou o limite.
                        tbVelocidadeSolicitada.Text = Convert.ToString(oldValue);
                    }


                    //Retira o foco do textbox.
                    Keyboard.ClearFocus();

                    //Dispara o evento de atualizar a váriavel no CLP.
                    if (this.atualizarVelocidade != null)
                        this.atualizarVelocidade(this, e);

                }

            }
        }

        private void btAumenta_Click(object sender, RoutedEventArgs e)
        {
            //Recebe o valor.
            int newValue = Convert.ToInt16(tbVelocidadeSolicitada.Text);

            //Verifica se o valor está menor que o permitido
            if (newValue <= 100)
            {
                //Acresenta o valor solicitado com +5
                newValue = newValue + 5;

                //Verifica se o novo valor é maior que o permitido.
                if (newValue > 100)
                {
                    //Envia o valor máximo.
                    newValue = 100;
                }
            }
            else
            {

                newValue = 100;
            }

            tbVelocidadeSolicitada.Text = Convert.ToString(newValue);

            //Dispara o evento de atualizar a váriavel no CLP.
            if (this.atualizarVelocidade != null)
                this.atualizarVelocidade(this, e);

        }

        private void btDiminui_Click(object sender, RoutedEventArgs e)
        {
            //Recebe o valor.
            int newValue = Convert.ToInt16(tbVelocidadeSolicitada.Text);

            //Verifica se o valor esta permitido
            if (newValue >= 0)
            {
                //Diminui o valor solicitado com -5
                newValue = newValue - 5;

                //Verifica se o novo valor é maior que o permitido.
                if (newValue < 0)
                {
                    //Envia o valor minimo.
                    newValue = 0;
                }
            }
            else
            {

                newValue = 0;
            }

            tbVelocidadeSolicitada.Text = Convert.ToString(newValue);

            //Dispara o evento de atualizar a váriavel no CLP.
            if (this.atualizarVelocidade != null)
                this.atualizarVelocidade(this, e);
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
    }
}
