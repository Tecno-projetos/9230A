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
using System.Windows.Shapes;

namespace _9230A_V00___PI.Telas_Fluxo.Producao
{
    /// <summary>
    /// Lógica interna para PopUpFinalizarDosagem.xaml
    /// </summary>
    public partial class PopUpFinalizarDosagem : Window
    {

        public PopUpFinalizarDosagem(float pesodosado)
        {
            InitializeComponent();

            txtPeso.Text = Convert.ToString(pesodosado);

        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            this.Hide();
        }
    }
}
