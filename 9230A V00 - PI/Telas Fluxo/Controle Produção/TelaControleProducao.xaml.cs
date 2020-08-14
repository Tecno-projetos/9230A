using _9230A_V00___PI.Utilidades;
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
    /// Interaction logic for TelaControleProducao.xaml
    /// </summary>
    public partial class TelaControleProducao : UserControl
    {
        int slotSolicitado = 0;

        public int SlotSolicitado { get => slotSolicitado; set => slotSolicitado = value; }

        public TelaControleProducao()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Status_Controle_Producao.SlotSolicitado = slotSolicitado;
            lb_Producao_Receita.Content = "Produção Nº: " + VariaveisGlobais.ProducaoReceita.id +" "+ VariaveisGlobais.ProducaoReceita.receita.nomeReceita;

            if (slotSolicitado == 1)
            {
                lb_NumeroBatelada.Content = "Batelada: " + VariaveisGlobais.executaProducao.ControleExecucao.Slot_1.NumeroBatelada;
            }
            else if (slotSolicitado == 2)
            {
                lb_NumeroBatelada.Content = "Batelada: " + VariaveisGlobais.executaProducao.ControleExecucao.Slot_2.NumeroBatelada;
            }
            else if (slotSolicitado == 3)
            {
                lb_NumeroBatelada.Content = "Batelada: " + VariaveisGlobais.executaProducao.ControleExecucao.Slot_3.NumeroBatelada;
            }

        }
    }
}
