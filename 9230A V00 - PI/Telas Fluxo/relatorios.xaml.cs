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


            //string filename = " ";

            ////Abre onde deseja salvar
            //Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            //dlg.FileName = "Balanca_" + "" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year; // Default file name
            //dlg.DefaultExt = ".pdf"; // Default file extension
            //dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension

            //// Show save file dialog box
            //Nullable<bool> result = dlg.ShowDialog();
            //// Process save file dialog box results
            //if (result == true)
            //{
            //    // Save document
            //    filename = dlg.FileName;

            //    Relatorios.ExportacaoRelatorios.exportProducao(filename,Utilidades.VariaveisGlobais.PesquisaProducao, "Produção Total", DateTime.Now, DateTime.Now);


            //  System.Diagnostics.Process.Start(filename);

            //}
        }

        private void btBateladas_Click(object sender, RoutedEventArgs e)
        {
            if (spRelatorio.Children != null)
            {
                spRelatorio.Children.Clear();
            }

            spRelatorio.Children.Add(pesquisaBateladas);
        }


        private void btInto_Click(object sender, RoutedEventArgs e)
        {


            for (int i = 0; i < 100; i++)
            {
                Utilidades.Producao aa = new Utilidades.Producao();
                Utilidades.Receita receita = new Utilidades.Receita();

                if (i%2==0)
                {
                    receita.nomeReceita = "Milho " + i;
                    receita.id = i;
                }
                else
                {
                    receita.nomeReceita = "Mandioca " + i;
                    receita.id = i;
                }
           
               





                aa.id = i;
                aa.IdReceitaBase = i;
                aa.receita = receita;
                aa.quantidadeBateladas = i;
                aa.tempoPosMistura = i;
                aa.tempoPreMistura = i;
                aa.pesoTotalProducao = 1500;
                aa.volumeTotalProducao = 500;
                aa.pesoTotalProduzido = 1500;
                aa.volumeTotalProduzido = 500;
                aa.dateTimeInicioProducao = DateTime.Now;
                aa.dateTimeFimProducao = DateTime.Now;


                Utilidades.VariaveisGlobais.PesquisaProducao.Add(aa);




            }
        }

    }
}
