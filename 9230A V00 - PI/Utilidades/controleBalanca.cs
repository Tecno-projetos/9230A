﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.Utilidades
{
    public class controleBalanca
    {

        Utilidades.VariaveisGlobais.IndicadorPesagem IndicadorPesagem = new Utilidades.VariaveisGlobais.IndicadorPesagem(); //Controle Indicador de pesagem

        Utilidades.VariaveisGlobais.AuxiliaresProcesso auxiliaresProcesso = new VariaveisGlobais.AuxiliaresProcesso();//Controle auxiliares de processo.

        int bufferPlc_Auxiliares;
        int bufferPlc_idicador;


        public controleBalanca(int bufferPlc_Auxiliares, int bufferPlc_idicador)
        {
            this.bufferPlc_Auxiliares = bufferPlc_Auxiliares;
            this.bufferPlc_idicador = bufferPlc_idicador;
        }

        #region Auxiliares Processo

        /// <summary>
        /// Função para ler as váriveis do DB Auxiliares
        /// </summary>
        public void readVariablesBuffer_AuxiliaresProcesso()
        {
            //Controle Máquinas
            auxiliaresProcesso.Maximo_Silo_Produto_Acabado = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 0);
            auxiliaresProcesso.Maximo_Silo1_Materia_Prima = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 4);
            auxiliaresProcesso.Maximo_Silo2_Materia_Prima = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 8);
            auxiliaresProcesso.Maximo_Balanca = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 12);
            auxiliaresProcesso.Maximo_PreMisturador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 16);
            auxiliaresProcesso.Maximo_PosMisturador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 20);


            //Controle Registro
            auxiliaresProcesso.Abertura_Máxima_Silo1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 24);
            auxiliaresProcesso.Inicio_Reducao_Silo1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 28);
            auxiliaresProcesso.Fechamento_Antecipado_Silo1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 32);

            auxiliaresProcesso.Abertura_Máxima_Silo2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 36);
            auxiliaresProcesso.Inicio_Reducao_Silo2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 40);
            auxiliaresProcesso.Fechamento_Antecipado_Silo2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 44);


            //Geral
            auxiliaresProcesso = Move_Bits.DwordTocontroleAuxiliaresProcesso(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 48), auxiliaresProcesso);
            auxiliaresProcesso.Percentual_Habilita_Balanca_Vazia_Automatica = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 54);
            auxiliaresProcesso.Percentual_Habilita_Balanca_Vazia_Manual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 58);

        }

        /// <summary>
        /// Função para escrever no DB Auxilaires
        /// </summary>
        public void writeVariables_AuxiliaresProcesso()
        {

            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Read = false;

            //Controle Máquinas
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 0, auxiliaresProcesso.Maximo_Silo_Produto_Acabado);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 4, auxiliaresProcesso.Maximo_Silo1_Materia_Prima);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 8, auxiliaresProcesso.Maximo_Silo2_Materia_Prima);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 12, auxiliaresProcesso.Maximo_Balanca);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 16, auxiliaresProcesso.Maximo_PreMisturador);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 20, auxiliaresProcesso.Maximo_PosMisturador);


            //Controle Registro
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 24, auxiliaresProcesso.Abertura_Máxima_Silo1);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 28, auxiliaresProcesso.Inicio_Reducao_Silo1);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 32, auxiliaresProcesso.Fechamento_Antecipado_Silo1);

            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 36, auxiliaresProcesso.Abertura_Máxima_Silo2);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 40, auxiliaresProcesso.Inicio_Reducao_Silo2);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 44, auxiliaresProcesso.Fechamento_Antecipado_Silo2);
            //Geral
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 54, auxiliaresProcesso.Percentual_Habilita_Balanca_Vazia_Automatica);
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 58, auxiliaresProcesso.Percentual_Habilita_Balanca_Vazia_Manual);


            VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Write = true;

        }

        /// <summary>
        /// Seta a palavra de comando das auxiliares Geral
        /// </summary>
        public bool WriteCommandGeral_Auxiliares
        {
            set
            {
                VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Read = false;
                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Buffer, 48, Move_Bits.AuxiliaresProcessoToDword(auxiliaresProcesso)); //Atualiza os Bits do command
                VariaveisGlobais.Buffer_PLC[bufferPlc_Auxiliares].Enable_Write = true;
            }

        }

        #endregion

        #region Indicador de Pesagem

        public void readVariablesBuffer_indicadorPesagem()
        {
            //Controle Máquinas
            IndicadorPesagem.Valor_Atual_Indicador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc_idicador].Buffer, 372);

            IndicadorPesagem = Move_Bits.ByteToIndicadorPesagem(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc_idicador].Buffer, 376), IndicadorPesagem);
        }


        public bool WriteCommandGeral_Indicador
        {
            set
            {
                VariaveisGlobais.Buffer_PLC[bufferPlc_idicador].Enable_Read = false;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc_idicador].Buffer, 376, Move_Bits.IndicadorPesagemToByte(IndicadorPesagem)); //Atualiza os Bits do command
                VariaveisGlobais.Buffer_PLC[bufferPlc_idicador].Enable_Write = true;
            }

        }

        #endregion
    }


}






