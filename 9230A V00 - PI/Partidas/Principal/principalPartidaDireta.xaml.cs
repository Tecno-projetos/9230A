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

namespace _9230A_V00___PI.Partidas.Principal
{
    /// <summary>
    /// Lógica interna para principalPartidaDireta.xaml
    /// </summary>
    public partial class principalPartidaDireta : Window
    {

        private SolidColorBrush Vermelho = new SolidColorBrush(Colors.Red);
        private SolidColorBrush Branco = new SolidColorBrush(Colors.White);

        public event EventHandler Bt_Fechar_Click;

        public principalPartidaDireta(string titulo)
        {
            InitializeComponent();

            this.Title = titulo;
        }

        public void actualize_UI(Utilidades.VariaveisGlobais.type_All Command)
        {
            controlePD.actualize_UI(Command);
            configuracoesPD.actualize_UI(Command);

        }

        private void Home_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pckInicial.Foreground = Vermelho;
            pckAlarmes.Foreground = Branco;
            pckConfiguracoes.Foreground = Branco;

            this.Width = 245;
            this.Height = 510;

        }


        private void config_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pckInicial.Foreground = Branco;
            pckAlarmes.Foreground = Branco;
            pckConfiguracoes.Foreground = Vermelho;


            this.Width = 245;
            this.Height = 510;
        }

        private void alarmes_Tela_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Fechar_Click != null)
                this.Bt_Fechar_Click(this, e);
        }

    }
}
