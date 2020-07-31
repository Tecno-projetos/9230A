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
            Command.Standard.Reset_Timer = Command.PD.resetHotimetroTotal;
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
            Command.PD.resetHotimetroTotal = Command.Standard.Reset_Timer;
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
            Command.PD.resetHotimetroTotal = bits[14];
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
            bits[14] = Command.PD.resetHotimetroTotal;
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
    }
}
