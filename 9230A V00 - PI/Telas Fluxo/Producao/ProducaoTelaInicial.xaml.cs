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
    /// Interaction logic for ProducaoTelaInicial.xaml
    /// </summary>
    public partial class ProducaoTelaInicial : UserControl
    {
        public event EventHandler EventoReceitaSelecionada;

        Utilidades.messageBox inputDialog;

        public ProducaoTelaInicial()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utilidades.functions.atualizalistReceitas();

            DataTable dt = new DataTable();

            dt = DataBase.SqlFunctionsReceitas.getReceitas();

            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });

            DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = null; });
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
                dt.Columns.Add("Tipo");
                dt.Columns.Add("Modo Dosagem"); 

                foreach (var item in Utilidades.VariaveisGlobais.listReceitas[index].listProdutos)
                {
                    DataRow dr = dt.NewRow();

                    dr["Produto"] = item.produto.descricao;
                    dr["Peso(kg)"] = item.pesoPorProduto;
                   
                    if (item.produto.tipoProduto.Contains("Complemento"))
                    {
                        dr["Tipo"] = "Comple.";
                    }
                    else if (item.produto.tipoProduto.Contains("Matéria"))
                    {
                        dr["Tipo"] = "M. P.";
                    }
                    else
                    {
                        dr["Tipo"] = "N/A";
                    }

                    if (item.tipoDosagemMateriaPrima.Contains("Auto"))
                    {
                        dr["Modo Dosagem"] = "Automática";
                    }
                    else if (item.tipoDosagemMateriaPrima.Contains("Manual"))
                    {
                        dr["Modo Dosagem"] = "Manual";
                    }
                    else
                    {
                        dr["Modo Dosagem"] = "N/A";
                    }    

                    dt.Rows.Add(dr);
                }

                DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
            }

        }

        private void DataGrid_Receita_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid_Receita.Columns[0].Visibility = Visibility.Hidden;
        }

        private void btSelecionaRota_Click(object sender, RoutedEventArgs e)
        {
            if (!Utilidades.VariaveisGlobais.ProducaoReceita.IniciouProducao)
            {
                if (DataGrid_Receita.SelectedIndex != -1)
                {

                    Utilidades.VariaveisGlobais.ProducaoReceita = new Utilidades.Producao();

                    var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

                    Utilidades.functions.atualizalistReceitas();

                    var index = Utilidades.VariaveisGlobais.listReceitas.FindIndex(x => x.id == Convert.ToInt32(rowList.Row.ItemArray[0]));

                    //Passa id da receita desejada para a produção receita
                    Utilidades.VariaveisGlobais.ProducaoReceita.IdReceitaBase = Utilidades.VariaveisGlobais.listReceitas[index].id;
                    //Passa a Receita desejada para a produção Receita
                    Utilidades.VariaveisGlobais.ProducaoReceita.receita = Utilidades.VariaveisGlobais.listReceitas[index];

                    //Passa TempoPreMistura da receita desejada para a produção receita
                    Utilidades.VariaveisGlobais.ProducaoReceita.tempoPreMistura = Utilidades.VariaveisGlobais.ValoresEspecificacoesEquipamentos.TempoPreMistura;

                    //Passa TempoPosMistura da receita desejada para a produção receita
                    Utilidades.VariaveisGlobais.ProducaoReceita.tempoPosMistura = Utilidades.VariaveisGlobais.ValoresEspecificacoesEquipamentos.TempoPosMistura;

                    //Dispara evento para editar produtos.
                    if (this.EventoReceitaSelecionada != null)
                        this.EventoReceitaSelecionada(this, e);
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Em produção", "Existe uma produção em andamento, aguarde a finalização da produção!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();
            }


        }
    }
}
