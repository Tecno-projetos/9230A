using System;
using System.Collections.Generic;
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

        public void ShowBatelada (Utilidades.VariaveisGlobais.SlotBatelada batelada)
        {
            
            if (batelada.Status == 1) // 1 - Dosagem Matéria Prima Manual
            {
                //Mostrar um Grid com os produtos da batelada e qual produto esta dosando e o peso atual
            }
            else if (batelada.Status == 2) // 2 - Dosagem Matéria Prima Automática
            {
                //Mostrar um Grid com os produtos da batelada e qual produto esta dosando e o peso atual
            }
            else if (batelada.Status == 3) // 3 - Transporte Para Pré Mistura
            {
                //Mostrar quanto que falta para zerar a balança
            }
            else if (batelada.Status == 4) // 4 - Pré Mistura
            {
                //Mostrar quanto tempo resta de pré mistura
            }
            else if (batelada.Status == 5) // 5 - Moagem e Transporte Pós Mistura
            {
                //Motrar o Tempo desde que começou a Moagem
            }
            else if (batelada.Status == 6) // 6 - Pós Mistura
            {
                //Mostrar quanto tempo resta de pós mistura
            }
            else if (batelada.Status == 7) // 7 - Transporte Para Produto Acabado
            {
                //Mostrar o tempo desde que começou o transporte
            }
            else                           // Sem Status
            {
                //Mostrar que esta sem status
            }


        }
    }
}
