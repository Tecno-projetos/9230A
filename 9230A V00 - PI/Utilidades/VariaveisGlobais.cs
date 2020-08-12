﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;

namespace _9230A_V00___PI.Utilidades
{
    public enum typeEquip { PD, INV, SS, Atuador, BF, TRF }
    public enum typeCommand { PD, INV, SS, Atuador_Digital, Atuador_Analogico }

    public class VariaveisGlobais
    {
        #region Structs

        public struct type_SS
        {
            public type_SS(string value) : this()
            {
                offSet_SP_Manutencao = 4;
                offSet_HorimetroParcial = 8;
                offSet_HorimetroTotal = 12;
                offSet_Tempo_Limpeza = 16;
                offSet_Corrente_Atual = 20;
                offSet_SP_Corrente_Motor_Vazio = 24;
                offSet_SP_Tempo_Reversao = 28;
                offSet_Tempo_Reversao_Atual = 32;

            }

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
            public bool resetHorimetroTotal;
            public bool resetHorimetroParcial;
            public bool emergencia;
            public bool disjuntorDesligado;
            public bool tempoManutencao;
            public bool falhaGeral;
            public bool inverterSentidoGiro;
            public bool sentidoGiro;
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
            public Int32 SP_Manutencao;
            public Int32 HorimetroParcial;
            public Int32 HorimetroTotal;
            public Int32 Tempo_Limpeza;
            public float Corrente_Atual;
            public float SP_Corrente_Motor_Vazio;
            public Int32 SP_Tempo_Reversao;
            public Int32 Tempo_Reversao_Atual;

            public int offSet_SP_Manutencao;
            public int offSet_HorimetroParcial;
            public int offSet_HorimetroTotal;
            public int offSet_Tempo_Limpeza;
            public int offSet_Corrente_Atual;
            public int offSet_SP_Corrente_Motor_Vazio;
            public int offSet_SP_Tempo_Reversao;
            public int offSet_Tempo_Reversao_Atual;

        }

        public struct type_PD
        {

            public type_PD(string value) : this()
            {
                offSet_SP_Manutencao = 4;
                offSet_HorimetroParcial = 8;
                offSet_HorimetroTotal = 12;
                offSet_Tempo_Limpeza = 16;
            }

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
            public bool resetHorimetroTotal;
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

            public int offSet_SP_Manutencao;
            public int offSet_HorimetroParcial;
            public int offSet_HorimetroTotal;
            public int offSet_Tempo_Limpeza;

        }

        public struct type_INV
        {
            public type_INV(string value) : this()
            {
                offSet_Velocidade_Manual = 4;
                offSet_Velocidade_Automatica_Solicita = 8;
                offSet_Velocidade_Atual = 12;
                offSet_Velocidade_Nominal = 16;
                offSet_SP_Corrente_Motor_Vazio = 20;
                offSet_Corrente_Atual = 24;
                offSet_Codigo_Alarme = 28;
                offSet_Codigo_Falha = 32;
                offSet_SP_Manutencao = 36;
                offSet_HorimetroParcial = 40;
                offSet_HorimetroTotal = 44;
                offSet_Tempo_Limpeza = 48;
            }

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
            public bool resetHorimetroTotal;
            public bool resetHorimetroParcial;
            public bool emergencia;
            public bool disjuntorDesligado;
            public bool tempoManutencao;
            public bool falha;
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
            public bool bitReserva_12;
            public bool bitReserva_13;
            public bool bitReserva_14;
            public bool bitReserva_15;
            public float Velocidade_Manual;
            public float Velocidade_Automatica_Solicita;
            public float Velocidade_Atual;
            public float Velocidade_Nominal;
            public float SP_Corrente_Motor_Vazio;
            public float Corrente_Atual;
            public float Codigo_Alarme;
            public float Codigo_Falha;
            public Int32 SP_Manutencao;
            public Int32 HorimetroParcial;
            public Int32 HorimetroTotal;
            public Int32 Tempo_Limpeza;

            public int offSet_Velocidade_Manual;
            public int offSet_Velocidade_Automatica_Solicita;
            public int offSet_Velocidade_Atual;
            public int offSet_Velocidade_Nominal;
            public int offSet_SP_Corrente_Motor_Vazio;
            public int offSet_Corrente_Atual;
            public int offSet_Codigo_Alarme;
            public int offSet_Codigo_Falha;
            public int offSet_SP_Manutencao;
            public int offSet_HorimetroParcial;
            public int offSet_HorimetroTotal;
            public int offSet_Tempo_Limpeza;
        }

