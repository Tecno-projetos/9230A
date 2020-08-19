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
        Utilidades.messageBox inputDialog;

        public event EventHandler ProximaTela;
        public event EventHandler TelaAnterior;

        bool contemMateriaPrimaDosagemAutomatica = false;
        string codigoProdutoMateriaPrima1 = "";
        string codigoProdutoMateriaPrima2 = "";
        public ConfiguracaoReceitaProducao()
        {
            InitializeComponent();
        }

        #region Seleção Silo para Dosagem Automática Matéria Prima

        private void btSilo1MateriaPrima1_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 1;
            AtualizaBTDosagemAutomatica();
        }

        private void btSilo2MateriaPrima1_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 2;
            AtualizaBTDosagemAutomatica();
        }

        private void btSilo1MateriaPrima2_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 2;
            AtualizaBTDosagemAutomatica();
        }

        private void btSilo2MateriaPrima2_Click(object sender, RoutedEventArgs e)
        {
            DosagemAutomaticaMateriaPrima1 = 1;
            AtualizaBTDosagemAutomatica();
        }

        private void AtualizaBTDosagemAutomatica()
        {
            if (DosagemAutomaticaMateriaPrima1 == 1)
            {
                btSilo1MateriaPrima1.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo2MateriaPrima1.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                btSilo2MateriaPrima2.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo1MateriaPrima2.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1 = codigoProdutoMateriaPrima1;
                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2 = codigoProdutoMateriaPrima2;
            }
            else if (DosagemAutomaticaMateriaPrima1 == 2)
            {
                btSilo2MateriaPrima1.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo1MateriaPrima1.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                btSilo1MateriaPrima2.Background = new SolidColorBrush(Colors.ForestGreen);
                btSilo2MateriaPrima2.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo1 = codigoProdutoMateriaPrima2;
                VariaveisGlobais.ProducaoReceita.CodigoProdutoDosagemAutomaticaSilo2 = codigoProdutoMateriaPrima1;
            }
        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            codigoProdutoMateriaPrima1 = "";
            codigoProdutoMateriaPrima2 = "";

            txtSiloMateriaPrima1.Text = "";
            txtSiloMateriaPrima2.Text = "";

            //Preenche os campos das duas possíveis matérias primas de dosagem automática, para poder selecionar o silo que deseja produzir a matéria prima.
            bool count = false;
            foreach (var item in VariaveisGlobais.ProducaoReceita.receita.listProdutos)//Pega a lista de produtos a partir da lista base da receita que será produzida
            {
                //Verifica se o tipo de dosagem do produto será feita de maneira automática, se sim inserimos no primeiro campo, após no segundo campo
                //SÓ PODE TER DUAS MATÉRIAS PRIMAS COM DOSAGEM AUTOMÁTICA NO MÁXIMO, DEVIDO A QUANTIDADE DE SILO.
                if (item.tipoDosagemMateriaPrima.Equals("Automático"))
                {
                    contemMateriaPrimaDosagemAutomatica = true;
                    if (count)
                    {
                        txtSiloMateriaPrima2.Text = item.produto.descricao;
                        codigoProdutoMateriaPrima2 = item.produto.codigo;
                        break;
                    }
                    else
                    {
                        txtSiloMateriaPrima1.Text = item.produto.descricao;
                        codigoProdutoMateriaPrima1 = item.produto.codigo;
                        count = true;
                    }
                }

            }

            //Atualiza os botões de seleção dos silos
            AtualizaBTDosagemAutomatica();

            //Atualiza Peso máximo e volume máximo suportado
            txtPesoMaximoPermitido.Text = VariaveisGlobais.ValoresEspecificacoesEquipamentos.PesoMaximoPermitidoBatelada().ToString();

            txtVolumeMaximoPermitido.Text = VariaveisGlobais.ValoresEspecificacoesEquipamentos.VolumeMaximoPermitidoBatelada().ToString();

            //Atualiza Valores de peso desejado e quantidade de bateladas que ja estejam carregados.
            atualizaValoresPesoVolumeQtdBatelada();
        }

        private bool calculaApartirPesoTotalDesejado(bool AddBateladas)
        {
            bool ret = false;
            int pesoDesejado = 0;
            int bateladas = 0;
            int pesoResto = 0;
            int countBatelada = 0;

            if (!String.IsNullOrEmpty(txtPesoDesejado.Text))
            {

                if (Int32.TryParse(txtPesoDesejado.Text, out pesoDesejado))
                {
                    //atualiza o peso total da produção
                    Utilidades.VariaveisGlobais.ProducaoReceita.pesoTotalProducao = pesoDesejado;

                    //Calcula quantas bateladas inteiras terão utilizando o máximo permitido de peso
                    bateladas = pesoDesejado / Convert.ToInt32(txtPesoMaximoPermitido.Text);

                    //Calcula o peso da ultima batelada
                    pesoResto = pesoDesejado % Convert.ToInt32(txtPesoMaximoPermitido.Text);

                    if (AddBateladas)
                    {
                        Utilidades.VariaveisGlobais.ProducaoReceita.batelada.Clear();

                        //cria um dummy da batelada para poder inserir cada peso desejado para cada batelada
                        Utilidades.Batelada DummyBatelada = new Batelada();

                        //passa por cada batelada e adiciona o peso das bateladas inteiras
                        for (int i = 0; i < bateladas; i++)
                        {
                            countBatelada += 1;

                            DummyBatelada = new Batelada();

                            DummyBatelada.pesoDesejado = Convert.ToInt32(txtPesoMaximoPermitido.Text);
                            DummyBatelada.numeroBatelada = countBatelada;
                            Utilidades.VariaveisGlobais.ProducaoReceita.batelada.Add(DummyBatelada);
                        }

                        //Verifica se tem peso resto para adicionar na ultima batelada o restante (isso ira acontecer quando ocorrer valores que não forem multiplo do valor máximo permitido)
                        if (pesoResto > 0)
                        {
                            bateladas += 1;
                            countBatelada += 1;
                            DummyBatelada = new Batelada();

                            DummyBatelada.pesoDesejado = pesoResto;
                            DummyBatelada.numeroBatelada = countBatelada;
                            Utilidades.VariaveisGlobais.ProducaoReceita.batelada.Add(DummyBatelada);
                        }
                    }
                    else
                    {
                        //Verifica se tem peso resto para adicionar na ultima batelada o restante (isso ira acontecer quando ocorrer valores que não forem multiplo do valor máximo permitido)
                        if (pesoResto > 0)
                        {
                            bateladas += 1;
                        }
                    }


                    //passa para a produção receita a quantidade de bateladas.
                    Utilidades.VariaveisGlobais.ProducaoReceita.quantidadeBateladas = bateladas;

                    ret = true;
                }
                else
                {
                    if (AddBateladas)
                    {
                        inputDialog = new Utilidades.messageBox("Valor não é inteiro", "Por favor verifique se o valor pertecem aos números inteiros", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                        inputDialog.ShowDialog();
                    }

                }

            }
            else
            {
                if (AddBateladas)
                {
                    inputDialog = new Utilidades.messageBox("Campo Necessário", "Por favor verifique se o campo Peso Total Desejado esta vazio!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }

            }

            atualizaValoresPesoVolumeQtdBatelada();

            return ret;
        }

        private void atualizaValoresPesoVolumeQtdBatelada()
        {
            txtPesoDesejado.Text = Utilidades.VariaveisGlobais.ProducaoReceita.pesoTotalProducao.ToString();
            txtQtdBateladas.Text = Utilidades.VariaveisGlobais.ProducaoReceita.quantidadeBateladas.ToString();
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void btContinuar_Click(object sender, RoutedEventArgs e)
        {
            //Verifica se o calculo das quantidades das bateladas esta correto
            if (calculaApartirPesoTotalDesejado(true))
            {
                //verifica se tem dosagem automática de materia prima
                if (contemMateriaPrimaDosagemAutomatica)
                {
                    //Verifica se foi selecionado silo para as dosagem automáticas
                    if (DosagemAutomaticaMateriaPrima1 != 0)
                    {
                        //Chama proximo tela
                        if (this.ProximaTela != null)
                            this.ProximaTela(this, e);
                    }
                    else
                    {
                        inputDialog = new Utilidades.messageBox("Seleção Silo", "Falta Selecionar um silo de origem da Matéria Prima", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                        inputDialog.ShowDialog();
                    }
                }
                else
                {
                    //Chama proximo tela
                    if (this.ProximaTela != null)
                        this.ProximaTela(this, e);
                }
            }
            
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            //Chama proximo tela
            if (this.TelaAnterior != null)
                this.TelaAnterior(this, e);
        }

        private void txtPesoDesejado_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.floatingKeypad(txtReceber.Text, 6).ToString();

            calculaApartirPesoTotalDesejado(false);
        }
    }
}
