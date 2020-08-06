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

        private string tagEquip = "";

        public event EventHandler Bt_Fechar_Click;

        public principalPartidaDireta(string nome, string tag, string numeroPartida, string paginaProjeto)
        {
            InitializeComponent();          
            this.Title = nome + " " + tag;

            pckInicial.Foreground = Vermelho;
            pckAlarmes.Foreground = Branco;
            pckConfiguracoes.Foreground = Branco;

            tagEquip = tag;

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

            this.Height = 510;
            this.Width = 255;

        }


        private void config_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pckInicial.Foreground = Branco;
            pckAlarmes.Foreground = Branco;
            pckConfiguracoes.Foreground = Vermelho;


            this.Height = 510;
            this.Width = 255;

        }

        private void alarmes_Tela_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pckInicial.Foreground = Branco;
            pckAlarmes.Foreground = Vermelho;
            pckConfiguracoes.Foreground = Branco;


            this.Height = 510;
            this.Width = 515;

            DateTime dtin;
            DateTime dtout;

            dtin = DateTime.Now.AddMonths(-1);
            dtout = DateTime.Now.AddMinutes(2);

            /// Referencia de código para a tela de alarmes
            // Click para atualizar os alarmes tela de alarmes
            alarmes.DataGrid_ItemSource_Alarms_And_Events(DataBase.SqlFunctionsEquips.GetReportAlarm_Table_EquipAlarmEvent(dtin, dtout, "_" + tagEquip), alarmes.DataGrid_Search_Alarme, true);

            //Click para atualizar os Eventos na tela de alarmes
            alarmes.DataGrid_ItemSource_Alarms_And_Events(DataBase.SqlFunctionsEquips.GetReportEvent_Table_EquipAlarmEvent(dtin, dtout, "_" + tagEquip), alarmes.DataGrid_Search_Eventos, false);

        }

        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Bt_Fechar_Click != null)
                this.Bt_Fechar_Click(this, e);
        }

    }
}
