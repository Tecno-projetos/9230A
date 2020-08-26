using _9230A_V00___PI.Utilidades;
using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            lbposicao26A.Content = Motor_26_Silo1.Equip_GS.Command_Get.AtuadorA.PosicaoAtual + " %";
            lbposicao26B.Content = Motor_26_Silo2.Equip_GS.Command_Get.AtuadorA.PosicaoAtual + " %";
            lbposicao49.Content = Motor_49.Equip_GS.Command_Get.AtuadorA.PosicaoAtual + " %";


            rec22 = AtulizaCano(rec22, Motor_22.Equip_GS.Command_Get.PD.ligado);

            rec23_Esquerda = AtulizaCano(rec23_Esquerda, Motor_22.Equip_GS.Command_Get.PD.ligado && Motor_23.Equip_GS.Command_Get.AtuadorD.emPosicaoLado1);
            rec23_Direita = AtulizaCano(rec23_Direita, Motor_22.Equip_GS.Command_Get.PD.ligado && Motor_23.Equip_GS.Command_Get.AtuadorD.emPosicaoLado2);

            rec26A = AtulizaCano(rec26A, Motor_26_Silo1.Equip_GS.Command_Get.AtuadorA.ligaManual || Motor_26_Silo1.Equip_GS.Command_Get.AtuadorA.acionandoAutomatico);
            rec26B = AtulizaCano(rec26B, Motor_26_Silo2.Equip_GS.Command_Get.AtuadorA.ligaManual || Motor_26_Silo2.Equip_GS.Command_Get.AtuadorA.acionandoAutomatico);

            rec42 = AtulizaCano(rec42, Motor_42.Equip_GS.Command_Get.PD.ligado);

            rec49 = AtulizaCano(rec49, Motor_49.Equip_GS.Command_Get.AtuadorA.PosicaoAtual > 1);
            rec62 = AtulizaCano(rec62, Motor_62.Equip_GS.Command_Get.INV.ligado);
            rec65 = AtulizaCano(rec65, Motor_65.Equip_GS.Command_Get.INV.ligado);


            silo1.Nivel_Alto_GS = Utilidades.VariaveisGlobais.niveis.Superior_Silo_1;
            silo2.Nivel_Alto_GS = Utilidades.VariaveisGlobais.niveis.Superior_Silo_2;

            silo1.Nivel_Baixo_GS = Utilidades.VariaveisGlobais.niveis.Inferior_Silo_1;
            silo2.Nivel_Baixo_GS = Utilidades.VariaveisGlobais.niveis.Inferior_Silo_2;

            siloexp.Nivel_Alto_GS = Utilidades.VariaveisGlobais.niveis.Superior_Silo_Exp;
            siloexp.Nivel_Baixo_GS = Utilidades.VariaveisGlobais.niveis.Inferior_Silo_Exp;


            nivel48.Nivel_Baixo_GS = !Utilidades.VariaveisGlobais.niveis.Inferior_Pos_Misturador;
            if (Utilidades.VariaveisGlobais.niveis.Inferior_Pos_Misturador)
            {
                txtNivel48.Text = "Com Produto";
            }
            else
            {
                txtNivel48.Text = "Sem Produto";
            }

            VariaveisGlobais.Fluxo.inicialProducao.atualiza(ref VariaveisGlobais.executaProducao, ref VariaveisGlobais.ProducaoReceita);
            VariaveisGlobais.Fluxo.indicadorPesagem.Actualize_UI(VariaveisGlobais.indicadorPesagem);


            if (Utilidades.VariaveisGlobais.controlePID.Habilita_PID)
            {
                RECpid.Stroke = new SolidColorBrush(Colors.Green);
                txtPID.Foreground = new SolidColorBrush(Colors.Green);

            }
            else
            {
            
                RECpid.Stroke = new SolidColorBrush(Colors.Red);
                txtPID.Foreground = new SolidColorBrush(Colors.Red);
            }

            //Atualzia peso do ensaque
            lbPesoEnsaque.Content = Utilidades.VariaveisGlobais.executaEnsaque.IndicadorPesagem_Get.Valor_Atual_Indicador.ToString("N", CultureInfo.GetCultureInfo("pt-BR")) + " kg";
            lbStatusEnsaque = Utilidades.VariaveisGlobais.executaEnsaque.StatusBalanca(lbStatusEnsaque);
        }

        private void bt_Ensaque_Click(object sender, RoutedEventArgs e)
        {
            if (Utilidades.VariaveisGlobais.NumberOfGroup_GS == 0)
            {
                Utilidades.messageBox inputDialog = new messageBox(Utilidades.VariaveisGlobais.faltaUsuarioTitle, Utilidades.VariaveisGlobais.faltaUsuarioMessage, MaterialDesignThemes.Wpf.PackIconKind.Error, "OK", "Fechar");

                inputDialog.ShowDialog();

                return;
            }

            if (this.ensque_Click != null)
                this.ensque_Click(this, e);
        }


        private Rectangle AtulizaCano(Rectangle rectangle, bool statusMotor) 
        {
            if (statusMotor)
            {
                rectangle.Fill = new SolidColorBrush(Colors.Green);

            }
            else
            {
                rectangle.Fill = new SolidColorBrush(Color.FromRgb(60,60,60));
            }

            return rectangle;
        }

        private Arc AtulizaCano(Arc arc, bool statusMotor)
        {
            if (statusMotor)
            {
                arc.Stroke = new SolidColorBrush(Colors.Green);

            }
            else
            {
                arc.Stroke = new SolidColorBrush(Color.FromRgb(60, 60, 60));
            }

            return arc;
        }

    }
}
