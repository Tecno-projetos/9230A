﻿using System;
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

        public EquipsControl(typeEquip Equip, typeCommand TCommand, int initialOffSet, int bufferPlc, string nome, string tag, string numeroPartida, string paginaProjeto)
        {
            Command.initialOffSet = initialOffSet;
            Command.bufferPlc = bufferPlc;
            Command.TypeEquip = Equip;
            Command.TypeCommand = TCommand;
            Command.Nome = nome;
            Command.Tag = tag;
            Command.NumeroPartida = numeroPartida;
            Command.PaginaProjeto = paginaProjeto;

            //==========================================================================================
            //Inicia a tela dependendo o tipo de motor.

            //PD
            if (Equip == typeEquip.PD)
            {
                Window_PD = new Partidas.controlePartidaDireta(nome, tag, numeroPartida, paginaProjeto);

                Window_PD.Closing += Window_PD_Closing;

               //Click para controle da Partida 
               Window_PD.Bt_Ligar_Click += new EventHandler(PD_Bt_Ligar_Click);
               Window_PD.Bt_Reset_Click += new EventHandler(PD_Bt_Reset_Click);
               Window_PD.Bt_Libera_Click += new EventHandler(PD_Bt_Libera_Click);
               Window_PD.Bt_Manutencao_Click += new EventHandler(PD_Bt_Manutencao_Click);
               Window_PD.Bt_Manual_Click += new EventHandler(PD_Bt_Manual_Click);
               Window_PD.Bt_Fechar_Click += new EventHandler(PD_Bt_Fechar_Click);
            }
            //INV
            else if (Equip == typeEquip.INV)
            {
                Window_INV = new Partidas.controleInversor(nome, tag, numeroPartida, paginaProjeto);

                Window_INV.Closing += Window_INV_Closing;

                //Click para controle da Partida 
                Window_INV.Bt_Ligar_Click += new EventHandler(INV_Bt_Ligar_Click);
                Window_INV.Bt_Reset_Click += new EventHandler(INV_Bt_Reset_Click);
                Window_INV.Bt_Libera_Click += new EventHandler(INV_Bt_Libera_Click);
                Window_INV.Bt_Manutencao_Click += new EventHandler(INV_Bt_Manutencao_Click);
                Window_INV.Bt_Manual_Click += new EventHandler(INV_Bt_Manual_Click);
                Window_INV.Bt_Fechar_Click += new EventHandler(INV_Bt_Fechar_Click);
                Window_INV.atualizarVelocidade += new EventHandler(INV_atualiza_Velocidade);

            }
            //SS
            else if (Equip == typeEquip.SS)
            {
                Window_SS = new Partidas.controleSoftStarter(nome, tag, numeroPartida, paginaProjeto);

                Window_SS.Closing += Window_SS_Closing;

                //Click para controle da Partida 
                Window_SS.Bt_Ligar_Click += new EventHandler(SS_Bt_Ligar_Click);
                Window_SS.Bt_Reset_Click += new EventHandler(SS_Bt_Reset_Click);
                Window_SS.Bt_Libera_Click += new EventHandler(SS_Bt_Libera_Click);
                Window_SS.Bt_Manutencao_Click += new EventHandler(SS_Bt_Manutencao_Click);
                Window_SS.Bt_Manual_Click += new EventHandler(SS_Bt_Manual_Click);
                Window_SS.Bt_Fechar_Click += new EventHandler(SS_Bt_Fechar_Click);
                Window_SS.Bt_Inverte_Click += new EventHandler(SS_Bt_InverterSentido_Click);

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

        private void Window_SS_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            Window_SS.Hide();
        }

        private void Window_BF_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Window_BF.Hide();
        }


        #endregion

        #region Events Screens

        //PD
        protected void PD_Bt_Ligar_Click(object sender, EventArgs e)
        {
            invertBitLigar();
        }

        protected void PD_Bt_Reset_Click(object sender, EventArgs e)
        {
            setBitReset();
        }

        protected void PD_Bt_Libera_Click(object sender, EventArgs e)
        {
            invertBitLibera();
        }

        protected void PD_Bt_Manutencao_Click(object sender, EventArgs e)
        {
            invertBitManutencao();
        }

        protected void PD_Bt_Manual_Click(object sender, EventArgs e)
        {
            invertBitManual();
        }

        protected void PD_Bt_Fechar_Click(object sender, EventArgs e)
        {
            Window_PD.DialogResult = true;
        }

        //INV
        protected void INV_Bt_Ligar_Click(object sender, EventArgs e)
        {
            invertBitLigar();
        }

        protected void INV_Bt_Reset_Click(object sender, EventArgs e)
        {
            setBitReset();
        }

        protected void INV_Bt_Libera_Click(object sender, EventArgs e)
        {
            invertBitLibera();
        }

        protected void INV_Bt_Manutencao_Click(object sender, EventArgs e)
        {
            invertBitManutencao();
        }

        protected void INV_Bt_Manual_Click(object sender, EventArgs e)
        {
            invertBitManual();
        }

        protected void INV_Bt_Fechar_Click(object sender, EventArgs e)
        {
            Window_INV.DialogResult = true;
        }

        private void INV_atualiza_Velocidade(object sender, EventArgs e)
        {
            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 4, Convert.ToSingle(Window_INV.velocidadeManual_GS));

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;
        }

        //SS
        protected void SS_Bt_Ligar_Click(object sender, EventArgs e)
        {
            invertBitLigar();
        }

        protected void SS_Bt_Reset_Click(object sender, EventArgs e)
        {
            setBitReset();
        }

        protected void SS_Bt_Libera_Click(object sender, EventArgs e)
        {
            invertBitLibera();
        }

        protected void SS_Bt_Manutencao_Click(object sender, EventArgs e)
        {
            invertBitManutencao();
        }

        protected void SS_Bt_Manual_Click(object sender, EventArgs e)
        {
            invertBitManual();
        }

        protected void SS_Bt_InverterSentido_Click(object sender, EventArgs e)
        {
            if (Command.Standard.inverterSentidoGiro)
            {
                Command.Standard.inverterSentidoGiro = false;
            }
            else
            {
                Command.Standard.inverterSentidoGiro = true;
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            if (Command_Get.TypeEquip == typeEquip.SS && Command_Get.TypeCommand == typeCommand.SS)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeSS_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeSS(Command)));
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;

            if (Command.Standard.inverterSentidoGiro)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Sentido Horário", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Sentido Anti-Horário", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        protected void SS_Bt_Fechar_Click(object sender, EventArgs e)
        {
            Window_SS.DialogResult = true;
        }

        #endregion

        #region Functions

        private void invertBitLigar()
        {
            if (Command.Standard.Liga_Manual)
            {
                Command.Standard.Liga_Manual = false;
            }
            else
            {
                Command.Standard.Liga_Manual = true;
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typePD_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typePD(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeINV_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeINV(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.SS && Command_Get.TypeCommand == typeCommand.SS)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeSS_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeSS(Command)));
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;

            if (Command.Standard.Liga_Manual)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ligar", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Desligar", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        private void setBitReset()
        {
            Command.Standard.Reset = true;

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typePD_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typePD(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeINV_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeINV(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.SS && Command_Get.TypeCommand == typeCommand.SS)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeSS_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeSS(Command)));
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;

            if (Command.Standard.Reset)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Reset Falha", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        private void invertBitLibera()
        {
            if (Command.Standard.Libera_Bloqueio)
            {
                Command.Standard.Libera_Bloqueio = false;
            }
            else
            {
                Command.Standard.Libera_Bloqueio = true;
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typePD_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typePD(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeINV_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeINV(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.SS && Command_Get.TypeCommand == typeCommand.SS)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeSS_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeSS(Command)));
            }
            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;

            if (Command.Standard.Libera_Bloqueio)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Libera Bloqueio", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        private void invertBitManutencao()
        {
            //if (Utilidades.VariaveisGlobais.NumberOfGroup_GS < 2)
            //{
            //    TopMost.TopMostMessageBox.Show(Utilidades.VariaveisGlobais.faltaPermissaoMessage, Utilidades.VariaveisGlobais.faltaPermissaoTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            //}
            //else
            //{
            //    Solicita_Manutencao = true;
            //}
            if (Command.Standard.Manutencao)
            {
                Command.Standard.Manutencao = false;
            }
            else
            {
                Command.Standard.Manutencao = true;
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typePD_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typePD(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeINV_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeINV(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.SS && Command_Get.TypeCommand == typeCommand.SS)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeSS_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeSS(Command)));
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;

            if (Command.Standard.Manutencao)
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Sair Modo Manutenção", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
            else
            {
                DataBase.SqlFunctionsEquips.IntoDate_Table_EquipAlarmEvent("_" + Command.Tag, "Comando Ir Para Modo Manutenção", true, false, 1, false, "", Utilidades.VariaveisGlobais.UserLogged_GS, Utilidades.VariaveisGlobais.GroupUserLogged_GS, DateTime.Now.ToString(), "", "", DateTime.Now, "");
            }
        }

        private void invertBitManual()
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

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read = false;

            if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typePD_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typePD(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeINV_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeINV(Command)));
            }
            else if (Command_Get.TypeEquip == typeEquip.SS && Command_Get.TypeCommand == typeCommand.SS)
            {
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet, Utilidades.Move_Bits.typeSS_TO_Dword(Utilidades.Move_Bits.typeStandardGUI_TO_typeSS(Command)));
            }

            VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Write = true;

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

        public bool actualize_Equip
        {
            set
            {
                //Leitura das Variaveis
                if (VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Enable_Read)
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
                    else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
                    {
                        //Lendo variaveis do buffer do CLP
                        Command.DWord = Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet);
                        Command.INV.Velocidade_Manual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 4);
                        Command.INV.Velocidade_Automatica_Solicita = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 8);
                        Command.INV.Velocidade_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 12);
                        Command.INV.Velocidade_Nominal = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 16);
                        Command.INV.SP_Corrente_Motor_Vazio = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 20);
                        Command.INV.Corrente_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 24);
                        Command.INV.Codigo_Alarme = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 28);
                        Command.INV.Codigo_Falha = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 32);
                        Command.INV.SP_Manutencao = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 36);
                        Command.INV.HorimetroParcial = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 40);
                        Command.INV.HorimetroTotal = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 44);
                        Command.INV.Tempo_Limpeza = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[Command.bufferPlc].Buffer, Command.initialOffSet + 48);

                        //Atualizando as variaveis para o standard GUI

                        //Primeiro converte a Dword para os bits
                        Command = Utilidades.Move_Bits.Dword_TO_typeINV(Command.DWord, Command);

                        //Segundo atualiza o standard GUI
                        Command = Utilidades.Move_Bits.typeINV_TO_typeStandardGUI(Command);
                    }
                }

                //Atualiza Window
                if (Command_Get.TypeEquip == typeEquip.PD && Command_Get.TypeCommand == typeCommand.PD)
                {
                    Window_PD.actualize_UI(Command);
                }
                else if (Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
                {
                    Window_INV.actualize_UI(Command);
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
            else if(Command_Get.TypeEquip == typeEquip.INV && Command_Get.TypeCommand == typeCommand.INV)
            {
                Window_INV.velocidadeManual_GS = Command.INV.Velocidade_Manual.ToString();

                Window_INV.ShowDialog();
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
