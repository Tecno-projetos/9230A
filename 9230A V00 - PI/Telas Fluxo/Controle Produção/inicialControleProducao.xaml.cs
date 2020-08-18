using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9230A_V00___PI.Telas_Fluxo.Controle_Produção
{
    /// <summary>
    /// Interação lógica para inicialControleProducao.xam
    /// </summary>
    public partial class inicialControleProducao : UserControl
    {
        public event EventHandler BtSlot1_Click;
        public event EventHandler BtSlot2_Click;
        public event EventHandler BtSlot3_Click;

        public void atualiza(ref Utilidades.ExecutaProducao executaProducao, ref Utilidades.Producao producao) 
        {
            //Verifica se existe produção produzindo
            if (producao.id != 0)
            {
                lbNomeReceita.Content = producao.receita.nomeReceita;
                numeroBateladas.Content = producao.quantidadeBateladas;
                pesoTonelada.Content = producao.pesoTotalProducao.ToString("N", CultureInfo.GetCultureInfo("pt-BR"));
                bateladasconcluidas.Content = executaProducao.ControleExecucao.Bateladas_Finalizadas;


                statusSlot1 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_1.Status_Batelada, statusSlot1);
                statusSlot2 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_2.Status_Batelada, statusSlot2);
                statusSlot3 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_3.Status_Batelada, statusSlot3);

                bt1 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_1.Status_Batelada, bt1, executaProducao, 1, executaProducao.ControleExecucao.Slot_1.NumeroBatelada);

                bt2 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_2.Status_Batelada, bt2, executaProducao, 2, executaProducao.ControleExecucao.Slot_2.NumeroBatelada);

                bt3 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_3.Status_Batelada, bt3, executaProducao, 3, executaProducao.ControleExecucao.Slot_3.NumeroBatelada);
            }
            else
            {
                lbNomeReceita.Content = "Sem Receita em Produção";
                numeroBateladas.Content = "0";
                pesoTonelada.Content = "0";
                bateladasconcluidas.Content = "0";

                statusSlot1 = Utilidades.functions.controleStatus(0, statusSlot1);
                statusSlot2 = Utilidades.functions.controleStatus(0, statusSlot2);
                statusSlot3 = Utilidades.functions.controleStatus(0, statusSlot3);

                bt1 = Utilidades.functions.controleStatus(0, bt1, executaProducao, 1, 0);

                bt2 = Utilidades.functions.controleStatus(0, bt2, executaProducao, 2, 0);

                bt3 = Utilidades.functions.controleStatus(0, bt3, executaProducao, 3, 0);
            }



        }

        public inicialControleProducao()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            if (this.BtSlot1_Click != null)
                this.BtSlot1_Click(this, e);
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (this.BtSlot2_Click != null)
                this.BtSlot2_Click(this, e);
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            if (this.BtSlot3_Click != null)
                this.BtSlot3_Click(this, e);
        }
    }
}
