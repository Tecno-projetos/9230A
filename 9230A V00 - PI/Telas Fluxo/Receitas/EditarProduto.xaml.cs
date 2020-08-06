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
    /// Interaction logic for EditarProduto.xaml
    /// </summary>
    public partial class EditarProduto : UserControl
    {
        public EditarProduto()
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

        private void btEditarProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utilidades.functions.atualizalistProdutos();

            Utilidades.ListtoDataTableConverter converter = new Utilidades.ListtoDataTableConverter();

            DataTable dt = converter.ToDataTable(Utilidades.VariaveisGlobais.listProdutos);

            DataGrid.Dispatcher.Invoke(delegate { DataGrid.ItemsSource = dt.DefaultView; });

            lbNomeProduto.Content = "";

        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //var rowList = (Utilidades.Produto)DataGrid.SelectedItem; //(DataGrid.ItemContainerGenerator.ContainerFromIndex(DataGrid.SelectedIndex) as DataGridRow).Item;

            //lbNomeProduto.Content = rowList.descricao;


        }
    }
}
