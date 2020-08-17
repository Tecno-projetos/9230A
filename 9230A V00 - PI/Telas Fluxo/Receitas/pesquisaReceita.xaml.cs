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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataReceitas();

            atualizaFiltroDataReceita();

        }

        private void atualizaFiltroDataReceita()
        {
            Utilidades.functions.atualizalistReceitas();

            var filter = from p in Utilidades.VariaveisGlobais.listReceitas where p.nomeReceita.Contains(txtDesc.Text) select p;

            var listReceitaFiltered = filter.ToList();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(listReceitaFiltered);

            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });
        }


        private void loadDataReceitas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Produto");
            dt.Columns.Add("Peso(kg)");

            foreach (var item in Utilidades.VariaveisGlobais.listReceitas)
            {
                DataRow dr = dt.NewRow();

                dr["Nome"] = item.nomeReceita;
                dr["Peso Base"] = item.pesoBase;
                dr["Quantidade Produtos"] = item.listProdutos.Count;
                dr["Observação"] = item.observacao;

                dt.Rows.Add(dr);
            }


            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });
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
