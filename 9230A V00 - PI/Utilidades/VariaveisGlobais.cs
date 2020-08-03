using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.Utilidades
{
    public enum typeEquip { PD, INV, SS, Atuador, BF, TRF }
    public enum typeCommand { PD, INV, SS, Atuador_Digital, Atuador_Analogico }

    public class VariaveisGlobais
    {
        #region Structs

        public struct type_PD
        {
            public bool ligaManual;
            public bool manual;
            public bool automatico;
            public bool manutencao;
            public bool Libera_Bloqueio_Manual;
            public bool reset;
            public bool ligado;
            public bool ligando;
            public bool desligando;
            public bool liberado;
            public bool falhaPartidaNaoConfirmou;
            public bool falhaContatorDesligou;
            public bool falhaDisjuntoDesligou;
            public bool falhaPartidaNaoDesligou;
            public bool resetHotimetroTotal;
            public bool resetHorimetroParcial;
            public bool emergencia;
            public bool disjuntorDesligado;
            public bool tempoManutencao;
            public bool falhaGeral;
            public bool bitReserva;
            public bool bitReserva_1;
            public bool bitReserva_2;
            public bool bitReserva_3;
            public bool bitReserva_4;
            public bool bitReserva_5;
            public bool bitReserva_6;
            public bool bitReserva_7;
            public bool bitReserva_8;
            public bool bitReserva_9;
            public bool bitReserva_10;
            public bool bitReserva_11;
            public Int32 SP_Manutencao;
            public Int32 HorimetroParcial;
            public Int32 HorimetroTotal;
            public Int32 Tempo_Limpeza;

        }

        //Padrão de bits, com todos os bits de todas as UDTs que existem no clp relacionada a equipamentos.
        public struct type_All
        {
            public type_Standard_GUI Standard;   //Tipo de estrutura padrão para GUI
                                                 //
            public type_PD PD;                 //Tipo de estrutura PD_PCM
            public UInt32 DWord;                 //Valor recebido do PLC
                                                 //
            public string Name;                  //Nome
            public string Tag;                   //Tag
            public string NumeroPartida;         //Numero da Partida
            public string PaginaProjeto;         //Pagina do Projeto

            public bool HabilitaCorrente;        //Habilitado Corrente

            public float CorrenteAtual;          //Corrente Atual
            public float VelocidadeAtual;
            public float CodigoFalha;
            public float CodigoAlarme;

            public float VelocidadeManual;
            public bool EnableWrite_Velocidade;
            public bool ReadVelocidadeManualOneTime;

            public bool ClickLeft;               //Click que recebe na UI e envia para controle.
            public bool ClickRight;              //Click que recebe na UI e envia para controle.
            public bool ClickMiddle;             //Click que recebe na UI e envia para controle.
            public bool ClickOpenWindowForked;   //Click abrir tela quando for Furcada.
            public bool ClickBodyForked;         //Click no corpo da furcada.
            public bool ResetClicks;             //Variavel auxiliar para poder resetar os clicks no equip UI.

            public bool enableReadDwordCommand; //Habilita leitura no Buffer do PLC
            public bool enableWriteDwordCommand; //Habilita escrita do Buffer do PLC

            public int Total_Horas;           //Total Horas Motor Ligado
            public int Parcial_Horas;         //Parcial Horas
            public int ManutencaoEm;          //Tempo que falta para Manutenção
            public short TempoLimpeza;          //Tempo de limpeza de cada motor, para a rota.

            public typeEquip TypeEquip;          //tipo do equipamento
            public typeCommand TypeCommand;      //tipo de palavra que o equipamento ira utilizar

            public bool HabilitaAtualizaUI;
        }

        public struct type_Standard_GUI
        {
            public bool Emergencia;

            //Comandos Partidas
            public bool Liga_Manual;
            public bool Manual;
            public bool Automatico;
            public bool Manutencao;
            public bool Libera_Bloqueio;
            public bool Reset;
            public bool Libera_Manual;

            //Comando Registro
            public bool Abre;
            public bool Fecha;
            public bool StatusSensorAberto;
            public bool StatusSensorFechado;
            public bool RegistroAbertoOuFechado;

            //Status Partidas
            public bool Ligado;
            public bool Ligando;
            public bool Desligando;
            public bool Bloqueado;
            public bool Liberado;

            //Falhas Partidas
            public bool Falha_Geral;
            public bool Falha_Partida_Nao_Confirmou;
            public bool Falha_Contator_Desligou;
            public bool Falha_Disjuntor_Desligou;
            public bool Falha_Partida_Nao_Desligou;
            public bool Falha_Sensor_Movimento;
            public bool Falha_Contator_Ligou;
            public bool Falha_Sensor_Externo;
            public bool Falha_Excedeu_Limite_Corrente;
            public bool Falha_Contator_PCM_Nao_Ligou;
            public bool Falha_Compensadora;
            public bool Falha_AltaTemperatura_Compensadora;
            public bool Disjuntor_Desligado;
            public bool Falha_Sensor_Abre;
            public bool Falha_Sensor_Fecha;
            public bool Falha_Posicao;

            //Resets
            public bool Reset_Timer;
            public bool Reset_Timer_Total;

            //Utilidades
            public bool Tempo_Manutencao;
            public bool Desabilita_Sensor_Embuchamento;
            public bool Desabilita_Bloqueio_Manual;

            //Furcadas
            public bool Abre_Esquerda;
            public bool Abre_Direita;
            public bool Esquerda_Aberto;
            public bool Direita_Aberto;
            public bool Abre_Meio;
            public bool Meio_Aberto;
            public bool Habilitado_Direita;
            public bool Habilitado_Esquerda;
            public bool Habilitado_Meio;
            public bool Confirma_Posicao_Furcada;


            //Bifurcadas Automáticas
            public bool Sensor_Direita;
            public bool Sensor_Esquerda;
            public bool EmTransicao;
            public bool Ligado_Direita;
            public bool Ligado_Esquerda;
            public bool Ligando_Direita;
            public bool Ligando_Esquerda;
            public bool Desligando_Direita;
            public bool Desligando_Esquerda;
            public bool Falha_Sensor_Direita;
            public bool Falha_Sensor_Esquerda;
            public bool Manual_Automatico;

        }

        public struct type_BufferPLC
        {
            public string Name;         //Nome do DB que esta no clp e alguma descrição
            public byte[] Buffer;       //Array de buffer
            public int DBNumber;        //Número do DB
            public int Start;           //Inicio de leitura e escrita do DB
            public int Size;            //Tamanho do Buffer
            public int Result;          //List error de retorno
            public bool Enable_Read;    //Habilita leitura
            public bool Enable_Write;   //Habilita Escrita
            public bool OnlyWrite;      //Buffer somente de escrita

        }

        public struct typeUsers
        {
            public string userLogged;
            public string groupUserLogged;
            public string passwordLogged;
            public int numberOfGroup;

            private string v1;
            private string v2;
            private string v3;
            private int v4;

            public typeUsers(string v1, string v2, string v3, int v4) : this()
            {
                userLogged = v1;
                groupUserLogged = v2;
                passwordLogged = v3;
                numberOfGroup = v4;
            }
        }

        #endregion

        #region Mensagens Padrões

        public static string faltaPermissaoMessage = "Permissão insuficiente para realizar esse tipo de operação!";
        public static string faltaUsuarioMessage = "Falta realizar o login!";

        public static string faltaPermissaoTitle = "Permissão insuficiente";
        public static string faltaUsuarioTitle = "Falta realizar o login";

        #endregion

        #region Telas Supervisão 

        public static TelasAuxiliares.Buffer_Diag Window_Buffer_Diagnostic = new TelasAuxiliares.Buffer_Diag();

        public static TelasAuxiliares.Diagnosticos Window_Diagnostic = new TelasAuxiliares.Diagnosticos();

        public static Telas_Fluxo.Fluxo Fluxo = new Telas_Fluxo.Fluxo();

        public static Usuarios.controleUsuario controleUsuario = new Usuarios.controleUsuario();

        #endregion

        #region Connection PLC

        public static string IP_Plc = "192.168.0.10";

        public static int Rack_PLC = 0;
        public static int Slot_PLC = 1;

        public static string IP_Plc_GS { get => IP_Plc; set => IP_Plc = value; }
        public static int Rack_PLC_GS { get => Rack_PLC; set => Rack_PLC = value; }
        public static int Slot_PLC_GS { get => Slot_PLC; set => Slot_PLC = value; }

        public static bool PLCConnected = false;

        public static type_BufferPLC[] Buffer_PLC = new type_BufferPLC[50];

        #endregion

        #region Connection DB and Type DB (SQLExpress or SqlCe)

        static bool DB_Connected;
        private static bool SQLCe;
        private static string Connection_DB_Create = "";
        private static string Connection_DB_Users = "";
        private static string Connection_DB_Equip = "";
        private static string Connection_DB_Current = "";


        public static string Connection_DB_Users_GS { get => Connection_DB_Users; set => Connection_DB_Users = value; }
        public static string Connection_DB_Equip_GS { get => Connection_DB_Equip; set => Connection_DB_Equip = value; }
        public static string Connection_DB_Current_GS { get => Connection_DB_Current; set => Connection_DB_Current = value; }
        public static string Connection_DB_Create_GS { get => Connection_DB_Create; set => Connection_DB_Create = value; }

        public static bool SQLCe_GS { get => SQLCe; set => SQLCe = value; }

        public static bool DB_Connected_GS
        {
            get { return DB_Connected; }
            set
            {
                DB_Connected = value;
            }
        }

        #endregion

        #region Controle de Usuário

        static typeUsers Users = new typeUsers(UserLogged_GS = "", GroupUserLogged_GS = "", PasswordLogged_GS = "", NumberOfGroup_GS = 0);

        public static string UserLogged_GS { get => Users.userLogged; set => Users.userLogged = value; }
        public static string GroupUserLogged_GS { get => Users.groupUserLogged; set => Users.groupUserLogged = value; }
        public static string PasswordLogged_GS { get => Users.passwordLogged; set => Users.passwordLogged = value; }
        public static int NumberOfGroup_GS { get => Users.numberOfGroup; set => Users.numberOfGroup = value; }

        #endregion











































































































































































































































































































        //--------------------
        //Emanuel







    }
}
