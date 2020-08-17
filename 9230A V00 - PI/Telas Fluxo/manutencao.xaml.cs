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
        public manutencao()
        {
            InitializeComponent();
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
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
            //rede.atualizaRede();
     
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
    }
}
