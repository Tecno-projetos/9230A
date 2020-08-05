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

        public controleSoftStarter(string nome, string tag, string numeroPartida, string paginaProjeto)
        {
            InitializeComponent();
            lbName.Content = nome;
            this.Title = nome + " " + tag;
        }

        public string CorrenteMotorVazio
        {
            set
            {
                tbCorrenteVazio.Dispatcher.Invoke(delegate { tbCorrenteVazio.Text = value; });
                
            }
            get
            {
                return tbCorrenteVazio.Text;
            }
        }

        public string SP_TempoReversao
        {
            set
            {
                tbReversao.Dispatcher.Invoke(delegate { tbReversao.Text = value; });

            }
            get
            {
                return tbReversao.Text;
            }
        }

        public void actualize_UI(Utilidades.VariaveisGlobais.type_All Command)
        {
            //Habilita ou desabilita botões
            if (!Command.Standard.Emergencia || Command.Standard.Falha_Geral)
            {
                btReset.Dispatcher.Invoke(delegate { btReset.IsEnabled = false; });

                btManual.Dispatcher.Invoke(delegate { btManual.IsEnabled = false; });

                btManutencao.Dispatcher.Invoke(delegate { btManutencao.IsEnabled = false; });

                btLibera.Dispatcher.Invoke(delegate { btLibera.IsEnabled = false; });

                btLigar.Dispatcher.Invoke(delegate { btLigar.IsEnabled = false; });

                btInverte.Dispatcher.Invoke(delegate { btInverte.IsEnabled = false; });

                

            }
            else
            {
                btReset.Dispatcher.Invoke(delegate { btReset.IsEnabled = true; });

                btManual.Dispatcher.Invoke(delegate { btManual.IsEnabled = true; });

                btManutencao.Dispatcher.Invoke(delegate { btManutencao.IsEnabled = true; });

                btLibera.Dispatcher.Invoke(delegate { btLibera.IsEnabled = true; });

                btLigar.Dispatcher.Invoke(delegate { btLigar.IsEnabled = true; });

                btInverte.Dispatcher.Invoke(delegate { btInverte.IsEnabled = true; });
            }

            //Atualiza status dos botões2

            if (Command.Standard.Liga_Manual)
            {
                btLigar.Dispatcher.Invoke(delegate { btLigar.IsChecked = true; });
            }
            else
            {
                btLigar.Dispatcher.Invoke(delegate { btLigar.IsChecked = false; });
            }

            if (Command.Standard.Manual)
            {
                btManual.Dispatcher.Invoke(delegate { btManual.Content = "M"; });
                lbManual.Dispatcher.Invoke(delegate { lbManual.Text = "Em Modo Manual"; });


            }

            if (Command.Standard.Automatico)
            {
                btManual.Dispatcher.Invoke(delegate { btManual.Content = "A"; });
                lbManual.Dispatcher.Invoke(delegate { lbManual.Text = "Em Modo Automático"; });
            }

            if (Command.Standard.Manutencao)
            {
                btManutencao.Dispatcher.Invoke(delegate { btManutencao.IsChecked = true; });
            }
            else
            {
                btManutencao.Dispatcher.Invoke(delegate { btManutencao.IsChecked = false; });
            }

            if (Command.Standard.Libera_Bloqueio)
            {
                iconLibera.Dispatcher.Invoke(delegate { iconLibera.Kind = MaterialDesignThemes.Wpf.PackIconKind.LockOpen; });
                textLibera.Dispatcher.Invoke(delegate { textLibera.Text = "Bloquear Liberada"; });
                btLibera.Dispatcher.Invoke(delegate { btLibera.Background = new SolidColorBrush(Colors.Green); });
            }
            else
            {
                iconLibera.Dispatcher.Invoke(delegate { iconLibera.Kind = MaterialDesignThemes.Wpf.PackIconKind.Lock; });
                textLibera.Dispatcher.Invoke(delegate { textLibera.Text = "Liberar Cascata"; });
                btLibera.Dispatcher.Invoke(delegate { btLibera.Background = new SolidColorBrush(Colors.Yellow); });
            }

            //Status Motor
            if (!Command.Standard.Emergencia)
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Em Emergência"; });
            }
            else if (Command.Standard.Falha_Geral)
            {
                if (Command.Standard.Falha_Partida_Nao_Confirmou)
                {
                    lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Falha Confirmação"; });
                }
                else if (Command.Standard.Falha_Contator_Desligou)
                {
                    lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Falha Partida Não Desligou"; });
                }
                else if (Command.Standard.Falha_Disjuntor_Desligou)
                {
                    lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Falha Partida Desligou"; });
                }
                else if (Command.Standard.Falha_Partida_Nao_Desligou)
                {
                    lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Falha Partida Não Desligou"; });
                }
            }
            else if (Command.Standard.Manutencao)
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Em Manutenção"; });
            }
            else if (Command.Standard.Disjuntor_Desligado)
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Disjuntor Desligado"; });
            }
            else if (Command.Standard.Ligando)
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Ligando"; });
            }
            else if (Command.Standard.Desligando)
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Desligando"; });
            }
            else if (Command.Standard.Ligado)
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Ligado"; });
            }
            else
            {
                lbStatusMotor.Dispatcher.Invoke(delegate { lbStatusMotor.Content = "Desligado"; });
            }

            lbCorrenteAtual.Dispatcher.Invoke(delegate { lbCorrenteAtual.Content = Command.SS.Corrente_Atual + " A"; });
            lbTempoReversao.Dispatcher.Invoke(delegate { lbTempoReversao.Content = "Falta: "+ Command.INV.Codigo_Falha+" min."; });

            if (Command.Standard.SentidoGiro)
            {
                lbSentidoGiro.Dispatcher.Invoke(delegate { lbSentidoGiro.Content = "Sentido Horário"; });
            }
            else
            {
                lbSentidoGiro.Dispatcher.Invoke(delegate { lbSentidoGiro.Content = "Sentido Anti-Horário"; });
            }


        }

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
