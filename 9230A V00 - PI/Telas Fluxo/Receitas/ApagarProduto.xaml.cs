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

namespace _9230A_V00___PI.Telas_Fluxo.Receitas
{
    /// <summary>
    /// Interaction logic for ApagarProduto.xaml
    /// </summary>
    public partial class ApagarProduto : UserControl
    {

        Utilidades.messageBox inputDialog;

        public ApagarProduto()
        {
            InitializeComponent();
        }

        private void btLeftList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 5);
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Utilidades.functions.atualizalistProdutos();

            var filter = from p in Utilidades.VariaveisGlobais.listProdutos
                         where p.codigo.Contains(txtCod.Text) &&
                         p.descricao.Contains(txtDesc.Text)
                         select p;

            var listProdutosFiltered = filter.ToList();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(listProdutosFiltered);

            DataGrid.Dispatcher.Invoke(delegate { DataGrid.ItemsSource = dt.DefaultView; });
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid.SelectedIndex != -1 )
            {
                var rowList = (DataGrid.ItemContainerGenerator.ContainerFromIndex(DataGrid.SelectedIndex) as DataGridRow).Item as DataRowView;

                lbNomeProduto.Content = (string)rowList.Row.ItemArray[1] + " - " + (string)rowList.Row.ItemArray[2];
            }

        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid.Columns[0].Visibility = Visibility.Hidden;
            DataGrid.Columns[1].Header = "Código";
            DataGrid.Columns[2].Header = "Descrição";
            DataGrid.Columns[3].Header = "Densidade (kg/m³)";
            DataGrid.Columns[4].Header = "Tipo Produto";
            DataGrid.Columns[5].Header = "Observação";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utilidades.functions.atualizalistProdutos();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(Utilidades.VariaveisGlobais.listProdutos);

            DataGrid.Dispatcher.Invoke(delegate { DataGrid.ItemsSource = dt.DefaultView; });

            lbNomeProduto.Content = "";
        }

        private void btApagarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedIndex != -1)
            {
                inputDialog = new Utilidades.messageBox("Apagar Produto", "Voçê tem certeza que deseja apagar? o processo não pode ser revertido!", MaterialDesignThemes.Wpf.PackIconKind.Error, "Sim", "Não");

                inputDialog.ShowDialog();

                if (inputDialog.DialogResult == true)
                {
                    var rowList = (DataGrid.ItemContainerGenerator.ContainerFromIndex(DataGrid.SelectedIndex) as DataGridRow).Item as DataRowView;

                    if (rowList != null)
                    {
                        if (DataBase.SqlFunctionsProdutos.getCodigoProdutoUsado((string)rowList.Row.ItemArray[1]) <= 0)
                        {
                            if (DataBase.SqlFunctionsProdutos.Delete_Rows(Convert.ToInt32(rowList.Row.ItemArray[0])))
                            {
                                inputDialog = new Utilidades.messageBox("Apagar", "Produto apagado com sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                                inputDialog.ShowDialog();

                                Utilidades.functions.atualizalistProdutos();

                                Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

                                DataTable dt = converter.ToDataTable(Utilidades.VariaveisGlobais.listProdutos);

                                DataGrid.Dispatcher.Invoke(delegate { DataGrid.ItemsSource = dt.DefaultView; });

                            }
                            else
                            {
                                inputDialog = new Utilidades.messageBox("Apagar", "Ocorreu algum erro ao apagar!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                                inputDialog.ShowDialog();
                            }
                        }
                        else
                        {
                            inputDialog = new Utilidades.messageBox("Apagar Produto", "O produto selecionado existe em uma receita!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }
                    }
                    else
                    {
                        inputDialog = new Utilidades.messageBox("Apagar", "Verifique se selecionou algum produto!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                        inputDialog.ShowDialog();
                    }

                }
            }


        }

        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)e.OriginalSource;
                tb.Dispatcher.BeginInvoke(
                    new Action(delegate
                    {
                        tb.SelectAll();
                    }), System.Windows.Threading.DispatcherPriority.Input);
            }
            catch (Exception ex)
            {
                Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();

            }
        }

    }
}
