using System;

namespace _9230A_V00___PI.Utilidades
{
    public class Move_Bits
    {

        //Type Motor
        //=====================================================================================================================================

        //public static Utilidades.VariaveisGlobais.type_All typeMotor_TO_typeStandardGUI(Utilidades.VariaveisGlobais.type_All Command)
        //{
        //    Command.Standard.Liga_Manual = Command.Motor.Liga_Manual;
        //    Command.Standard.Manual = Command.Motor.Manual;
        //    Command.Standard.Automatico = !Command.Motor.Manual;
        //    Command.Standard.Manutencao = Command.Motor.Manutencao;
        //    Command.Standard.Sem_Bloqueio = Command.Motor.Sem_Bloqueio;
        //    Command.Standard.Reset = Command.Motor.Reset;
        //    Command.Standard.Seleciona_Rota = Command.Motor.Seleciona_Rota;
        //    Command.Standard.Ligado = Command.Motor.Ligado;
        //    Command.Standard.Ligando = Command.Motor.Ligando;
        //    Command.Standard.Desligando = Command.Motor.Desligando;
        //    Command.Standard.Bloqueado = Command.Motor.Bloqueado;
        //    Command.Standard.Falha_Partida_Nao_Confirmou = Command.Motor.Falha_Partida_Nao_Confirmou;
        //    Command.Standard.Falha_Contator_Desligou = Command.Motor.Falha_Contator_Desligou;
        //    Command.Standard.Falha_Disjuntor_Desligou = Command.Motor.Falha_Disjuntor_Desligou;
        //    Command.Standard.Falha_Partida_Nao_Desligou = Command.Motor.Falha_Partida_Nao_Desligou;
        //    Command.Standard.Reset_Rolamento_Horimetro = Command.Motor.Reset_Rolamento_Horimetro;
        //    Command.Standard.Reset_Caixa_Horimetro = Command.Motor.Reset_Caixa_Horimetro;
        //    Command.Standard.Habilitado_Ligar_Rota = Command.Motor.Habilitado_Ligar_Rota;
        //    Command.Standard.Emergencia = Command.Motor.Emergencia;
        //    Command.Standard.Disjuntor_Desligado = Command.Motor.Disjuntor_Desligado;
        //    Command.Standard.Liga_Manual_Sentido2 = Command.Motor.Liga_Manual_Sentido2;
        //    Command.Standard.Falha_Sensor_Movimento = Command.Motor.Falha_Sensor_Movimento;
        //    Command.Standard.Desabilita_Sensor_Movimento = Command.Motor.Desabilita_Sensor_Movimento;
        //    Command.Standard.Sensor_Movimento_Habilitado = Command.Motor.Sensor_Movimento_Habilitado;
        //    Command.Standard.Tempo_Rolamento_Atingido = Command.Motor.Tempo_Rolamento_Atingido;
        //    Command.Standard.Tempo_CxOleo_Atingido = Command.Motor.Tempo_CxOleo_Atingido;
        //    Command.Standard.Escreve_parametros_INV = Command.Motor.Escreve_parametros_INV;
        //    Command.Standard.Escrevendo_Parametros_INV = Command.Motor.Escrevendo_Parametros_INV;
        //    Command.Standard.Falha_Geral = Command.Motor.Falha_Geral;
        //    Command.Standard.Libera_Manual = Command.Motor.Libera_Manual;
        //    return Command;

        //}

