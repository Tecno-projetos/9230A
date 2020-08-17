using _9230A_V00___PI.Telas_Fluxo.Relatorios;
using MaterialDesignThemes.Wpf;
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

namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interação lógica para alarmes.xam
    /// </summary>
    public partial class alarmes : UserControl
    {
        public alarmes()
        {
            InitializeComponent();
            DataContext = new PickersViewModel();

            var lang = System.Windows.Markup.XmlLanguage.GetLanguage("pt-BR");
            CombinedCalendar.Language = lang;
            CombinedClock.Language = lang;

            CombinedCalendar_FIM.Language = lang;
            CombinedClock_FIM.Language = lang;

            int descontarsegundos;
            descontarsegundos = DateTime.Now.Second;

            txtDataSelecionada.Content = DateTime.Now.AddSeconds(-descontarsegundos).AddDays(-1).ToString();

            txtFIM.Content = DateTime.Now.AddSeconds(-descontarsegundos).AddMinutes(1).ToString();

        }

        #region Controle Calendario

        public void CombinedDialogOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {
            DataGrid_Search_Alarme.Visibility = Visibility.Hidden;


            CombinedCalendar.SelectedDate = ((PickersViewModel)DataContext).Date;
            CombinedClock.Time = ((PickersViewModel)DataContext).Time;
        }

        public void CombinedDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (Equals(eventArgs.Parameter, "1"))
            {

                var combined = CombinedCalendar.SelectedDate.Value.AddSeconds(CombinedClock.Time.TimeOfDay.TotalSeconds);
                ((PickersViewModel)DataContext).Time = combined;
                ((PickersViewModel)DataContext).Date = combined;

                int descontarsegundos;
                descontarsegundos = combined.Second;

                txtDataSelecionada.Content = Convert.ToString(combined.AddSeconds(-descontarsegundos));
            }

            DataGrid_Search_Alarme.Visibility = Visibility.Visible;
        }

        public void CombinedDialogOpenedEventHandler_FIM(object sender, DialogOpenedEventArgs eventArgs)
        {

            DataGrid_Search_Alarme.Visibility = Visibility.Hidden;

            CombinedCalendar_FIM.SelectedDate = ((PickersViewModel)DataContext).Date;
            CombinedClock_FIM.Time = ((PickersViewModel)DataContext).Time;


        }

        public void CombinedDialogClosingEventHandler_FIM(object sender, DialogClosingEventArgs eventArgs)
        {
            if (Equals(eventArgs.Parameter, "1"))
            {
                var combined = CombinedCalendar_FIM.SelectedDate.Value.AddSeconds(CombinedClock_FIM.Time.TimeOfDay.TotalSeconds);
                ((PickersViewModel)DataContext).Time = combined;
                ((PickersViewModel)DataContext).Date = combined;

                int descontarsegundos;
                descontarsegundos = combined.Second;

                txtFIM.Content = Convert.ToString(combined.AddSeconds(-descontarsegundos));
            }

            DataGrid_Search_Alarme.Visibility = Visibility.Visible;
        }

        #endregion

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_Search_Alarme_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void ButtonOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            PopupAddCustom1.IsOpen = false;
        }

        private void ButtonOpenDialogFim_Click(object sender, RoutedEventArgs e)
        {
            PopupAddCustom.IsOpen = false;
        }
    }
}

