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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9230A_V00___PI.Equipamentos
{
    /// <summary>
    /// Interação lógica para moinho.xam
    /// </summary>
    public partial class moinho : UserControl
    {
        Storyboard Gira_Vent;

        #region Variables

        Utilidades.EquipsControl equip;

        bool Aux_StoryBoard = true;

        bool ticktack = false;

        bool loadedEquip = false;

        #endregion

        public moinho()
        {
            InitializeComponent();

            Gira_Vent = (Storyboard)this.Resources["Storyboard1"];
            Gira_Vent.Completed += new EventHandler(Gira_Vent_Completed);

            this.PreviewMouseLeftButtonUp += Moinho_PreviewMouseLeftButtonUp;
        }

        private void Gira_Vent_Completed(object sender, EventArgs e)
        {
            if (!Aux_StoryBoard)
            {
                Gira_Vent.Begin();
            }
            else
            {
                Gira_Vent.Stop();
            }
        }

        private void Moinho_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                if (!equip.Command_Get.Standard.Emergencia)
                {
                    Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Red; });
                    Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Red; });
                    Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Red; });

                }
                else if (equip.Command_Get.Standard.Falha_Geral)
                {
                    if (ticktack)
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Red; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Red; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Red; });
                    }
                    else
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Gray; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Gray; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Gray; });
                    }
                }
                else if (equip.Command_Get.Standard.Manutencao)
                {
                    Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Blue; });
                    Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Blue; });
                    Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Blue; });
                }
                else if (!equip.Command_Get.Standard.Liberado)
                {
                    Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Yellow; });
                    Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Yellow; });
                    Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Yellow; });



                }
                else if (equip.Command_Get.Standard.Ligando)
                {
                    if (ticktack)
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Green; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Green; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Green; });
                    }
                    else
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.ForestGreen; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.ForestGreen; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.ForestGreen; });
                    }
                }
                else if (equip.Command_Get.Standard.Desligando)
                {
                    if (ticktack)
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Green; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Green; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Green; });
                    }
                    else
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Gray; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Gray; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Gray; });
                    }
                }
                else
                {
                    if (equip.Command_Get.Standard.Ligado)
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Green; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Green; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Green; });
                    }
                    else
                    {
                        Apa_0.Dispatcher.Invoke(delegate { Apa_0.Fill = Brushes.Gray; });
                        Apa_1.Dispatcher.Invoke(delegate { Apa_1.Fill = Brushes.Gray; });
                        Apa_2.Dispatcher.Invoke(delegate { Apa_2.Fill = Brushes.Gray; });
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

                #endregion

                #region StoryBoard

                if (equip.Command_Get.Standard.Ligado)
                {
                    if (Aux_StoryBoard)
                    {
                        Gira_Vent.Dispatcher.Invoke(delegate { Gira_Vent.Begin(); });

                        Aux_StoryBoard = false;
                    }
                }
                else
                {
                    if (!Aux_StoryBoard)
                    {
                        Aux_StoryBoard = true;
                    }
                }
                #endregion
            }
        }

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

        public EquipsControl Equip_GS { get => equip; }
    }
}
