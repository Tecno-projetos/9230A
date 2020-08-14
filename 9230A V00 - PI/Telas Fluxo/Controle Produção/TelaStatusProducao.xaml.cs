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

namespace _9230A_V00___PI.Telas_Fluxo.Controle_Produção
{
    /// <summary>
    /// Interaction logic for TelaStatusProducao.xaml
    /// </summary>
    public partial class TelaStatusProducao : UserControl
    {
        int slotSolicitado = 0;

        public int SlotSolicitado { get => slotSolicitado; set => slotSolicitado = value; }

        public TelaStatusProducao()
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

        public void AtualizaBateladaTela (ref Utilidades.VariaveisGlobais.SlotBatelada batelada)
        {
            //Atualiza Peso Atual

            //Atualiza Tempo Restante Pré Mistura

            //Atualiza Tempo Restante Pos Mistura

            //Atualiza Tempo Passo Atual

            //Atualiza Tempo Total Batelada


            //Atualiza Grid dos produtos da batelada
            atualizaGridProdutos(ref batelada);
        }

        public void atualizaGridProdutos(ref Utilidades.VariaveisGlobais.SlotBatelada batelada)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Produto");
            dt.Columns.Add("Peso");
            dt.Columns.Add("Peso Dosado");

            foreach (var item in Utilidades.VariaveisGlobais.ProducaoReceita.batelada[batelada.NumeroBatelada].produtos)
            {
                DataRow dr = dt.NewRow();

                dr["Produto"] = item.descricao;
                dr["Peso"] = item.pesoDesejado;
                dr["Peso Dosado"] = item.pesoDosado;

                dt.Rows.Add(dr);
            }

            DataGrid_Produtos.Dispatcher.Invoke(delegate { DataGrid_Produtos.ItemsSource = dt.DefaultView; });
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var teste = slotSolicitado;

            atualizaBotoesSlots();
        }

        private void btSlot1_Click(object sender, RoutedEventArgs e)
        {
            SlotSolicitado = 1;
            atualizaBotoesSlots();
        }

        private void btSlot2_Click(object sender, RoutedEventArgs e)
        {
            SlotSolicitado = 2;
            atualizaBotoesSlots();
        }

        private void btSlot3_Click(object sender, RoutedEventArgs e)
        {
            SlotSolicitado = 3;
            atualizaBotoesSlots();
        }

        private void atualizaBotoesSlots()
        {
            if (SlotSolicitado ==1)
            {
                btSlot1.Background = new SolidColorBrush(Colors.Green);
                btSlot2.Background = new SolidColorBrush(Colors.Gray);
                btSlot3.Background = new SolidColorBrush(Colors.Gray);
            }
            else if (SlotSolicitado == 2)
            {
                btSlot1.Background = new SolidColorBrush(Colors.Gray);
                btSlot2.Background = new SolidColorBrush(Colors.Green);
                btSlot3.Background = new SolidColorBrush(Colors.Gray);
            }
            else if (SlotSolicitado == 3)
            {
                btSlot1.Background = new SolidColorBrush(Colors.Gray);
                btSlot2.Background = new SolidColorBrush(Colors.Gray);
                btSlot3.Background = new SolidColorBrush(Colors.Green);
            }

            
        }

        private void DataGrid_Produtos_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var teste = e.Row.GetIndex();

        }
    }
}
