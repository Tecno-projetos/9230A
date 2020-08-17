using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
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
    /// Interação lógica para configuracoes.xam
    /// </summary>
    public partial class configuracoes : UserControl
    {

        Telas_Fluxo.Configuracoes.Especificacoes especificaoes = new Configuracoes.Especificacoes();

        Telas_Fluxo.Configuracoes.especificacoesRegistros especificaoesRegistro = new Configuracoes.especificacoesRegistros();
        public configuracoes()
        {
            InitializeComponent();

        }

        private void btInformacoesEspecificacoes_Click(object sender, RoutedEventArgs e)
        {
            if (spConfiguracao != null)
            {
                spConfiguracao.Children.Clear();
            }

            spConfiguracao.Children.Add(especificaoes);
        }


        private void btInformacoesEspecificacoesRegistro_Click(object sender, RoutedEventArgs e)
        {
            if (spConfiguracao != null)
            {
                spConfiguracao.Children.Clear();
            }

            spConfiguracao.Children.Add(especificaoesRegistro);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (spConfiguracao != null)
            {
                spConfiguracao.Children.Clear();
            }
        }
    }
}
