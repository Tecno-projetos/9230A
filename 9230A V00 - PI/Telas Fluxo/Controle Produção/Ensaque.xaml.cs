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

        #endregion

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.IntergerKeypad(txtReceber.Text, 3, 9999).ToString();

            Utilidades.VariaveisGlobais.executaEnsaque.WritePesoDesejado(Convert.ToSingle(txtReceber.Text));

        }


        public void Actualize_UI()
        {
            //Atualiza Váriaveis
            Utilidades.VariaveisGlobais.executaEnsaque.Actualize();

            //Chama atualização de sacos no ensaque
            Utilidades.VariaveisGlobais.executaEnsaque.ensaques();

            //Verifica se abriu tela e atualiza os valores
            if (abriuTela)
            {

                if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.IniciaEnsaque)
                {
                    if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.Saco_Atual_Dosando)
                    {
                        lbStatusEnsaque.Content = "Dosando Saco";
                        lbStatusEnsaque.Background = new SolidColorBrush(Colors.Green);
                        lbStatusBalança.Foreground = new SolidColorBrush(Colors.Black);
                    }
                    else if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.Saco_Atual_Finalizado)
                    {
                        lbStatusEnsaque.Content = "Dosagem Concluída";
                        lbStatusEnsaque.Background = new SolidColorBrush(Colors.Green);
                        lbStatusBalança.Foreground = new SolidColorBrush(Colors.Black);
                    }
                    else
                    {
                        lbStatusEnsaque.Content = "Aguardando Inicío de Dosagem";
                        lbStatusEnsaque.Background = new SolidColorBrush(Colors.Gray);
                        lbStatusBalança.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
                else if (!Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.Habilita_Iniciar_Ensaque)
                {
                    lbStatusEnsaque.Content = "Aguardando Habilitar Ensaque";
                    lbStatusEnsaque.Background = new SolidColorBrush(Colors.Red);
                    lbStatusBalança.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    lbStatusEnsaque.Content = "Aguardando Inicío de Ensaque";
                    lbStatusEnsaque.Background = new SolidColorBrush(Colors.Gray);
                    lbStatusBalança.Foreground = new SolidColorBrush(Colors.White);
                }


                //Atualiza Peso da balança
                 lbPesoBalnca.Content = Utilidades.VariaveisGlobais.executaEnsaque.IndicadorPesagem_Get.Valor_Atual_Indicador.ToString("N", CultureInfo.GetCultureInfo("pt-BR")) + " kg";

                //Verifica Status da balança
                if (Utilidades.VariaveisGlobais.executaEnsaque.IndicadorPesagem_Get.Erro_Leitura)
                {
                    lbStatusBalança.Content = "Balança não operável";
                    lbStatusBalança.Background = new SolidColorBrush(Colors.Red);
                    lbStatusBalança.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    lbStatusBalança.Content = "Balança operável";
                    lbStatusBalança.Background = new SolidColorBrush(Colors.Green);
                    lbStatusBalança.Foreground = new SolidColorBrush(Colors.Black);
                }


            }



            

        }

        private void btIniaEnsaque_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.pesoDesejado > 0)
            {
                if (Utilidades.VariaveisGlobais.executaEnsaque.Ensaque_Get.controleEnsaque.Habilita_Iniciar_Ensaque)
                {
                    Utilidades.VariaveisGlobais.executaEnsaque.InverbitIniciouEnsaque();

                    //Iniciou com a produção X
                    Utilidades.VariaveisGlobais.executaEnsaque.producaoEnsaque(VariaveisGlobais.Id_Producao_No_Silo_Expedicao);


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

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            abriuTela = false;


        }


    }
}
