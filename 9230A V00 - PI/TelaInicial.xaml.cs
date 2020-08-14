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
        #region Varivaies



        #endregion

        #region Dispacher Timers

        DispatcherTimer timer50ms = new DispatcherTimer(); //Roda o CLP


        DispatcherTimer timer1s = new DispatcherTimer(); //Roda ciclos de 1 segundo
        
        #endregion

        #region Equipamentos

        //Utilidades.EquipsControl Motor_22 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Bifurcada_23 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Atuador_26_Silo_1 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Atuador_26_Silo_2 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_29 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_30 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_42 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_43 = new Utilidades.EquipsControl(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV);
        //Utilidades.EquipsControl Motor_44 = new Utilidades.EquipsControl(Utilidades.typeEquip.SS, Utilidades.typeCommand.SS);
        //Utilidades.EquipsControl Motor_45 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_46 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_48 = new Utilidades.EquipsControl(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD);
        //Utilidades.EquipsControl Motor_49 = new Utilidades.EquipsControl(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Digital);
        //Utilidades.EquipsControl Motor_62 = new Utilidades.EquipsControl(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV);
        //Utilidades.EquipsControl Motor_65 = new Utilidades.EquipsControl(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV);


        #endregion


        public TelaInicial()
        {
            TelasAuxiliares.FirstLoading windowFirstLoading = new TelasAuxiliares.FirstLoading();
            windowFirstLoading.Show();

            InitializeComponent();

            VariaveisGlobais.Load_Connection();

            spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            #region Equipamentos

            VariaveisGlobais.Fluxo.Motor_22.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 0, 0, "Elevador", "22", "22", "11");

            VariaveisGlobais.Fluxo.Motor_23.loadEquip(Utilidades.typeEquip.BF, Utilidades.typeCommand.Atuador_Digital, 20, 0, "Atuador", "20", "49", "0");

            VariaveisGlobais.Fluxo.Motor_29.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 56, 0, "Rosca", "29", "29", "12");

            VariaveisGlobais.Fluxo.Motor_30.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 76, 0, "Rosca", "30", "30", "12");

            VariaveisGlobais.Fluxo.Motor_42.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 96, 0, "Rosca", "42", "42", "12");

            VariaveisGlobais.Fluxo.Motor_43.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 116, 0, "Rosca", "43", "43", "12");

            VariaveisGlobais.Fluxo.Motor_44.loadEquip(Utilidades.typeEquip.SS, Utilidades.typeCommand.SS, 168, 0, "Moinho", "44", "44", "0");

            VariaveisGlobais.Fluxo.Motor_45.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 204, 0, "Rosca", "45", "45", "0");

            VariaveisGlobais.Fluxo.Motor_46.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 224, 0, "Rosca", "46", "46", "0");

            VariaveisGlobais.Fluxo.Motor_48.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 244, 0, "Rosca", "48", "48", "0");

            VariaveisGlobais.Fluxo.Motor_49.loadEquip(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Digital, 264, 0, "Atuador", "49", "49", "0");

            VariaveisGlobais.Fluxo.Motor_62.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 268, 0, "Elevador", "62", "62", "10");

            VariaveisGlobais.Fluxo.Motor_65.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 320, 0, "Rosca", "65", "65", "10");

            VariaveisGlobais.Fluxo.Motor_26_Silo1.loadEquip(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Analogico, 24, 0, "Atuador", "26 Silo 1", "62", "10");

            VariaveisGlobais.Fluxo.Motor_26_Silo2.loadEquip(Utilidades.typeEquip.Atuador, Utilidades.typeCommand.Atuador_Analogico, 40, 0, "Atuador", "26 Silo 2", "62", "10");

            VariaveisGlobais.Fluxo.Motor_65.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 320, 0, "Elevador", "65", "65", "10");



            #endregion

            #region Configuração Buffers PLC

            Utilidades.VariaveisGlobais.Buffer_PLC[0].Name = "DB Controle Todos Equipamentos";
            Utilidades.VariaveisGlobais.Buffer_PLC[0].DBNumber = 2;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Size = 372;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Write = false;

            Utilidades.VariaveisGlobais.Buffer_PLC[1].Name = "DB Produção Automática";
            Utilidades.VariaveisGlobais.Buffer_PLC[1].DBNumber = 15;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Size = 78;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[1].Enable_Write = false;

            for (int i = 0; i < Utilidades.VariaveisGlobais.Buffer_PLC.Length; i++)
            {
                Utilidades.VariaveisGlobais.Buffer_PLC[i].Buffer = new byte[Utilidades.VariaveisGlobais.Buffer_PLC[i].Size];
                Utilidades.VariaveisGlobais.Buffer_PLC[i].Result = 99999;
            }

            #endregion

            #region Configuração Dispatcher

            timer50ms.Interval = TimeSpan.FromMilliseconds(1);
            timer50ms.Tick += timer_Tick;
            timer50ms.Start();
            //====================================================
            timer1s.Interval = TimeSpan.FromSeconds(1);
            timer1s.Tick += timer1s_Tick;
            timer1s.Start();

            #endregion


            pckManutencao.Foreground = VariaveisGlobais.Branco;
            pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
            pckHome.Foreground = VariaveisGlobais.Verde;
            pckProducao.Foreground = VariaveisGlobais.Branco;
            pckReceitas.Foreground = VariaveisGlobais.Branco;
            pckRelatorio.Foreground = VariaveisGlobais.Branco;
            pckUser.Foreground = VariaveisGlobais.Branco;


            windowFirstLoading.Close();

            Utilidades.functions.atualizalistReceitas();


            VariaveisGlobais.Fluxo.inicialProducao.Bt1_Click += InicialProducao_Bt1_Click;
            VariaveisGlobais.Fluxo.inicialProducao.Bt2_Click += InicialProducao_Bt2_Click;
            VariaveisGlobais.Fluxo.inicialProducao.Bt3_Click += InicialProducao_Bt3_Click;
            VariaveisGlobais.Fluxo.ensque_Click += Fluxo_ensque_Click;

            //Verifica qual Produção esta em execução e carrega a produção
            DataBase.SQLFunctionsProducao.AtualizaProducaoEmExecucao();
        }

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

            pckManutencao.Foreground = VariaveisGlobais.Branco;
            pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
            pckHome.Foreground = VariaveisGlobais.Branco;
            pckProducao.Foreground = VariaveisGlobais.Verde;
            pckReceitas.Foreground = VariaveisGlobais.Branco;
            pckRelatorio.Foreground = VariaveisGlobais.Branco;
            pckUser.Foreground = VariaveisGlobais.Branco;
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

            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaControleProducao);

            pckManutencao.Foreground = VariaveisGlobais.Branco;
            pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
            pckHome.Foreground = VariaveisGlobais.Branco;
            pckProducao.Foreground = VariaveisGlobais.Verde;
            pckReceitas.Foreground = VariaveisGlobais.Branco;
            pckRelatorio.Foreground = VariaveisGlobais.Branco;
            pckUser.Foreground = VariaveisGlobais.Branco;
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

            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaControleProducao);

            pckManutencao.Foreground = VariaveisGlobais.Branco;
            pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
            pckHome.Foreground = VariaveisGlobais.Branco;
            pckProducao.Foreground = VariaveisGlobais.Verde;
            pckReceitas.Foreground = VariaveisGlobais.Branco;
            pckRelatorio.Foreground = VariaveisGlobais.Branco;
            pckUser.Foreground = VariaveisGlobais.Branco;

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

            Utilidades.VariaveisGlobais.producao.spControleProducao.Children.Add(Utilidades.VariaveisGlobais.producao.TelaControleProducao);

            pckManutencao.Foreground = VariaveisGlobais.Branco;
            pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
            pckHome.Foreground = VariaveisGlobais.Branco;
            pckProducao.Foreground = VariaveisGlobais.Verde;
            pckReceitas.Foreground = VariaveisGlobais.Branco;
            pckRelatorio.Foreground = VariaveisGlobais.Branco;
            pckUser.Foreground = VariaveisGlobais.Branco;
        }

        private void timer1s_Tick(object sender, EventArgs e)
        {
            //Chama a atulização da Manutenção
            VariaveisGlobais.manutencao.atualizaManutencao();

            VariaveisGlobais.Fluxo.actualiza_UI();





        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                lbAno.Content = DateTime.Now.Year;
                lbDiaMes.Content = DateTime.Now.Day + "/" + DateTime.Now.Month;
                lbHorario.Content = DateTime.Now.ToLongTimeString();

                VariaveisGlobais.CommunicationPLC.readBuffersPLC(); //Chama a leitura no PLC


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
                //VariaveisGlobais.Fluxo.Motor_26_Silo1.actualize_Equip = true;
                //VariaveisGlobais.Fluxo.Motor_26_Silo2.actualize_Equip = true;
                VariaveisGlobais.Fluxo.Motor_23.actualize_Equip = true;

                //Atualiza Execução Produção
                if (VariaveisGlobais.ProducaoReceita.IniciouProducao && !VariaveisGlobais.ProducaoReceita.FinalizouProducao)
                {
                    VariaveisGlobais.executaProducao.Produzir = true;
                }

                VariaveisGlobais.CommunicationPLC.writeBufferPLC();//Chama a escrita no PLC
            }
            catch (Exception ex)
            {

                throw;
            }



        }
        //-----------------------------------------------------------------------
        //Emanuel
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

        }

        #endregion



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

                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Verde;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);



            }
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);


                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground  = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Verde;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;




            }



        }

        private void btProducao_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Verde;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;

            }
        }

        private void btReceitas_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.receitas);

                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Verde;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;

            }
        }

        private void btConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.configuracoes);

                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Verde;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;

            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.relatorios);

                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Verde;
                pckUser.Foreground = VariaveisGlobais.Branco;

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

        #endregion

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

                pckManutencao.Foreground = VariaveisGlobais.Branco;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Verde;


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

        private void btManutencao_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.manutencao);

                pckManutencao.Foreground = VariaveisGlobais.Verde;
                pckConfiguracoes.Foreground = VariaveisGlobais.Branco;
                pckHome.Foreground = VariaveisGlobais.Branco;
                pckProducao.Foreground = VariaveisGlobais.Branco;
                pckReceitas.Foreground = VariaveisGlobais.Branco;
                pckRelatorio.Foreground = VariaveisGlobais.Branco;
                pckUser.Foreground = VariaveisGlobais.Branco;


            }
        }
    }
}