        public struct type_AtuadorDigital
        {
            public bool manual;
            public bool automatico;
            public bool manutencao;
            public bool Libera_Bloqueio_Manual;
            public bool emergencia;
            public bool liberado;
            public bool acionaLado1;
            public bool acionaLado2;
            public bool acionandoLado1;
            public bool acionandoLado2;
            public bool acionandoAutomatico;
            public bool emPosicaoLado1;
            public bool emPosicaoLado2;
            public bool falhaAcionandoLado1;
            public bool falhaAcionandoLado2;
            public bool falha2PosicoesAtiva;
            public bool falhaConfirmacaoContatorLado1;
            public bool falhaConfirmacaoContatorLado2;
            public bool reset;
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
            public bool bitReserva_12;

        }

        public struct type_AtuadorAnalogico
        {

            public type_AtuadorAnalogico(string value) : this()
            {
                offSet_PosicaoSolicitadaAutomatico = 28;
                offSet_SP_Posicao_Manual = 32;
                offSet_PosicaoAtual = 36;


            }

            public bool ligaManual;
            public bool manual;
            public bool automatico;
            public bool manutencao;
            public bool Libera_Bloqueio_Manual;
            public bool emergencia;
            public bool liberado;
            public bool acionandoAutomatico;
            public bool falhaConfirmacaoContatorLado1;
            public bool falhaConfirmacaoContatorLado2;
            public bool falhaPosicionamento;
            public bool falhaLeituraPosicao;
            public bool reset;
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
            public bool bitReserva_12;
            public bool bitReserva_13;
            public bool bitReserva_14;
            public bool bitReserva_15;
            public bool bitReserva_16;
            public bool bitReserva_17;
            public bool bitReserva_18;

            public float PosicaoSolicitadaAutomatico;
            public float SP_Posicao_Manual;
            public float PosicaoAtual;

            public int offSet_PosicaoSolicitadaAutomatico;
            public int offSet_SP_Posicao_Manual;
            public int offSet_PosicaoAtual;
        }


        //Padrão de bits, com todos os bits de todas as UDTs que existem no clp relacionada a equipamentos.
        public struct type_All
        {
            public type_All(string value) : this()
            {
                PD = new type_PD("");
                INV = new type_INV("");
                SS = new type_SS("");
                AtuadorA = new type_AtuadorAnalogico("");
            }

            public UInt32 DWord;                  //Dword bits palavra de comando e status
            public type_Standard_GUI Standard;   //Tipo de estrutura padrão para GUI
                                                 //
            public type_PD PD;                   //Tipo de estrutura PD_PCM
            
            public type_INV INV;
            public type_SS SS;
            public type_AtuadorDigital AtuadorD;
            public type_AtuadorAnalogico AtuadorA;

            public int initialOffSet;
            public int bufferPlc;
            public string Nome;                  //Nome
            public string Tag;                   //Tag
            public string NumeroPartida;         //Numero da Partida
            public string PaginaProjeto;         //Pagina do Projeto

            public typeEquip TypeEquip;          //tipo do equipamento
            public typeCommand TypeCommand;      //tipo de palavra que o equipamento ira utilizar

         
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
            public bool inverterSentidoGiro;

            //Comandos Atuadores
            public bool AcionaLado1;
            public bool AcionaLado2;


            //Status Partidas
            public bool Ligado;
            public bool Ligando;
            public bool Desligando;
            public bool Liberado;
            public bool SentidoGiro;
            public bool AcionandoLado1;
            public bool AcionandoLado2;
            public bool AcionandoAutomatico;
            public bool EmPosicaoLado1;
            public bool EmPosicaoLado2;

            //Falhas Partidas
            public bool Falha_Geral;
            public bool Falha_Partida_Nao_Confirmou;
            public bool Falha_Contator_Desligou;
            public bool Falha_Disjuntor_Desligou;
            public bool Falha_Partida_Nao_Desligou;
            public bool Disjuntor_Desligado;

            //Falhas Atuadores
            public bool FalhaAcionandoLado1;
            public bool FalhaAcionandoLado2;
            public bool Falha2PosicoesAtiva;
            public bool FalhaConfirmacaoContatorLado1;
            public bool FalhaConfirmacaoContatorLado2;

            public bool falhaPosicionamento;
            public bool falhaLeituraPosicao;

            //Resets
            public bool Reset_Timer;
            public bool Reset_Timer_Total;

            //Utilidades
            public bool Tempo_Manutencao;
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

        public static Telas_Fluxo.manutencao manutencao = new Telas_Fluxo.manutencao();

        public static Telas_Fluxo.configuracoes configuracoes = new Telas_Fluxo.configuracoes();

