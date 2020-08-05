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
    }
}
