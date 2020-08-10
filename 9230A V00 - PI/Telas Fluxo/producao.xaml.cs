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

namespace _9230A_V00___PI.Telas_Fluxo
{
    /// <summary>
    /// Interação lógica para producao.xam
    /// </summary>
    public partial class producao : UserControl
    {
        Telas_Fluxo.Producao.ProducaoTelaInicial TelaInicialProducao = new Producao.ProducaoTelaInicial();
        Telas_Fluxo.Producao.ConfiguracaoReceitaProducao TelaConfiguracaoReceitaProducao = new Producao.ConfiguracaoReceitaProducao();

        public producao()
        {
            InitializeComponent();

            TelaInicialProducao.EventoReceitaSelecionada += new EventHandler(EventoReceitaSelecionada);
        }

        protected void EventoReceitaSelecionada(object sender, EventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaConfiguracaoReceitaProducao);
        }

        private void btTelaInicialEnsaque_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btTelaInicialRacao_Click(object sender, RoutedEventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaInicialProducao);
        }
    }
}
