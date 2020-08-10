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

        public CadastroReceitaInicial()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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
                    if (float.TryParse(txtPesoRef.Text.Replace('.', ','), out pesoReferencia))
                    {
                        VariaveisGlobais.ReceitaCadastro.nomeReceita = txtNome.Text;
                        VariaveisGlobais.ReceitaCadastro.pesoBase = pesoReferencia;
                        VariaveisGlobais.ReceitaCadastro.observacao = txtObs.Text;

                        if (this.FinalizadoInicioCadastroReceita != null)
                            this.FinalizadoInicioCadastroReceita(this, e);
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
}
