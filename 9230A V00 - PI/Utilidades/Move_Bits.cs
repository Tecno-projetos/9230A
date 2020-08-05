using System;

namespace _9230A_V00___PI.Utilidades
{
    public class Move_Bits
    {

        //Type PD
        //=====================================================================================================================================

        public static Utilidades.VariaveisGlobais.type_All typePD_TO_typeStandardGUI(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.Standard.Liga_Manual = Command.PD.ligaManual;
            Command.Standard.Manual = Command.PD.manual;
            Command.Standard.Automatico = Command.PD.automatico;
            Command.Standard.Manutencao = Command.PD.manutencao;
            Command.Standard.Libera_Bloqueio = Command.PD.Libera_Bloqueio_Manual;
            Command.Standard.Reset = Command.PD.reset;
            Command.Standard.Ligado = Command.PD.ligado;
            Command.Standard.Ligando = Command.PD.ligando;
            Command.Standard.Desligando = Command.PD.desligando;
            Command.Standard.Liberado = Command.PD.liberado;
            Command.Standard.Falha_Partida_Nao_Confirmou = Command.PD.falhaPartidaNaoConfirmou;
            Command.Standard.Falha_Contator_Desligou = Command.PD.falhaContatorDesligou;
            Command.Standard.Falha_Disjuntor_Desligou = Command.PD.falhaDisjuntoDesligou;
            Command.Standard.Falha_Partida_Nao_Desligou = Command.PD.falhaPartidaNaoDesligou;
            Command.Standard.Reset_Timer = Command.PD.resetHorimetroTotal;
            Command.Standard.Reset_Timer_Total = Command.PD.resetHorimetroParcial;
            Command.Standard.Emergencia = Command.PD.emergencia;
            Command.Standard.Disjuntor_Desligado = Command.PD.disjuntorDesligado;
            Command.Standard.Tempo_Manutencao = Command.PD.tempoManutencao;
            Command.Standard.Falha_Geral = Command.PD.falhaGeral;

            return Command;

        }

        public static Utilidades.VariaveisGlobais.type_All typeStandardGUI_TO_typePD(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.PD.ligaManual = Command.Standard.Liga_Manual;
            Command.PD.manual = Command.Standard.Manual;
            Command.PD.automatico = Command.Standard.Automatico;
            Command.PD.manutencao = Command.Standard.Manutencao;
            Command.PD.Libera_Bloqueio_Manual = Command.Standard.Libera_Bloqueio;
            Command.PD.reset = Command.Standard.Reset;
            Command.PD.ligado = Command.Standard.Ligado;
            Command.PD.ligando = Command.Standard.Ligando;
            Command.PD.desligando = Command.Standard.Desligando;
            Command.PD.liberado = Command.Standard.Liberado;
            Command.PD.falhaPartidaNaoConfirmou = Command.Standard.Falha_Partida_Nao_Confirmou;
            Command.PD.falhaContatorDesligou = Command.Standard.Falha_Contator_Desligou;
            Command.PD.falhaDisjuntoDesligou = Command.Standard.Falha_Disjuntor_Desligou;
            Command.PD.falhaPartidaNaoDesligou = Command.Standard.Falha_Partida_Nao_Desligou;
            Command.PD.resetHorimetroTotal = Command.Standard.Reset_Timer;
            Command.PD.resetHorimetroParcial = Command.Standard.Reset_Timer_Total;
            Command.PD.emergencia = Command.Standard.Emergencia;
            Command.PD.disjuntorDesligado = Command.Standard.Disjuntor_Desligado;
            Command.PD.tempoManutencao = Command.Standard.Tempo_Manutencao;
            Command.PD.falhaGeral = Command.Standard.Falha_Geral;

            return Command;
        }

        public static Utilidades.VariaveisGlobais.type_All Dword_TO_typePD(UInt32 DWord, Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            Conversions.Dword_To_Bit(DWord, ref bits, true);

            //Atualiza DWord
            Command.DWord = DWord;


            Command.PD.ligaManual = bits[0];
            Command.PD.manual = bits[1];
            Command.PD.automatico = bits[2];
            Command.PD.manutencao = bits[3];
            Command.PD.Libera_Bloqueio_Manual = bits[4];
            Command.PD.reset = bits[5];
            Command.PD.ligado = bits[6];
            Command.PD.ligando = bits[7];
            Command.PD.desligando = bits[8];
            Command.PD.liberado = bits[9];
            Command.PD.falhaPartidaNaoConfirmou = bits[10];
            Command.PD.falhaContatorDesligou = bits[11];
            Command.PD.falhaDisjuntoDesligou = bits[12];
            Command.PD.falhaPartidaNaoDesligou = bits[13];
            Command.PD.resetHorimetroTotal = bits[14];
            Command.PD.resetHorimetroParcial = bits[15];
            Command.PD.emergencia = bits[16];
            Command.PD.disjuntorDesligado = bits[17];
            Command.PD.tempoManutencao = bits[18]; 
            Command.PD.falhaGeral = bits[19];
            Command.PD.bitReserva = bits[20];
            Command.PD.bitReserva_1 = bits[21];
            Command.PD.bitReserva_2 = bits[22];
            Command.PD.bitReserva_3 = bits[23];
            Command.PD.bitReserva_4 = bits[24];
            Command.PD.bitReserva_5 = bits[25];
            Command.PD.bitReserva_6 = bits[26];
            Command.PD.bitReserva_7 = bits[27];
            Command.PD.bitReserva_8 = bits[28];
            Command.PD.bitReserva_9 = bits[29];
            Command.PD.bitReserva_10 = bits[30];
            Command.PD.bitReserva_11 = bits[31];

            return Command;
        }

