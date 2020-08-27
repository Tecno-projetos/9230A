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
    /// Interaction logic for CadastroReceitaInicial.xaml
    /// </summary>
    public partial class CadastroReceitaInicial : UserControl
    {
        Utilidades.messageBox inputDialog;
        public event EventHandler FinalizadoInicioCadastroReceita;


        float pesoReferencia = 0.0f;
        private float floatPoint;

        public CadastroReceitaInicial()
        {
            InitializeComponent();

            btCancelar.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.receitas.Editar_GS)
            {
                Utilidades.VariaveisGlobais.ReceitaCadastro = new Receita();
            }
            if (Utilidades.VariaveisGlobais.IniciouCadastro_GS)
            {
                btCancelar.Visibility = Visibility.Visible;
                lbTextButton.Text = "Continuar Cadastro";
            }
            else
            {
                btCancelar.Visibility = Visibility.Hidden;
                lbTextButton.Text = "Iniciar Cadastro";
            }
            leituraValoresCadastroReceita();


        }

        private void leituraValoresCadastroReceita()
        {
            //limpa campos
            txtNome.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita;
            txtObs.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.observacao;
            txtPesoRef.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase.ToString();
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

        private void btCadastrarIniciarCadastro_Click(object sender, RoutedEventArgs e)
        {
            if (VariaveisGlobais.DB_Connected_GS)
            {
                if (String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtPesoRef.Text))
                {
                    inputDialog = new Utilidades.messageBox("Campos Vazios", "Por favor verifique se todos os campos necessários estão preenchidos", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
                else
                {
                    //Verifica se ja existe uma receita com o nome desejado
                    if (DataBase.SqlFunctionsReceitas.getExistReceita(txtNome.Text) != 0)
                    {
                        inputDialog = new Utilidades.messageBox("Nome Igual", "Já existe uma receita com o mesmo nome!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                        inputDialog.ShowDialog();
                    }
                    else
                    {
                        if (float.TryParse(txtPesoRef.Text.Replace('.', ','), out pesoReferencia))
                        {
                            VariaveisGlobais.ReceitaCadastro.nomeReceita = txtNome.Text;
                            VariaveisGlobais.ReceitaCadastro.pesoBase = pesoReferencia;
                            VariaveisGlobais.ReceitaCadastro.observacao = txtObs.Text;

                            if (this.FinalizadoInicioCadastroReceita != null)
                                this.FinalizadoInicioCadastroReceita(this, e);


                            Utilidades.VariaveisGlobais.IniciouCadastro_GS = true;



                        }
                        else
                        {
                            inputDialog = new Utilidades.messageBox("Densidade", "Por favor verifique se contém somente número real no peso de Referência", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }
                    }
                }
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

            inputDialog = new Utilidades.messageBox("Cancelar Receita", "Deseja cancelar o cadastro dessa receita", MaterialDesignThemes.Wpf.PackIconKind.Error, "Sim", "Não");

            if (inputDialog.ShowDialog() == true) 
            {
                VariaveisGlobais.ReceitaCadastro.nomeReceita = "";
                VariaveisGlobais.ReceitaCadastro.pesoBase = 0f;
                VariaveisGlobais.ReceitaCadastro.observacao = "";

                VariaveisGlobais.ReceitaCadastro.listProdutos.Clear();

                Utilidades.VariaveisGlobais.IniciouCadastro_GS = false;
                btCancelar.Visibility = Visibility.Hidden;

                lbTextButton.Text = "Iniciar Cadastro"; 
                leituraValoresCadastroReceita();

            }
        }
    }
}
