using _9230A_V00___PI.Utilidades;
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

namespace _9230A_V00___PI.Equipamentos
{
    /// <summary>
    /// Interação lógica para dosadorOscilante.xam
    /// </summary>
    public partial class dosadorOscilante : UserControl
    {

        #region Variables
        //================================================================================================================================

        Utilidades.EquipsControl equip;

        bool loadedEquip = false;
        bool ticktack = false;

        #endregion
        //================================================================================================================================

        SolidColorBrush VM = new SolidColorBrush(Colors.Red);
        SolidColorBrush CZ = new SolidColorBrush(Colors.Gray);
        SolidColorBrush AZ = new SolidColorBrush(Colors.Blue);
        SolidColorBrush AM = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush VD = new SolidColorBrush(Colors.Green);

        public dosadorOscilante()
        {
            InitializeComponent();

            this.PreviewMouseLeftButtonUp += dosadorOscilante_PreviewMouseLeftButtonUp;

        }

        private void dosadorOscilante_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            equip.OpenWindow();
        }
        public void loadEquip(typeEquip Equip, typeCommand TCommand, int initialOffSet, int bufferPlc, string nome, string tag, string numeroPartida, string paginaProjeto)
        {
            equip = new EquipsControl(Equip, TCommand, initialOffSet, bufferPlc, nome, tag, numeroPartida, paginaProjeto);
            loadedEquip = true;
        }
        public void actualize_UI()
        {
            if (loadedEquip)
            {
                bool posicionando = false;
                if (!(equip.Command_Get.AtuadorA.PosicaoAtual <= equip.Command_Get.AtuadorA.SP_Posicao_Manual + 5 
                  && equip.Command_Get.AtuadorA.PosicaoAtual >= equip.Command_Get.AtuadorA.SP_Posicao_Manual -5))
                {
                    posicionando = true;
                }
                else
                {
                    posicionando = false;
                }



                if (!equip.Command_Get.Standard.Emergencia)
                {

                    rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VM));

                }
                else if (equip.Command_Get.Standard.Falha_Geral)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VM));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));

                    }
                }
                else if (equip.Command_Get.Standard.FalhaConfirmacaoContatorLado1)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VM));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));

                    }
                }
                else if (equip.Command_Get.Standard.FalhaConfirmacaoContatorLado2)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VM));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));

                    }
                }
                else if (equip.Command_Get.Standard.falhaPosicionamento)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VM));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));

                    }
                }
                else if (equip.Command_Get.Standard.falhaLeituraPosicao)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VM));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));

                    }
                }
                else if (equip.Command_Get.Standard.Manutencao)
                {
                    rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = AZ));
      
                }
                else if (!equip.Command_Get.Standard.Liberado)
                {
                    rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = AM));

                }
                else if (equip.Command_Get.Standard.Liga_Manual & posicionando)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VD));
   
                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VD));

                    }
                }
                else if (!equip.Command_Get.Standard.Liga_Manual & posicionando)
                {
                    if (ticktack)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VD));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));

                    }
                }
                else
                {
                    //ligado
                    if (equip.Command_Get.Standard.Liga_Manual & !posicionando)
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = VD));

                    }
                    else
                    {
                        rec1.Dispatcher.BeginInvoke((Action)(() => rec1.Fill = CZ));
            
                    }
                }

                ticktack = !ticktack;

                #region Names

                if (equip.Command_Get.Standard.Automatico)
                {
                    LB_M_A.Dispatcher.BeginInvoke((Action)(() => LB_M_A.Content = "A"));

                }
                else
                {
                    LB_M_A.Dispatcher.BeginInvoke((Action)(() => LB_M_A.Content = "M"));
                }


                float posicoAberta = 0;
                int layoutAbertura = 0;

                posicoAberta = ((40 * equip.Command_Get.AtuadorA.PosicaoAtual) / 100);

                layoutAbertura = 40 - Convert.ToInt32(posicoAberta);

                recAbertura.Width = layoutAbertura;

                #endregion
            }
        }
        public EquipsControl Equip_GS { get => equip; }
        public bool actualize_Equip
        {
            set
            {
                if (loadedEquip)
                {
                    //Atualiza Equipamento
                    equip.actualize_Equip = value;

                    //Atualiza visual do equipamento
                    actualize_UI();

                    //Atualiza tela de controle e status do equipamento

                }

            }
            get { return true; }

        }
    }
}
