﻿using _9230A_V00___PI.Utilidades;
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
    /// Interação lógica para bifurcadadireita.xam
    /// </summary>
    public partial class bifurcadaDireita : UserControl
    {

        Utilidades.EquipsControl equip;

        bool ticktack = false;

        bool loadedEquip = false;


        public bifurcadaDireita()
        {
            InitializeComponent();

            this.PreviewMouseLeftButtonUp += registro_PreviewMouseLeftButtonUp;

        }

        private void registro_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            equip.OpenWindow();
        }

        public void loadEquip(typeEquip Equip, typeCommand TCommand, int initialOffSet, int bufferPlc, string nome, string tag, string numeroPartida, string paginaProjeto)
        {
            equip = new EquipsControl(Equip, TCommand, initialOffSet, bufferPlc, nome, tag, numeroPartida, paginaProjeto);
            loadedEquip = true;
        }

        private void actualize_UI()
        {
            ticktack = Utilidades.VariaveisGlobais.TickTack_GS;

            if (!equip.Command_Get.Standard.Emergencia)
            {
                R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Red; });
                R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Red; });
                R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Red; });

            }
            else if(equip.Command_Get.Standard.FalhaAcionandoLado1 ||
                   equip.Command_Get.Standard.FalhaAcionandoLado2 ||
                   equip.Command_Get.Standard.Falha2PosicoesAtiva ||
                   equip.Command_Get.Standard.FalhaConfirmacaoContatorLado1 ||
                   equip.Command_Get.Standard.FalhaConfirmacaoContatorLado2)
                 {
                    if (ticktack)
                        {
                        R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Red; });
                        R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Red; });
                        R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Red; });
                    }
                    else
                    {
                        R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Gray; });
                        R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Gray; });
                        R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Gray; });
                    }


                 }

            else if (equip.Command_Get.Standard.Manutencao)
            {
                R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Blue; });
                R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Blue; });
                R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Blue; });

            }
            else if (!equip.Command_Get.Standard.Liberado)
            {
                R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Yellow; });
                R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Yellow; });
                R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Yellow; });
            }
            else if (equip.Command_Get.Standard.AcionandoLado1)
            {
                if (ticktack)
                {
                    R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Green; });

                    R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Gray; });

                    R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Green; });

                }
                else
                {
                    R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Green; });

                    R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Gray; });

                    R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Green; });


                }
            }
            else if (equip.Command_Get.Standard.AcionandoLado2)
            {
                if (ticktack)
                {
                    R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Gray; });

                    R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Green; });

                    R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Green; });


                }
                else
                {
                    R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Gray; });

                    R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Green; });

                    R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Green; });


                }
            }
            else if (equip.Command_Get.Standard.EmPosicaoLado1)
            {
                R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Green; });

                R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Gray; });

                R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Green; });

            }
            else if (equip.Command_Get.Standard.EmPosicaoLado2)
            {
                R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Gray; });

                R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Green; });

                R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Green; });

            }
            else
            {

                R1.Dispatcher.Invoke(delegate { R1.Fill = Brushes.Gray; });
                R2.Dispatcher.Invoke(delegate { R2.Fill = Brushes.Gray; });
                R3.Dispatcher.Invoke(delegate { R3.Fill = Brushes.Gray; });

            }


            #region Names

            if (equip.Command_Get.Standard.Automatico)
            {
                LB_M_A_Tag.Dispatcher.Invoke(delegate { LB_M_A_Tag.Content = "A"; });

            }
            else
            {
                LB_M_A_Tag.Dispatcher.Invoke(delegate { LB_M_A_Tag.Content = "M"; });
            }

            #endregion

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