        public static Telas_Fluxo.producao producao = new Telas_Fluxo.producao();

        public static Telas_Fluxo.receitas receitas = new Telas_Fluxo.receitas();

        public static Telas_Fluxo.relatorios relatorios = new Telas_Fluxo.relatorios();


        #endregion

        #region Connection PLC

        //Cria comunicação com CLP
        public static Comunicacao.CallCommunicationPLC CommunicationPLC = new Comunicacao.CallCommunicationPLC(0, 10);

        private static string IP_Plc = "192.168.0.10";

        private static int Rack_PLC = 0;
        private static int Slot_PLC = 1;

        public static string IP_Plc_GS { get => IP_Plc; set => IP_Plc = value; }
        public static int Rack_PLC_GS { get => Rack_PLC; set => Rack_PLC = value; }
        public static int Slot_PLC_GS { get => Slot_PLC; set => Slot_PLC = value; }

        public static type_BufferPLC[] Buffer_PLC = new type_BufferPLC[50];

        #endregion

        #region Pastas

        private static string folderSql = @"C:\SQLCe"; //nome do diretorio a ser criado
        private static string folderLogs = @"C:\Logs";


        #endregion

        #region Connection DB and Type DB (SQLExpress or SqlCe)

        static bool DB_Connected;
        private static bool SQLCe;
        private static string Connection_DB_Create = "";
        private static string Connection_DB_Users = @"Data Source =" + folderSql + "\\" + "BeckerUsers" + ".sdf";
        private static string Connection_DB_Equip = @"Data Source =" + folderSql + "\\" + "BeckerEquip" + ".sdf";
        private static string Connection_DB_Current = "";
        private static string Connection_DB_Receitas = @"Data Source =" + folderSql + "\\" + "BeckerReceitas" + ".sdf";

        public static string Connection_DB_Users_GS { get => Connection_DB_Users; set => Connection_DB_Users = value; }
        public static string Connection_DB_Equip_GS { get => Connection_DB_Equip; set => Connection_DB_Equip = value; }
        public static string Connection_DB_Current_GS { get => Connection_DB_Current; set => Connection_DB_Current = value; }
        public static string Connection_DB_Create_GS { get => Connection_DB_Create; set => Connection_DB_Create = value; }
        public static string Connection_DB_Receitas_GS { get => Connection_DB_Receitas; set => Connection_DB_Receitas = value; }

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

        #region Cor de Fundo Icones

        public static SolidColorBrush Verde = new SolidColorBrush(Colors.Green);

        public static SolidColorBrush Branco = new SolidColorBrush(Colors.White);

        #endregion

        private static void createFolder(string folder) 
        {
          
            //Se o diretório não existir...

            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

        }

        public static void Load_Connection()
        {
            //Cria pastas para Apliacação
            createFolder(folderSql);
            createFolder(folderLogs);

            SQLCe_GS = true;

            DB_Connected_GS = true;

            //Criação dos Bancos
            DataBase.SqlGlobalFuctions.Create_DB("BeckerUsers");
            DataBase.SqlGlobalFuctions.Create_DB("BeckerEquip");

            DataBase.SqlGlobalFuctions.Create_DB("BeckerProdutos");
            DataBase.SqlGlobalFuctions.Create_DB("BeckerReceitas");

            //Inicializa Tabelas
            DataBase.SqlFunctionsUsers.Initialize_ProgramDBCA();
            DataBase.SqlFunctionsEquips.ExistTable();
            DataBase.SqlFunctionsProdutos.ExistTable();
            DataBase.SqlFunctionsReceitas.Create_Table_Receita();
            DataBase.SQLFunctionsProducao.Create_Table_Producao();
        }

        public static List<Produto> listProdutos = new List<Produto>();

        public static List<Receita> listReceitas = new List<Receita>();

        public static Receita ReceitaCadastro = new Receita();

        public static Producao ProducaoReceita = new Producao();

        public static List<Producao> PesquisaProducao = new List<Producao>();

        public static EspecificacoesEquipamentos ValoresEspecificacoesEquipamentos = new EspecificacoesEquipamentos();
    }

    public class functions
    {
        public static void atualizalistProdutos()
        {
            VariaveisGlobais.listProdutos.Clear();

            DataTable dt = DataBase.SqlFunctionsProdutos.getTableProdutos();

            Produto dummyProduto;

            foreach (DataRow item in dt.Rows)
            {
                dummyProduto = new Produto();

                dummyProduto.id = (int)item.ItemArray[0];
                dummyProduto.codigo = (string)item.ItemArray[1];
                dummyProduto.descricao = (string)item.ItemArray[2];
                dummyProduto.densidade = (float)item.ItemArray[3];
                dummyProduto.tipoProduto = (string)item.ItemArray[4];
                dummyProduto.observacao = (string)item.ItemArray[5];

                VariaveisGlobais.listProdutos.Add(dummyProduto);
            }
        }

