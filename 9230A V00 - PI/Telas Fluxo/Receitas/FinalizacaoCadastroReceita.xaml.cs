﻿using _9230A_V00___PI.Teclados;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for FinalizacaoCadastroReceita.xaml
    /// </summary>
    public partial class FinalizacaoCadastroReceita : UserControl
    {
        float pesoProdutosSomados = 0.0f;
        bool pesoProdutoIgualPesoRef = false;
        string NommeROta = "";
        Utilidades.messageBox inputDialog;
        private float floatPoint;

        public event EventHandler VoltarAdicaoProdutosReceita;

        public event EventHandler FinalizadoCadastroReceita;

        public FinalizacaoCadastroReceita()
        {
            InitializeComponent();
        }

        private void btLeftList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset - 20);
        }

        private void btDownList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset + 5);
        }

        private void btRightList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToHorizontalOffset(scroll.HorizontalOffset + 20);
        }

        private void btUpList_Click(object sender, RoutedEventArgs e)
        {
            var scroll = (VisualTreeHelper.GetChild(DataGrid_Receita, 0) as Decorator).Child as ScrollViewer;

            scroll.ScrollToVerticalOffset(scroll.VerticalOffset - 5);
        }

        private void btEditarProdutoReceita_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Receita.SelectedIndex != -1)
            {
                var rowList = (DataGrid_Receita.ItemContainerGenerator.ContainerFromIndex(DataGrid_Receita.SelectedIndex) as DataGridRow).Item as DataRowView;

                var index = Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos.FindIndex(x => x.produto.id == Convert.ToInt32(rowList.Row.ItemArray[0]));

                //Abre tela para editar o produto
                Telas_Fluxo.Receitas.AdicionarProdutoReceitaPouUp adcionaProdutoReceita = new AdicionarProdutoReceitaPouUp(Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index], Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index].pesoPorProduto, true, Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos[index].tipoDosagemMateriaPrima, true);
                adcionaProdutoReceita.ShowDialog();
                loadDataReceitas();
                atualizaPesoProdutoSomado();
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

        private void btVoltarAdicaoProdutos_Click(object sender, RoutedEventArgs e)
        {
            if (this.VoltarAdicaoProdutosReceita != null)
                this.VoltarAdicaoProdutosReceita(this, e);
        }

        private void btFinalizaCadastroReceita_Click(object sender, RoutedEventArgs e)
        {
            if (pesoProdutoIgualPesoRef)
            {
                if (!String.IsNullOrEmpty(txtNome.Text) && !String.IsNullOrEmpty(txtPesoRef.Text))
                {

                    if (Utilidades.VariaveisGlobais.receitas.Editar_GS)
                    {
                        inputDialog = new Utilidades.messageBox("Confirmação", "Você tem certeza que deseja editar essa Receita?", MaterialDesignThemes.Wpf.PackIconKind.QuestionAnswer, "Sim", "Não");

                        if (inputDialog.ShowDialog() == true) 
                        {
                            DataBase.SqlFunctionsReceitas.EditRecipeBD();

                        }
                    }
                    else
                    {
                        inputDialog = new Utilidades.messageBox("Confirmação", "Você tem certeza que deseja criar essa Receita?", MaterialDesignThemes.Wpf.PackIconKind.QuestionAnswer, "Sim", "Não");

                        inputDialog.ShowDialog();
                    }

                    if (inputDialog.DialogResult == true)
                    {

                        //Carrega nome, peso referencia observação e calcula o peso dos produtos somados
                        txtNome.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita;
            

                        txtObs.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.observacao;


                        Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita = txtNome.Text.ToString();
                        Utilidades.VariaveisGlobais.ReceitaCadastro.observacao = txtObs.Text.ToString();

                         int result = DataBase.SqlFunctionsReceitas.AddNewRecipeBD();

                        //Se foi criado com sucesso a receita
                        if (result >= 0)
                        {
                            //Limpar Cadastro Receita Global
                            Utilidades.VariaveisGlobais.ReceitaCadastro = new Utilidades.Receita();

                            Utilidades.functions.atualizalistReceitas();

                            if (this.FinalizadoCadastroReceita != null)
                                this.FinalizadoCadastroReceita(this, e);
                        }
                        else
                        {
                            inputDialog = new Utilidades.messageBox("Erro", "Erro ao adicionar receita com o código de erro = " + result, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }
                    }

                }
                else
                {
                    inputDialog = new Utilidades.messageBox("Campos Vazios", "Por favor verifique se tem campos vazios", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
            }
            else
            {
                inputDialog = new Utilidades.messageBox("Peso Referência", "Por favor verifique se o Peso referência é igual ao peso somado dos produtos", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
        }
        private void loadDataReceitas()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id");
            dt.Columns.Add("Produto");
            dt.Columns.Add("Peso(kg)");
            dt.Columns.Add("Percentual");

            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                DataRow dr = dt.NewRow();

                dr["Id"] = item.produto.id;
                dr["Produto"] = item.produto.descricao;
                dr["Peso(kg)"] = item.pesoPorProduto;
                dr["Percentual"] = Utilidades.functions.percentualProduto(item.pesoPorProduto, Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase).ToString() + " %";

                dt.Rows.Add(dr);
            }


            DataGrid_Receita.Dispatcher.Invoke(delegate { DataGrid_Receita.ItemsSource = dt.DefaultView; });
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Carrega itens da receita
            loadDataReceitas();

            //Carrega nome, peso referencia observação e calcula o peso dos produtos somados
            txtNome.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.nomeReceita;
            txtPesoRef.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase.ToString();
            txtObs.Text = Utilidades.VariaveisGlobais.ReceitaCadastro.observacao;
            atualizaPesoProdutoSomado();


        }

        private void atualizaPesoProdutoSomado()
        {
            CalculaPesoProdutosSomados();

            txtPesoProdutosSomados.Text = pesoProdutosSomados.ToString();

            if (pesoProdutosSomados == Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase)
            {
                BackgroundPesoProdutoSomado.Background = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));

                pesoProdutoIgualPesoRef = true;
            }
            else
            {
                BackgroundPesoProdutoSomado.Background = new SolidColorBrush(Color.FromArgb(255, 155, 0, 0));
                pesoProdutoIgualPesoRef = false;
            }

        }

        private void CalculaPesoProdutosSomados()
        {
            pesoProdutosSomados = 0.0f;

            foreach (var item in Utilidades.VariaveisGlobais.ReceitaCadastro.listProdutos)
            {
                pesoProdutosSomados += item.pesoPorProduto;
            }
        }

        private void openKeyboard(object sender, MouseButtonEventArgs e)
        {
            Teclados.keyboard.openKeyboard();
        }

        private void txtPesoRef_LostFocus(object sender, RoutedEventArgs e)
        {
            atualizaPesoProdutoSomado();
        }

        private void txtPesoRef_KeyUp(object sender, KeyEventArgs e)
        {
            atualizaPesoProdutoSomado();
        }

        private void floatingPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            TextBox txtReceber = (TextBox)sender;

            txtReceber.Text = Utilidades.VariaveisGlobais.floatingKeypad(txtReceber.Text, 10).ToString();
            //Retira o foco do textbox.
            Keyboard.ClearFocus();

            Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase = Convert.ToSingle(txtReceber.Text);

            CalculaPeso();

            loadDataReceitas();



        }

        private void CalculaPeso()
        {
            double peso = 0;

            foreach (DataRowView row in DataGrid_Receita.Items)
            {
                float Descricao = Convert.ToSingle(row.Row.ItemArray[2]);

                peso = peso + Descricao;

            }

            txtPesoProdutosSomados.Text = peso.ToString();

            if (peso == Utilidades.VariaveisGlobais.ReceitaCadastro.pesoBase)
            {
                BackgroundPesoProdutoSomado.Background = new SolidColorBrush(Color.FromArgb(255, 60, 60, 60));

                pesoProdutoIgualPesoRef = true;

            }
            else
            {
                BackgroundPesoProdutoSomado.Background = new SolidColorBrush(Color.FromArgb(255, 155, 0, 0));
                pesoProdutoIgualPesoRef = false;

            }
        }
    }
}
