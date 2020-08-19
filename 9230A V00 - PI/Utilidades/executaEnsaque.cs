using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9230A_V00___PI.Utilidades
{
    public class executaEnsaque
    {

        Utilidades.VariaveisGlobais.Ensaque ensaque = new Utilidades.VariaveisGlobais.Ensaque(); //Slot 1 
        int bufferPlc;

        public executaEnsaque(int bufferPlc)
        {
            this.bufferPlc = bufferPlc;
        }

        private void readVariablesBuffer()
        {
            //Leitura Controle
            ensaque.controleEnsaque.quantidadeEnsaques = Comunicacao.Sharp7.S7.GetDIntAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 4);
            ensaque.controleEnsaque.pesoDesejado = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 8);
            ensaque.controleEnsaque.pesoSacoAtual = Comunicacao.Sharp7.S7.GetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 12);
            ensaque.controleEnsaque = Move_Bits.DwordTocontroleEnsaque(Comunicacao.Sharp7.S7.GetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 0), ensaque.controleEnsaque);

        }

        public void escreverDword() 
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;

            Comunicacao.Sharp7.S7.SetDWordAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 0, Move_Bits.EnsaqueToDwordControleEnsaque(ensaque.controleEnsaque)); //Atualiza os Bits do command

            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;

        }
        private void writeVariables()
        {
            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read = false;
            //Escreve peso desejado por saco
            Comunicacao.Sharp7.S7.SetRealAt(VariaveisGlobais.Buffer_PLC[bufferPlc].Buffer, 8, ensaque.controleEnsaque.pesoDesejado);

            VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Write = true;
        }

        public bool Ensacar
        {
            set
            {
                //Leitura das variáveis
                if (VariaveisGlobais.Buffer_PLC[bufferPlc].Enable_Read)
                {
                    readVariablesBuffer();
                }
            }

        }
        public VariaveisGlobais.Ensaque Ensaque_GS { get => ensaque; set => ensaque = value; }

        private void salvaValores() 
        {
        
        
        
        }
    
    }
}