        public static void atualizalistReceitas()
        {
            VariaveisGlobais.listReceitas.Clear();

            DataTable dtReceitas = DataBase.SqlFunctionsReceitas.getReceitas();

            Receita dummyReceita;

            atualizalistProdutos();

            foreach (DataRow item in dtReceitas.Rows)
            {
                dummyReceita = new Receita();

                dummyReceita.id = (int)item.ItemArray[0];
                dummyReceita.nomeReceita = (string)item.ItemArray[1];
                dummyReceita.pesoBase = (float)item.ItemArray[2];
                dummyReceita.observacao = (string)item.ItemArray[3];

                DataTable dtProdutosReceita = DataBase.SqlFunctionsReceitas.getProdutosReceita(dummyReceita.nomeReceita);

                foreach (DataRow item1 in dtProdutosReceita.Rows)
                {
                    ProdutoReceita dummyProdutoReceita = new ProdutoReceita();
                    Produto dummyProduto = new Produto();

                    dummyProduto.codigo = (string)item1.ItemArray[1]; //Codigo do produto 
                    dummyProdutoReceita.pesoPorProduto = (float)item1.ItemArray[2]; //Peso do produto na receita     
                    dummyProdutoReceita.tipoDosagemMateriaPrima = (string)item1.ItemArray[3]; //Tipo da dosagem do produto na receita

                    ActualizeValuesProduto(ref dummyProduto); //pega os valores do produto e atualiza esse produto


                    dummyProdutoReceita.produto = dummyProduto;
                    dummyReceita.listProdutos.Add(dummyProdutoReceita);
                }

                VariaveisGlobais.listReceitas.Add(dummyReceita);
            }

        }

        private static void ActualizeValuesProduto(ref Produto prod)
        {
            //Atualiza a lista de produtos a partir do banco de dados
            
            string codigo = prod.codigo;

            var index = VariaveisGlobais.listProdutos.FindIndex(x => x.codigo == codigo);

            prod.densidade = VariaveisGlobais.listProdutos[index].densidade;
            prod.descricao = VariaveisGlobais.listProdutos[index].descricao;
            prod.id = VariaveisGlobais.listProdutos[index].id;
            prod.observacao = VariaveisGlobais.listProdutos[index].observacao;
            prod.tipoProduto = VariaveisGlobais.listProdutos[index].tipoProduto;
        }

    }

    //

    public class EspecificacoesEquipamentos
    {
        public float VolumeMaximoPermitidoSilo1_2 { get; set; } //Volume máximo permitido no silo 1 e silo 2 m³

        public float VolumeMaximoPermitidoBalanca{ get; set; } //Volume máximo permitido na balança

        public float VolumeMaximoPermitidoPreMisturador { get; set; } //Volume máximo permitido no Pré Misturador

        public float VolumeMaximoPermitidoPosMisturador { get; set; } //Volume máximo permitido no Pos Misturador

        public float PesoMaximoPermitidoBalanca { get; set; } //Peso máximo permitido na balança

        public float PesoMaximoPermitidoPreMisturador { get; set; } //Peso máximo permitido no Pré Misturador

        public float PesoMaximoPermitidoPosMisturador { get; set; } //Peso máximo permitido no Pos Misturador

        public Int32 TempoPreMistura { get; set; } //Tempo de pré mistura

        public Int32 TempoPosMistura { get; set; } //Tempo de pos mistura

        public float VolumeMaximoPermitidoBatelada()
        {
            float value = VolumeMaximoPermitidoBalanca;

            if (VolumeMaximoPermitidoPreMisturador < value)
            {
                value = VolumeMaximoPermitidoPreMisturador;
            }

            if (VolumeMaximoPermitidoPosMisturador < value)
            {
                value = VolumeMaximoPermitidoPosMisturador;
            }

            return value;
        }

        public float PesoMaximoPermitidoBatelada()
        {
            float value = PesoMaximoPermitidoBalanca;

            if (PesoMaximoPermitidoPreMisturador < value)
            {
                value = PesoMaximoPermitidoPreMisturador;
            }

            if (PesoMaximoPermitidoPosMisturador < value)
            {
                value = PesoMaximoPermitidoPosMisturador;
            }

            return value;
        }

