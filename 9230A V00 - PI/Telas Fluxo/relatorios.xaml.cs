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
        public relatorios()
        {
            InitializeComponent();
        }

        private void btCriarUsuario_Click(object sender, RoutedEventArgs e)
        {

            string filename = " ";

            DataTable dtbl = new DataTable();

            dtbl.Columns.Add("Inicial/Hora");
            dtbl.Columns.Add("Final/Hora");
            dtbl.Columns.Add("Quantidade Bateladas");


            //Abre onde deseja salvar
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Balanca_" + "" + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year; // Default file name
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;

                Relatorios.ExportacaoRelatorios.ExportDataTableToPdf(filename,Utilidades.VariaveisGlobais.PesquisaProducao, "Relátorio de Produção TOtal", "150", DateTime.Now, DateTime.Now);


              System.Diagnostics.Process.Start(filename);
               
            }
        }
    }
}