        public static UInt32 typePD_TO_Dword(Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            bits[0] = Command.PD.ligaManual;
            bits[1] = Command.PD.manual;
            bits[2] = Command.PD.automatico;
            bits[3] = Command.PD.manutencao;
            bits[4] = Command.PD.Libera_Bloqueio_Manual;
            bits[5] = Command.PD.reset;
            bits[6] = Command.PD.ligado;
            bits[7] = Command.PD.ligando;
            bits[8] = Command.PD.desligando;
            bits[9] = Command.PD.liberado;
            bits[10] = Command.PD.falhaPartidaNaoConfirmou;
            bits[11] = Command.PD.falhaContatorDesligou;
            bits[12] = Command.PD.falhaDisjuntoDesligou;
            bits[13] = Command.PD.falhaPartidaNaoDesligou;
            bits[14] = Command.PD.resetHorimetroTotal;
            bits[15] = Command.PD.resetHorimetroParcial;
            bits[16] = Command.PD.emergencia;
            bits[17] = Command.PD.disjuntorDesligado;
            bits[18] = Command.PD.tempoManutencao;
            bits[19] = Command.PD.falhaGeral;
            bits[20] = Command.PD.bitReserva;
            bits[21] = Command.PD.bitReserva_1;
            bits[22] = Command.PD.bitReserva_2;
            bits[23] = Command.PD.bitReserva_3;
            bits[24] = Command.PD.bitReserva_4;
            bits[25] = Command.PD.bitReserva_5;
            bits[26] = Command.PD.bitReserva_6;
            bits[27] = Command.PD.bitReserva_7;
            bits[28] = Command.PD.bitReserva_8;
            bits[29] = Command.PD.bitReserva_9;
            bits[30] = Command.PD.bitReserva_10;
            bits[31] = Command.PD.bitReserva_11;

            Command.DWord = Conversions.Bit_To_Dword(ref bits, true);

            return Command.DWord;
        }

        //Type INV
        //=====================================================================================================================================

        public static Utilidades.VariaveisGlobais.type_All typeINV_TO_typeStandardGUI(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.Standard.Liga_Manual = Command.INV.ligaManual;
            Command.Standard.Manual = Command.INV.manual;
            Command.Standard.Automatico = Command.INV.automatico;
            Command.Standard.Manutencao = Command.INV.manutencao;
            Command.Standard.Libera_Bloqueio = Command.INV.Libera_Bloqueio_Manual;
            Command.Standard.Reset = Command.INV.reset;
            Command.Standard.Ligado = Command.INV.ligado;
            Command.Standard.Ligando = Command.INV.ligando;
            Command.Standard.Desligando = Command.INV.desligando;
            Command.Standard.Liberado = Command.INV.liberado;
            Command.Standard.Reset_Timer = Command.INV.resetHorimetroTotal;
            Command.Standard.Reset_Timer_Total = Command.INV.resetHorimetroParcial;
            Command.Standard.Emergencia = Command.INV.emergencia;
            Command.Standard.Disjuntor_Desligado = Command.INV.disjuntorDesligado;
            Command.Standard.Tempo_Manutencao = Command.INV.tempoManutencao;
            Command.Standard.Falha_Geral = Command.INV.falha;

            return Command;

        }

