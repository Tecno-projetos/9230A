using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
        
        private string fileName = "";
        private string nameArquivo = "";
        private string folder = @"C:\Temp";
        private bool NecessitaApagar = false;
        private string OldfileName = "";
        private string exportacao = "";
        private Int32 idproducao = -1;

        Utilidades.messageBox inputDialog;

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

        private void controlVisible(Visibility visibility)         
        {
            rec.Visibility = visibility;
            lbNomeProduto.Visibility = visibility;
            DataGrid_Receita.Visibility = visibility;
        }

        #region Controle Calendario

        public void CombinedDialogOpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {
            controlVisible(Visibility.Hidden);
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

            controlVisible(Visibility.Visible);
        }

        public void CombinedDialogOpenedEventHandler_FIM(object sender, DialogOpenedEventArgs eventArgs)
        {
            controlVisible(Visibility.Hidden);

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

            controlVisible(Visibility.Visible);


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


            if (pd.Count > 0)
            {
                pd.Clear();
            }

            pd = Utilidades.functions.PesquisaDateInDateOut(Convert.ToDateTime(txtDataSelecionada.Content), Convert.ToDateTime(txtFIM.Content));


            dt1.Columns.Add("N° Produção");
            dt1.Columns.Add("Nome Receita");
            dt1.Columns.Add("Total Produzido");
            dt1.Columns.Add("Bateladas");
            dt1.Columns.Add("Data Produção");

            foreach (var item in pd)
            {
                DataRow dr = dt1.NewRow();

                dr["N°"] = item.id;
                dr["Nome Receita"] = item.receita.nomeReceita;
                dr["Total Produzido"] = item.pesoTotalProduzido;
                dr["Bateladas"] = item.quantidadeBateladas;
                dr["Data Produção"] = item.dateTimeInicioProducao;

                dt1.Rows.Add(dr);
            }

            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt1.DefaultView; });

        }

        private void DataGrid_Receita_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

            idproducao = Convert.ToInt32((string)rowList.Row.ItemArray[0]);

            lbNomeProduto.Content = "N° Produção: " + (string)rowList.Row.ItemArray[0] + " - Nome Receita: " + (string)rowList.Row.ItemArray[1];
        }

        private void btExportar_Click(object sender, RoutedEventArgs e)
        {
            discoExportar exportacaoMessage = new discoExportar();

            if (exportacaoMessage.ShowDialog() == true)
            {
                exportacao = exportacaoMessage.discoExportacao;

                if (!String.IsNullOrEmpty((string)lbNomeProduto.Content))
                {
                    string destinationFile = exportacao + "\\" + nameArquivo;

                    if (!File.Exists(destinationFile))
                    {
                        inputDialog = new Utilidades.messageBox("Exportando", "Isso pode levar alguns minutos, por favor aguarde.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                        inputDialog.ShowDialog();

                        //Relatorios.ExportacaoRelatorios.exportProducao(destinationFile, Utilidades.VariaveisGlobais.PesquisaProducao, "Produção Total", DateTime.Now, DateTime.Now);

                        //Original
                        //Relatorios.ExportacaoRelatorios.exportProducao(fileName, DataBase.SQLFunctionsProducao.PesquisaDateInDateOut(producao.dataInicial_GS, producao.dataFinal_GS), "Produção Total", DateTime.Now, DateTime.Now);

                        inputDialog = new Utilidades.messageBox("Arquivo exportado", "O arquivo foi exportado com sucesso", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                        inputDialog.ShowDialog();

                    }
                    else
                    {
                        inputDialog = new Utilidades.messageBox("Arquivo já exportado", "O arquivo já foi exportado.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                        inputDialog.ShowDialog();

                    }
                }
                else
                {
                    inputDialog = new Utilidades.messageBox("Realizar Pesquisa", "Para exportar algum arquivo é necessário realizar a pesquisa.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Operação Cancelada", "A exportação foi cancelada pelo usuário.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
        }

        private void KillRunningProcess()
        {
            Process[] tabtip = Process.GetProcessesByName("Acrord32");

            if (null != tabtip)
            {
                tabtip.ToList().ForEach(a => { if (null != a) { a.Kill(); } });

            }
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty((string)lbNomeProduto.Content) && idproducao != -1)
            {
                inputDialog = new Utilidades.messageBox("Gerar relatório", "Deseja gerar o relátorio " + lbNomeProduto.Content, MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                if (inputDialog.ShowDialog() == true)
                {

                    string filename = " ";

                    //Abre onde deseja salvar
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Balanca_" + "" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year; // Default file name
                    dlg.DefaultExt = ".pdf"; // Default file extension
                    dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension

                    // Show save file dialog box
                    Nullable<bool> result = dlg.ShowDialog();
                    // Process save file dialog box results
                    if (result == true)
                    {
                        // Save document
                        filename = dlg.FileName;

                        //Original
                        Relatorios.ExportacaoRelatorios.exportarBatelada(filename, Utilidades.functions.GetProducaoFromIdProducao(idproducao), "Produção Total");


                        //Tester
                        //Relatorios.ExportacaoRelatorios.exportarBatelada(filename, Utilidades.VariaveisGlobais.PesquisaProducao.ElementAt(idproducao), "Produção Total", DateTime.Now, DateTime.Now);


                        System.Diagnostics.Process.Start(filename);

                    }
                }
                else
                {
                    inputDialog = new Utilidades.messageBox("Operação Cancelada", "A exportação foi cancelada pelo usuário.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Selecione produção!", "Para gerar reletórios ", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
            
            



        }
    }
}
