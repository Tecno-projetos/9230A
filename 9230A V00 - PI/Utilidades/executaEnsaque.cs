using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace _9230A_V00___PI.Utilidades
{
    public class executaEnsaque
    {
        #region Variaveis
        /// <summary>
        /// Vatiavel de controle
        /// </summary>
        private Utilidades.VariaveisGlobais.Ensaque ensaque = new Utilidades.VariaveisGlobais.Ensaque(); //Slot 1 

        private Utilidades.VariaveisGlobais.IndicadorPesagem indicadorPesagem = new Utilidades.VariaveisGlobais.IndicadorPesagem(); 

        /// <summary>
        /// Variavel buffer do DB controle automático ensaque
        /// </summary>
        int bufferPlcEnsaque;

        /// <summary>
        /// Buffer onde se encontra o Indicador da balança
        /// </summary>
        int bufferCLPBalanca;


        #endregion


        /// <summary>
        /// Controle de Buffer
        /// </summary>
        /// <param name="bufferPlcEnsaque">Variavel buffer do DB controle automático ensaque </param>
        /// <param name="bufferCLPBalanca">Buffer onde se encontra o Indicador da balança</param>
        public executaEnsaque(int bufferPlcEnsaque, int bufferCLPBalanca)
        {
            this.bufferPlcEnsaque = bufferPlcEnsaque;
            this.bufferCLPBalanca = bufferCLPBalanca;
        }

        #region Encapsulamentos

        /// <summary>
        /// Função get do controle de Ensaque para utilizar em lugares diferentes
        /// </summary>
        public VariaveisGlobais.Ensaque Ensaque_Get { get => ensaque; }

        /// <summary>
        /// Função get do controle do Indicador de pesagem Ensaque para utilizar em lugares diferentes
        /// </summary>
        public VariaveisGlobais.IndicadorPesagem IndicadorPesagem_Get { get => indicadorPesagem;}

        #endregion


        /// <summary>
        /// Função para atualizar ciclico
        /// </summary>
        public void Actualize() 
        {
            readVariablesBuffer();
        }

        /// <summary>
        /// Ler váriaveis do CLP
        /// </summary>
        private void readVariablesBuffer()
        {
            //Controle Ensaque
            //=====================================================================================================================================================================================
            ensaque.controleEnsaque = Move_Bits.DwordTocontroleEnsaque(Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 266), ensaque.controleEnsaque);

            //Leitura Reais
            ensaque.controleEnsaque.pesoDesejado = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 270);
            ensaque.controleEnsaque.pesoSacoAtual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 274);

            //Controle Indicador de Pesagem
            //=====================================================================================================================================================================================

            //Leitura pavra de controle indicador de pessagem
            indicadorPesagem = Move_Bits.ByteToIndicadorPesagem(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferCLPBalanca].Buffer, 410), indicadorPesagem);

            //Leitura Reais
            indicadorPesagem.Valor_Atual_Indicador = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferCLPBalanca].Buffer, 398);

        }

        #region Escritas CLP

        /// <summary>
        /// Função para Inverter o bit de Iniciar ensaque.
        /// </summary>
        public void InverbitIniciouEnsaque()
        {
            if (ensaque.controleEnsaque.Habilita_Iniciar_Ensaque)
            {
                VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Read = false;

                ensaque.controleEnsaque.IniciaEnsaque = true;

                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 266, Move_Bits.EnsaqueToDwordControleEnsaque(ensaque.controleEnsaque)); //Atualiza os Bits do command

                VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Write = true;
            }
        }

        /// <summary>
        /// Função para Inverter o bit de Iniciar ensaque.
        /// </summary>
        public void InverbitTerminouEnsaque()
        {
            if (ensaque.controleEnsaque.HabilitaFinalizarEnsaque)
            {
                VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Read = false;

                ensaque.controleEnsaque.IniciaEnsaque = false;
                ensaque.controleEnsaque.TerminaEnsaque = true;

                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 266, Move_Bits.EnsaqueToDwordControleEnsaque(ensaque.controleEnsaque)); //Atualiza os Bits do command

                VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Write = true;

            }
        }

        /// <summary>
        /// Função para escrever peso desejado de cada saco.
        /// </summary>
        public void WritePesoDesejado(float pesoDesejado)
        {
                VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Read = false;

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 270, pesoDesejado); //Atualiza os Bits do command

                VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Write = true;


        }

        /// <summary>
        /// Função para setar bit de supervisorio salvou dados do saco no banco de dados
        /// </summary>
        public void SetBitSalvouDadosSacoBD()
        {

            VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Read = false;

            ensaque.controleEnsaque.Supervisorio_Salvou_Saco_Atual = true;

            Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Buffer, 266, Move_Bits.EnsaqueToDwordControleEnsaque(ensaque.controleEnsaque)); //Atualiza os Bits do command

            VariaveisGlobais.Buffer_PLC[bufferPlcEnsaque].Enable_Write = true;

            
        }


        #endregion

        #region Banco de Dados
        public void producaoEnsaque(int IdProducao) 
        {
            DataBase.SqlFunctionsEnsaques.IntoDate_Table_ProducaoEnsaque(IdProducao, ensaque.controleEnsaque.pesoDesejado, DateTime.Now, DateTime.Now, "");
        }

        public void updateProducaoTerminou() 
        {
            DataBase.SqlFunctionsEnsaques.Update_Finaliza_Producao();

        }


        public bool ensaques() 
        {

            if (ensaque.controleEnsaque.Saco_Atual_Finalizado && !ensaque.controleEnsaque.Supervisorio_Salvou_Saco_Atual)
            {
                if (DataBase.SqlFunctionsEnsaques.IntoDate_Table_Ensaques(DataBase.SqlFunctionsEnsaques.getIdProducaoEnsaque(VariaveisGlobais.Id_Producao_No_Silo_Expedicao), ensaque.controleEnsaque.pesoSacoAtual, "") != -1 )
                {
                    SetBitSalvouDadosSacoBD();

                    return true;
                }
                else
                {
                    Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = "Não escreveu no banco de dados o saco do ensaque da produção: " + VariaveisGlobais.Id_Producao_No_Silo_Expedicao.ToString() + " com peso: " + ensaque.controleEnsaque.pesoSacoAtual.ToString() +" kg!!";

                    return false;
                }
            }

            return false;

        }

        #endregion


        #region Funcoes

        public Label StatusBalanca(Label lbStatusEnsaque) 
        {
            if (indicadorPesagem.Erro_Leitura)
            {
                lbStatusEnsaque.Content = "Erro Balança";
                lbStatusEnsaque.Background = new SolidColorBrush(Colors.Red);
                lbStatusEnsaque.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                if (ensaque.controleEnsaque.IniciaEnsaque)
                {
                    if (ensaque.controleEnsaque.Saco_Atual_Dosando)
                    {
                        lbStatusEnsaque.Content = "Dosando Saco";
                        lbStatusEnsaque.Background = new SolidColorBrush(Colors.Green);
                        lbStatusEnsaque.Foreground = new SolidColorBrush(Colors.Black);


                    }
                    else if (ensaque.controleEnsaque.Saco_Atual_Finalizado)
                    {
                        lbStatusEnsaque.Content = "Dosagem Concluída";
                        lbStatusEnsaque.Background = new SolidColorBrush(Colors.Green);
                        lbStatusEnsaque.Foreground = new SolidColorBrush(Colors.Black);

                    }
                    else
                    {
                        lbStatusEnsaque.Content = "Aguardando Inicío de Dosagem";
                        lbStatusEnsaque.Background = new SolidColorBrush(Colors.Gray);
                        lbStatusEnsaque.Foreground = new SolidColorBrush(Colors.White);

                    }
                }
                else if (!ensaque.controleEnsaque.Habilita_Iniciar_Ensaque)
                {
                    lbStatusEnsaque.Content = "Aguardando Habilitar Ensaque";
                    lbStatusEnsaque.Background = new SolidColorBrush(Colors.Red);
                    lbStatusEnsaque.Foreground = new SolidColorBrush(Colors.White);

                }
                else
                {
                    lbStatusEnsaque.Content = "Aguardando Inicío de Ensaque";
                    lbStatusEnsaque.Background = new SolidColorBrush(Colors.Gray);
                    lbStatusEnsaque.Foreground = new SolidColorBrush(Colors.White);

                }
            }



            return lbStatusEnsaque;

        }

        #endregion
    }
}