        public static Utilidades.VariaveisGlobais.type_All typeStandardGUI_TO_typeINV(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.INV.ligaManual = Command.Standard.Liga_Manual;
            Command.INV.manual = Command.Standard.Manual;
            Command.INV.automatico = Command.Standard.Automatico;
            Command.INV.manutencao = Command.Standard.Manutencao;
            Command.INV.Libera_Bloqueio_Manual = Command.Standard.Libera_Bloqueio;
            Command.INV.reset = Command.Standard.Reset;
            Command.INV.ligado = Command.Standard.Ligado;
            Command.INV.ligando = Command.Standard.Ligando;
            Command.INV.desligando = Command.Standard.Desligando;
            Command.INV.liberado = Command.Standard.Liberado;
            Command.INV.resetHorimetroTotal = Command.Standard.Reset_Timer;
            Command.INV.resetHorimetroParcial = Command.Standard.Reset_Timer_Total;
            Command.INV.emergencia = Command.Standard.Emergencia;
            Command.INV.disjuntorDesligado = Command.Standard.Disjuntor_Desligado;
            Command.INV.tempoManutencao = Command.Standard.Tempo_Manutencao;
            Command.INV.falha = Command.Standard.Falha_Geral;

            return Command;
        }

        public static Utilidades.VariaveisGlobais.type_All Dword_TO_typeINV(UInt32 DWord, Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            Conversions.Dword_To_Bit(DWord, ref bits, true);

            //Atualiza DWord
            Command.DWord = DWord;


            Command.INV.ligaManual = bits[0];
            Command.INV.manual = bits[1];
            Command.INV.automatico = bits[2];
            Command.INV.manutencao = bits[3];
            Command.INV.Libera_Bloqueio_Manual = bits[4];
            Command.INV.reset = bits[5];
            Command.INV.ligado = bits[6];
            Command.INV.ligando = bits[7];
            Command.INV.desligando = bits[8];
            Command.INV.liberado = bits[9];
            Command.INV.resetHorimetroTotal = bits[10];
            Command.INV.resetHorimetroParcial = bits[11];
            Command.INV.emergencia = bits[12];
            Command.INV.disjuntorDesligado = bits[13];
            Command.INV.tempoManutencao = bits[14];
            Command.INV.falha = bits[15];
            Command.INV.bitReserva = bits[16];
            Command.INV.bitReserva_1 = bits[17];
            Command.INV.bitReserva_2 = bits[18];
            Command.INV.bitReserva_3 = bits[19];
            Command.INV.bitReserva_4 = bits[20];
            Command.INV.bitReserva_5 = bits[21];
            Command.INV.bitReserva_6 = bits[22];
            Command.INV.bitReserva_7 = bits[23];
            Command.INV.bitReserva_8 = bits[24];
            Command.INV.bitReserva_9 = bits[25];
            Command.INV.bitReserva_10 = bits[26];
            Command.INV.bitReserva_11 = bits[27];
            Command.INV.bitReserva_12 = bits[28];
            Command.INV.bitReserva_13 = bits[29];
            Command.INV.bitReserva_14 = bits[30];
            Command.INV.bitReserva_15 = bits[31];

            return Command;
        }

        public static UInt32 typeINV_TO_Dword(Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            bits[0] = Command.INV.ligaManual;
            bits[1] = Command.INV.manual;
            bits[2] = Command.INV.automatico;
            bits[3] = Command.INV.manutencao;
            bits[4] = Command.INV.Libera_Bloqueio_Manual;
            bits[5] = Command.INV.reset;
            bits[6] = Command.INV.ligado;
            bits[7] = Command.INV.ligando;
            bits[8] = Command.INV.desligando;
            bits[9] = Command.INV.liberado;
            bits[10] = Command.INV.resetHorimetroTotal;
            bits[11] = Command.INV.resetHorimetroParcial;
            bits[12] = Command.INV.emergencia;
            bits[13] = Command.INV.disjuntorDesligado;
            bits[14] = Command.INV.tempoManutencao;
            bits[15] = Command.INV.falha;
            bits[16] = Command.INV.bitReserva;
            bits[17] = Command.INV.bitReserva_1;
            bits[18] = Command.INV.bitReserva_2;
            bits[19] = Command.INV.bitReserva_3;
            bits[20] = Command.INV.bitReserva_4;
            bits[21] = Command.INV.bitReserva_5;
            bits[22] = Command.INV.bitReserva_6;
            bits[23] = Command.INV.bitReserva_7;
            bits[24] = Command.INV.bitReserva_8;
            bits[25] = Command.INV.bitReserva_9;
            bits[26] = Command.INV.bitReserva_10;
            bits[27] = Command.INV.bitReserva_11;
            bits[28] = Command.INV.bitReserva_12;
            bits[29] = Command.INV.bitReserva_13;
            bits[30] = Command.INV.bitReserva_14;
            bits[31] = Command.INV.bitReserva_15;
            Command.DWord = Conversions.Bit_To_Dword(ref bits, true);

            return Command.DWord;
        }

        //Type SS
        //=====================================================================================================================================

