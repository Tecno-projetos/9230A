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

        //Produtos
        Telas_Fluxo.Receitas.CadastroProdutos cadastroProdutos = new Receitas.CadastroProdutos();
        Telas_Fluxo.Receitas.EditarProduto editarProdutos = new Receitas.EditarProduto();
        Telas_Fluxo.Receitas.ApagarProduto apagarProdutos = new Receitas.ApagarProduto();

        //Receitas
        Telas_Fluxo.Receitas.CadastroReceitas cadastroReceitas = new Receitas.CadastroReceitas();

        public receitas()
        {
            InitializeComponent();
            editarProdutos.Bt_Editar_Click += new EventHandler(Bt_Editar_Produtos_Click);
            cadastroProdutos.EditadoSucesso += new EventHandler(EditadoSucesso);

        }

        protected void EditadoSucesso(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(editarProdutos);
        }

        protected void Bt_Editar_Produtos_Click(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            cadastroProdutos.EditarProduto = true;
            cadastroProdutos.ProdutoEditar = editarProdutos.ProdutoEditar;

            spReceitas.Children.Add(cadastroProdutos);
        }

        private void btCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            cadastroProdutos.EditarProduto = false;
            cadastroProdutos.ProdutoEditar = -1;

            spReceitas.Children.Add(cadastroProdutos);
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

        private void btEditarProduto_Click(object sender, RoutedEventArgs e)
        {

            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }

            spReceitas.Children.Add(editarProdutos);

        }

        private void btTesteIntoProd_Click(object sender, RoutedEventArgs e)
        {
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("1", "Arroz", 1.1f, "Matéria Prima", "Teste1");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("2", "Feijao", 1.2f, "Matéria Prima", "Teste2");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("3", "Batata", 1.3f, "Matéria Prima", "Teste3");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("4", "Frango", 1.4f, "Complemento", "Teste4");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("5", "Mandioca", 1.5f, "Complemento", "Teste5");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("6", "Farelo", 1.6f, "Matéria Prima", "Teste6");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("7", "Soja", 1.7f, "Complemento", "Teste7");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("8", "Milho", 1.8f, "Complemento", "Teste8");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("9", "Azeitona", 1.9f, "Complemento", "Teste9");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("10", "Pepino", 2.0f, "Complemento", "Teste10");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("11", "Pipoca", 2.1f, "Complemento", "Teste11");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("12", "Gado", 2.2f, "Complemento", "Teste12");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("13", "Café", 2.3f, "Complemento", "Teste13");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("14", "Milho Seco", 2.4f, "Matéria Prima", "Teste14");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("15", "Casca de Soja", 2.5f, "Matéria Prima", "Teste15");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("16", "Sal Comum", 2.6f, "Complemento", "Teste16");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("17", "Calcário Calcíto", 2.7f, "Complemento", "Teste17");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("18", "Antioxidante", 2.8f, "Matéria Prima", "Teste18");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("19", "Prote-N", 2.9f, "Matéria Prima", "Teste19");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("20", "Farelo de Trigo", 3.0f, "Complemento", "Teste20");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("21", "Bovigold Indutrial", 3.1f, "Complemento", "Teste21");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("22", "Bovi Premium", 3.2f, "Complemento", "Teste22");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("23", "Farelo de Soja 46%", 3.3f, "Matéria Prima", "Teste23");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("24", "Milho Moido", 3.4f, "Matéria Prima", "Teste24");
            DataBase.SqlFunctionsProdutos.IntoDate_Table_Produtos("25", "Aromatizante", 3.5f, "Complementoa", "Teste25");
        }

        private void btApagarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }

            spReceitas.Children.Add(apagarProdutos);
        }
    }
}