        //public static Utilidades.VariaveisGlobais.type_All typeStandardGUI_TO_typeMotor(Utilidades.VariaveisGlobais.type_All Command)
        //{
        //    Command.Motor.Liga_Manual = Command.Standard.Liga_Manual;
        //    Command.Motor.Manual = Command.Standard.Manual;
        //    Command.Motor.Automatico = !Command.Standard.Manual;
        //    Command.Motor.Manutencao = Command.Standard.Manutencao;
        //    Command.Motor.Sem_Bloqueio = Command.Standard.Sem_Bloqueio;
        //    Command.Motor.Reset = Command.Standard.Reset;
        //    Command.Motor.Seleciona_Rota = Command.Standard.Seleciona_Rota;
        //    Command.Motor.Ligado = Command.Standard.Ligado;
        //    Command.Motor.Ligando = Command.Standard.Ligando;
        //    Command.Motor.Desligando = Command.Standard.Desligando;
        //    Command.Motor.Bloqueado = Command.Standard.Bloqueado;
        //    Command.Motor.Falha_Partida_Nao_Confirmou = Command.Standard.Falha_Partida_Nao_Confirmou ;
        //    Command.Motor.Falha_Contator_Desligou = Command.Standard.Falha_Contator_Desligou;
        //    Command.Motor.Falha_Disjuntor_Desligou = Command.Standard.Falha_Disjuntor_Desligou;
        //    Command.Motor.Falha_Partida_Nao_Desligou = Command.Standard.Falha_Partida_Nao_Desligou;
        //    Command.Motor.Reset_Rolamento_Horimetro = Command.Standard.Reset_Rolamento_Horimetro;
        //    Command.Motor.Reset_Caixa_Horimetro = Command.Standard.Reset_Caixa_Horimetro;
        //    Command.Motor.Habilitado_Ligar_Rota = Command.Standard.Habilitado_Ligar_Rota;
        //    Command.Motor.Emergencia = Command.Standard.Emergencia;
        //    Command.Motor.Disjuntor_Desligado = Command.Standard.Disjuntor_Desligado;
        //    Command.Motor.Liga_Manual_Sentido2 = Command.Standard.Liga_Manual_Sentido2;
        //    Command.Motor.Falha_Sensor_Movimento = Command.Standard.Falha_Sensor_Movimento;
        //    Command.Motor.Desabilita_Sensor_Movimento = Command.Standard.Desabilita_Sensor_Movimento;
        //    Command.Motor.Sensor_Movimento_Habilitado = Command.Standard.Sensor_Movimento_Habilitado;
        //    Command.Motor.Tempo_Rolamento_Atingido = Command.Standard.Tempo_Rolamento_Atingido;
        //    Command.Motor.Tempo_CxOleo_Atingido = Command.Standard.Tempo_CxOleo_Atingido;
        //    Command.Motor.Escreve_parametros_INV = Command.Standard.Escreve_parametros_INV;
        //    Command.Motor.Escrevendo_Parametros_INV = Command.Standard.Escrevendo_Parametros_INV;
        //    Command.Motor.Falha_Geral = Command.Standard.Falha_Geral;
        //    Command.Motor.Libera_Manual = Command.Standard.Libera_Manual;
        //    return Command;
        //}

        //public static Utilidades.VariaveisGlobais.type_All Dword_TO_typeMotor(UInt32 DWord, Utilidades.VariaveisGlobais.type_All Command)
        //{
        //    bool[] bits = new bool[32];

        //    Conversions.Dword_To_Bit(DWord, ref bits, true);

        //    //Atualiza DWord
        //    Command.DWord = DWord;

