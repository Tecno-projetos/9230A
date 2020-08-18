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
    /// Interação lógica para pesquisaReceita.xam
    /// </summary>
    public partial class pesquisaReceita : UserControl
    {
        public pesquisaReceita()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utilidades.functions.atualizalistReceitas();

            loadDataReceitas();


        }

        #region Move List

        private void btLeftList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Produtos, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 5);
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


        private void atualizaFiltroDataReceita()
        {
            Utilidades.functions.atualizalistReceitas();

            var filter = from p in Utilidades.VariaveisGlobais.listReceitas where p.nomeReceita.Contains(txtDesc.Text) select p;

            var listReceitaFiltered = filter.ToList();

            //Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            //DataTable dt = converter.ToDataTable(listReceitaFiltered);
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Peso Base");
            dt.Columns.Add("Produção");
            dt.Columns.Add("Observação");

            foreach (var item in listReceitaFiltered)
            {
                DataRow dr = dt.NewRow();

                dr["Id"] = item.id;
                dr["Nome"] = item.nomeReceita;
                dr["Peso Base"] = item.pesoBase;
                dr["Produção"] = item.listProdutos.Count;
                dr["Observação"] = item.observacao;

                dt.Rows.Add(dr);
            }


            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });
            DataGrid_Receita.Columns[0].Visibility = Visibility.Hidden;

        }


        private void loadDataReceitas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Nome");
            dt.Columns.Add("Peso Base");
            dt.Columns.Add("Produção");
            dt.Columns.Add("Observação");

            foreach (var item in Utilidades.VariaveisGlobais.listReceitas)
            {
                DataRow dr = dt.NewRow();

                dr["Id"] = item.id;
                dr["Nome"] = item.nomeReceita;
                dr["Peso Base"] = item.pesoBase;
                dr["Produção"] = item.listProdutos.Count;
                dr["Observação"] = item.observacao;

                dt.Rows.Add(dr);
            }

            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });

            DataGrid_Receita.Columns[0].Visibility = Visibility.Hidden;

        }

        private void DataGrid_Receita_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Atualiza o Grid de equipamentos com os equipamentos que pertencem a receita selecionada.
            if (DataGrid_Receita.SelectedIndex != -1)
            {

                var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

                Utilidades.functions.atualizalistReceitas();

                var index = Utilidades.VariaveisGlobais.listReceitas.FindIndex(x => x.id == Convert.ToInt32(rowList.Row.ItemArray[0]));

                DataTable dt = new DataTable();

                dt.Columns.Add("Produto");
                dt.Columns.Add("Peso(kg)");
       

                foreach (var item in Utilidades.VariaveisGlobais.listReceitas[index].listProdutos)
                {
                    DataRow dr = dt.NewRow();

                    dr["Produto"] = item.produto.descricao;
                    dr["Peso(kg)"] = item.pesoPorProduto;

                    dt.Rows.Add(dr);
                }

                DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
            }
        }


        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            atualizaFiltroDataReceita();
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }
    }
}
