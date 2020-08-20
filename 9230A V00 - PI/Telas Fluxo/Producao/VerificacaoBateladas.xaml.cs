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

namespace _9230A_V00___PI.Telas_Fluxo.Producao
{
    /// <summary>
    /// Interaction logic for VerificacaoBateladasE.xaml
    /// </summary>
    public partial class VerificacaoBateladas : UserControl
    {
        public event EventHandler IniciouProducao;
        public event EventHandler TelaAnterior;

        Utilidades.messageBox inputDialog;

        public VerificacaoBateladas()
        {
            InitializeComponent();
        }


        private void btLeftList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Bateladas, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Bateladas, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Bateladas, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Bateladas, 0) as Decorator).Child as ScrollViewer;

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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //Carrega as bateladas no datagrid
            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(Utilidades.VariaveisGlobais.ProducaoReceita.batelada);
            DataGrid_Bateladas.Dispatcher.Invoke(delegate { DataGrid_Bateladas.ItemsSource = dt.DefaultView; });

            //Atualiza o peso de cada produto de cada batelada de acordo com a receita e o peso da batelada
            atualizaProdutosBatelada();
        }

        /// <summary>
        /// cria cada produto necessário para cada batelada e atualiza as informações
        /// </summary>
        private void atualizaProdutosBatelada()
        {
            //Cria cada produto na batelada
            //Atualizado o peso desejado para cada produto
            //Fatorpeso = (Peso da batelada total / Peso total da base da receita)
            //Peso desejado = pesoProdutoNaRceita * fatorPeso 

            Utilidades.ProdutoBatelada produtoBatelada;
            //Pegada cada batelada
            foreach (var item in Utilidades.VariaveisGlobais.ProducaoReceita.batelada)
            {
                float FatorPeso = item.pesoDesejado / Utilidades.VariaveisGlobais.ProducaoReceita.receita.pesoBase;

                //pega cada produto da receita base
                foreach (var item1 in Utilidades.VariaveisGlobais.ProducaoReceita.receita.listProdutos)
                {
                    produtoBatelada = new Utilidades.ProdutoBatelada();

                    //Preenchido os dados do produto
                    produtoBatelada.id = item1.produto.id;
                    produtoBatelada.codigo = item1.produto.codigo;
                    produtoBatelada.descricao = item1.produto.descricao;
                    produtoBatelada.densidade = item1.produto.densidade;
                    produtoBatelada.tipoProduto = item1.produto.tipoProduto;
                    produtoBatelada.observacao = item1.produto.observacao;

                    //preenchido os dados do produtoBatelada
                    produtoBatelada.pesoDesejado = item1.pesoPorProduto * FatorPeso;
                    produtoBatelada.idProducao = Utilidades.VariaveisGlobais.ProducaoReceita.id;

                    item.produtos.Add(produtoBatelada);
                }
            }
        }

        private void DataGrid_Bateladas_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid_Bateladas.Columns[2].Visibility = Visibility.Hidden;
            DataGrid_Bateladas.Columns[3].Visibility = Visibility.Hidden;

            DataGrid_Bateladas.Columns[0].Header = "N° Batelada";
            DataGrid_Bateladas.Columns[1].Header = "Peso Batelada";
        }

        private void DataGrid_Bateladas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid_Bateladas.SelectedIndex != -1)
            {
                //Verifica a batelada selecionada e carrega para o datagrid os produtos com seu peso proporcional ao peso da batelada e a receita.

                var rowList = (DataGrid_Bateladas.ItemContainerGenerator.ContainerFromIndex(DataGrid_Bateladas.SelectedIndex) as DataGridRow).Item as DataRowView;

                var index = Utilidades.VariaveisGlobais.ProducaoReceita.batelada.FindIndex(x => x.numeroBatelada == Convert.ToInt32(rowList.Row.ItemArray[0]));

                DataTable dt = new DataTable();

                dt.Columns.Add("Produto");
                dt.Columns.Add("Peso(kg)");

                foreach (var item in Utilidades.VariaveisGlobais.ProducaoReceita.batelada[index].produtos)
                {
                    DataRow dr = dt.NewRow();

                    dr["Produto"] = item.descricao;
                    dr["Peso(kg)"] = item.pesoDesejado;

                    dt.Rows.Add(dr);
                }

                DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });


            }

        }

        private void btContinuar_Click(object sender, RoutedEventArgs e)
        {
            inputDialog = new Utilidades.messageBox("Confirmação", "Você tem certeza que deseja iniciar a produção?", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

            inputDialog.ShowDialog();

            if (inputDialog.DialogResult == true)
            {
                //Preenche data inicial e data final
                Utilidades.VariaveisGlobais.ProducaoReceita.dateTimeInicioProducao = DateTime.Now;
                Utilidades.VariaveisGlobais.ProducaoReceita.dateTimeFimProducao = DateTime.Now;

                //Preenche que iniciou a produção
                Utilidades.VariaveisGlobais.ProducaoReceita.IniciouProducao = true;

                DataBase.SQLFunctionsProducao.AddProducao(Utilidades.VariaveisGlobais.ProducaoReceita);

                //Verifica qual Produção esta em execução e carrega a produção
                DataBase.SQLFunctionsProducao.AtualizaProducaoEmExecucao();

                if (this.IniciouProducao != null)
                    this.IniciouProducao(this, e);
            }


        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            //Chama proximo tela
            if (this.TelaAnterior != null)
                this.TelaAnterior(this, e);
        }
    }
}
