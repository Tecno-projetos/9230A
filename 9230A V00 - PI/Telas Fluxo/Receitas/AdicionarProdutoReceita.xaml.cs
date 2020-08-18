using _9230A_V00___PI.Utilidades;
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
    /// Interaction logic for AdicionarProdutoReceita.xaml
    /// </summary>
    public partial class AdicionarProdutoReceita : UserControl
    {
        string filtroTipoProduto = "";

        public event EventHandler FinalizadoAdicaoProdutosReceita;

        public AdicionarProdutoReceita()
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

            //Atualiza o datagrid de receitas com os produtos inseridos na receita cadastro
            loadDataReceitas();

        }

        private void DataGrid_Produtos_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid_Produtos.Columns[0].Visibility = Visibility.Visible;
            DataGrid_Produtos.Columns[3].Visibility = Visibility.Visible;
            DataGrid_Produtos.Columns[4].Visibility = Visibility.Visible;
            DataGrid_Produtos.Columns[5].Visibility = Visibility.Visible;

            DataGrid_Produtos.Columns[1].Header = "Código";
            DataGrid_Produtos.Columns[2].Header = "Descrição";
        }

        private void DataGrid_Produtos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

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

        private void DataGrid_Receita_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void DataGrid_Receita_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid_Receita.Columns[0].Visibility = Visibility.Hidden;

            //DataGrid_Receita.Columns[0].Header = "Produto";
            //DataGrid_Receita.Columns[1].Header = "Peso";
        }
        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void btAddProdutoReceita_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Produtos.SelectedIndex != -1)
            {
                var rowList = (DataGrid_Produtos.ItemContainerGenerator.ContainerFromIndex(DataGrid_Produtos.SelectedIndex) as DataGridRow).Item as DataRowView;

                //Verifica se ja não tem o item na lista 
                if (true)
                {
                    Utilidades.ProdutoReceita produtoReceita = new Utilidades.ProdutoReceita();
                    produtoReceita.produto = new Produto();

                    produtoReceita.produto.id = Convert.ToInt32(rowList.Row.ItemArray[0]);
                    produtoReceita.produto.codigo = Convert.ToString(rowList.Row.ItemArray[1]);
                    produtoReceita.produto.descricao = Convert.ToString(rowList.Row.ItemArray[2]);
                    produtoReceita.produto.densidade = Convert.ToSingle(rowList.Row.ItemArray[3]);
                    produtoReceita.produto.tipoProduto = Convert.ToString(rowList.Row.ItemArray[4]);
                    produtoReceita.produto.observacao = Convert.ToString(rowList.Row.ItemArray[5]);

                    //Abre tela para escolha do peso do produto na receita e se a matéria prima irá ser dosada manual ou automáticamente
                    Telas_Fluxo.Receitas.AdicionarProdutoReceitaPouUp adcionaProdutoReceita = new AdicionarProdutoReceitaPouUp(produtoReceita, 0, false, "");
                    adcionaProdutoReceita.ShowDialog();
                    loadDataReceitas();
                }
                else
                {
                    //Avisa que não pode adicionar o mesmo item na lista
                }
            }
           
        }

        private void btEditarProdutoReceita_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Receita.SelectedIndex != -1)
            {
                var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

                var index = Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.FindIndex(x => x.produto.id == Convert.ToInt32(rowList.Row.ItemArray[0]));

                //Abre tela para editar o produto
                Telas_Fluxo.Receitas.AdicionarProdutoReceitaPouUp adcionaProdutoReceita = new AdicionarProdutoReceitaPouUp(Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index], Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index].pesoPorProduto, true, Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index].tipoDosagemMateriaPrima);
                adcionaProdutoReceita.ShowDialog();
                loadDataReceitas();
            }


        }

        private void btSubProdutoReceita_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Receita.SelectedIndex != -1)
            {
                var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

                var index = Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.FindIndex(x => x.produto.id == Convert.ToInt32(rowList.Row.ItemArray[0]));

                Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.RemoveAt(index);

                loadDataReceitas();
            }

        }

        private void loadDataProdutos()
        {
            Utilidades.functions.atualizalistProdutos();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(Utilidades.VariaveisGlobais.listProdutos);

            DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
        }

        private void loadDataReceitas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Produto");
            dt.Columns.Add("Peso(kg)");

            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                DataRow dr = dt.NewRow();

                dr["Id"] = item.produto.id;
                dr["Produto"] = item.produto.descricao;
                dr["Peso(kg)"] = item.pesoPorProduto;

                dt.Rows.Add(dr);
            }


            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });
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

            var filter = from p in Utilidades.VariaveisGlobais.listProdutos where p.descricao.Contains(txtDesc.Text) && p.tipoProduto.Contains(filtroTipoProduto)
                         select p;

            var listProdutosFiltered = filter.ToList();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(listProdutosFiltered);

            DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
        }

        private void btFinalizarAdicaoProduto_Click(object sender, RoutedEventArgs e)
        {
            if (this.FinalizadoAdicaoProdutosReceita != null)
                this.FinalizadoAdicaoProdutosReceita(this, e);
        }
    }
}
