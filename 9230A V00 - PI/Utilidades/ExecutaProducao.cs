using System;
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

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 36, controleExecucao.Slot_1.Complemento_Pre.Quantidade_Total_Desejada);

                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 40, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_1.Complemento_Pre));

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 42, controleExecucao.Slot_1.Complemento_Pos.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual pós mistura

                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 54, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_1.Complemento_Pos));

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 72, controleExecucao.Slot_1.Quantidade_Total_Produtos);

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 80, controleExecucao.Slot_1.NumeroBatelada);

                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 82, Move_Bits.SlotToDwordBatelada(controleExecucao.Slot_1)); //Atualiza os Bits do command

            }

            if (slot == 2)
            {
                Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 86, controleExecucao.Slot_2.Tempo_Pre_Mistura); //Escreve no Buffer Tempo Pré Mistura
                Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 90, controleExecucao.Slot_2.Tempo_Pos_Mistura); //Escreve no Buffer Tempo Pós Mistura
                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 94, controleExecucao.Slot_2.Peso_Total_Batelada_Desejado); //Escreve no Buffer Peso total da produção

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 98, controleExecucao.Slot_2.Dosagem_Materia_Prima_Silo_1); //Escreve no Buffer Dosagem Matéria Prima automática Silo 1
                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 102, controleExecucao.Slot_2.Dosagem_Materia_Prima_Silo_2); //Escreve no Buffer Dosagem Matéria Prima automática Silo 2

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 114, controleExecucao.Slot_2.Complemento_Pre.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual matéria prima

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 122, controleExecucao.Slot_2.Complemento_Pre.Quantidade_Total_Desejada);

                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 126, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_2.Complemento_Pre));

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 128, controleExecucao.Slot_2.Complemento_Pos.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual pós mistura

                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 140, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_2.Complemento_Pos));

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 158, controleExecucao.Slot_2.Quantidade_Total_Produtos);

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 166, controleExecucao.Slot_2.NumeroBatelada);

                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 168, Move_Bits.SlotToDwordBatelada(controleExecucao.Slot_2)); //Atualiza os Bits do command

            }

            if (slot == 3)
            {
                Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 172, controleExecucao.Slot_3.Tempo_Pre_Mistura); //Escreve no Buffer Tempo Pré Mistura
                Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 176, controleExecucao.Slot_3.Tempo_Pos_Mistura); //Escreve no Buffer Tempo Pós Mistura
                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 180, controleExecucao.Slot_3.Peso_Total_Batelada_Desejado); //Escreve no Buffer Peso total da produção

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 184, controleExecucao.Slot_3.Dosagem_Materia_Prima_Silo_1); //Escreve no Buffer Dosagem Matéria Prima automática Silo 1
                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 188, controleExecucao.Slot_3.Dosagem_Materia_Prima_Silo_2); //Escreve no Buffer Dosagem Matéria Prima automática Silo 2
            
                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 200, controleExecucao.Slot_3.Complemento_Pre.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual matéria prima

                Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 208, controleExecucao.Slot_3.Complemento_Pre.Quantidade_Total_Desejada);

                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 212, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_3.Complemento_Pre));

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 214, controleExecucao.Slot_3.Complemento_Pos.Quantidade_Itens); //Escreve no Buffer Quantidade de itens dosagem manual pós mistura

                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 226, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_3.Complemento_Pos));

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 244, controleExecucao.Slot_3.Quantidade_Total_Produtos);

                Comunicacao.Sharp7.S7.SetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 252, controleExecucao.Slot_3.NumeroBatelada);

                Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 254, Move_Bits.SlotToDwordBatelada(controleExecucao.Slot_3)); //Atualiza os Bits do command

            }

            Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 262, Move_Bits.ControleExecucaoProducaoToDword(controleExecucao));

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
                controleExecucao.Slot_1.Complemento_Pre.Quantidade_Total_Desejada = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 36);
                controleExecucao.Slot_1.Complemento_Pre = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 40), controleExecucao.Slot_1.Complemento_Pre);

                //Complemento Pós
                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 42);
                controleExecucao.Slot_1.Complemento_Pos.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 44);
                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 46);
                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Total_Desejada = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 50);
                controleExecucao.Slot_1.Complemento_Pos = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 54), controleExecucao.Slot_1.Complemento_Pos);

                controleExecucao.Slot_1.TempoAtualDesdeIniciado = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 56);
                controleExecucao.Slot_1.TempoAtualPasso = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 60);
                controleExecucao.Slot_1.TempoRestantePreMistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 64);
                controleExecucao.Slot_1.TempoRestantePosMistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 68);
                controleExecucao.Slot_1.Quantidade_Total_Produtos = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 72);
                controleExecucao.Slot_1.Produto_Atual_Em_Producao = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 74);
                controleExecucao.Slot_1.Status_Produto_Atual_Em_Producao = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 76);
                controleExecucao.Slot_1.Status_Batelada = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 78);
                controleExecucao.Slot_1.NumeroBatelada = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 80);

                controleExecucao.Slot_1 = Move_Bits.DwordToSlotBatelada(Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 82), controleExecucao.Slot_1);
            }

            if (slot == 2)
            {
                controleExecucao.Slot_2.Tempo_Pre_Mistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 86);
                controleExecucao.Slot_2.Tempo_Pos_Mistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 90);
                controleExecucao.Slot_2.Peso_Total_Batelada_Desejado = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 94);
                controleExecucao.Slot_2.Dosagem_Materia_Prima_Silo_1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 98);
                controleExecucao.Slot_2.Dosagem_Materia_Prima_Silo_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 102);
                controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 106);
                controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 110);

                //Complemento Pré
                controleExecucao.Slot_2.Complemento_Pre.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 114);
                controleExecucao.Slot_2.Complemento_Pre.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 116);
                controleExecucao.Slot_2.Complemento_Pre.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 118);
                controleExecucao.Slot_2.Complemento_Pre.Quantidade_Total_Desejada = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 122);
                controleExecucao.Slot_2.Complemento_Pre = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 126), controleExecucao.Slot_2.Complemento_Pre);

                //Complemento Pós
                controleExecucao.Slot_2.Complemento_Pos.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 128);
                controleExecucao.Slot_2.Complemento_Pos.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 130);
                controleExecucao.Slot_2.Complemento_Pos.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 132);
                controleExecucao.Slot_2.Complemento_Pos.Quantidade_Total_Desejada = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 136);
                controleExecucao.Slot_2.Complemento_Pos = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 140), controleExecucao.Slot_2.Complemento_Pos);

                controleExecucao.Slot_2.TempoAtualDesdeIniciado = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 142);
                controleExecucao.Slot_2.TempoAtualPasso = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 146);
                controleExecucao.Slot_2.TempoRestantePreMistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 150);
                controleExecucao.Slot_2.TempoRestantePosMistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 154);
                controleExecucao.Slot_2.Quantidade_Total_Produtos = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 158);
                controleExecucao.Slot_2.Produto_Atual_Em_Producao = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 160);
                controleExecucao.Slot_2.Status_Produto_Atual_Em_Producao = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 162);
                controleExecucao.Slot_2.Status_Batelada = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 164);
                controleExecucao.Slot_2.NumeroBatelada = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 166);

                controleExecucao.Slot_2 = Move_Bits.DwordToSlotBatelada(Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 168), controleExecucao.Slot_2);
            }

            if (slot == 3)
            {
                controleExecucao.Slot_3.Tempo_Pre_Mistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 172);
                controleExecucao.Slot_3.Tempo_Pos_Mistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 176);
                controleExecucao.Slot_3.Peso_Total_Batelada_Desejado = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 180);
                controleExecucao.Slot_3.Dosagem_Materia_Prima_Silo_1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 184);
                controleExecucao.Slot_3.Dosagem_Materia_Prima_Silo_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 188);
                controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_1 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 192);
                controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_2 = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 196);

                //Complemento Pré
                controleExecucao.Slot_3.Complemento_Pre.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 200);
                controleExecucao.Slot_3.Complemento_Pre.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 202);
                controleExecucao.Slot_3.Complemento_Pre.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 204);
                controleExecucao.Slot_3.Complemento_Pre.Quantidade_Total_Desejada = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 208);
                controleExecucao.Slot_3.Complemento_Pre = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 212), controleExecucao.Slot_3.Complemento_Pre);

                //Complemento Pós
                controleExecucao.Slot_3.Complemento_Pos.Quantidade_Itens = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 214);
                controleExecucao.Slot_3.Complemento_Pos.Item_Atual = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 216);
                controleExecucao.Slot_3.Complemento_Pos.Quantidade_Dosada_Item_Atual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 218);
                controleExecucao.Slot_3.Complemento_Pos.Quantidade_Total_Desejada = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 222);
                controleExecucao.Slot_3.Complemento_Pos = Move_Bits.ByteToComplementoBatelada(Comunicacao.Sharp7.S7.GetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 226), controleExecucao.Slot_3.Complemento_Pos);

                controleExecucao.Slot_3.TempoAtualDesdeIniciado = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 228);
                controleExecucao.Slot_3.TempoAtualPasso = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 232);
                controleExecucao.Slot_3.TempoRestantePreMistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 236);
                controleExecucao.Slot_3.TempoRestantePosMistura = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 240);
                controleExecucao.Slot_3.Quantidade_Total_Produtos = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 244);
                controleExecucao.Slot_3.Produto_Atual_Em_Producao = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 246);
                controleExecucao.Slot_3.Status_Produto_Atual_Em_Producao = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 248);
                controleExecucao.Slot_3.Status_Batelada = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 250);
                controleExecucao.Slot_3.NumeroBatelada = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 252);

                controleExecucao.Slot_3 = Move_Bits.DwordToSlotBatelada(Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 254), controleExecucao.Slot_3);
            }

            controleExecucao.Bateladas_Iniciadas = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 258);
            controleExecucao.Bateladas_Finalizadas = Comunicacao.Sharp7.S7.GetIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 260);
            controleExecucao = Move_Bits.DwordToControleExecucaoProducao(Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 262), controleExecucao);

        }

        /// <summary>
        /// Adiciona as variaveis necessarias para iniciar a produção da batelada em um determinado slot do CLP
        /// </summary>
        private bool addInfoBateladaSlot(int slot, short numeroBatelada)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false; //Desabilita a leitura do buffer

            float pesoBatelada = 0;
            short count = 0;
            float pesoComplementosPre = 0;

            #region SLOT 1

            if (slot == 1)
            {
                controleExecucao.Slot_1.NumeroBatelada = Convert.ToInt16(numeroBatelada + 1);
                controleExecucao.Slot_1.Tempo_Pre_Mistura = VariaveisGlobais.ProducaoReceita.tempoPreMistura;               //Tempo Pré Mistura
                controleExecucao.Slot_1.Tempo_Pos_Mistura = VariaveisGlobais.ProducaoReceita.tempoPosMistura;               //Tempo Pós Mistura

                pesoBatelada = 0;
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    pesoBatelada += item.pesoDesejado;
                }

                controleExecucao.Slot_1.Peso_Total_Batelada_Desejado = pesoBatelada;  //Peso total da batelada

                //Pesquisa na lista de produtos o produto que irá ser utilizado para dosagem automática no silo 1/2, caso tenha irá retornar o peso desejado, caso não retornará 0
                controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_1 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1.Equals("") ? 0 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1)).pesoDesejado;
                controleExecucao.Slot_1.Dosagem_Materia_Prima_Silo_2 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2.Equals("") ? 0 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2)).pesoDesejado;


                //Verifica se a primeira dosagem automática será feita pelo silo 2
                var indexSilo1 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1.Equals("") ? -1 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.FindIndex(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1));
                var indexSilo2 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2.Equals("") ? -1 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.FindIndex(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2));

                if (indexSilo2 < indexSilo1)
                {
                    controleExecucao.Slot_1.Dosar_Primeiro_Silo_2 = true;
                }

                //Envia a quantidade de itens a ser dosado manualmente na balança (Considerado dosagem de matéria prima manual ou dosagem de complemento pré)
                //Todos os produtos que tem as especificações abaixo:
                //Tipo do produto = "Matéria Prima"
                //Código diferente do CodigoProdutoDosagemAutomaticaSilo1 e CodigoProdutoDosagemAutomaticaSilo1.

                //Realiza a pesquisa conforme especificações acima.
                count = 0;
                pesoComplementosPre = 0;
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    if (!item.codigo.Equals(VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1) &&
                        !item.codigo.Equals(VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2) &&
                        item.tipoProduto.Equals("Matéria Prima")
                        )
                    {
                        count += 1;
                        pesoComplementosPre += item.pesoDesejado;
                    }
                }

                controleExecucao.Slot_1.Complemento_Pre.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na balança, 
                controleExecucao.Slot_1.Complemento_Pre.Quantidade_Total_Desejada = pesoComplementosPre; //Passa a quantidade total desejada dos complementos pré

                count = 0;
                //Envia a quantidade de itens a ser dosado manualmente no Pós misturador (Considerado dosagem de complemento no pós misturador)
                //Todos os produtos que tem as especificações abaixo:
                //Tipo do produto = "Complemento"
                //Realiza a pesquisa conforme especificações acima.
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    if (item.tipoProduto.Equals("Complemento"))
                    {
                        count += 1;
                    }
                }

                controleExecucao.Slot_1.Complemento_Pos.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na pós mistura
                controleExecucao.Slot_1.Supervisao_Carregou_Dados_Batelada = true;

            }

            #endregion

            #region SLOT 2

            if (slot == 2)
            {
                controleExecucao.Slot_2.NumeroBatelada = Convert.ToInt16(numeroBatelada + 1);
                controleExecucao.Slot_2.Tempo_Pre_Mistura = VariaveisGlobais.ProducaoReceita.tempoPreMistura;               //Tempo Pré Mistura
                controleExecucao.Slot_2.Tempo_Pos_Mistura = VariaveisGlobais.ProducaoReceita.tempoPreMistura;               //Tempo Pós Mistura

                pesoBatelada = 0;
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    pesoBatelada += item.pesoDesejado;
                }

                controleExecucao.Slot_2.Peso_Total_Batelada_Desejado = pesoBatelada;  //Peso total da batelada

                //Pesquisa na lista de produtos o produto que irá ser utilizado para dosagem automática no silo 1/2, caso tenha irá retornar o peso desejado, caso não retornará 0
                controleExecucao.Slot_2.Dosagem_Materia_Prima_Silo_1 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1.Equals("") ? 0 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1)).pesoDesejado;
                controleExecucao.Slot_2.Dosagem_Materia_Prima_Silo_2 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2.Equals("") ? 0 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2)).pesoDesejado;


                //Envia a quantidade de itens a ser dosado manualmente na balança (Considerado dosagem de matéria prima manual ou dosagem de complemento pré)
                //Todos os produtos que tem as especificações abaixo:
                //Tipo do produto = "Matéria Prima"
                //Código diferente do CodigoProdutoDosagemAutomaticaSilo1 e CodigoProdutoDosagemAutomaticaSilo1.

                //Realiza a pesquisa conforme especificações acima.
                count = 0;
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    if (!item.codigo.Equals(VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1) &&
                        !item.codigo.Equals(VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2) &&
                        item.tipoProduto.Equals("Matéria Prima")
                        )
                    {
                        count += 1;
                    }
                }

                controleExecucao.Slot_2.Complemento_Pre.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na balança, 

                count = 0;
                //Envia a quantidade de itens a ser dosado manualmente no Pós misturador (Considerado dosagem de complemento no pós misturador)
                //Todos os produtos que tem as especificações abaixo:
                //Tipo do produto = "Complemento"
                //Realiza a pesquisa conforme especificações acima.
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    if (item.tipoProduto.Equals("Complemento"))
                    {
                        count += 1;
                    }
                }

                controleExecucao.Slot_2.Complemento_Pos.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na pós mistura
                controleExecucao.Slot_2.Supervisao_Carregou_Dados_Batelada = true;

            }

            #endregion

            #region SLOT 3

            if (slot == 3)
            {
                controleExecucao.Slot_3.NumeroBatelada = Convert.ToInt16(numeroBatelada + 1);
                controleExecucao.Slot_3.Tempo_Pre_Mistura = VariaveisGlobais.ProducaoReceita.tempoPreMistura;               //Tempo Pré Mistura
                controleExecucao.Slot_3.Tempo_Pos_Mistura = VariaveisGlobais.ProducaoReceita.tempoPreMistura;               //Tempo Pós Mistura

                pesoBatelada = 0;
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    pesoBatelada += item.pesoDesejado;
                }

                controleExecucao.Slot_3.Peso_Total_Batelada_Desejado = pesoBatelada;  //Peso total da batelada

                //Pesquisa na lista de produtos o produto que irá ser utilizado para dosagem automática no silo 1/2, caso tenha irá retornar o peso desejado, caso não retornará 0
                controleExecucao.Slot_3.Dosagem_Materia_Prima_Silo_1 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1.Equals("") ? 0 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1)).pesoDesejado;
                controleExecucao.Slot_3.Dosagem_Materia_Prima_Silo_2 = VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2.Equals("") ? 0 : (VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos.Find(x => x.codigo == VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2)).pesoDesejado;


                //Envia a quantidade de itens a ser dosado manualmente na balança (Considerado dosagem de matéria prima manual ou dosagem de complemento pré)
                //Todos os produtos que tem as especificações abaixo:
                //Tipo do produto = "Matéria Prima"
                //Código diferente do CodigoProdutoDosagemAutomaticaSilo1 e CodigoProdutoDosagemAutomaticaSilo1.

                //Realiza a pesquisa conforme especificações acima.
                count = 0;
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    if (!item.codigo.Equals(VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1) &&
                        !item.codigo.Equals(VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2) &&
                        item.tipoProduto.Equals("Matéria Prima")
                        )
                    {
                        count += 1;
                    }
                }

                controleExecucao.Slot_3.Complemento_Pre.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na balança, 

                count = 0;
                //Envia a quantidade de itens a ser dosado manualmente no Pós misturador (Considerado dosagem de complemento no pós misturador)
                //Todos os produtos que tem as especificações abaixo:
                //Tipo do produto = "Complemento"
                //Realiza a pesquisa conforme especificações acima.
                foreach (var item in VariaveisGlobais.ProducaoReceita.batelada[numeroBatelada].produtos)
                {
                    if (item.tipoProduto.Equals("Complemento"))
                    {
                        count += 1;
                    }
                }

                controleExecucao.Slot_3.Complemento_Pos.Quantidade_Itens = count; //Passa quantidade de itens para dosar manualmente na pós mistura
                controleExecucao.Slot_3.Supervisao_Carregou_Dados_Batelada = true;

            }

            #endregion

            writeVariablesSlotIntoBuffer(slot);

            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;

            return true;
        }

        /// <summary>
        /// Verifica se tem disponibilidade de colocar em produção uma nova batelada se tiver nova batelada para produzir
        /// </summary>
        private void verificaDisponibilidadeSlot()
        {
            if (controleExecucao.Iniciar_Producao)
            {
                //Verifica se a quantidade de bateladas iniciadas é diferente da quantidade de bateladas existentes, cado for igual significa que ja foi iniciado todas as bateladas
                if (controleExecucao.Bateladas_Iniciadas < Utilidades.VariaveisGlobais.ProducaoReceita.quantidadeBateladas)
                {
                    if (controleExecucao.Slot_1.Solicita_Nova_Batelada && !controleExecucao.Slot_1.Supervisao_Carregou_Dados_Batelada) //Verifica se o slot 1 do CLP pode receber uma batelada
                    {
                        //Adiciona a batelada no slot 1
                        addInfoBateladaSlot(1, controleExecucao.Bateladas_Iniciadas);
                    }
                    else if (controleExecucao.Slot_2.Solicita_Nova_Batelada && !controleExecucao.Slot_2.Supervisao_Carregou_Dados_Batelada) //Verifica se o slot 2 do CLP pode receber uma batelada
                    {
                        //Adiciona a batelada no slot 2
                        addInfoBateladaSlot(2, controleExecucao.Bateladas_Iniciadas);
                    }
                    else if (controleExecucao.Slot_3.Solicita_Nova_Batelada && !controleExecucao.Slot_3.Supervisao_Carregou_Dados_Batelada) //Verifica se o slot 3 do CLP pode receber uma batelada
                    {
                        //Adiciona a batelada no slot 3
                        addInfoBateladaSlot(3, controleExecucao.Bateladas_Iniciadas);
                    }
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

                    //Slot 2
                    readVariablesBuffer(2);

                    //Slot 3
                    readVariablesBuffer(3);
                }
                //Após Leitura das Variáveis

                //Verifica se foi solicitado iniciar a produção, se não inicia
                if (!controleExecucao.Iniciar_Producao)
                {
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false; //Desabilita a leitura do buffer


                    controleExecucao.Iniciar_Producao = true;
                    writeVariablesSlotIntoBuffer(0);
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true; //Desabilita a leitura do buffer
                }

                //Verifica disponibilidade de slot
                verificaDisponibilidadeSlot();

                //Salva Pesos Dosados
                salva_Peso_Dosado_Item_Produzindo();

                //Finaliza a produção
                finaliza_Producao();

                //Verifica se tem nível no silo de expedição e adiciona o Id da produção no silo de expedição
                if (VariaveisGlobais.niveis.Inferior_Silo_Exp)
                {
                    if (VariaveisGlobais.Id_Producao_No_Silo_Expedicao != VariaveisGlobais.ProducaoReceita.id)
                    {
                        VariaveisGlobais.Buffer_PLC[1].Enable_Read = false;

                        //Seta o ID da produção que esta no silo de expedição
                        Comunicacao.Sharp7.S7.SetDIntAt(VariaveisGlobais.Buffer_PLC[1].Buffer, 278, VariaveisGlobais.ProducaoReceita.id);

                        VariaveisGlobais.Buffer_PLC[1].Enable_Write = true;
                    }
                }
            }
        }

        public void finalizaProducao()
        {
            //Retira produção do Banco de dados
            DataBase.SQLFunctionsProducao.Update_Finaliza_Producao(0,0);

            //Atualiza a produção que esta em execução
            //se não encontrar nada em produção no banco de dados, instancia uma nova produção
            DataBase.SQLFunctionsProducao.AtualizaProducaoEmExecucao();

            //Envia para o CLP retirar a produção
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

            controleExecucao.RetiraProducao = true;

            writeVariablesSlotIntoBuffer(0);

            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;

        }

        private void finaliza_Producao()
        {
            //Se iniciou a produção
            if (controleExecucao.Iniciar_Producao)
            {
                //Verifica se a quantidade de bateladas é igual a quantidade de bateladas finalizadas, se for finaliza a batelada
                if (controleExecucao.Bateladas_Finalizadas == (short)Utilidades.VariaveisGlobais.ProducaoReceita.quantidadeBateladas)
                {
                    float pesoTotal = 0.0f;
                    float volumeTotal = 0.0f;
                    //Verifica o peso e volume total dosado na batelada
                    foreach (var batelada in VariaveisGlobais.ProducaoReceita.batelada)
                    {
                        pesoTotal += batelada.pesoDosado;
                    }

                    //Atualiza no banco de dados 
                    DataBase.SQLFunctionsProducao.Update_Finaliza_Producao(pesoTotal, volumeTotal);

                    //Atualiza a produção que esta em execução
                    //se não encontrar nada em produção no banco de dados, instancia uma nova produção
                    DataBase.SQLFunctionsProducao.AtualizaProducaoEmExecucao();

                    //reseta o iniciar produção
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false; //Desabilita a leitura do buffer
                    controleExecucao.Iniciar_Producao = false;
                    writeVariablesSlotIntoBuffer(0);
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true; //Desabilita a leitura do buffer

                }
            }
        }

        private void salva_Peso_Dosado_Item_Produzindo()
        {
            //Verifica qual slot iniciou a produção

            #region SLOT 1

            if (controleExecucao.Slot_1.Iniciou_Producao_No_Processo)
            {
                //Verifica se tem item da dosagem de complemento pré para salvar no banco de dados, após libera para a prx dosagem de complemento
                if (controleExecucao.Slot_1.Complemento_Pre.Item_Atual_Finalizado_Dosagem)
                {

                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_1.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_1.Complemento_Pre.Quantidade_Dosada_Item_Atual);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_1.Complemento_Pre.Quantidade_Dosada_Item_Atual;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_1.Complemento_Pre.Quantidade_Dosada_Item_Atual;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_1.Complemento_Pre.Supervisao_Salvou_Dados_Dosado_Item_Atual = true;

                    writeVariablesSlotIntoBuffer(1);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se tem item da dosagem de complemento pós para salvar no banco de dados, após libera para a prx dosagem de complemento
                if (controleExecucao.Slot_1.Complemento_Pos.Item_Atual_Finalizado_Dosagem)
                {

                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_1.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].codigo,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDesejado);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDosado = VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDesejado;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].pesoDosado += VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDosado;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_1.Complemento_Pos.Supervisao_Salvou_Dados_Dosado_Item_Atual = true;

                    writeVariablesSlotIntoBuffer(1);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se foi finalizado a dosagem do silo 1 para salvar no banco de dados
                if (controleExecucao.Slot_1.Finalizou_Dosagem_Automatica_Silo_1)
                {
                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_1.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_1);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_1;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_1;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_1.Supervisorio_Salvou_Dados_Silo_1 = true;

                    controleExecucao.Slot_1.Finalizou_Dosagem_Automatica_Silo_1 = false;

                    writeVariablesSlotIntoBuffer(1);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se foi finalizado a dosagem do silo 2 para salvar no banco de dados
                if (controleExecucao.Slot_1.Finalizou_Dosagem_Automatica_Silo_2)
                {
                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_1.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_2);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].produtos[controleExecucao.Slot_1.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_2;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_1.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_1.Dosado_Materia_Prima_Silo_2;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_1.Supervisorio_Salvou_Dados_Silo_2 = true;

                    controleExecucao.Slot_1.Finalizou_Dosagem_Automatica_Silo_2 = false;

                    writeVariablesSlotIntoBuffer(1);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }
            }

            #endregion

            #region SLOT 2

            if (controleExecucao.Slot_2.Iniciou_Producao_No_Processo)
            {
                //Verifica se tem item da dosagem de complemento pré para salvar no banco de dados, após libera para a prx dosagem de complemento
                if (controleExecucao.Slot_2.Complemento_Pre.Item_Atual_Finalizado_Dosagem)
                {

                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_2.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_2.Complemento_Pre.Quantidade_Dosada_Item_Atual);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_2.Complemento_Pre.Quantidade_Dosada_Item_Atual;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_2.Complemento_Pre.Quantidade_Dosada_Item_Atual;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_2.Complemento_Pre.Supervisao_Salvou_Dados_Dosado_Item_Atual = true;

                    writeVariablesSlotIntoBuffer(2);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se tem item da dosagem de complemento pós para salvar no banco de dados, após libera para a prx dosagem de complemento
                if (controleExecucao.Slot_2.Complemento_Pos.Item_Atual_Finalizado_Dosagem)
                {

                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_2.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].codigo,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].pesoDesejado);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].pesoDosado = VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].pesoDesejado;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_2.Complemento_Pos.Quantidade_Dosada_Item_Atual;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_2.Complemento_Pos.Supervisao_Salvou_Dados_Dosado_Item_Atual = true;

                    writeVariablesSlotIntoBuffer(2);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se foi finalizado a dosagem do silo 1 para salvar no banco de dados
                if (controleExecucao.Slot_2.Finalizou_Dosagem_Automatica_Silo_1)
                {
                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_2.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_1);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_1;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_1;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_2.Supervisorio_Salvou_Dados_Silo_1 = true;

                    controleExecucao.Slot_2.Finalizou_Dosagem_Automatica_Silo_1 = false;

                    writeVariablesSlotIntoBuffer(2);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se foi finalizado a dosagem do silo 2 para salvar no banco de dados
                if (controleExecucao.Slot_2.Finalizou_Dosagem_Automatica_Silo_2)
                {
                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_2.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_2);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].produtos[controleExecucao.Slot_2.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_2;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_2.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_2.Dosado_Materia_Prima_Silo_2;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_2.Supervisorio_Salvou_Dados_Silo_2 = true;

                    controleExecucao.Slot_2.Finalizou_Dosagem_Automatica_Silo_2 = false;

                    writeVariablesSlotIntoBuffer(2);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }
            }

            #endregion

            #region SLOT 3

            if (controleExecucao.Slot_3.Iniciou_Producao_No_Processo)
            {
                //Verifica se tem item da dosagem de complemento pré para salvar no banco de dados, após libera para a prx dosagem de complemento
                if (controleExecucao.Slot_3.Complemento_Pre.Item_Atual_Finalizado_Dosagem)
                {

                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_3.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_3.Complemento_Pre.Quantidade_Dosada_Item_Atual);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_3.Complemento_Pre.Quantidade_Dosada_Item_Atual;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_3.Complemento_Pre.Quantidade_Dosada_Item_Atual;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_3.Complemento_Pre.Supervisao_Salvou_Dados_Dosado_Item_Atual = true;

                    writeVariablesSlotIntoBuffer(3);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se tem item da dosagem de complemento pós para salvar no banco de dados, após libera para a prx dosagem de complemento
                if (controleExecucao.Slot_3.Complemento_Pos.Item_Atual_Finalizado_Dosagem)
                {

                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_3.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].codigo,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].pesoDesejado);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].pesoDosado = VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].pesoDesejado;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_3.Complemento_Pos.Quantidade_Dosada_Item_Atual;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_3.Complemento_Pos.Supervisao_Salvou_Dados_Dosado_Item_Atual = true;

                    writeVariablesSlotIntoBuffer(3);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se foi finalizado a dosagem do silo 1 para salvar no banco de dados
                if (controleExecucao.Slot_3.Finalizou_Dosagem_Automatica_Silo_1)
                {
                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_3.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_1);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_1;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_1;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_3.Supervisorio_Salvou_Dados_Silo_1 = true;

                    controleExecucao.Slot_3.Finalizou_Dosagem_Automatica_Silo_1 = false;

                    writeVariablesSlotIntoBuffer(3);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }

                //Verifica se foi finalizado a dosagem do silo 2 para salvar no banco de dados
                if (controleExecucao.Slot_3.Finalizou_Dosagem_Automatica_Silo_2)
                {
                    DataBase.SQLFunctionsProducao.Update_PesoDosado_ProdutoBatelada(
                        VariaveisGlobais.ProducaoReceita.id,
                        controleExecucao.Slot_3.NumeroBatelada,
                        VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].codigo,
                        controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_2);

                    //Atualiza o produto batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].produtos[controleExecucao.Slot_3.Produto_Atual_Em_Producao - 1].pesoDosado = controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_2;

                    //Atualiza total dosado batelada
                    VariaveisGlobais.ProducaoReceita.batelada[controleExecucao.Slot_3.NumeroBatelada - 1].pesoDosado += controleExecucao.Slot_3.Dosado_Materia_Prima_Silo_2;

                    //Reseta o finalizado dosagem de complemento
                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

                    controleExecucao.Slot_3.Supervisorio_Salvou_Dados_Silo_2 = true;

                    controleExecucao.Slot_3.Finalizou_Dosagem_Automatica_Silo_2 = false;

                    writeVariablesSlotIntoBuffer(3);

                    VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
                }
            }

            #endregion

        }

        /// <summary>
        /// Inicia a dosagem manual do complemento pre
        /// </summary>
        public void InicioDosagemManualComplementoPre(int slot)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false; //Desabilita a leitura do buffer

            if (slot ==1)
            {
                controleExecucao.Slot_1.Complemento_Pre.Botao_Inicio_Fim_Dosagem_IHM = true;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 40, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_1.Complemento_Pre));
            }
            else if (slot == 2)
            {
                controleExecucao.Slot_2.Complemento_Pre.Botao_Inicio_Fim_Dosagem_IHM = true;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 126, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_2.Complemento_Pre));
            }
            else if (slot == 3)
            {
                controleExecucao.Slot_3.Complemento_Pre.Botao_Inicio_Fim_Dosagem_IHM = true;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 212, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_3.Complemento_Pre));
            }


            

            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;

        }


        /// <summary>
        /// Inicia a dosagem manual do complemento pos
        /// </summary>
        public void InicioDosagemManualComplementoPos(int slot)
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false; //Desabilita a leitura do buffer

            if (slot == 1)
            {
                controleExecucao.Slot_1.Complemento_Pos.Botao_Inicio_Fim_Dosagem_IHM = true;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 54, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_1.Complemento_Pos));
            }
            else if (slot == 2)
            {
                controleExecucao.Slot_2.Complemento_Pos.Botao_Inicio_Fim_Dosagem_IHM = true;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 140, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_2.Complemento_Pos));

            }
            else if (slot == 3)
            {
                controleExecucao.Slot_3.Complemento_Pos.Botao_Inicio_Fim_Dosagem_IHM = true;
                Comunicacao.Sharp7.S7.SetByteAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 226, Move_Bits.ComplementoToByteBatelada(controleExecucao.Slot_3.Complemento_Pos));
            }

            

            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;

        }

        public VariaveisGlobais.ControleExecucaoProducao ControleExecucao { get => controleExecucao;}
    }
}