        public bool ValoresPreenchidos()
        {
            if (VolumeMaximoPermitidoSilo1_2 != 0)
            {
                if (VolumeMaximoPermitidoBalanca != 0)
                {
                    if (VolumeMaximoPermitidoPreMisturador != 0)
                    {
                        if (VolumeMaximoPermitidoPosMisturador != 0)
                        {
                            if (PesoMaximoPermitidoBalanca != 0)
                            {
                                if (PesoMaximoPermitidoPreMisturador != 0)
                                {
                                    if (PesoMaximoPermitidoPosMisturador != 0)
                                    {
                                        if (TempoPreMistura != 0)
                                        {
                                            if (TempoPosMistura != 0)
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }

    public class Produto
    {
        public int id { get; set; }
        public string codigo { get; set; } 

        public string descricao { get; set; }

        public float densidade { get; set; }

        public string tipoProduto { get; set; }

        public string observacao { get; set; }
    }

    public class ProdutoReceita
    {
        public Produto produto { get; set; }

        public float pesoPorProduto = 0.0f;

        public string tipoDosagemMateriaPrima = ""; //"Automático" ou "Manual" - Na matéria prima pode ser dosado o produto manualmente ou automaticamente
    }

    public class Receita
    {
        public int id = -1;

        public string nomeReceita = "";

        public float pesoBase { get; set; }

        public List<ProdutoReceita> listProdutos = new List<ProdutoReceita>();

        public string observacao = "";
    }

    public class ProdutoBatelada : Produto
    {
        /// <summary>
        /// Atualizado na tela VerificacaoBateladas
        /// </summary>
        public int idProducao { get; set; }

        /// <summary>
        /// Atualizado na tela VerificacaoBateladas
        /// </summary>
        public float pesoDesejado { get; set; }

        public float pesoDosado { get; set; }

        public float volumeDesejado { get; set; }

        public string statusItem { get; set; }

    }

    public class Batelada
    {

        public List<ProdutoBatelada> produtos = new List<ProdutoBatelada>();

        public int numeroBatelada { get; set; }

        public float pesoDesejado { get; set; }

        public float pesoDosado { get; set; }

        public float volumeDesejado { get; set; }
    }

    public class Producao
    {
        public int id {get; set;} // Id da produção

        /// <summary>
        /// Atualizado na tela ProduçãoTelaInicial
        /// </summary>
        public int IdReceitaBase { get; set; } // Id da receita base

        /// <summary>
        /// Atualizado na tela ProduçãoTelaInicial
        /// </summary>
        public Receita receita { get; set; } //Receita Base

        /// <summary>
        /// Atualizado na tela ConfiguracaoReceitaProducao
        /// </summary>
        public int quantidadeBateladas { get; set; } //Quantidade de bateladas

        /// <summary>
        /// Atualizado na tela ConfiguracaoReceitaProducao
        /// </summary>
        public List<Batelada> batelada = new List<Batelada>(); //Lista das bateladas

        /// <summary>
        /// 
        /// </summary>
        public Int32 tempoPreMistura { get; set; } //Tempo de pré mistura

        /// <summary>
        /// 
        /// </summary>
        public Int32 tempoPosMistura { get; set; } //Tempo de pos mistura

        /// <summary>
        /// Atualizado na tela ConfiguracaoReceitaProducao
        /// </summary>
        public float pesoTotalProducao { get; set; } //Peso total da produção - 

        /// <summary>
        /// 
        /// </summary>
        public float volumeTotalProducao { get; set; }//Volume total da produção

        /// <summary>
        /// Atualizado na tela ConfiguracaoReceitaProducao
        /// </summary>
        public string CodigoProdutoDosagemAutomaticaSilo1 { get; set; } //Codigo do produto que sera dosado automaticamente no silo 1.

        /// <summary>
        /// Atualizado na tela ConfiguracaoReceitaProducao
        /// </summary>
        public string CodigoProdutoDosagemAutomaticaSilo2 { get; set; } //Codigo do produto que sera dosado automaticamente no silo 2.
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime dateTimeInicioProducao { get; set; } //Data Inicio produção
       
        /// <summary>
        /// 
        /// </summary>
        public DateTime dateTimeFimProducao { get; set; } //Data fim da produção

        /// <summary>
        /// 
        /// </summary>
        public bool IniciouProducao { get; set; } //Iniciou Produção

        /// <summary>
        /// 
        /// </summary>
        public bool FinalizouProducao { get; set; } //Finalizou Produção

        /// <summary>
        /// 
        /// </summary>
        public float pesoTotalProduzido { get; set; } //Peso total produzido

        /// <summary>
        /// 
        /// </summary>
        public float volumeTotalProduzido { get; set; }//Volume total produzido

    }




}
