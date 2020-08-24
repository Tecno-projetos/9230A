using _9230A_V00___PI.Utilidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interação lógica para manutencao.xam
    /// </summary>
    public partial class manutencao : UserControl
    {

        Manutenção.informacoesSistema informacoesSistema = new Manutenção.informacoesSistema();

        Manutenção.conexoes conexoes  = new Manutenção.conexoes();

        Manutenção.diagramaRede rede = new Manutenção.diagramaRede();

        Manutenção.DiagnosticoCLP DiagCLP = new Manutenção.DiagnosticoCLP();

        Manutenção.projetoEletrico prjEletrico = new Manutenção.projetoEletrico();

        Manutenção.manualUsuario manual = new Manutenção.manualUsuario();

        Manutenção.alarmes alarmes = new Manutenção.alarmes();


        private bool telaManutencaoAtiva = false;

        public bool TelaManutencaoAtiva_Get { get => telaManutencaoAtiva; }

        public manutencao()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {

            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS < 2)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaPermissaoTitle, Utilidades.VariaveisGlobais.faltaPermissaoMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();

                return;
            }

            App.Current.Shutdown();
            Process proc = Process.GetCurrentProcess();
            proc.Kill();
        }

        private void btInformacoesSistema_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(informacoesSistema);

        }

        private void btConexoes_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(conexoes);
        }

        private void btDiagrama_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(rede);
        }

        public void atualizaManutencao() 
        {
            informacoesSistema.atualizaSistema();
            conexoes.atualizaConexoes();
            rede.atualizaRede(3); // Buffer 3    
        }

        private void btDiagnosticoCLP_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(DiagCLP);
        }

        private void btDiagnosticoSuP_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(Utilidades.VariaveisGlobais.Window_Buffer_Diagnostic);
        }

        private void btPrjEletrico_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(prjEletrico);
        }


        private void btManual_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(manual);
        }

        private void btAlarmes_Click(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            spManutencao.Children.Add(alarmes);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (spManutencao != null)
            {
                spManutencao.Children.Clear();
            }

            telaManutencaoAtiva = true;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            telaManutencaoAtiva = false;
        }

        private void btDiagnosticoTime_Click(object sender, RoutedEventArgs e)
        {
            Utilidades.VariaveisGlobais.Window_Diagnostic.Show();
        }
    }
}
