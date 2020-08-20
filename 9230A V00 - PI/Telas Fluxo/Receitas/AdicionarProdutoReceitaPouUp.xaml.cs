using _9230A_V00___PI.Teclados;
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
using System.Windows.Shapes;

namespace _9230A_V00___PI.Telas_Fluxo.Receitas
{
    /// <summary>
    /// Interaction logic for AdicionarProdutoReceitaPouUp.xaml
    /// </summary>
    public partial class AdicionarProdutoReceitaPouUp : Window
    {
        float pesoProduto = 0.0f;
        bool editarProduto = false;

        string AutomaticoManual = "";

        Utilidades.messageBox inputDialog;

        Utilidades.ProdutoReceita produtoReceita = new Utilidades.ProdutoReceita();
        private float floatPoint;

        public AdicionarProdutoReceitaPouUp(Utilidades.ProdutoReceita produtoReceita, float pesoProduto, bool editarProduto, string AutomaticoManual, bool bloqueiaAutomatico)
        {
            InitializeComponent();

            if (bloqueiaAutomatico)
            {
                btAutomatico.IsEnabled = false;
            }
            else
            {
                btAutomatico.IsEnabled = true;
            }

            this.produtoReceita = produtoReceita;
            this.pesoProduto = pesoProduto;
            this.editarProduto = editarProduto;

            //Se abrir a tela e solicitar editar o produto, carrega o valor do peso cadastrado e também o tipo de dosagem se tiver
            if (editarProduto)
            {
                //Se recebeu algum peso carrega na tela
                if (pesoProduto != 0)
                {
                    txtPeso.Text = pesoProduto.ToString();
                }

                //se for matéria prima carrega o tipo de dosagem atual
                if (produtoReceita.produto.tipoProduto == "Matéria Prima")
                {
                    if (AutomaticoManual == "Automático")
                    {
                        SetDosagemAutomatico();
                    }
                    else if (AutomaticoManual == "Manual")
                    {
                        SetDosagemManual();
                    }
                }
                //Mudar o titulo da tela para edição
                this.Title = "Editar Produto Receita";

                //Mudar o Label do botão para editar e o icone do botão para editar
                lbTextButton.Text = "Editar Item";
                packiconCadastrarEditar.Kind = MaterialDesignThemes.Wpf.PackIconKind.Edit;
            }

            //Verifica se não é materia prima o produto, se não for não deixa selecionar o tipo de dosagem
            if (produtoReceita.produto.tipoProduto != "Matéria Prima")
            {
                btAutomatico.IsEnabled = false;
                btManual.IsEnabled = false;
            }

            lbNomeProduto.Content = produtoReceita.produto.descricao;

        }

        private void btAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            //Verifica se o campo de peso esta vazio ou não
            if (!String.IsNullOrEmpty(txtPeso.Text))
            {
                //Adiciona na ReceitaCadastro.listProdutos o item desejado
                if (float.TryParse(txtPeso.Text.Replace('.', ','), out pesoProduto))
                {
                    //Verifica se é materia prima, se sim é obrigatório selecionar um tipo de dosagem, automatico ou manual
                    if (produtoReceita.produto.tipoProduto == "Matéria Prima")
                    {
                        if (AutomaticoManual == "Automático" || AutomaticoManual == "Manual")
                        {
                            produtoReceita.pesoPorProduto = pesoProduto;
                            produtoReceita.tipoDosagemMateriaPrima = AutomaticoManual;

                            if (!editarProduto)
                            {
                                AdicionaProdutoReceita();
                            }
                            else
                            {
                                EditaProdutoReceita();
                            }

                            DialogResult = true;
                        }
                        else
                        {
                            inputDialog = new Utilidades.messageBox("Tipo de Dosagem", "Por favor selecione um tipo de dosagem, Automático ou Manual!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }
                    }
                    else
                    {
                        //Adiciona na ReceitaCadastro.listProdutos o item desejado
                        produtoReceita.pesoPorProduto = pesoProduto;

                        if (!editarProduto)
                        {
                            AdicionaProdutoReceita();
                        }
                        else
                        {
                            EditaProdutoReceita();
                        }

                        DialogResult = true;
                    }
                }
                else
                {
                    inputDialog = new Utilidades.messageBox("Peso Produto", "Por favor verifique se contém somente número real no peso do Produto!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Peso", "Por favor preencha um Peso para o produto!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
        }

        private void AdicionaProdutoReceita()
        {
            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);
        }

        private void EditaProdutoReceita()
        {
            var index = Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.FindIndex(x => x.produto.id == produtoReceita.produto.id);

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index].pesoPorProduto = produtoReceita.pesoPorProduto;
            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index].tipoDosagemMateriaPrima = produtoReceita.tipoDosagemMateriaPrima;

        }

        private void btAutomatico_Click(object sender, RoutedEventArgs e)
        {
            SetDosagemAutomatico();
        }

        private void btManual_Click(object sender, RoutedEventArgs e)
        {
            SetDosagemManual();
        }

        private void SetDosagemAutomatico()
        {
            btAutomatico.Background = new SolidColorBrush(Colors.ForestGreen);
            btManual.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));
            AutomaticoManual = "Automático";
        }

        private void SetDosagemManual()
        {
            btManual.Background = new SolidColorBrush(Colors.ForestGreen);
            btAutomatico.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));

            AutomaticoManual = "Manual";
        }
        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.floatingKeypad(txtReceber.Text, 10).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();

        }

        private void IntergerPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.IntergerKeypad(txtReceber.Text, 6, 9999999).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();
        }

        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)e.OriginalSource;
                tb.Dispatcher.BeginInvoke(
                    new Action(delegate
                    {
                        tb.SelectAll();
                    }), System.Windows.Threading.DispatcherPriority.Input);
            }
            catch (Exception ex)
            {
                Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic.List_Error = ex.ToString();

            }
        }



    }
}
