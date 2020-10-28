using _9230A_V00___PI.Utilidades;
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


        #region Dispacher Timers

        DispatcherTimer timer50ms = new DispatcherTimer(); //Roda o CLP

        DispatcherTimer timer1s = new DispatcherTimer(); //Roda ciclos de 1 segundo

        DispatcherTimer timer4h = new DispatcherTimer(); //Roda ciclos de 1 segundo

        DispatcherTimer Clock_TickTack = new DispatcherTimer(); //Roda ciclos de 1 segundo

        #endregion

        public TelaInicial()
        {

            InitializeComponent();

            #region Verifica se existe alguma instãnca do arquivo aberta se existir fecha todos

            string nomeProcesso = Process.GetCurrentProcess().ProcessName;

            // Obtém todos os processos com o nome do atual
            Process[] processes = Process.GetProcessesByName(nomeProcesso);

            // Maior do que 1, porque a instância atual também conta
            if (processes.Length > 1)
            {

                VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = "Supervisório Aberto! Fechando todas as instâncias.";

                Process[] proc1 = Process.GetProcessesByName(nomeProcesso);
                proc1[0].Kill();

                Process proc = Process.GetCurrentProcess();
                proc.Kill();

                return;
            }


            VariaveisGlobais.Load_Connection();

            #endregion

            spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            #region Equipamentos

            VariaveisGlobais.Fluxo.Motor_22.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 0, 0, "Elevador", "22", "22", "11");

            VariaveisGlobais.Fluxo.Motor_23.loadEquip(Utilidades.typeEquip.BF, Utilidades.typeCommand.Atuador_Digital, 20, 0, "Atuador", "23", "49", "0");

            VariaveisGlobais.Fluxo.Motor_26_Silo1.loadEquip(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Analogico, 24, 0, "Atuador", "26 Silo 1", "62", "10");

            VariaveisGlobais.Fluxo.Motor_26_Silo2.loadEquip(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Analogico, 40, 0, "Atuador", "26 Silo 2", "62", "10");

            VariaveisGlobais.Fluxo.Motor_29.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 56, 0, "Rosca", "29", "29", "12");

            VariaveisGlobais.Fluxo.Motor_30.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 76, 0, "Rosca", "30", "30", "12");

            VariaveisGlobais.Fluxo.Motor_42.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 96, 0, "Rosca", "42", "42", "12");

            VariaveisGlobais.Fluxo.Motor_43.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 116, 0, "Rosca", "43", "43", "12");

            VariaveisGlobais.Fluxo.Motor_44.loadEquip(Utilidades.typeEquip.SS, Utilidades.typeCommand.SS, 168, 0, "Moinho", "44", "44", "0");

            VariaveisGlobais.Fluxo.Motor_45.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 204, 0, "Rosca", "45", "45", "0");

            VariaveisGlobais.Fluxo.Motor_46.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 224, 0, "Rosca", "46", "46", "0");

            VariaveisGlobais.Fluxo.Motor_48.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 244, 0, "Rosca", "48", "48", "0");

            VariaveisGlobais.Fluxo.Motor_49.loadEquip(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Analogico, 264, 0, "Atuador", "49", "49", "0");

            VariaveisGlobais.Fluxo.Motor_62.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 280, 0, "Elevador", "62", "62", "10");

            VariaveisGlobais.Fluxo.Motor_65.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 332, 0, "Rosca", "65", "65", "10");

            #endregion

            #region Configuração Buffers PLC

            Utilidades.VariaveisGlobais.Buffer_PLC[0].Name = "DB Controle Todos Equipamentos";
            Utilidades.VariaveisGlobais.Buffer_PLC[0].DBNumber = 2;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Size = 414;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Write = false;

            Utilidades.VariaveisGlobais.Buffer_PLC[1].Name = "DB Produção Automática";
            Utilidades.VariaveisGlobais.Buffer_PLC[1].DBNumber = 15;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Size = 282;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Enable_Write = false;

            Utilidades.VariaveisGlobais.Buffer_PLC[2].Name = "DB Produção Ensaque";
            Utilidades.VariaveisGlobais.Buffer_PLC[2].DBNumber = 25;
            Utilidades.VariaveisGlobais.Buffer_PLC[2].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[2].Size = 16;
            Utilidades.VariaveisGlobais.Buffer_PLC[2].Enable_Read = false;
            Utilidades.VariaveisGlobais.Buffer_PLC[2].Enable_Write = false;

            Utilidades.VariaveisGlobais.Buffer_PLC[3].Name = "DB Auxiliares";
            Utilidades.VariaveisGlobais.Buffer_PLC[3].DBNumber = 22;
            Utilidades.VariaveisGlobais.Buffer_PLC[3].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[3].Size = 32;
            Utilidades.VariaveisGlobais.Buffer_PLC[3].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[3].Enable_Write = false;

            Utilidades.VariaveisGlobais.Buffer_PLC[4].Name = "DB Configuracoes Auxiliares Processo";
            Utilidades.VariaveisGlobais.Buffer_PLC[4].DBNumber = 23;
            Utilidades.VariaveisGlobais.Buffer_PLC[4].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[4].Size = 102;
            Utilidades.VariaveisGlobais.Buffer_PLC[4].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[4].Enable_Write = false;


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
            //====================================================
            timer1s.Interval = TimeSpan.FromSeconds(1);
            timer1s.Tick += timer1s_Tick;
            timer1s.Start();
            //====================================================
            timer4h.Interval = TimeSpan.FromHours(4);
            timer4h.Tick += timer4h_Tick;
            timer4h.Start();
            //====================================================
            Clock_TickTack.Interval = TimeSpan.FromSeconds(1);
            Clock_TickTack.Tick += timerTickTack;
            Clock_TickTack.Start();

            #endregion

            AtualizaButton(pckHome);

            Utilidades.functions.atualizalistReceitas();

            VariaveisGlobais.producao.IniciouProducao += Producao_IniciouProducao;

            VariaveisGlobais.Fluxo.inicialProducao.BtSlot1_Click += InicialProducao_Bt1_Click;
            VariaveisGlobais.Fluxo.inicialProducao.BtSlot2_Click += InicialProducao_Bt2_Click;
            VariaveisGlobais.Fluxo.inicialProducao.BtSlot3_Click += InicialProducao_Bt3_Click;

            VariaveisGlobais.Fluxo.ensque_Click += Fluxo_ensque_Click;

            VariaveisGlobais.Fluxo.indicadorPesagem.abreTela += IndicadorPesagem_abreTela;

            VariaveisGlobais.telabalanca.Closing += Telabalanca_Closing;

            Utilidades.VariaveisGlobais.Window_Diagnostic.Closing += Window_Diagnostic_Closing;

            //Verifica qual Produção esta em execução e carrega a produção
            DataBase.SQLFunctionsProducao.AtualizaProducaoEmExecucao();

            VariaveisGlobais.windowFirstLoading.Close();

        }

        private void Window_Diagnostic_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Utilidades.VariaveisGlobais.Window_Diagnostic.Hide();
        }

        private void Producao_IniciouProducao(object sender, EventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

                AtualizaButton(pckHome);
            }
        }

        private void Telabalanca_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            VariaveisGlobais.telabalanca.Hide();
        }

        private void IndicadorPesagem_abreTela(object sender, EventArgs e)
        {

            VariaveisGlobais.telabalanca.atualizaTela();
            VariaveisGlobais.telabalanca.ShowDialog();
        }


        #region Timer Ticks

        private void timer4h_Tick(object sender, EventArgs e)
        {
            DataBase.SqlGlobalFuctions.AutoDelete(6);
        }

        private void timerTickTack(object sender, EventArgs e)
        {
            if (Utilidades.VariaveisGlobais.TickTack_GS)
            {
                Utilidades.VariaveisGlobais.TickTack_GS = false;
            }
            else
            {
                Utilidades.VariaveisGlobais.TickTack_GS = true;
            }
        }

        private void timer1s_Tick(object sender, EventArgs e)
        {
            //Chama a atulização da Manutenção
            VariaveisGlobais.manutencao.atualizaManutencao();

            VariaveisGlobais.configuracoes.atualizaValoresConfiguracoes();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                VariaveisGlobais.CommunicationPLC.readBuffersPLC(); //Chama a leitura no PLC

                if (Utilidades.VariaveisGlobais.Buffer_PLC[1].Enable_Read)
                {
                    if (VariaveisGlobais.Libera_Escrita_Slot)
                    {
                        VariaveisGlobais.Libera_Escrita_Slot = false;
                    }
                }

                lbAno.Content = DateTime.Now.Year;
                lbDiaMes.Content = DateTime.Now.Day + "/" + DateTime.Now.Month;
                lbHorario.Content = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

                LB_No_Connection.Dispatcher.Invoke(delegate { LB_No_Connection.Visibility = Visibility.Hidden; });
                REC_No_Connection.Dispatcher.Invoke(delegate { REC_No_Connection.Visibility = Visibility.Hidden; });

                if (Utilidades.VariaveisGlobais.CommunicationPLC.ConnectionStatus_GS == 1 || VariaveisGlobais.manutencao.TelaManutencaoAtiva_Get)
                {
                    LB_PLC_STOP.Dispatcher.Invoke(delegate { LB_PLC_STOP.Visibility = Visibility.Hidden; });
                    REC_PLC_STOP.Dispatcher.Invoke(delegate { REC_PLC_STOP.Visibility = Visibility.Hidden; });
                }
                else if (Utilidades.VariaveisGlobais.CommunicationPLC.ConnectionStatus_GS == 0)
                {
                    LB_PLC_STOP.Dispatcher.Invoke(delegate { LB_PLC_STOP.Visibility = Visibility.Visible; });
                    REC_PLC_STOP.Dispatcher.Invoke(delegate { REC_PLC_STOP.Visibility = Visibility.Visible; });
                }


                if (!Utilidades.VariaveisGlobais.CommunicationPLC.PLCConnected_GS && !VariaveisGlobais.manutencao.TelaManutencaoAtiva_Get)
                {
                    LB_No_Connection.Dispatcher.Invoke(delegate { LB_No_Connection.Visibility = Visibility.Visible; });
                    REC_No_Connection.Dispatcher.Invoke(delegate { REC_No_Connection.Visibility = Visibility.Visible; });

                    LB_PLC_STOP.Dispatcher.Invoke(delegate { LB_PLC_STOP.Visibility = Visibility.Hidden; });
                    REC_PLC_STOP.Dispatcher.Invoke(delegate { REC_PLC_STOP.Visibility = Visibility.Hidden; });
                }
                else
                {
                    LB_No_Connection.Dispatcher.Invoke(delegate { LB_No_Connection.Visibility = Visibility.Hidden; });
                    REC_No_Connection.Dispatcher.Invoke(delegate { REC_No_Connection.Visibility = Visibility.Hidden; });

                }


                //Verifica se esta lendo valor válido do CLP
                if (Comunicacao.Sharp7.S7.GetIntAt(Utilidades.VariaveisGlobais.Buffer_PLC[0].Buffer, Utilidades.VariaveisGlobais.Buffer_PLC[0].Size - 2) == 1000)
                {
                             
                    //Atualiza Niveis Silos
                    Utilidades.VariaveisGlobais.niveis = Move_Bits.Dword_TO_NIveis(Comunicacao.Sharp7.S7.GetDWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[3].Buffer, 0), Utilidades.VariaveisGlobais.niveis);

                    //Atualiza Dword Geral de auxiliares Processo.
                    Utilidades.VariaveisGlobais.auxiliaresProcesso = Move_Bits.DwordTocontroleAuxiliaresProcesso(Comunicacao.Sharp7.S7.GetDWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[4].Buffer, 56), Utilidades.VariaveisGlobais.auxiliaresProcesso);


                    VariaveisGlobais.telabalanca.atualiza_Balanca();

                    //Atualização Equip
                    VariaveisGlobais.Fluxo.Motor_22.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_29.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_30.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_42.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_43.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_44.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_45.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_46.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_48.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_49.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_62.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_65.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_26_Silo1.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_26_Silo2.actualize_Equip = true;
                    VariaveisGlobais.Fluxo.Motor_23.actualize_Equip = true;

                    VariaveisGlobais.Fluxo.actualiza_UI();

                    //Atualiza a variavel Id da produção que esta no silo da expedição
                    //O valor que esta no PLC é atualizado conforme abaixo:
                    //Se tem produção é atualizado com a produção atual se tiver nível na chamada do VariaveisGlobais.executaProducao.Produzir = true;
                    //Se não tem produção, é verificado se tem nível no silo de expedição
                    //se tiver nível, verifica se a produção é <=0 se for pega a ultima produção
                    //se não tiver nível coloca 0 no Id da produção.
                    VariaveisGlobais.Id_Producao_No_Silo_Expedicao = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[1].Buffer, 278);

                    //Atualiza Execução Produção
                    AtualizaExecucaoProducao();

                    //Atualiza execução do ensaque
                    VariaveisGlobais.producao.atualizaTelaEnsaque();

                }

                VariaveisGlobais.CommunicationPLC.writeBufferPLC();//Chama a escrita no PLC
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region Click Ensaque e Bateladas

        private void Fluxo_ensque_Click(object sender, EventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

            }

            spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

            if (Utilidades.VariaveisGlobais.producao.spControleProducao.Children != null)
            {
                Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Clear();
            }

            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaEnsaque);

            AtualizaButton(pckProducao);
        }

        private void InicialProducao_Bt1_Click(object sender, EventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

            }
            spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

            if (Utilidades.VariaveisGlobais.producao.spControleProducao.Children != null)
            {
                Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Clear();
            }

            Utilidades.VariaveisGlobais.producao.TelaControleProducao.SlotSolicitado = 1;
            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaControleProducao);

            AtualizaButton(pckProducao);
        }

        private void InicialProducao_Bt2_Click(object sender, EventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

            }
            spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

            if (Utilidades.VariaveisGlobais.producao.spControleProducao.Children != null)
            {
                Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Clear();
            }

            Utilidades.VariaveisGlobais.producao.TelaControleProducao.SlotSolicitado = 2;
            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaControleProducao);

            AtualizaButton(pckProducao);

        }

        private void InicialProducao_Bt3_Click(object sender, EventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

            }
            spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

            if (Utilidades.VariaveisGlobais.producao.spControleProducao.Children != null)
            {
                Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Clear();
            }
            Utilidades.VariaveisGlobais.producao.TelaControleProducao.SlotSolicitado = 3;
            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaControleProducao);

            AtualizaButton(pckProducao);
        }

        #endregion

        #region Clicks Menu

        Utilidades.messageBox inputDialog;

        #region Login e Logout

        private bool login()
        {
            if (DataBase.SqlFunctionsUsers.ExistTableDBCA(txtUser.Text))
            {
                if (DataBase.SqlFunctionsUsers.CheckPasswordDBCA(txtUser.Text, txtSenha.Password))
                {
                    DataBase.SqlFunctionsUsers.IntoDateDBCA(txtUser.Text, DataBase.SqlFunctionsUsers.MD5Cryptography(txtSenha.Password), DataBase.SqlFunctionsUsers.GetLastValueTableDBCA(txtUser.Text, "GroupUser"), DataBase.SqlFunctionsUsers.GetLastValueTableDBCA(txtUser.Text, "Email"), "Entrou");

                    VariaveisGlobais.UserLogged_GS = txtUser.Text;
                    VariaveisGlobais.GroupUserLogged_GS = DataBase.SqlFunctionsUsers.GetLastValueTableDBCA(txtUser.Text, "GroupUser");
                    VariaveisGlobais.PasswordLogged_GS = txtSenha.Password;



                    if (VariaveisGlobais.GroupUserLogged_GS.Equals("Operador"))
                    {
                        VariaveisGlobais.NumberOfGroup_GS = 1;
                    }
                    else if (VariaveisGlobais.GroupUserLogged_GS.Equals("Manutenção"))
                    {
                        VariaveisGlobais.NumberOfGroup_GS = 2;
                    }
                    else if (VariaveisGlobais.GroupUserLogged_GS.Equals("Administrador"))
                    {
                        VariaveisGlobais.NumberOfGroup_GS = 3;
                    }


                    txtUser.IsEnabled = false;
                    txtSenha.Password = "";
                    txtSenha.IsEnabled = false;


                    iconLogin.Kind = MaterialDesignThemes.Wpf.PackIconKind.Logout;
                    iconLogin.Foreground = new SolidColorBrush(Colors.Red);

                    return true;

                }
                else
                {
                    Utilidades.messageBox inputDialog = new messageBox("Senha Incorreta", "Senha incorreta, por favor verifique e tente novamente", MaterialDesignThemes.Wpf.PackIconKind.Error,"OK","Fechar");

                    inputDialog.ShowDialog();

                    return false;

                }
            }
            else
            {

                Utilidades.messageBox inputDialog = new messageBox("Usuário não Cadastrado", "Usuário não cadastrado, por favor verifique e tente novamente", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();

                return false;
          
            
            }
        }

        private void logout() 
        {
            DataBase.SqlFunctionsUsers.IntoDateDBCA(VariaveisGlobais.UserLogged_GS,DataBase.SqlFunctionsUsers.GetLastValueTableDBCA(VariaveisGlobais.UserLogged_GS, "Password"), DataBase.SqlFunctionsUsers.GetLastValueTableDBCA(VariaveisGlobais.UserLogged_GS, "GroupUser"), DataBase.SqlFunctionsUsers.GetLastValueTableDBCA(VariaveisGlobais.UserLogged_GS, "Email"), "Saiu");

            txtUser.IsEnabled = true;
            txtSenha.IsEnabled = true;

            txtUser.Text = "";
            VariaveisGlobais.UserLogged_GS = "";
            VariaveisGlobais.GroupUserLogged_GS = "";
            VariaveisGlobais.PasswordLogged_GS = "";
            VariaveisGlobais.NumberOfGroup_GS = 0;

            iconLogin.Kind = MaterialDesignThemes.Wpf.PackIconKind.Login;
            iconLogin.Foreground = new SolidColorBrush(Colors.White);

        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if (iconLogin.Kind == MaterialDesignThemes.Wpf.PackIconKind.Login)
            {
                login();
            }
            else
            {
                logout();

                spInical.Children.Clear();

                AtualizaButton(pckHome);

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            }
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
                {
                    Teclados.keyboard.openKeyboard();
                }
            }
            catch (Exception ex)
            {
                Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();
            }
        }

        private void txtSenha_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();
            if (e.Key == Key.Enter || e.Key == Key.DeadCharProcessed)
            {
                login();
                btLogin.Focus();
            }
        }
        #endregion

        #region Click Menu
        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);


                AtualizaButton(pckHome);

            }
        }

        private void btProducao_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaUsuarioTitle, Utilidades.VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();

                return;
            }

            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.producao);
                AtualizaButton(pckProducao);

            }

            if (Utilidades.VariaveisGlobais.producao.spControleProducao.Children != null)
            {
                Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Clear();
            }

        }

        private void btReceitas_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaUsuarioTitle, Utilidades.VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();


                return;
            }

            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.receitas);

                AtualizaButton(pckReceitas);

            }
         
        }

        private void btConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaUsuarioTitle, Utilidades.VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();

                return;
            }


            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.configuracoes);

                AtualizaButton(pckConfiguracoes);

            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {

            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaUsuarioTitle, Utilidades.VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();

                return;
            }

            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.relatorios);

                AtualizaButton(pckRelatorio);

            }
        }

        private void btConfiguracoesUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                inputDialog = new Utilidades.messageBox(VariaveisGlobais.faltaUsuarioTitle, VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");
                inputDialog.ShowDialog();
            }
            else
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.controleUsuario);

                Utilidades.VariaveisGlobais.controleUsuario.spControleUsuario.Children.Clear();

                AtualizaButton(pckUser);


            }
        }

        private void btManutencao_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaUsuarioTitle, Utilidades.VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();

                return;
            }

            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.manutencao);

                AtualizaButton(pckManutencao);

            }
        }

        #endregion

        #endregion

        #region Funções

        private void AtualizaExecucaoProducao()
        {
            //Atualiza Execução Produção
            if (VariaveisGlobais.ProducaoReceita.IniciouProducao && !VariaveisGlobais.ProducaoReceita.FinalizouProducao)
            {
                VariaveisGlobais.executaProducao.Produzir = true;
                VariaveisGlobais.producao.atualizaTelaEmProducao();
            }
            else
            {
                //Se não tem produção verifica se não tem nivel no silo de expedição
                //Se não tem nível verifica se o ID da produção que tinha no silo é diferente de zero, se for zera.
                if (!VariaveisGlobais.niveis.Inferior_Silo_Exp)
                {
                    if (VariaveisGlobais.Id_Producao_No_Silo_Expedicao != 0)
                    {
                        VariaveisGlobais.Buffer_PLC[1].Enable_Read = false;

                        //Seta zero
                        Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[1].Buffer, 278, 0);
                        VariaveisGlobais.NomeReceita_No_Silo_Expedicao = "Sem Ração no Silo Exp.";

                        VariaveisGlobais.Buffer_PLC[1].Enable_Write = true;
                    }
                }
                //Caso tenha finalizado a expedição, e ainda tem nível o ID da produção será a ultima produção
                else
                {
                    if (VariaveisGlobais.Id_Producao_No_Silo_Expedicao <= 0 || VariaveisGlobais.NomeReceita_No_Silo_Expedicao.Equals(""))
                    {
                        VariaveisGlobais.Buffer_PLC[1].Enable_Read = false;

                        Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[1].Buffer, 278, DataBase.SQLFunctionsProducao.getLast_ID_Producao());

                        VariaveisGlobais.NomeReceita_No_Silo_Expedicao = DataBase.SqlFunctionsReceitas.getNomeReceitaFromId(DataBase.SQLFunctionsProducao.getID_Receita_Base_From_Id_Producao(DataBase.SQLFunctionsProducao.getLast_ID_Producao()));

                        VariaveisGlobais.Buffer_PLC[1].Enable_Write = true;

                    }

                }
            }
        }

        public void AtualizaButton(MaterialDesignThemes.Wpf.PackIcon packIcon)
        {
            if (packIcon.Name == pckManutencao.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Verde;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;
            }
            else if (packIcon.Name == pckConfiguracoes.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Verde;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;
            }
            else if (packIcon.Name == pckHome.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Verde;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;
            }
            else if (packIcon.Name == pckProducao.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Verde;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;
            }
            else if (packIcon.Name == pckReceitas.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Verde;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;
            }
            else if (packIcon.Name == pckRelatorio.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Verde;
                pckUser.Foreground = VariaveisGlobais.Branco;
            }
            else if (packIcon.Name == pckUser.Name)
            {
                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Verde;
            }
        }


        #endregion


    }
}
