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

namespace _9230A_V00___PI.Telas_Fluxo
{
    /// <summary>
    /// Interação lógica para receitas.xam
    /// </summary>
    public partial class receitas : UserControl
    {
        Utilidades.messageBox inputDialog;
        Telas_Fluxo.Receitas.CadastroProdutos cadastroProdutos = new Receitas.CadastroProdutos();
        Telas_Fluxo.Receitas.CadastroReceitas cadastroReceitas = new Receitas.CadastroReceitas();

        public receitas()
        {
            InitializeComponent();
        }

        private void btCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 3)
            {
                if (spReceitas != null)
                {
                    spReceitas.Children.Clear();
                }

                spReceitas.Children.Add(cadastroProdutos);

            }
            else
            {
                inputDialog = new Utilidades.messageBox(Utilidades.VariaveisGlobais.faltaPermissaoTitle, Utilidades.VariaveisGlobais.faltaPermissaoMessage, MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
        }

        private void btCadastroReceita_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 3)
            {
                if (spReceitas != null)
                {
                    spReceitas.Children.Clear();
                }

                spReceitas.Children.Clear();

                spReceitas.Children.Add(cadastroReceitas);

            }
            else
            {
                inputDialog = new Utilidades.messageBox(Utilidades.VariaveisGlobais.faltaPermissaoTitle, Utilidades.VariaveisGlobais.faltaPermissaoMessage, MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
        }
    }
}
