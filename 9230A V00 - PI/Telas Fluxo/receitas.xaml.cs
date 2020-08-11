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

        Telas_Fluxo.Receitas.CadastroReceitaInicial cadastroReceitaInicial = new Receitas.CadastroReceitaInicial(); //Tela inicial do cadastro de receitas, onde é preenchido o nome, peso referencia da receita e observações
        Telas_Fluxo.Receitas.AdicionarProdutoReceita adicionarProdutoReceita = new Receitas.AdicionarProdutoReceita(); //Tela onde é realizado a adição de produtos na receita.
        Telas_Fluxo.Receitas.FinalizacaoCadastroReceita finalizaCadastroReceita = new Receitas.FinalizacaoCadastroReceita(); //Tela onde é finalizado o cadastro da receita, o sistema verifica a soma dos pesos dos produtos e tem que ser igual ao peso ref., e também é´possível
        //o cliente editar qualquer produto na receita nessa tela, caso queira adicionar mais produtos, terá que voltar a tela anterior...
        Telas_Fluxo.Receitas.EditarReceita EditarCadastroReceita = new Receitas.EditarReceita();
        Telas_Fluxo.Receitas.ApagarReceitaxaml ApagarCadastroReceita = new Receitas.ApagarReceitaxaml();

        public receitas()
        {
            InitializeComponent();

            //Chama a tela de cadastro só para edição, isso após a escolha do produto que deseja editar
            editarProdutos.Bt_Editar_Click += new EventHandler(Bt_Editar_Produtos_Click);

            //Produto editado com sucesso
            cadastroProdutos.EditadoSucesso += new EventHandler(EditadoSucesso);

            //Finalizado inicio do cadastro de receitas, agora irá chamar a tela de adicionar produtos na receita.
            cadastroReceitaInicial.FinalizadoInicioCadastroReceita += new EventHandler(EventoFinalizadoInicioCadastroReceita);

            //Finalizado adição de produtos na receita, agora irá chamar a tela de finalização do cadastro da receita
            adicionarProdutoReceita.FinalizadoAdicaoProdutosReceita += new EventHandler(EventoFinalizadoAdicaoProdutosReceita);

            //Solicitação da tela de finalizar cadastro de receita para voltar para adição de produtos na receita.
            finalizaCadastroReceita.VoltarAdicaoProdutosReceita += new EventHandler(EventoVoltarAdicaoProdutosReceita);

            //Tela de editar cadastro da receita solicita editar uma receita, assim é chamado a tela de cadastro normal, porem na tela editar já foi carregado a receita na variavel receitacadastro.
            EditarCadastroReceita.EventoEditarReceita += new EventHandler(EventoEditarReceitar);

            //Finalizado cadastro de receita
            finalizaCadastroReceita.FinalizadoCadastroReceita += new EventHandler(EventoFinalizadoCadastroReceita);

            //Apagado receita com sucesso
            ApagarCadastroReceita.EventoApagadoSucesso += new EventHandler(EventoApagadoSucesso);
        }

        protected void EventoApagadoSucesso(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(ApagarCadastroReceita);
        }

        protected void EventoFinalizadoCadastroReceita(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(cadastroReceitaInicial);
        }

        protected void EventoEditarReceitar(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(adicionarProdutoReceita);
        }

        protected void EventoVoltarAdicaoProdutosReceita(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(adicionarProdutoReceita);
        }
        protected void EventoFinalizadoAdicaoProdutosReceita(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(finalizaCadastroReceita);
        }


        protected void EventoFinalizadoInicioCadastroReceita(object sender, EventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }
            spReceitas.Children.Add(adicionarProdutoReceita);
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
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }

            spReceitas.Children.Add(cadastroReceitaInicial);
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

        private void btEditarReceita_Click(object sender, RoutedEventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }

            spReceitas.Children.Add(EditarCadastroReceita);
        }

        private void btApagarReceita_Click(object sender, RoutedEventArgs e)
        {
            if (spReceitas != null)
            {
                spReceitas.Children.Clear();
            }

            spReceitas.Children.Add(ApagarCadastroReceita);
        }

        private void btTesteIntoReceita_Click(object sender, RoutedEventArgs e)
        {
            //====================================================================================
            //Receita 1
            Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita = "FrangoTipo1";
            Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase = 100.0F;
            Utilidades.VariaveisGlobais.ReceitaCadastro.observacao = "Teste Frango 1";

            Utilidades.ProdutoReceita produtoReceita = new Utilidades.ProdutoReceita();

            produtoReceita.produto = new Utilidades.Produto();

            produtoReceita.produto.id = 1;
            produtoReceita.produto.codigo = "1";
            produtoReceita.produto.descricao = "Arroz";
            produtoReceita.produto.densidade = 1.1f;
            produtoReceita.produto.tipoProduto = "Matéria Prima";
            produtoReceita.produto.observacao = "Teste1";
            produtoReceita.pesoPorProduto = 50;
            produtoReceita.tipoDosagemMateriaPrima = "Automático";

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);

            produtoReceita = new Utilidades.ProdutoReceita();
            produtoReceita.produto = new Utilidades.Produto();
            produtoReceita.produto.id = 16;
            produtoReceita.produto.codigo = "16";
            produtoReceita.produto.descricao = "Sal Comum";
            produtoReceita.produto.densidade = 2.6f;
            produtoReceita.produto.tipoProduto = "Matéria Prima";
            produtoReceita.produto.observacao = "Teste16";
            produtoReceita.pesoPorProduto = 25;
            produtoReceita.tipoDosagemMateriaPrima = "Manual";

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);

            produtoReceita = new Utilidades.ProdutoReceita();
            produtoReceita.produto = new Utilidades.Produto();
            produtoReceita.produto.id = 7;
            produtoReceita.produto.codigo = "7";
            produtoReceita.produto.descricao = "Soja";
            produtoReceita.produto.densidade = 1.7f;
            produtoReceita.produto.tipoProduto = "Complemento";
            produtoReceita.produto.observacao = "Teste7";
            produtoReceita.pesoPorProduto = 25;
            produtoReceita.tipoDosagemMateriaPrima = "";

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);

            //Adicionar receita no banco de dados.
            DataBase.SqlFunctionsReceitas.AddNewRecipeBD();
            //Limpar Cadastro Receita Global
            Utilidades.VariaveisGlobais.ReceitaCadastro = new Utilidades.Receita();

            //====================================================================================
            //Receita 2
            Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita = "GadoTipo1";
            Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase = 100.0F;
            Utilidades.VariaveisGlobais.ReceitaCadastro.observacao = "Teste Gado 1";

            produtoReceita = new Utilidades.ProdutoReceita();
            produtoReceita.produto = new Utilidades.Produto();
            produtoReceita.produto.id = 2;
            produtoReceita.produto.codigo = "2";
            produtoReceita.produto.descricao = "Feijão";
            produtoReceita.produto.densidade = 1.2f;
            produtoReceita.produto.tipoProduto = "Matéria Prima";
            produtoReceita.produto.observacao = "Teste2";
            produtoReceita.pesoPorProduto = 50;
            produtoReceita.tipoDosagemMateriaPrima = "Automática";

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);

            produtoReceita = new Utilidades.ProdutoReceita();
            produtoReceita.produto = new Utilidades.Produto();
            produtoReceita.produto.id = 16;
            produtoReceita.produto.codigo = "16";
            produtoReceita.produto.descricao = "Sal Comum";
            produtoReceita.produto.densidade = 2.6f;
            produtoReceita.produto.tipoProduto = "Matéria Prima";
            produtoReceita.produto.observacao = "Teste16";
            produtoReceita.pesoPorProduto = 25;
            produtoReceita.tipoDosagemMateriaPrima = "Manual";

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);

            produtoReceita = new Utilidades.ProdutoReceita();
            produtoReceita.produto = new Utilidades.Produto();
            produtoReceita.produto.id = 7;
            produtoReceita.produto.codigo = "7";
            produtoReceita.produto.descricao = "Soja";
            produtoReceita.produto.densidade = 1.7f;
            produtoReceita.produto.tipoProduto = "Complemento";
            produtoReceita.produto.observacao = "Teste7";
            produtoReceita.pesoPorProduto = 25;
            produtoReceita.tipoDosagemMateriaPrima = "";

            Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.Add(produtoReceita);

            //Adicionar receita no banco de dados.
            DataBase.SqlFunctionsReceitas.AddNewRecipeBD();
            //Limpar Cadastro Receita Global
            Utilidades.VariaveisGlobais.ReceitaCadastro = new Utilidades.Receita();
        }
    }
}
