using _9230A_V00___PI.Utilidades;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Ensaque.xaml
    /// </summary>
    public partial class Ensaque : UserControl
    {

        private bool abriuTela = false;
        Utilidades.messageBox inputDialog;


        public Ensaque()
        {
            InitializeComponent();
        }

        #region Move Lista

        private void btLeftList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Ensaques, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Ensaques, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Ensaques, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Produtos_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Ensaques, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 5);
        }

        #endregion

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.IntergerKeypad(txtReceber.Text, 3, 9999).ToString();

            Utilidades.VariaveisGlobais.executaEnsaque.WritePesoDesejado(Convert.ToSingle(txtReceber.Text));

        }


        //Monta o grid conforme a seleção
        #region Data Source

        private void DataGrid_ItemSource(System.Data.DataTable Data)
        {
            DataGrid_Ensaques.ItemsSource = Data.DefaultView;

            DataGrid_Ensaques.Columns[0].Visibility = Visibility.Hidden;
            DataGrid_Ensaques.Columns[1].Header = "Nº Produção";
            DataGrid_Ensaques.Columns[2].Header = "Peso Dosado";
            DataGrid_Ensaques.Columns[3].Visibility = Visibility.Hidden;
        }
        #endregion


        public void Actualize_UI()
        {
            //Atualiza Váriaveis
            Utilidades.VariaveisGlobais.executaEnsaque.Actualize();

            //Chama atualização de sacos no ensaque
            if (Utilidades.VariaveisGlobais.executaEnsaque.ensaques()) 
            {
                atualizaGrid();
            }

            //Verifica se abriu tela e atualiza os valores
            if (abriuTela)
            {

                lbStatusEnsaque = Utilidades.VariaveisGlobais.executaEnsaque.StatusBalanca(lbStatusEnsaque);



                //Atualiza Peso da balança
                 lbPesoBalnca.Content = Utilidades.VariaveisGlobais.executaEnsaque.IndicadorPesagem_Get.Valor_Atual_Indicador.ToString("N", CultureInfo.GetCultureInfo("pt-BR")) + " kg";

                //Verifica Status da balança
                if (Utilidades.VariaveisGlobais.executaEnsaque.IndicadorPesagem_Get.Erro_Leitura)
                {
                    lbStatusBalança.Content = "Balança com erro";
                    lbStatusBalança.Background = new SolidColorBrush(Colors.Red);
                    lbStatusBalança.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    lbStatusBalança.Content = "Balança em operação";
                    lbStatusBalança.Background = new SolidColorBrush(Colors.Green);
                    lbStatusBalança.Foreground = new SolidColorBrush(Colors.Black);
                }


                if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.IniciaEnsaque)
                {
                    btIniaEnsaque.Background = new SolidColorBrush(Color.FromRgb(80,80,80));
                    btIniaEnsaque.IsEnabled = false;

                }
                else
                {
                    btIniaEnsaque.Background = new SolidColorBrush(Color.FromRgb(53, 182, 15));
                    btIniaEnsaque.IsEnabled = true;
                }

                if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.HabilitaFinalizarEnsaque)
                {
                    btTerminou.Background = new SolidColorBrush(Colors.Red);
                    btTerminou.IsEnabled = true;

                }
                else
                {
                    btTerminou.Background = new SolidColorBrush(Color.FromRgb(80, 80, 80));
                    btTerminou.IsEnabled = false;
                }

            }

        }

        private void btIniaEnsaque_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.pesoDesejado > 0)
            {
                if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.Habilita_Iniciar_Ensaque)
                {
                    //Comparador para não escrever 2 vezes a mesma produção
                    if (!Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.IniciaEnsaque)
                    {
                        //Iniciou com a produção X
                        Utilidades.VariaveisGlobais.executaEnsaque.producaoEnsaque(VariaveisGlobais.Id_Producao_No_Silo_Expedicao);

                        atualizaGrid();
                    }

                    Utilidades.VariaveisGlobais.executaEnsaque.InverbitIniciouEnsaque();
                }
                else
                {
                    inputDialog = new Utilidades.messageBox("Ensaque não Habilitado", "Aguarde habilitar o ensaque!", MaterialDesignThemes.Wpf.PackIconKind.Information, "Ok", "Fechar");
                    inputDialog.ShowDialog();

                }
            }
            else
            {

                inputDialog = new Utilidades.messageBox("Valor Vazio", "O campo de peso desejado não foi preenchido!", MaterialDesignThemes.Wpf.PackIconKind.Information, "Ok", "Fechar");
                inputDialog.ShowDialog();


            }
         
        }

        private void btTerminou_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.HabilitaFinalizarEnsaque)
            {
                Utilidades.VariaveisGlobais.executaEnsaque.InverbitTerminouEnsaque();

                Utilidades.VariaveisGlobais.executaEnsaque.updateProducaoTerminou();

                DataGrid_Ensaques.ItemsSource = null;

            }
            else
            {
                inputDialog = new Utilidades.messageBox("Ensaque não Habilitado", "Aguarde habilitar o ensaque!", MaterialDesignThemes.Wpf.PackIconKind.Information, "Ok", "Fechar");
                inputDialog.ShowDialog();

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            abriuTela = true;

            txtQtdEnsaque.Text = Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.pesoDesejado.ToString();

            DataGrid_Ensaques.ItemsSource = null;

            if (DataBase.SqlFunctionsEnsaques.getIdProducaoEnsaque(VariaveisGlobais.Id_Producao_No_Silo_Expedicao) != -1)
            {
                atualizaGrid();

                lnNomeReceita.Content = DataBase.SqlFunctionsEnsaques.getNameReceita(DataBase.SqlFunctionsEnsaques.getIdProducaoEnsaque(VariaveisGlobais.Id_Producao_No_Silo_Expedicao));

            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            abriuTela = false;
        }

        private void atualizaGrid() 
        {
            if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.IniciaEnsaque)
            {
                DataGrid_ItemSource(DataBase.SqlFunctionsEnsaques.getEnsaqueFromIdProducaoEnsaque(DataBase.SqlFunctionsEnsaques.getIdProducaoEnsaque(VariaveisGlobais.Id_Producao_No_Silo_Expedicao)));

            }
        }

        
        private void DataGrid_Ensaques_LoadingRow(object sender, DataGridRowEventArgs e)
        {
          int index = e.Row.GetIndex();

            if (index == 0)
            {
                e.Row.Background = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
