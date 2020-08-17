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

namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interação lógica para manualUsuario.xam
    /// </summary>
    public partial class manualUsuario : UserControl
    {
        public manualUsuario()
        {
            InitializeComponent();

            if (this.webBrowse != null)
            {
                this.webBrowse.Navigate(@"C:\Projetos\Manual.pdf");
            }

        }
    }
}
