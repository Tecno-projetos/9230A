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

namespace _9230A_V00___PI.Telas_Fluxo.Configuracoes
{
    /// <summary>
    /// Interaction logic for Especificacoes.xaml
    /// </summary>
    public partial class Especificacoes : UserControl
    {
        Utilidades.messageBox inputDialog;

        public Especificacoes()
        {
            InitializeComponent();
        }

        private void btSalvarInformacoes_Click(object sender, RoutedEventArgs e)
        {
            EscritaInformacoes();
        }

        private void LeituraInformacoes()
        {

        }

        private void EscritaInformacoes()
        {



            inputDialog = new Utilidades.messageBox("Salvar", "Informações salvas com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

            inputDialog.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LeituraInformacoes();
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }
    }
}