        public static Utilidades.VariaveisGlobais.type_All typeSS_TO_typeStandardGUI(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.Standard.Liga_Manual = Command.SS.ligaManual;
            Command.Standard.Manual = Command.SS.manual;
            Command.Standard.Automatico = Command.SS.automatico;
            Command.Standard.Manutencao = Command.SS.manutencao;
            Command.Standard.Libera_Bloqueio = Command.SS.Libera_Bloqueio_Manual;
            Command.Standard.Reset = Command.SS.reset;
            Command.Standard.Ligado = Command.SS.ligado;
            Command.Standard.Ligando = Command.SS.ligando;
            Command.Standard.Desligando = Command.SS.desligando;
            Command.Standard.Liberado = Command.SS.liberado;
            Command.Standard.Falha_Partida_Nao_Confirmou = Command.SS.falhaPartidaNaoConfirmou;
            Command.Standard.Falha_Contator_Desligou = Command.SS.falhaContatorDesligou;
            Command.Standard.Falha_Disjuntor_Desligou = Command.SS.falhaDisjuntoDesligou;
            Command.Standard.Falha_Partida_Nao_Desligou = Command.SS.falhaPartidaNaoDesligou;
            Command.Standard.Reset_Timer = Command.SS.resetHorimetroParcial;
            Command.Standard.Reset_Timer_Total = Command.SS.resetHorimetroTotal;
            Command.Standard.Emergencia = Command.SS.emergencia;
            Command.Standard.Disjuntor_Desligado = Command.SS.disjuntorDesligado;
            Command.Standard.Tempo_Manutencao = Command.SS.tempoManutencao;
            Command.Standard.Falha_Geral = Command.SS.falhaGeral;
            Command.Standard.inverterSentidoGiro = Command.SS.inverterSentidoGiro;
            Command.Standard.SentidoGiro = Command.SS.sentidoGiro;
            return Command;

        }

        public static Utilidades.VariaveisGlobais.type_All typeStandardGUI_TO_typeSS(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.SS.ligaManual = Command.Standard.Liga_Manual;
            Command.SS.manual = Command.Standard.Manual;
            Command.SS.automatico = Command.Standard.Automatico;
            Command.SS.manutencao = Command.Standard.Manutencao;
            Command.SS.Libera_Bloqueio_Manual = Command.Standard.Libera_Bloqueio;
            Command.SS.reset = Command.Standard.Reset;
            Command.SS.ligado = Command.Standard.Ligado;
            Command.SS.ligando = Command.Standard.Ligando;
            Command.SS.desligando = Command.Standard.Desligando;
            Command.SS.liberado = Command.Standard.Liberado;
            Command.SS.falhaPartidaNaoConfirmou = Command.Standard.Falha_Partida_Nao_Confirmou;
            Command.SS.falhaContatorDesligou = Command.Standard.Falha_Contator_Desligou;
            Command.SS.falhaDisjuntoDesligou = Command.Standard.Falha_Disjuntor_Desligou;
            Command.SS.falhaPartidaNaoDesligou = Command.Standard.Falha_Partida_Nao_Desligou;
            Command.SS.resetHorimetroTotal = Command.Standard.Reset_Timer;
            Command.SS.resetHorimetroParcial = Command.Standard.Reset_Timer_Total;
            Command.SS.emergencia = Command.Standard.Emergencia;
            Command.SS.disjuntorDesligado = Command.Standard.Disjuntor_Desligado;
            Command.SS.tempoManutencao = Command.Standard.Tempo_Manutencao;
            Command.SS.falhaGeral = Command.Standard.Falha_Geral;
            Command.SS.inverterSentidoGiro = Command.Standard.inverterSentidoGiro;
            Command.SS.sentidoGiro = Command.Standard.SentidoGiro;
            return Command;
        }

        public static Utilidades.VariaveisGlobais.type_All Dword_TO_typeSS(UInt32 DWord, Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            Conversions.Dword_To_Bit(DWord, ref bits, true);

            //Atualiza DWord
            Command.DWord = DWord;


            Command.SS.ligaManual = bits[0];
            Command.SS.manual = bits[1];
            Command.SS.automatico = bits[2];
            Command.SS.manutencao = bits[3];
            Command.SS.Libera_Bloqueio_Manual = bits[4];
            Command.SS.reset = bits[5];
            Command.SS.ligado = bits[6];
            Command.SS.ligando = bits[7];
            Command.SS.desligando = bits[8];
            Command.SS.liberado = bits[9];
            Command.SS.falhaPartidaNaoConfirmou = bits[10];
            Command.SS.falhaContatorDesligou = bits[11];
            Command.SS.falhaDisjuntoDesligou = bits[12];
            Command.SS.falhaPartidaNaoDesligou = bits[13];
            Command.SS.resetHorimetroTotal = bits[14];
            Command.SS.resetHorimetroParcial = bits[15];
            Command.SS.emergencia = bits[16];
            Command.SS.disjuntorDesligado = bits[17];
            Command.SS.tempoManutencao = bits[18];
            Command.SS.falhaGeral = bits[19];
            Command.SS.inverterSentidoGiro = bits[20];
            Command.SS.sentidoGiro = bits[21];
            Command.SS.bitReserva = bits[22];
            Command.SS.bitReserva_1 = bits[23];
            Command.SS.bitReserva_2 = bits[24];
            Command.SS.bitReserva_3 = bits[25];
            Command.SS.bitReserva_4 = bits[26];
            Command.SS.bitReserva_5 = bits[27];
            Command.SS.bitReserva_6 = bits[28];
            Command.SS.bitReserva_7 = bits[29];
            Command.SS.bitReserva_8 = bits[30];
            Command.SS.bitReserva_9 = bits[31];

            return Command;
        }

