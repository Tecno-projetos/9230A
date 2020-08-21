using _9230A_V00___PI.Telas_Fluxo.Relatorios;
using MaterialDesignThemes.Wpf;
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

namespace _9230A_V00___PI.Telas_Fluxo
{
    /// <summary>
    /// Interação lógica para relatorios.xam
    /// </summary>
    public partial class relatorios : UserControl
    {

        Relatorios.relatorioProducao producao = new relatorioProducao();
        Relatorios.pesquisaBatelada pesquisaBateladas = new pesquisaBatelada();
        Relatorios.relatorioProducaoEnsaque relatorioProducaoEnsaque = new relatorioProducaoEnsaque();

       
        public relatorios()
        {
            InitializeComponent();
        }

        private void btProducao_Click(object sender, RoutedEventArgs e)
        {
            if (spRelatorio.Children != null)
            {
                spRelatorio.Children.Clear();
            }

            spRelatorio.Children.Add(producao);

            pckProducao.Foreground = new SolidColorBrush(Colors.Red);
            pckBateladas.Foreground = new SolidColorBrush(Colors.White);
            pckEnsaque.Foreground = new SolidColorBrush(Colors.White);

        }

        private void btBateladas_Click(object sender, RoutedEventArgs e)
        {
            if (spRelatorio.Children != null)
            {
                spRelatorio.Children.Clear();
            }

            spRelatorio.Children.Add(pesquisaBateladas);

            pckProducao.Foreground = new SolidColorBrush(Colors.White);
            pckBateladas.Foreground = new SolidColorBrush(Colors.Red);
            pckEnsaque.Foreground = new SolidColorBrush(Colors.White);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (spRelatorio.Children != null)
            {
                spRelatorio.Children.Clear();
            }

            pckProducao.Foreground = new SolidColorBrush(Colors.White);
            pckBateladas.Foreground = new SolidColorBrush(Colors.White);
            pckEnsaque.Foreground = new SolidColorBrush(Colors.White);
        }


        private void btEnsaques_Click(object sender, RoutedEventArgs e)
        {
            if (spRelatorio.Children != null)
            {
                spRelatorio.Children.Clear();
            }

            spRelatorio.Children.Add(relatorioProducaoEnsaque);

            pckProducao.Foreground = new SolidColorBrush(Colors.White);
            pckBateladas.Foreground = new SolidColorBrush(Colors.White);
            pckEnsaque.Foreground = new SolidColorBrush(Colors.Red);
        }
    }
}
