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

namespace _9230A_V00___PI.Telas_Fluxo
{
    /// <summary>
    /// Interação lógica para producao.xam
    /// </summary>
    public partial class producao : UserControl
    {
        //Ração
        public Telas_Fluxo.Producao.ProducaoTelaInicial TelaInicialProducao = new Producao.ProducaoTelaInicial();
        public Telas_Fluxo.Producao.ConfiguracaoReceitaProducao TelaConfiguracaoReceitaProducao = new Producao.ConfiguracaoReceitaProducao();
        public Telas_Fluxo.Producao.VerificacaoBateladas TelaVerificaoBateladas = new Producao.VerificacaoBateladas();
        public Telas_Fluxo.Controle_Produção.TelaControleProducao TelaControleProducao = new Controle_Produção.TelaControleProducao();
        public Telas_Fluxo.Controle_Produção.Ensaque TelaEnsaque = new Controle_Produção.Ensaque();

        Utilidades.messageBox inputDialog;

        public producao()
        {
            InitializeComponent();

            TelaInicialProducao.EventoReceitaSelecionada += new EventHandler(EventoReceitaSelecionada);

            TelaConfiguracaoReceitaProducao.ProximaTela += new EventHandler(EventoProximaTela);

            TelaConfiguracaoReceitaProducao.TelaAnterior += new EventHandler(EventoTelaAnterior);

            TelaVerificaoBateladas.ProximaTela += new EventHandler(EventoProximaTelaVerificacaoBateladas);

            TelaVerificaoBateladas.TelaAnterior += new EventHandler(EventoTelaAnteriorVerificacaoBateladas);
        }

        protected void EventoTelaAnteriorVerificacaoBateladas(object sender, EventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaConfiguracaoReceitaProducao);
        }

        protected void EventoProximaTelaVerificacaoBateladas(object sender, EventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            //spControleProducao.Children.Add(TelaInicialProducao);
        }

        protected void EventoTelaAnterior(object sender, EventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaInicialProducao);
        }

        protected void EventoProximaTela(object sender, EventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaVerificaoBateladas);
        }

        protected void EventoReceitaSelecionada(object sender, EventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaConfiguracaoReceitaProducao);
        }

        private void btTelaInicialEnsaque_Click(object sender, RoutedEventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaEnsaque);
        }

        private void btTelaInicialRacao_Click(object sender, RoutedEventArgs e)
        {

            if (Utilidades.VariaveisGlobais.ValoresEspecificacoesEquipamentos.ValoresPreenchidos())
            {
                if (!VariaveisGlobais.niveis.Inferior_Silo_Exp)
                {
                    if (spControleProducao != null)
                    {
                        spControleProducao.Children.Clear();
                    }
                    spControleProducao.Children.Add(TelaInicialProducao);
                }
                else
                {
                    //falta preencher algum valor
                    inputDialog = new Utilidades.messageBox("Silo Expedição", "Para iniciar uma nova produção o silo de expedição precisa estar vazio!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }

            }
            else
            {
                //falta preencher algum valor
                inputDialog = new Utilidades.messageBox("Falta informções", "Verifique se os valores na tela de configuração das especificações estão preenchidos!", MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();
            }


        }

        private void btEmProducao_Click(object sender, RoutedEventArgs e)
        {
            if (spControleProducao != null)
            {
                spControleProducao.Children.Clear();
            }
            spControleProducao.Children.Add(TelaControleProducao);
        }

        public void atualizaTela()
        {
            TelaControleProducao.atualizaTela();
        }
    }
}
