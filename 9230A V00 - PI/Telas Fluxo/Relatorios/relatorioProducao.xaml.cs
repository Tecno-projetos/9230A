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
using iTextSharp.text.pdf;          //*iTextSharp
using iTextSharp.text.pdf.parser;   //*iTextSharp Text-Reader


namespace _9230A_V00___PI.Telas_Fluxo.Relatorios
{
    /// <summary>
    /// Interação lógica para relatorioProducao.xam
    /// </summary>
    public partial class relatorioProducao : UserControl
    {
        //Pega o caminho da aplicação
        private string curDir = "";
        private string fileName = "";

        public relatorioProducao()
        {
            InitializeComponent();

            producao.bt_Exportar += Producao_bt_Exportar;

            producao.bt_Pesquisar += Producao_bt_Pesquisar;

            //Pega o caminho da aplicação
            string curDir = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
        }

        private void Producao_bt_Pesquisar(object sender, EventArgs e)
        {

             string folder = @"C:\Relatorio_Producoes";

            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            fileName = folder + "\\" + "Producao" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".pdf";

            //Teste
            Relatorios.ExportacaoRelatorios.exportProducao(fileName, Utilidades.VariaveisGlobais.PesquisaProducao, "Produção Total", DateTime.Now, DateTime.Now);


            producao.atualizaProjeto(fileName);

            //Original
            //Relatorios.ExportacaoRelatorios.exportProducao(fileName, DataBase.SQLFunctionsProducao.PesquisaDateInDateOut(producao.dataInicial_GS, producao.dataFinal_GS), "Produção Total", DateTime.Now, DateTime.Now);
        }

        private void Producao_bt_Exportar(object sender, EventArgs e)
        {

        }
    }
}
