using _9230A_V00___PI.Telas_Fluxo.Relatorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private bool error = false;

        Utilidades.messageBox inputDialog;

        public relatorioProducao()
        {
            InitializeComponent();

 
        }

        //Apaga tudo dentro do diretório
        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
        public void enviaProjeto() 
        {
            KillRunningProcess();
         

            inputDialog = new Utilidades.messageBox("Iniciando", "Isso pode levar alguns minutos, por favor aguarde.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

            inputDialog.ShowDialog();

            clearFolder(folder);

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

                    error = true;

                    inputDialog.ShowDialog();
                }
                atualizaProjeto(fileName);
            }

            error = false;

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
            if (error)
            {
                inputDialog = new Utilidades.messageBox("Erro", "Erro ao exportar relatório. Tente Novamente!", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                inputDialog.ShowDialog();
            }
            else
            {
                string exportacao = "";

                discoExportar exportacaoMessage = new discoExportar();

                if (exportacaoMessage.ShowDialog() == true)
                {
                    exportacao = exportacaoMessage.discoExportacao;


                    string destinationFile = exportacao + "\\" + nameArquivo;

                    if (!File.Exists(destinationFile))
                    {
                        inputDialog = new Utilidades.messageBox("Exportando", "Isso pode levar alguns minutos, por favor aguarde.", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                        inputDialog.ShowDialog();

                        if (Relatorios.ExportacaoRelatorios.producaoInicial(destinationFile, Utilidades.VariaveisGlobais.ProducaoReceita, "Produção Relatório"))
                        {
                            inputDialog = new Utilidades.messageBox("Arquivo exportado", "O arquivo foi exportado com sucesso", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }
                        else
                        {
                            inputDialog = new Utilidades.messageBox("Erro", "Erro ao exportar relatório. Tente Novamente!", MaterialDesignThemes.Wpf.PackIconKind.Information, "OK", "Fechar");

                            inputDialog.ShowDialog();
                        }

                    }

                }
            }
          
        }

        private void KillRunningProcess()
        {
            Process[] tabtip = Process.GetProcessesByName("Acrord32");

            if (null != tabtip)
            {
                tabtip.ToList().ForEach(a => { if (null != a) { a.Kill(); } });

            }
        }
    }
}
