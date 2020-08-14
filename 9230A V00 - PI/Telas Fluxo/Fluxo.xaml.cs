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

namespace _9230A_V00___PI.Telas_Fluxo
{
    /// <summary>
    /// Interação lógica para Fluxo.xam
    /// </summary>
    public partial class Fluxo : UserControl
    {
        public event EventHandler ensque_Click;

        public Fluxo()
        {
            InitializeComponent();
        }

        public void actualiza_UI() 
        {
            lbCorrenteMoinho.Content = Motor_44.Equip_GS.Command_Get.SS.Corrente_Atual + "  (A)";
            lbCorrente43.Content = Motor_43.Equip_GS.Command_Get.INV.Corrente_Atual + "  (A)";
            lbVelocidade43.Content = Motor_43.Equip_GS.Command_Get.INV.Velocidade_Atual + " RPM";
            lbCorrente62.Content = Motor_62.Equip_GS.Command_Get.INV.Corrente_Atual + "  (A)";
            lbVelocidade62.Content = Motor_62.Equip_GS.Command_Get.INV.Velocidade_Atual + " RPM";
            lbCorrente65.Content = Motor_65.Equip_GS.Command_Get.INV.Corrente_Atual + "  (A)";
            lbVelocidade65.Content = Motor_65.Equip_GS.Command_Get.INV.Velocidade_Atual + " RPM";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.ensque_Click != null)
                this.ensque_Click(this, e);
        }
    }
}