        //    Command.Motor.Liga_Manual = bits[0];
        //    Command.Motor.Manual = bits[1];
        //    Command.Motor.Automatico = bits[2];
        //    Command.Motor.Manutencao = bits[3];
        //    Command.Motor.Sem_Bloqueio = bits[4];
        //    Command.Motor.Reset = bits[5];
        //    Command.Motor.Seleciona_Rota = bits[6];
        //    Command.Motor.Nao_Usar = bits[7];
        //    Command.Motor.Ligado = bits[8];
        //    Command.Motor.Ligando = bits[9];
        //    Command.Motor.Desligando = bits[10];
        //    Command.Motor.Bloqueado = bits[11];
        //    Command.Motor.Falha_Partida_Nao_Confirmou = bits[12];
        //    Command.Motor.Falha_Contator_Desligou = bits[13];
        //    Command.Motor.Falha_Disjuntor_Desligou = bits[14];
        //    Command.Motor.Falha_Partida_Nao_Desligou = bits[15];
        //    Command.Motor.Reset_Rolamento_Horimetro = bits[16];
        //    Command.Motor.Reset_Caixa_Horimetro = bits[17];
        //    Command.Motor.Habilitado_Ligar_Rota = bits[18];
        //    Command.Motor.Emergencia = bits[19];
        //    Command.Motor.Disjuntor_Desligado = bits[20];
        //    Command.Motor.Liga_Manual_Sentido2 = bits[21];
        //    Command.Motor.Falha_Sensor_Movimento = bits[22];
        //    Command.Motor.Desabilita_Sensor_Movimento = bits[23];
        //    Command.Motor.Sensor_Movimento_Habilitado = bits[24];
        //    Command.Motor.Tempo_Rolamento_Atingido = bits[25];
        //    Command.Motor.Tempo_CxOleo_Atingido = bits[26];
        //    Command.Motor.Escreve_parametros_INV = bits[27];
        //    Command.Motor.Escrevendo_Parametros_INV = bits[28];
        //    Command.Motor.Falha_Geral = bits[29];
        //    Command.Motor.Libera_Manual = bits[30];
        //    Command.Motor.Bit31 = bits[31];

        //    return Command;
        //}

        //public static UInt32 typeMotor_TO_Dword(Utilidades.VariaveisGlobais.type_All Command)
        //{
        //    bool[] bits = new bool[32];

        //    bits[0] = Command.Motor.Liga_Manual;
        //    bits[1] = Command.Motor.Manual;
        //    bits[2] = Command.Motor.Automatico;
        //    bits[3] = Command.Motor.Manutencao;
        //    bits[4] = Command.Motor.Sem_Bloqueio;
        //    bits[5] = Command.Motor.Reset;
        //    bits[6] = Command.Motor.Seleciona_Rota;
        //    bits[7] = Command.Motor.Nao_Usar;
        //    bits[8] = Command.Motor.Ligado;
        //    bits[9] = Command.Motor.Ligando;
        //    bits[10] = Command.Motor.Desligando;
        //    bits[11] = Command.Motor.Bloqueado;
        //    bits[12] = Command.Motor.Falha_Partida_Nao_Confirmou;
        //    bits[13] = Command.Motor.Falha_Contator_Desligou;
        //    bits[14] = Command.Motor.Falha_Disjuntor_Desligou;
        //    bits[15] = Command.Motor.Falha_Partida_Nao_Desligou;
        //    bits[16] = Command.Motor.Reset_Rolamento_Horimetro;
        //    bits[17] = Command.Motor.Reset_Caixa_Horimetro;
        //    bits[18] = Command.Motor.Habilitado_Ligar_Rota;
        //    bits[19] = Command.Motor.Emergencia;
        //    bits[20] = Command.Motor.Disjuntor_Desligado;
        //    bits[21] = Command.Motor.Liga_Manual_Sentido2;
        //    bits[22] = Command.Motor.Falha_Sensor_Movimento;
        //    bits[23] = Command.Motor.Desabilita_Sensor_Movimento;
        //    bits[24] = Command.Motor.Sensor_Movimento_Habilitado;
        //    bits[25] = Command.Motor.Tempo_Rolamento_Atingido;
        //    bits[26] = Command.Motor.Tempo_CxOleo_Atingido;
        //    bits[27] = Command.Motor.Escreve_parametros_INV;
        //    bits[28] = Command.Motor.Escrevendo_Parametros_INV;
        //    bits[29] = Command.Motor.Falha_Geral;
        //    bits[30] = Command.Motor.Libera_Manual;
        //    bits[31] = Command.Motor.Bit31;

        //    Command.DWord = Conversions.Bit_To_Dword(ref bits, true);

        //    return Command.DWord;
        //}
    }
}
