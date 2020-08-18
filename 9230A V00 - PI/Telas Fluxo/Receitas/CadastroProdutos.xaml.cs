using _9230A_V00___PI.Teclados;
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

namespace _9230A_V00___PI.Telas_Fluxo.Receitas
{
    /// <summary>
    /// Interaction logic for CadastroProdutos.xaml
    /// </summary>
    public partial class CadastroProdutos : UserControl
    {
        Utilidades.messageBox inputDialog;
        public event EventHandler EditadoSucesso;

        long codigoProduto = 0;
        float densidade = 0.0f;
        string tipoProduto = "";
        bool editarProduto = false;
        int produtoEditar = -1;
        private float floatPoint;

        public int ProdutoEditar { get => produtoEditar; set => produtoEditar = value; }

        public bool EditarProduto 
        {
            set
            {
                editarProduto = value;

            }
        }

        public CadastroProdutos()
        {
            InitializeComponent();
            limpaCampos();
        }

        

        private void lbMateriaPrima_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lbMateriaPrima.IsSelected)
            {
                pckMateriaPrima.Visibility = Visibility.Visible;
                pckComplemento.Visibility = Visibility.Hidden;
            }
        }

        private void lbComplemento_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (lbComplemento.IsSelected)
            {
                pckMateriaPrima.Visibility = Visibility.Hidden;
                pckComplemento.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            limpaCampos();

            if (editarProduto)
            {
                lbTextButton.Text = "Editar";
                lbTitle.Content = "Editar Produto";
                packiconCadastrarEditar.Kind = MaterialDesignThemes.Wpf.PackIconKind.Edit;


                //Carrega valores do produto selecionado para edição
                Utilidades.functions.atualizalistProdutos();

                var filter = from p in Utilidades.VariaveisGlobais.listProdutos
                             where p.id == ProdutoEditar
                             select p;

                var listProdutosFiltered = filter.ToList();

                //limpa campos
                txtCod.Text = listProdutosFiltered[0].codigo;
                txtDesc.Text = listProdutosFiltered[0].descricao;
                txtDensidade.Text = listProdutosFiltered[0].densidade.ToString();
                txtObs.Text = listProdutosFiltered[0].observacao;

                if (listProdutosFiltered[0].tipoProduto == "Matéria Prima")
                {
                    lbMateriaPrima.IsSelected = true;
                    pckComplemento.Visibility = Visibility.Hidden;
                    pckMateriaPrima.Visibility = Visibility.Visible;
                }
                else if(listProdutosFiltered[0].tipoProduto == "Complemento")
                {
                    lbComplemento.IsSelected = true;
                    pckComplemento.Visibility = Visibility.Visible;
                    pckMateriaPrima.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                lbTextButton.Text = "Cadastrar";
                lbTitle.Content = "Cadastrar Produto";
                packiconCadastrarEditar.Kind = MaterialDesignThemes.Wpf.PackIconKind.Plus;
            }
        }

        private void limpaCampos()
        {

            //limpa campos
            txtCod.Text = "";
            txtDesc.Text = "";
            txtDensidade.Text = "";
            txtObs.Text = "";

            lbMateriaPrima.IsSelected = true;
            pckComplemento.Visibility = Visibility.Hidden;
            pckMateriaPrima.Visibility = Visibility.Visible;
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBox txtReceber = (TextBox)sender;

            keypad mainWindow = new keypad(false, 10);


            if (mainWindow.ShowDialog() == true)
            {
                //Recebe Valor antigo digitado no Textbox
                double oldValue = Convert.ToDouble(txtReceber.Text);
                //Recebe o novo valor digitado no Keypad


                double newValue = Convert.ToDouble(mainWindow.Result.Replace('.', ','));


                bool isNumeric = float.TryParse(txtReceber.Text, out floatPoint);

                if (isNumeric)
                {
                    if (oldValue != newValue)
                    {
                        txtReceber.Text = Convert.ToString(newValue);

                        //Retira o foco do textbox.
                        Keyboard.ClearFocus();

                    }
                }
                else
                {
                    //Envia o oldValue pois o valor máximo ultrapassou o limite.
                    txtReceber.Text = Convert.ToString(oldValue);
                }

            }
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

        private void btCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (VariaveisGlobais.DB_Connected_GS)
            {
                if (String.IsNullOrEmpty(txtCod.Text) || String.IsNullOrEmpty(txtDesc.Text) || String.IsNullOrEmpty(txtDensidade.Text))
                {
                    inputDialog = new Utilidades.messageBox("Campos Vazios", "Por favor verifique se todos os campos necessários estão preenchidos", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
                else
                {
                    if (lbComplemento.IsSelected || lbMateriaPrima.IsSelected)
                    {
                        if (long.TryParse(txtCod.Text, out codigoProduto))
                        {
                            if (float.TryParse(txtDensidade.Text.Replace('.', ','), out densidade))
                            {
                                if (lbComplemento.IsSelected)
                                {
                                    tipoProduto = "Complemento";
                                }
                                else if (lbMateriaPrima.IsSelected)
                                {
                                    tipoProduto = "Matéria Prima";
                                }

                                //Verifica se a tela esta criando ou editando produto
                                if (editarProduto)
                                {
                                    if (DataBase.SqlFunctionsProdutos.UpdateTableProdutos(produtoEditar, codigoProduto.ToString(), txtDesc.Text, densidade, tipoProduto, txtObs.Text) == 1)
                                    {
                                        inputDialog = new Utilidades.messageBox("Edição", "Produto: " + txtDesc.Text + " Editado com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

                                        inputDialog.ShowDialog();

                                        if (this.EditadoSucesso != null)
                                            this.EditadoSucesso(this, e);

                                        limpaCampos();
                                    }
                                    else
                                    {
                                        inputDialog = new Utilidades.messageBox("Edição", "Ocorreu algum erro ao editar o produto, verificar se existe cadastrado um produto com o mesmo código!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                                        inputDialog.ShowDialog();
                                    }
                                }
                                else
                                {
                                    if (DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos(codigoProduto.ToString(), txtDesc.Text, densidade, tipoProduto, txtObs.Text) == 1)
                                    {
                                        inputDialog = new Utilidades.messageBox("Cadastro", "Produto: " + txtDesc.Text + " Cadastrado com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

                                        inputDialog.ShowDialog();

                                        limpaCampos();
                                    }
                                    else
                                    {
                                        inputDialog = new Utilidades.messageBox("Cadastro", "Ocorreu algum erro ao cadastrar o produto, verificar se existe cadastrado um produto com o mesmo código!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                                        inputDialog.ShowDialog();
                                    }
                                }
                            }
                            else
                            {
                                inputDialog = new Utilidades.messageBox("Densidade", "Por favor verifique se contém somente número real na densidade", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                                inputDialog.ShowDialog();
                            }
                        }
                        else
                        {
                            inputDialog = new Utilidades.messageBox("Código Produto", "Por favor verifique se contém somente números inteiros no Código Produto", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }
                    }
                    else
                    {
                        inputDialog = new Utilidades.messageBox("Tipo de Produto", "Por favor selecione o tipo de Produto", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                        inputDialog.ShowDialog();
                    }
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Sem conexão com Banco de Dados", "Por favor verifique a conexão com o Banco de Dados", MaterialDesignThemes.Wpf.PackIconKind.DatabaseRefresh, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
        }
    }
}