        public static UInt32 typeSS_TO_Dword(Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            bits[0] = Command.SS.ligaManual;
            bits[1] = Command.SS.manual;
            bits[2] = Command.SS.automatico;
            bits[3] = Command.SS.manutencao;
            bits[4] = Command.SS.Libera_Bloqueio_Manual;
            bits[5] = Command.SS.reset;
            bits[6] = Command.SS.ligado;
            bits[7] = Command.SS.ligando;
            bits[8] = Command.SS.desligando;
            bits[9] = Command.SS.liberado;
            bits[10] = Command.SS.falhaPartidaNaoConfirmou;
            bits[11] = Command.SS.falhaContatorDesligou;
            bits[12] = Command.SS.falhaDisjuntoDesligou;
            bits[13] = Command.SS.falhaPartidaNaoDesligou;
            bits[14] = Command.SS.resetHorimetroTotal;
            bits[15] = Command.SS.resetHorimetroParcial;
            bits[16] = Command.SS.emergencia;
            bits[17] = Command.SS.disjuntorDesligado;
            bits[18] = Command.SS.tempoManutencao;
            bits[19] = Command.SS.falhaGeral;
            bits[20] = Command.SS.inverterSentidoGiro;
            bits[21] = Command.SS.sentidoGiro;
            bits[22] = Command.SS.bitReserva;
            bits[23] = Command.SS.bitReserva_1;
            bits[24] = Command.SS.bitReserva_2;
            bits[25] = Command.SS.bitReserva_3;
            bits[26] = Command.SS.bitReserva_4;
            bits[27] = Command.SS.bitReserva_5;
            bits[28] = Command.SS.bitReserva_6;
            bits[29] = Command.SS.bitReserva_7;
            bits[30] = Command.SS.bitReserva_8;
            bits[31] = Command.SS.bitReserva_9;

            Command.DWord = Conversions.Bit_To_Dword(ref bits, true);

            return Command.DWord;
        }

        //Type Atuador Digital
        //=====================================================================================================================================

        public static Utilidades.VariaveisGlobais.type_All typeAtuadorD_TO_typeStandardGUI(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.Standard.Manual = Command.AtuadorD.manual;
            Command.Standard.Automatico = Command.AtuadorD.automatico;
            Command.Standard.Manutencao = Command.AtuadorD.manutencao;
            Command.Standard.Libera_Bloqueio = Command.AtuadorD.Libera_Bloqueio_Manual;
            Command.Standard.Emergencia = Command.AtuadorD.emergencia;
            Command.Standard.Liberado = Command.AtuadorD.liberado;
            Command.Standard.AcionaLado1 = Command.AtuadorD.acionaLado1;
            Command.Standard.AcionaLado2 = Command.AtuadorD.acionaLado2;
            Command.Standard.AcionandoLado1 = Command.AtuadorD.acionandoLado1;
            Command.Standard.AcionandoLado2 = Command.AtuadorD.acionandoLado2;
            Command.Standard.AcionandoAutomatico = Command.AtuadorD.acionandoAutomatico;
            Command.Standard.EmPosicaoLado1 = Command.AtuadorD.emPosicaoLado1;
            Command.Standard.EmPosicaoLado2 = Command.AtuadorD.emPosicaoLado2;
            Command.Standard.FalhaAcionandoLado1 = Command.AtuadorD.falhaAcionandoLado1;
            Command.Standard.FalhaAcionandoLado2 = Command.AtuadorD.falhaAcionandoLado2;
            Command.Standard.Falha2PosicoesAtiva = Command.AtuadorD.falha2PosicoesAtiva;
            Command.Standard.FalhaConfirmacaoContatorLado1 = Command.AtuadorD.falhaConfirmacaoContatorLado1;
            Command.Standard.FalhaConfirmacaoContatorLado2 = Command.AtuadorD.falhaConfirmacaoContatorLado2;
            Command.Standard.Reset = Command.AtuadorD.reset;
            return Command;

        }

