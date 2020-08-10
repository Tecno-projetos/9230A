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
    /// Interaction logic for ApagarReceitaxaml.xaml
    /// </summary>
    public partial class ApagarReceitaxaml : UserControl
    {
        Utilidades.messageBox inputDialog;

        public event EventHandler EventoApagadoSucesso;
        public ApagarReceitaxaml()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utilidades.functions.atualizalistReceitas();

            DataTable dt = new DataTable();

            dt = DataBase.SqlFunctionsReceitas.getReceitas();

            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });
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

        private void DataGrid_Receita_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGrid_Receita.Columns[0].Visibility = Visibility.Hidden;
        }

        private void btApagarReceitaSelecionada_Click(object sender, RoutedEventArgs e)
        {
            inputDialog = new Utilidades.messageBox("Apagar Receita", "Voçê tem certeza que deseja apagar? o processo não pode ser revertido!", MaterialDesignThemes.Wpf.PackIconKind.Error, "Sim", "Não");

            inputDialog.ShowDialog();

            if (inputDialog.DialogResult == true)
            {
                var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

                Utilidades.functions.atualizalistReceitas();

                var index = Utilidades.VariaveisGlobais.listReceitas.FindIndex(x => x.id == Convert.ToInt32(rowList.Row.ItemArray[0]));

                DataBase.SqlFunctionsReceitas.DeleteReceita(Utilidades.VariaveisGlobais.listReceitas[index].nomeReceita);
            }

            if (this.EventoApagadoSucesso != null)
                this.EventoApagadoSucesso(this, e);

        }


    }
}
