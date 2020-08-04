using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace _9230A_V00___PI.Utilidades
{
    public class EquipsControl
    {

        #region Variables 

        Partidas.controlePartidaDireta Window_PD;
        Partidas.controleInversor Window_INV;
        Partidas.controleSoftStarter Window_SS;
        Partidas.controleAtuadorAnalogico Window_Atuador_Analogico;
        Partidas.controleAtuadorLinear Window_Atuador_Digital;
        Partidas.controleAtuadorLinearBifurcada Window_BF;

        SolidColorBrush Verde = new SolidColorBrush(Color.FromRgb(0, 140, 0));
        SolidColorBrush Laranja = new SolidColorBrush(Color.FromRgb(250, 150, 0));
        SolidColorBrush Cinza = new SolidColorBrush(Color.FromRgb(150, 150, 150));

        //Palavra de comando geral
        Utilidades.VariaveisGlobais.type_All Command = new Utilidades.VariaveisGlobais.type_All();

        
        #endregion

        public EquipsControl(typeEquip Equip, typeCommand TCommand, int initialOffSet, int bufferPlc)
        {
            Command.initialOffSet = initialOffSet;
            Command.bufferPlc = bufferPlc;
            Command.TypeEquip = Equip;
            Command.TypeCommand = TCommand;

            //==========================================================================================
            //Inicia a tela dependendo o tipo de motor.

            //PD
            if (Equip == typeEquip.PD)
            {
                Window_PD = new Partidas.controlePartidaDireta();

                Window_PD.Closing += Window_PD_Closing;

               //Click para controle da Partida 
               Window_PD.Bt_Ligar_Click += new EventHandler(Bt_Ligar_Click);
               Window_PD.Bt_Reset_Click += new EventHandler(Bt_Reset_Click);
               Window_PD.Bt_Libera_Click += new EventHandler(Bt_Libera_Click);
               Window_PD.Bt_Manutencao_Click += new EventHandler(Bt_Manutencao_Click);
               Window_PD.Bt_Manual_Click += new EventHandler(Bt_Manual_Click);
               Window_PD.Bt_Fechar_Click += new EventHandler(Bt_Fechar_Click);
            }
            //INV
            else if (Equip == typeEquip.INV)
            {


            }
            //SS
            else if (Equip == typeEquip.SS)
            {


            }
            //Atuador
            else if (Equip == typeEquip.Atuador)
            {


            }
            //BF
            else if (Equip == typeEquip.BF)
            {


            }

        }


        #region Events Window

        private void Window_PD_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Window_PD.Hide();
        }

        private void Window_INV_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            Window_INV.Hide();
        }

        private void Window_BF_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Window_BF.Hide();
        }


        #endregion

        #region Events Screens

        //PD
        protected void Bt_Ligar_Click(object sender, EventArgs e)
        {
            if (Command.Standard.Liga_Manual)
            {
                Command.Standard.Liga_Manual = false;
            }
            else
            {
                Command.Standard.Liga_Manual = true;
            }

            if (Command.Standard.Liga_Manual)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ligar", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Desligar", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        protected void Bt_Reset_Click(object sender, EventArgs e)
        {
            if (Command.Standard.Reset)
            {
                Command.Standard.Reset = false;
            }
            else
            {
                Command.Standard.Reset = true;
            }

            if (Command.Standard.Reset)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Reset Falha", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }

        }

        protected void Bt_Libera_Click(object sender, EventArgs e)
        {
            if (Command.Standard.Libera_Bloqueio)
            {
                Command.Standard.Libera_Bloqueio = false;
            }
            else
            {
                Command.Standard.Libera_Bloqueio = true;
            }

            if (Command.Standard.Libera_Bloqueio)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Libera Bloqueio", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        protected void Bt_Manutencao_Click(object sender, EventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS < 2)
            {
                TopMost.TopMostMessageBox.Show(Utilidades.VariaveisGlobais.faltaPermissaoMessage, Utilidades.VariaveisGlobais.faltaPermissaoTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else
            {
                if (Command.Standard.Manutencao)
                {
                    Command.Standard.Manutencao = false;
                }
                else
                {
                    Command.Standard.Manutencao = true;
                }

                if (Command.Standard.Manutencao)
                {
                    DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Sair Modo Manutenção", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
                }
                else
                {
                    DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ir Para Modo Manutenção", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
                }

            }

        }

        protected void Bt_Manual_Click(object sender, EventArgs e)
        {
            if (Command.Standard.Automatico)
            {
                Command.Standard.Automatico = false;
                Command.Standard.Manual = true;
            }
            else
            {
                Command.Standard.Automatico = true;
                Command.Standard.Manual = false;
            }

            if (Command.Standard.Automatico)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ir Para Modo Automático", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ir Para Modo Manual", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        protected void Bt_Fechar_Click(object sender, EventArgs e)
        {

        }

        //INV
        protected void INV_Bt_Turn_On_Click(object sender, EventArgs e)
        {
            if (Command.Standard.Liga_Manual)
            {
                Command.Standard.Liga_Manual = false;
            }
            else
            {
                Command.Standard.Liga_Manual = true;
            }

            if (Command.Standard.Liga_Manual)
            {
                //DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ligar", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                //DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Desligar", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        protected void INV_Bt_Reset_Click(object sender, EventArgs e)
        {
            if (Command.Standard.Reset)
            {
                Command.Standard.Reset = false;
            }
            else
            {
                Command.Standard.Reset = true;
            }

            if (Command.Standard.Reset)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Reset Falha", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }

        }

        protected void INV_Bt_Maintenance_Click(object sender, EventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS < 2)
            {
                TopMost.TopMostMessageBox.Show(Utilidades.VariaveisGlobais.faltaPermissaoMessage, Utilidades.VariaveisGlobais.faltaPermissaoTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else
            {


            }
        }

        protected void INV_LB_Automatic_Click(object sender, EventArgs e)
        {

            if (Command.Standard.Automatico)
            {
                Command.Standard.Automatico = false;
                Command.Standard.Manual = true;
            }
            else
            {
                Command.Standard.Automatico = true;
                Command.Standard.Manual = false;
            }


            if (Command.Standard.Automatico)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ir Para Modo Automático", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ir Para Modo Manual", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        #endregion

        private bool Help_Click_Left()
        {
            //if (string.Equals(Utilidades.VariaveisGlobais.UserLogged_GS, ""))
            //{
            //    Command.ResetClicks = true;
            //    TopMost.TopMostMessageBox.Show("Por favor faça o login para interagir na aplicação!", "Falta Login", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            //    return false;
            //}
            //else
            //{ 
            //    Command.ResetClicks = true;
                return true;
            //}
        }

        #region Encapulate Fields

        public bool readPlcFromBuffer
        {
            set
            {
                if (Command.TypeEquip == typeEquip.PD && Command.TypeCommand == typeCommand.PD)
                {
                    //Lendo variaveis do buffer do CLP
                    Command.DWord = Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet);
                    Command.PD.SP_Manutencao = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 4);
                    Command.PD.HorimetroParcial = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 8);
                    Command.PD.HorimetroTotal = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 12);
                    Command.PD.Tempo_Limpeza = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 16);

                    //Atualizando as variaveis para o standard GUI

                    //Primeiro converte a Dword para os bits
                    Command = Utilidades.Move_Bits.Dword_TO_typePD(Command.DWord, Command);

                    //Segundo atualiza o standard GUI
                    Command = Utilidades.Move_Bits.typePD_TO_typeStandardGUI(Command);

                }
            }
        }

        public Utilidades.VariaveisGlobais.type_All Command_Get
        {
            get
            {
                return Command;
            }
        }

        public void OpenWindow()
        {
            if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
            {
                Window_PD.ShowDialog();
            }
        }

        #endregion

        //Carrega informações na tela
        public void LoadInfo(int index)
        {

            //if (Command.TypeEquip == Utility.typeEquip.PD)
            //{

            //    Command.indexList = index;

            //    PDHome.controlPD_Tela.LoadInfo(Command);

       
            //    //manutencaoMotor.LoadInfo(Command);


            //        if (Command.Tag != null)
            //        {

            //            //if (!AutomasulGUI.DataBase.SQLManutencao.ExistTable(Command.Tag))
            //            //{
            //            //    AutomasulGUI.DataBase.SQLManutencao.CreateTable_Manutencao(Command.Tag);
            //            //}
            //            //AutomasulGUI.DataBase.SQLManutencao.CreateTable_HistoricoManutencao(Command.Tag);

            //            PDHome.Command = Command;

            //            Window_PD.Title = Command.Tag;

            //            if (Command.HabilitaCorrente)
            //            {                     
            //                string str;

            //                str = Replace(Command.Tag);
            //                if (!DataBase.SqlFunctionsCurrent.ExistTable(str))
            //                {
            //                    DataBase.SqlFunctionsCurrent.CreateTable(str);
            //                }
                            
            //            }
            //        }
            //}
            //else if (Command.TypeEquip == Utility.typeEquip.PSSI)
            //{

            //}
            //else if (Command.TypeEquip == Utility.typeEquip.PSSM)
            //{

            //}
            //else if (Command.TypeEquip == Utility.typeEquip.INV)
            //{
            //    Command.indexList = index;

            //    INVHome.controleINV_Tela.LoadInfo(Command);

            //    if (Command.Tag != null)
            //    {
            //        INVHome.Command = Command;

            //        Window_INV.Title = Command.Tag;

            //        if (Command.HabilitaCorrente)
            //        {

            //            string str;

            //            str = Replace(Command.Tag);
            //            if (!DataBase.SqlFunctionsCurrent.ExistTable(str))
            //            {
            //                DataBase.SqlFunctionsCurrent.CreateTable(str);
            //            }
            //        }

            //    }
            //}
            //else if (Command.TypeEquip == Utility.typeEquip.PC)
            //{

            //    Command.indexList = index;

            //    if (Command.Tag != null)
            //    {
            //        PCHome.Command = Command;

            //        Window_PC.Title = Command.Tag;
            //    }

            //    PCHome.controlPC_Tela.LoadInfo(Command);
            //}
            //else if (Command.TypeEquip == Utility.typeEquip.PCM)
            //{

            //    Command.indexList = index;

            //    PCMHome.controlePCM_Tela.LoadInfo(Command);
            //    //Cria Tabela de Corrente dos motores.

            //    if (Command.Tag != null)
            //    {
            //        PCMHome.Command = Command;


            //        Window_PCM.Title = Command.Tag;

            //        if (Command.HabilitaCorrente)
            //        {

            //            string str;

            //            str = Replace(Command.Tag);
            //            if (!DataBase.SqlFunctionsCurrent.ExistTable(str))
            //            {
            //                DataBase.SqlFunctionsCurrent.CreateTable(str);
            //            }
            //        }

            //    }
            //}
            //else if (Command.TypeEquip == Utility.typeEquip.REG)
            //{
            //    Command.indexList = index;

            //    REGHome.controlPREG_Tela.LoadInfo(Command);

            //    if (Command.Tag != null)
            //    {
            //        REGHome.Command = Command;

            //        Window_Preg.Title = Command.Tag;
            //    }
            //}
            //else if (Command.TypeEquip == Utility.typeEquip.BF)
            //{

            //}
            //else if (Command.TypeEquip == Utility.typeEquip.TRF)
            //{

            //}

        }

    }

}
