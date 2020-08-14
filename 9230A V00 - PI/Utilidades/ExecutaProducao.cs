﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.Utilidades
{
    public class ExecutaProducao
    {

        Utilidades.VariaveisGlobais.ControleExecucaoProducao controleExecucao = new Utilidades.VariaveisGlobais.ControleExecucaoProducao(); //Slot 1 
        int bufferPlc;

        public ExecutaProducao(int bufferPlc)
        {
            this.bufferPlc = bufferPlc;
        }

        //public int Produzir(Utilidades.Producao producao)
        //{
        //    int ret = -1;
        //    //Returns
        //    // 0 = ok
        //    // 1 = Não esta habilitado para iniciar uma nova produção 

        //    if (!controleExecucao.Habilitado_Iniciar_Nova_Producao)
        //    {
        //        ret = 1;
        //    }
        //    else
        //    {
        //        //Verifica um slot disponível no CLP para alocar as informações da batelada, por ordem, primeiro slot 1 depois slot 2 e por fim slot 3

        //        if (controleExecucao.Slot_1.Solicita_Nova_Batelada)
        //        {

        //        }




        //    }
        //    return ret;
        //}

        private void writeVariablesSlotIntoBuffer(int slot)
        {
            if (slot == 1)
            {
                Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 0, controleExecucao.Slot_1.Tempo_Pre_Mistura); //Escreve no Buffer Tempo Pré Mistura
                Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 4, controleExecucao.Slot_1.Tempo_Pos_Mistura); //Escreve no Buffer Tempo Pós Mistura
                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 8, controleExecucao.Slot_1.Peso_Total_Batelada_Desejado); //Escreve no Buffer Peso total da produção

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 12, controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_1); //Escreve no Buffer Dosagem Matéria Prima automática Silo 1
                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 16, controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_2); //Escreve no Buffer Dosagem Matéria Prima automática Silo 2

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 28, controleExecucao.Slot_1.Complemento_Pre.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual matéria prima

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 42, controleExecucao.Slot_1.Complemento_Pos.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual pós mistura
            }


        }

        private void readVariablesBuffer(int slot)
        {
            if (slot == 1)
            {
                controleExecucao.Slot_1.Tempo_Pre_Mistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 0);
                controleExecucao.Slot_1.Tempo_Pos_Mistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 4);
                controleExecucao.Slot_1.Peso_Total_Batelada_Desejado = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 8);
                controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 12);
                controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 16);
                controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 20);
                controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 24);

                //Complemento Pré
                controleExecucao.Slot_1.Complemento_Pre.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 28);
                controleExecucao.Slot_1.Complemento_Pre.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 30);
                controleExecucao.Slot_1.Complemento_Pre.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 32);
                controleExecucao.Slot_1.Complemento_Pre.Quantidade_Dosada_Total = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 36);
                controleExecucao.Slot_1.Complemento_Pre = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 40), controleExecucao.Slot_1.Complemento_Pre);

                //Complemento Pós
                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 42);
                controleExecucao.Slot_1.Complemento_Pos.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 44);
                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 46);
                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Dosada_Total = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 50);
                controleExecucao.Slot_1.Complemento_Pos = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 54), controleExecucao.Slot_1.Complemento_Pos);

                controleExecucao.Slot_1.TempoAtualDesdeIniciado = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 56);
                controleExecucao.Slot_1.TempoAtualPasso = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 60);
                controleExecucao.Slot_1.Status = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 64);
            }
        }



        /// <summary>
        /// Adiciona as variaveis necessarias para iniciar a produção da batelada em um determinado slot do CLP
        /// </summary>
        private bool addInfoBateladaSlot(int slot, int numeroBatelada)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false; //Desabilita a leitura do buffer

            controleExecucao.Slot_1.Tempo_Pre_Mistura = VariaveisGlobais.ProducaoExecucao.tempoPreMistura;               //Tempo Pré Mistura
            controleExecucao.Slot_1.Tempo_Pos_Mistura = VariaveisGlobais.ProducaoExecucao.tempoPreMistura;               //Tempo Pós Mistura
            controleExecucao.Slot_1.Peso_Total_Batelada_Desejado = VariaveisGlobais.ProducaoExecucao.pesoTotalProducao;  //Peso total da produção

            //Pesquisa na lista de produtos o produto que irá ser utilizado para dosagem automática no silo 1/2, caso tenha irá retornar o peso desejado, caso não retornará 0
            controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_1 = VariaveisGlobais.ProducaoExecucao.CodigoProdutoDosagemAutomaticaSilo1.Equals("") ? 0 : (VariaveisGlobais.ProducaoExecucao.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoExecucao.CodigoProdutoDosagemAutomaticaSilo1)).pesoDesejado;
            controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_2 = VariaveisGlobais.ProducaoExecucao.CodigoProdutoDosagemAutomaticaSilo2.Equals("") ? 0 : (VariaveisGlobais.ProducaoExecucao.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoExecucao.CodigoProdutoDosagemAutomaticaSilo2)).pesoDesejado;


            //Envia a quantidade de itens a ser dosado manualmente na balança (Considerado dosagem de matéria prima manual ou dosagem de complemento pré)
            //Todos os produtos que tem as especificações abaixo:
            //Tipo do produto = "Matéria Prima"
            //Código diferente do CodigoProdutoDosagemAutomaticaSilo1 e CodigoProdutoDosagemAutomaticaSilo1.

            //Realiza a pesquisa conforme especificações acima.
            short count = 0;
            foreach (var item in VariaveisGlobais.ProducaoExecucao.batelada[numeroBatelada].produtos)
            {
                if (!item.codigo.Equals(VariaveisGlobais.ProducaoExecucao.CodigoProdutoDosagemAutomaticaSilo1) &&
                    !item.codigo.Equals(VariaveisGlobais.ProducaoExecucao.CodigoProdutoDosagemAutomaticaSilo1) &&
                    item.tipoProduto.Equals("Matéria Prima")
                    )
                {
                    count += 1;
                }
            }

            controleExecucao.Slot_1.Complemento_Pre.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na balança, 

            count = 0;
            //Envia a quantidade de itens a ser dosado manualmente no Pós misturador (Considerado dosagem de complemento no pós misturador)
            //Todos os produtos que tem as especificações abaixo:
            //Tipo do produto = "Complemento"
            //Realiza a pesquisa conforme especificações acima.
            foreach (var item in VariaveisGlobais.ProducaoExecucao.batelada[numeroBatelada].produtos)
            {
                if (item.tipoProduto.Equals("Complemento"))
                {
                    count += 1;
                }
            }

            controleExecucao.Slot_1.Complemento_Pos.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na pós mistura

            writeVariablesSlotIntoBuffer(slot);
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;

            return true;
        }

        /// <summary>
        /// Verifica se tem disponibilidade de colocar em produção uma nova batelada se tiver nova batelada para produzir
        /// </summary>
        private void verificaDisponibilidadeSlot()
        {
            //Verifica se a quantidade de bateladas iniciadas é diferente da quantidade de bateladas existentes, cado for igual significa que ja foi iniciado todas as bateladas
            if (controleExecucao.Bateladas_Iniciadas != Utilidades.VariaveisGlobais.ProducaoExecucao.quantidadeBateladas)
            {
                if (controleExecucao.Habilitado_Iniciar_Nova_Producao) //Verifica se o slot 1 do CLP pode receber uma batelada
                {
                    //Adiciona a batelada no slot 1
                    addInfoBateladaSlot(1, controleExecucao.Bateladas_Iniciadas);
                }
            }


        }


        public bool Produzir
        {
            set
            {
                //Leitura das variáveis
                if (VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read)
                {
                    //Slot 1
                    readVariablesBuffer(1);



                }




                //Após Leitura das Variáveis


                //Verifica disponibilidade de slot
                verificaDisponibilidadeSlot();


            }

        }

        public VariaveisGlobais.ControleExecucaoProducao ControleExecucao { get => controleExecucao;}
    }
}
