using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace _9230A_V00___PI.Telas_Fluxo.Relatorios
{
    /// <summary>
    /// Interação lógica para pesquisaBatelada.xam
    /// </summary>
    public partial class pesquisaBatelada : UserControl
    {


        private List<Utilidades.Producao> pd = new List<Utilidades.Producao>();
        public pesquisaBatelada()
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


        }

        public void CombinedDialogOpenedEventHandler_FIM(object sender, DialogOpenedEventArgs eventArgs)
        {


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


        }

        #endregion

        #region Mover lista
        private void ButtonOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            PopupAddCustom1.IsOpen = false;
        }

        private void ButtonOpenDialogFim_Click(object sender, RoutedEventArgs e)
        {
            PopupAddCustom.IsOpen = false;
        }
        private void btLeftList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 5);
        }

        #endregion


        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            //Cria o datatable para inserir os dados.
            DataTable dt1 = new DataTable();

            //Envia a lista pesquisada para a lista auxiliar.
            pd = Utilidades.VariaveisGlobais.PesquisaProducao;

            //if (pd.Count > 0)
            //{
            //    pd.Clear();
            //}
            //pd = DataBase.SQLFunctionsProducao.PesquisaDateInDateOut()(Convert.ToDateTime(txtDataSelecionada.Content), Convert.ToDateTime(txtFIM.Content));

            dt1.Columns.Add("N° Produção");
            dt1.Columns.Add("Nome Receita");
            dt1.Columns.Add("Total Produzido");
            dt1.Columns.Add("Bateladas");


            foreach (var item in pd)
            {
                DataRow dr = dt1.NewRow();

                dr["N° Produção"] = item.receita.id;
                dr["Nome Receita"] = item.receita.nomeReceita;
                dr["Total Produzido"] = item.pesoTotalProduzido;
                dr["Bateladas"] = item.quantidadeBateladas;

                dt1.Rows.Add(dr);
            }

            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt1.DefaultView; });

        }

        private void DataGrid_Receita_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void DataGrid_Receita_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

            lbNomeProduto.Content = "N° Produção:" + (string)rowList.Row.ItemArray[0] + " - " + (string)rowList.Row.ItemArray[1];
        }
    }
}
