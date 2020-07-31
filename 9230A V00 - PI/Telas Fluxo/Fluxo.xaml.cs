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
    /// Interação lógica para Fluxo.xam
    /// </summary>
    public partial class Fluxo : UserControl
    {
        public Fluxo()
        {
            InitializeComponent();
        }

        Partidas.controleAtuadorAnalogico controleAtuadorAnalogico = new Partidas.controleAtuadorAnalogico();

        Partidas.controleAtuadorLinear controleAtuadorLinear = new Partidas.controleAtuadorLinear();

        Partidas.controleAtuadorLinearBifurcada controleAtuadorLinearBifurcada = new Partidas.controleAtuadorLinearBifurcada();


        private void telaAnalogica_Click(object sender, RoutedEventArgs e)
        {
            controleAtuadorAnalogico.Show();
        }

        private void telaRegistro_Click(object sender, RoutedEventArgs e)
        {
            controleAtuadorLinear.Show();
        }

        private void telaRBifurcada_Click(object sender, RoutedEventArgs e)
        {
            controleAtuadorLinearBifurcada.Show();
        }
    }
}
