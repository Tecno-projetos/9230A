using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;


namespace _9230A_V00___PI.Telas_Fluxo.Relatorios
{
    /// <summary>
    /// Interação lógica para relatorioExportacao.xam
    /// </summary>
    public partial class relatorioExportacao : UserControl
    {


        public relatorioExportacao()
        {
            InitializeComponent();
            DataContext = new PickersViewModel();

            var lang = System.Windows.Markup.XmlLanguage.GetLanguage("pt-BR");
            CombinedCalendar.Language = lang;
            CombinedClock.Language = lang;
        }


        private void PresetTimePicker_SelectedTimeChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<System.DateTime?> e)
        {
            var oldValue = e.OldValue.HasValue ? e.OldValue.Value.ToLongTimeString() : "NULL";
            var newValue = e.NewValue.HasValue ? e.NewValue.Value.ToLongTimeString() : "NULL";

            Debug.WriteLine($"PresentTimePicker's SelectedTime changed from {oldValue} to {newValue}");
        }

        public void CombinedDialogOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {


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
            }
        }
    }
}
