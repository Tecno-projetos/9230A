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
    /// Interação lógica para pesquisaProduto.xam
    /// </summary>
    public partial class pesquisaProduto : UserControl
    {
        string filtroTipoProduto = "";

        public pesquisaProduto()
        {
            InitializeComponent();
        }

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

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            atualizaFiltroDataProduto();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Atualiza a lista de produtos conforme os filtros
            if (filtroTipoProduto == "Matéria Prima")
            {
                filtroMateriaPrima();
            }
            else if (filtroTipoProduto == "Complemento")
            {
                filtroComplemento();
            }

            atualizaFiltroDataProduto();
        }

        private void DataGrid_Produtos_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid_Produtos.Columns[0].Visibility = Visibility.Hidden;
            DataGrid_Produtos.Columns[1].Header = "Código";
            DataGrid_Produtos.Columns[2].Header = "Descrição";
            DataGrid_Produtos.Columns[3].Header = "Densidade";
            DataGrid_Produtos.Columns[4].Header = "Tipo Produto";
            DataGrid_Produtos.Columns[5].Header = "Observação";
        }

        private void filtroMateriaPrima()
        {
            btMateriaPrima.Background = new SolidColorBrush(Colors.ForestGreen);
            btComplemento.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));
            filtroTipoProduto = "Matéria Prima";
        }

        private void filtroComplemento()
        {
            btComplemento.Background = new SolidColorBrush(Colors.ForestGreen);
            btMateriaPrima.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

            filtroTipoProduto = "Complemento";
        }

        private void atualizaFiltroDataProduto()
        {
            Utilidades.functions.atualizalistProdutos();

            var filter = from p in Utilidades.VariaveisGlobais.listProdutos
                         where p.descricao.Contains(txtDesc.Text) && p.tipoProduto.Contains(filtroTipoProduto)
                         select p;

            var listProdutosFiltered = filter.ToList();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(listProdutosFiltered);

            DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
        }

        private void btMateriaPrima_Click(object sender, RoutedEventArgs e)
        {
            filtroMateriaPrima();
            atualizaFiltroDataProduto();
        }

        private void btComplemento_Click(object sender, RoutedEventArgs e)
        {
            filtroComplemento();
            atualizaFiltroDataProduto();
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

    }
}