        public static Utilidades.VariaveisGlobais.type_All typeStandardGUI_TO_typeAtuadorD(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.AtuadorD.manual = Command.Standard.Manual;
            Command.AtuadorD.automatico = Command.Standard.Automatico;
            Command.AtuadorD.manutencao = Command.Standard.Manutencao;
            Command.AtuadorD.Libera_Bloqueio_Manual = Command.Standard.Libera_Bloqueio;
            Command.AtuadorD.emergencia = Command.Standard.Emergencia;
            Command.AtuadorD.liberado = Command.Standard.Liberado;
            Command.AtuadorD.acionaLado1 = Command.Standard.AcionaLado1;
            Command.AtuadorD.acionaLado2 = Command.Standard.AcionaLado2;
            Command.AtuadorD.acionandoLado1 = Command.Standard.AcionandoLado1;
            Command.AtuadorD.acionandoLado2 = Command.Standard.AcionandoLado2;
            Command.AtuadorD.acionandoAutomatico = Command.Standard.AcionandoAutomatico;
            Command.AtuadorD.emPosicaoLado1 = Command.Standard.EmPosicaoLado1;
            Command.AtuadorD.emPosicaoLado2 = Command.Standard.EmPosicaoLado2;
            Command.AtuadorD.falhaAcionandoLado1 = Command.Standard.FalhaAcionandoLado1;
            Command.AtuadorD.falhaAcionandoLado2 = Command.Standard.FalhaAcionandoLado2;
            Command.AtuadorD.falha2PosicoesAtiva = Command.Standard.Falha2PosicoesAtiva;
            Command.AtuadorD.falhaConfirmacaoContatorLado1 = Command.Standard.FalhaConfirmacaoContatorLado1;
            Command.AtuadorD.falhaConfirmacaoContatorLado2 = Command.Standard.FalhaConfirmacaoContatorLado2;
            Command.AtuadorD.reset = Command.Standard.Reset;
            return Command;
        }

        public static Utilidades.VariaveisGlobais.type_All Dword_TO_typeAtuadorD(UInt32 DWord, Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            Conversions.Dword_To_Bit(DWord, ref bits, true);

            //Atualiza DWord
            Command.DWord = DWord;

            Command.AtuadorD.manual = bits[0];
            Command.AtuadorD.automatico = bits[1];
            Command.AtuadorD.manutencao = bits[2];
            Command.AtuadorD.Libera_Bloqueio_Manual = bits[3];
            Command.AtuadorD.emergencia = bits[4];
            Command.AtuadorD.liberado = bits[5];
            Command.AtuadorD.acionaLado1 = bits[6];
            Command.AtuadorD.acionaLado2 = bits[7];
            Command.AtuadorD.acionandoLado1 = bits[8];
            Command.AtuadorD.acionandoLado2 = bits[9];
            Command.AtuadorD.acionandoAutomatico = bits[10];
            Command.AtuadorD.emPosicaoLado1 = bits[11];
            Command.AtuadorD.emPosicaoLado2 = bits[12];
            Command.AtuadorD.falhaAcionandoLado1 = bits[13];
            Command.AtuadorD.falhaAcionandoLado2 = bits[14];
            Command.AtuadorD.falha2PosicoesAtiva = bits[15];
            Command.AtuadorD.falhaConfirmacaoContatorLado1 = bits[16];
            Command.AtuadorD.falhaConfirmacaoContatorLado2 = bits[17];
            Command.AtuadorD.reset = bits[18];
            Command.AtuadorD.bitReserva = bits[19];
            Command.AtuadorD.bitReserva_1 = bits[20];
            Command.AtuadorD.bitReserva_2 = bits[21];
            Command.AtuadorD.bitReserva_3 = bits[22];
            Command.AtuadorD.bitReserva_4 = bits[23];
            Command.AtuadorD.bitReserva_5 = bits[24];
            Command.AtuadorD.bitReserva_6 = bits[25];
            Command.AtuadorD.bitReserva_7 = bits[26];
            Command.AtuadorD.bitReserva_8 = bits[27];
            Command.AtuadorD.bitReserva_9 = bits[28];
            Command.AtuadorD.bitReserva_10 = bits[29];
            Command.AtuadorD.bitReserva_11 = bits[30];
            Command.AtuadorD.bitReserva_12 = bits[31];


            return Command;
        }

