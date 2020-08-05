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

        //Cria comunicação com CLP
        Comunicacao.CallCommunicationPLC CommunicationPLC = new Comunicacao.CallCommunicationPLC(0, 10);

        #endregion

        #region Dispacher Timers

        DispatcherTimer timer50ms = new DispatcherTimer();

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
            InitializeComponent();

            VariaveisGlobais.Load_Connection();

            spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            #region Equipamentos

            //Atribuição dos valores para cada equipamento
            //Motor_22.Command_GS.Name = "EXAUSTORES SECADOR";
            //Motor_22.Tag = "EX1-2-3-4SC";

            //Motor_22.TempoCompensadora = true;

            //Motor_22.HabilitaBloqueioExterno = true;

            //Atualiza informações de cada motor

            //Motor_22.initialOffSet = 0;
            //Motor_22.bufferPlc = 0;

            VariaveisGlobais.Fluxo.Motor_22.loadEquip(Utilidades.typeEquip.PD, Utilidades.typeCommand.PD, 0, 0, "Elevador Autolimpante", "22", "22", "11");
            VariaveisGlobais.Fluxo.Motor_62.loadEquip(Utilidades.typeEquip.INV, Utilidades.typeCommand.INV, 264, 0, "Elevador Expedição", "61", "61", "10");

            #endregion

            #region Configuração Buffers PLC

            Utilidades.VariaveisGlobais.Buffer_PLC[0].Name = "DB Controle Todos Equipamentos";
            Utilidades.VariaveisGlobais.Buffer_PLC[0].DBNumber = 2;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Start = 0;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Size = 368;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Read = true;
            Utilidades.VariaveisGlobais.Buffer_PLC[0].Enable_Write = false;

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

            #endregion
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lbAno.Content = DateTime.Now.Year;
            lbDiaMes.Content = DateTime.Now.Day + "/" + DateTime.Now.Month;
            lbHorario.Content = DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond;

            CommunicationPLC.readBuffersPLC(); //Chama a leitura no PLC


            //Atualização Equip
            VariaveisGlobais.Fluxo.Motor_22.actualize_Equip = true;
            VariaveisGlobais.Fluxo.Motor_62.actualize_Equip = true;


            CommunicationPLC.writeBufferPLC();//Chama a escrita no PLC

        }



































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































        //-----------------------------------------------------------------------
        //Emanuel
        #region Clicks Menu

        //private void btSair_Click(object sender, RoutedEventArgs e)
        //{
        //    App.Current.Shutdown();
        //    Process proc = Process.GetCurrentProcess();
        //    proc.Kill();

        //}

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
                    Utilidades.messageBox inputDialog = new messageBox("Senha Incorreta", "Senha incorreta, por favor verifique e tente novamente", MaterialDesignThemes.Wpf.PackIconKind.Error,"OK","Fchar");

                    inputDialog.ShowDialog();

                    return false;

                }
            }
            else
            {

                Utilidades.messageBox inputDialog = new messageBox("Usuário não Cadastrado", "Usuário não cadastrado, por favor verifique e tente novamente", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fchar");

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
            }
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.Fluxo);

            }
        }

        private void btProducao_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.producao);

            }
        }

        private void btReceitas_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.receitas);

            }
        }

        private void btConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.configuracoes);

            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.relatorios);

            }
        }

        private void btAlarmes_Click(object sender, RoutedEventArgs e)
        {
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.alarmes);

            }
        }

        private void txtUser_LostFocus(object sender, RoutedEventArgs e)
        {
            Process[] tabtip = Process.GetProcessesByName("TabTip");

            if (null != tabtip)
            {
                tabtip.ToList().ForEach(a => { if (null != a) { a.Kill(); } });

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
            if (spInical != null)
            {
                spInical.Children.Clear();

                spInical.Children.Add(Utilidades.VariaveisGlobais.controleUsuario);
            }
        }

        private void txtSenha_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();
            if (e.Key == Key.Enter || e.Key == Key.DeadCharProcessed)
            {
                login();
                spInical.Focus();
            }
        }
    }
}
