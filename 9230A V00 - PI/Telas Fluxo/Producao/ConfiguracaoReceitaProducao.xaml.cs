using _9230A_V00___PI.Utilidades;
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

namespace _9230A_V00___PI.Telas_Fluxo.Producao
{
    /// <summary>
    /// Interaction logic for ConfiguracaoReceitaProducao.xaml
    /// </summary>
    public partial class ConfiguracaoReceitaProducao : UserControl
    {
        int DosagemAutomaticaMateriaPrima1 = 0; //1 = Silo1, 2 = Silo2

        public ConfiguracaoReceitaProducao()
        {
            InitializeComponent();
        }

        #region Seleção Silo para Dosagem Automática Matéria Prima

        private void btSilo1MateriaPrima1_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 1;
        }

        private void btSilo2MateriaPrima1_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 2;
        }

        private void btSilo1MateriaPrima2_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 2;
        }

        private void btSilo2MateriaPrima2_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 1;
        }

        private void AtualizaBTDosagemAutomatica()
        {
            if (DosagemAutomaticaMateriaPrima1 == 1)
            {
                btSilo1MateriaPrima1.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo2MateriaPrima1.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                btSilo2MateriaPrima2.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo1MateriaPrima2.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1 = txtSiloMateriaPrima1.Text;
                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2 = txtSiloMateriaPrima2.Text;
            }
            else if (DosagemAutomaticaMateriaPrima1 == 2)
            {
                btSilo1MateriaPrima1.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo2MateriaPrima1.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                btSilo2MateriaPrima2.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo1MateriaPrima2.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1 = txtSiloMateriaPrima2.Text;
                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2 = txtSiloMateriaPrima1.Text;
            }
        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //Preenche os campos das duas possíveis matérias primas de dosagem automática, para poder selecionar o silo que deseja produzir a matéria prima.
            bool count = false;
            foreach (var item in VariaveisGlobais.ProducaoReceita.receita.listProdutos)//Pega a lista de produtos a partir da lista base da receita que será produzida
            {
                //Verifica se o tipo de dosagem do produto será feita de maneira automática, se sim inserimos no primeiro campo, após no segundo campo
                //SÓ PODE TER DUAS MATÉRIAS PRIMAS COM DOSAGEM AUTOMÁTICA NO MÁXIMO, DEVIDO A QUANTIDADE DE SILO.
                if (item.tipoDosagemMateriaPrima.Equals("Automático"))
                {
                    if (count)
                    {
                        txtSiloMateriaPrima2.Text = item.produto.descricao;
                        break;
                    }
                    else
                    {
                        txtSiloMateriaPrima1.Text = item.produto.descricao;
                    }
                }

            }

            //Atualiza os botões de seleção dos silos
            AtualizaBTDosagemAutomatica();
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void btInicarProducaoReceita_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