        public static UInt32 typeAtuadorD_TO_Dword(Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            bits[0] = Command.AtuadorD.manual;
            bits[1] = Command.AtuadorD.automatico;
            bits[2] = Command.AtuadorD.manutencao;
            bits[3] = Command.AtuadorD.Libera_Bloqueio_Manual;
            bits[4] = Command.AtuadorD.emergencia;
            bits[5] = Command.AtuadorD.liberado;
            bits[6] = Command.AtuadorD.acionaLado1;
            bits[7] = Command.AtuadorD.acionaLado2;
            bits[8] = Command.AtuadorD.acionandoLado1;
            bits[9] = Command.AtuadorD.acionandoLado2;
            bits[10] = Command.AtuadorD.acionandoAutomatico;
            bits[11] = Command.AtuadorD.emPosicaoLado1;
            bits[12] = Command.AtuadorD.emPosicaoLado2;
            bits[13] = Command.AtuadorD.falhaAcionandoLado1;
            bits[14] = Command.AtuadorD.falhaAcionandoLado2;
            bits[15] = Command.AtuadorD.falha2PosicoesAtiva;
            bits[16] = Command.AtuadorD.falhaConfirmacaoContatorLado1;
            bits[17] = Command.AtuadorD.falhaConfirmacaoContatorLado1;
            bits[18] = Command.AtuadorD.reset;
            bits[19] = Command.AtuadorD.bitReserva;
            bits[20] = Command.AtuadorD.bitReserva_1;
            bits[21] = Command.AtuadorD.bitReserva_2;
            bits[22] = Command.AtuadorD.bitReserva_3;
            bits[23] = Command.AtuadorD.bitReserva_4;
            bits[24] = Command.AtuadorD.bitReserva_5;
            bits[25] = Command.AtuadorD.bitReserva_6;
            bits[26] = Command.AtuadorD.bitReserva_7;
            bits[27] = Command.AtuadorD.bitReserva_8;
            bits[28] = Command.AtuadorD.bitReserva_9;
            bits[29] = Command.AtuadorD.bitReserva_10;
            bits[30] = Command.AtuadorD.bitReserva_11;
            bits[31] = Command.AtuadorD.bitReserva_12;

            Command.DWord = Conversions.Bit_To_Dword(ref bits, true);

            return Command.DWord;
        }

        //Type Atuador Analogico
        //=====================================================================================================================================

        public static Utilidades.VariaveisGlobais.type_All typeAtuadorA_TO_typeStandardGUI(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.Standard.Liga_Manual = Command.AtuadorA.ligaManual;
            Command.Standard.Manual = Command.AtuadorA.manual;
            Command.Standard.Automatico = Command.AtuadorA.automatico;
            Command.Standard.Manutencao = Command.AtuadorA.manutencao;
            Command.Standard.Libera_Bloqueio = Command.AtuadorA.Libera_Bloqueio_Manual;
            Command.Standard.Emergencia = Command.AtuadorA.emergencia;
            Command.Standard.Liberado = Command.AtuadorA.liberado;
            Command.Standard.AcionandoAutomatico = Command.AtuadorA.acionandoAutomatico;
            Command.Standard.FalhaConfirmacaoContatorLado1 = Command.AtuadorA.falhaConfirmacaoContatorLado1;
            Command.Standard.FalhaConfirmacaoContatorLado2 = Command.AtuadorA.falhaConfirmacaoContatorLado2;
            Command.Standard.falhaPosicionamento = Command.AtuadorA.falhaPosicionamento;
            Command.Standard.falhaLeituraPosicao = Command.AtuadorA.falhaLeituraPosicao;
            Command.Standard.Reset = Command.AtuadorA.reset;
            return Command;

        }

        public static Utilidades.VariaveisGlobais.type_All typeStandardGUI_TO_typeAtuadorA(Utilidades.VariaveisGlobais.type_All Command)
        {
            Command.AtuadorA.ligaManual = Command.Standard.Liga_Manual;
            Command.AtuadorA.manual = Command.Standard.Manual;
            Command.AtuadorA.automatico = Command.Standard.Automatico;
            Command.AtuadorA.manutencao = Command.Standard.Manutencao;
            Command.AtuadorA.Libera_Bloqueio_Manual = Command.Standard.Libera_Bloqueio;
            Command.AtuadorA.emergencia = Command.Standard.Emergencia;
            Command.AtuadorA.liberado = Command.Standard.Liberado;
            Command.AtuadorA.acionandoAutomatico = Command.Standard.AcionandoAutomatico;
            Command.AtuadorA.falhaConfirmacaoContatorLado1 = Command.Standard.FalhaConfirmacaoContatorLado1;
            Command.AtuadorA.falhaConfirmacaoContatorLado2 = Command.Standard.FalhaConfirmacaoContatorLado2;
            Command.AtuadorA.falhaPosicionamento = Command.Standard.falhaPosicionamento;
            Command.AtuadorA.falhaLeituraPosicao = Command.Standard.falhaLeituraPosicao;
            Command.AtuadorA.reset = Command.Standard.Reset;
            return Command;
        }

