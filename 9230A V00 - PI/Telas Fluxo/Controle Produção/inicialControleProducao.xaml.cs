using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        public event EventHandler Bt1_Click;
        public event EventHandler Bt2_Click;
        public event EventHandler Bt3_Click;

        public void atualiza(ref Utilidades.ExecutaProducao executaProducao, ref Utilidades.Producao producao) 
        {
            lbNomeReceita.Content = producao.receita.nomeReceita;
            numeroBateladas.Content = producao.quantidadeBateladas;
            pesoTonelada.Content = producao.pesoTotalProducao;
            totalbateladas.Content = "/" + producao.quantidadeBateladas;
            bateladasconcluidas.Content = executaProducao.ControleExecucao.Bateladas_Finalizadas;


            statusSlot1 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_1.Status);
            statusSlot2 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_2.Status);
            statusSlot3 = Utilidades.functions.controleStatus(executaProducao.ControleExecucao.Slot_3.Status);

        }

        public inicialControleProducao()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt1_Click != null)
                this.Bt1_Click(this, e);
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt2_Click != null)
                this.Bt2_Click(this, e);
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt3_Click != null)
                this.Bt3_Click(this, e);
        }
    }
}
