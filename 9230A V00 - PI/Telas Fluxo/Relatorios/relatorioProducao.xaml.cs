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
using iTextSharp.text.pdf;          //*iTextSharp
using iTextSharp.text.pdf.parser;   //*iTextSharp Text-Reader


namespace _9230A_V00___PI.Telas_Fluxo.Relatorios
{
    /// <summary>
    /// Interação lógica para relatorioProducao.xam
    /// </summary>
    public partial class relatorioProducao : UserControl
    {

        public relatorioProducao()
        {
            InitializeComponent();

            producao.bt_Exportar += Producao_bt_Exportar;

            producao.bt_Pesquisar += Producao_bt_Pesquisar;

            String sFilename = @"C:\Users\Emanuel\Documents\ffgdfgdfgs.pdf";


        }

        private void Producao_bt_Pesquisar(object sender, EventArgs e)
        {
           //Relatorios.ExportacaoRelatorios.exportProducao(filename, Utilidades.VariaveisGlobais.PesquisaProducao, "Produção Total", DateTime.Now, DateTime.Now);
        }

        private void Producao_bt_Exportar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