        public static Utilidades.VariaveisGlobais.type_All Dword_TO_typeAtuadorA(UInt32 DWord, Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            Conversions.Dword_To_Bit(DWord, ref bits, true);

            //Atualiza DWord
            Command.DWord = DWord;

            Command.AtuadorA.ligaManual = bits[0];
            Command.AtuadorA.manual = bits[1];
            Command.AtuadorA.automatico = bits[2];
            Command.AtuadorA.manutencao = bits[3];
            Command.AtuadorA.Libera_Bloqueio_Manual = bits[4];
            Command.AtuadorA.emergencia = bits[5];
            Command.AtuadorA.liberado = bits[6];
            Command.AtuadorA.acionandoAutomatico = bits[7];
            Command.AtuadorA.falhaConfirmacaoContatorLado1 = bits[8];
            Command.AtuadorA.falhaConfirmacaoContatorLado2 = bits[9];
            Command.AtuadorA.falhaPosicionamento = bits[10];
            Command.AtuadorA.falhaLeituraPosicao = bits[11];
            Command.AtuadorA.reset = bits[12];
            Command.AtuadorA.bitReserva = bits[12];
            Command.AtuadorA.bitReserva_1 = bits[13];
            Command.AtuadorA.bitReserva_2 = bits[15];
            Command.AtuadorA.bitReserva_3 = bits[16];
            Command.AtuadorA.bitReserva_4 = bits[17];
            Command.AtuadorA.bitReserva_5 = bits[18];
            Command.AtuadorA.bitReserva_6 = bits[19];
            Command.AtuadorA.bitReserva_7 = bits[20];
            Command.AtuadorA.bitReserva_8 = bits[21];
            Command.AtuadorA.bitReserva_9 = bits[22];
            Command.AtuadorA.bitReserva_10 = bits[23];
            Command.AtuadorA.bitReserva_11 = bits[24];
            Command.AtuadorA.bitReserva_12 = bits[25];
            Command.AtuadorA.bitReserva_13 = bits[26];
            Command.AtuadorA.bitReserva_14 = bits[27];
            Command.AtuadorA.bitReserva_15 = bits[28];
            Command.AtuadorA.bitReserva_16 = bits[29];
            Command.AtuadorA.bitReserva_17 = bits[30];
            Command.AtuadorA.bitReserva_18 = bits[31];

            return Command;
        }

        public static UInt32 typeAtuadorA_TO_Dword(Utilidades.VariaveisGlobais.type_All Command)
        {
            bool[] bits = new bool[32];

            bits[0] = Command.AtuadorA.ligaManual;
            bits[1] = Command.AtuadorA.manual;
            bits[2] = Command.AtuadorA.automatico;
            bits[3] = Command.AtuadorA.manutencao;
            bits[4] = Command.AtuadorA.Libera_Bloqueio_Manual;
            bits[5] = Command.AtuadorA.emergencia;
            bits[6] = Command.AtuadorA.liberado;
            bits[7] = Command.AtuadorA.acionandoAutomatico;
            bits[8] = Command.AtuadorA.falhaConfirmacaoContatorLado1;
            bits[9] = Command.AtuadorA.falhaConfirmacaoContatorLado1;
            bits[10] = Command.AtuadorA.falhaPosicionamento;
            bits[11] = Command.AtuadorA.falhaLeituraPosicao;
            bits[12] = Command.AtuadorA.reset;
            bits[13] = Command.AtuadorA.bitReserva;
            bits[14] = Command.AtuadorA.bitReserva_1;
            bits[15] = Command.AtuadorA.bitReserva_2;
            bits[16] = Command.AtuadorA.bitReserva_3;
            bits[17] = Command.AtuadorA.bitReserva_4;
            bits[18] = Command.AtuadorA.bitReserva_5;
            bits[19] = Command.AtuadorA.bitReserva_6;
            bits[20] = Command.AtuadorA.bitReserva_7;
            bits[21] = Command.AtuadorA.bitReserva_8;
            bits[22] = Command.AtuadorA.bitReserva_9;
            bits[23] = Command.AtuadorA.bitReserva_10;
            bits[24] = Command.AtuadorA.bitReserva_11;
            bits[25] = Command.AtuadorA.bitReserva_12;
            bits[26] = Command.AtuadorA.bitReserva_13;
            bits[27] = Command.AtuadorA.bitReserva_14;
            bits[28] = Command.AtuadorA.bitReserva_15;
            bits[29] = Command.AtuadorA.bitReserva_16;
            bits[30] = Command.AtuadorA.bitReserva_17;
            bits[31] = Command.AtuadorA.bitReserva_18;

            Command.DWord = Conversions.Bit_To_Dword(ref bits, true);

            return Command.DWord;
        }
    }
}
