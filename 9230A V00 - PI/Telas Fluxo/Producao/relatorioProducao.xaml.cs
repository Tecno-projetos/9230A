using System;
using System.Collections.Generic;
using System.IO;
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

namespace _9230A_V00___PI.Telas_Fluxo.Producao
{
    /// <summary>
    /// Interação lógica para relatorioProducao.xam
    /// </summary>
    public partial class relatorioProducao : UserControl
    {
        string nameArquivo = "";
        string fileName = "";
        private string folder = @"C:\Temp";


        Utilidades.messageBox inputDialog;

        public relatorioProducao()
        {
            InitializeComponent();
        }

        public void enviaProjeto() 
        {

            inputDialog = new Utilidades.messageBox("Iniciando", "Isso pode levar alguns minutos, por favor aguarde.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

            inputDialog.ShowDialog();


            //recebe novo nome de arquivo
            nameArquivo = "Producao_Iniciada" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".pdf";


            fileName = folder + "\\" + nameArquivo;

            //Verifica se o file já foi criado
            if (!File.Exists(fileName))
            {
                //Original
                if (!Relatorios.ExportacaoRelatorios.producaoInicial(fileName, Utilidades.VariaveisGlobais.ProducaoReceita, "Produção Relatório"))
                {
                    inputDialog = new Utilidades.messageBox("Erro", "Erro ao gerar relatório. Tente Novamente!", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                    inputDialog.ShowDialog();
                }
                atualizaProjeto(fileName);
            }

        }

        public void atualizaProjeto(String sFilename)
        {
            if (this.webBrowse != null)
            {
                this.webBrowse.Navigate(sFilename);
            }

        }

        private void btExportar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
