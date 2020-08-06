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

        long codigoProduto = 0;
        float densidade = 0.0f;
        string tipoProduto = "";

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


                                DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos(codigoProduto.ToString(), txtDesc.Text, densidade, tipoProduto, txtObs.Text);


                                inputDialog = new Utilidades.messageBox("Cadastro", "Produto: " + txtDesc.Text + " Cadastrado com Sucesso!", MaterialDesignThemes.Wpf.PackIconKind.Plus, "OK", "Fechar");

                                inputDialog.ShowDialog();

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
