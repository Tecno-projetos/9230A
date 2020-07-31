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
using System.Windows.Shapes;

namespace _9230A_V00___PI.TelasAuxiliares
{
    /// <summary>
    /// Interaction logic for Diagnosticos.xaml
    /// </summary>
    public partial class Diagnosticos : Window
    {
        string Tempo_Leitura_PLC;
        string Tempo_Escrita_PLC;

        public Diagnosticos()
        {
            InitializeComponent();
        }

        public string Tempo_Leitura_PLC_GS
        {
            get
            {
                return Tempo_Leitura_PLC;
            }
            set
            {
                Tempo_Leitura_PLC = value;
                LB_Leitura_PLC.Dispatcher.Invoke(delegate { LB_Leitura_PLC.Content = "Tempo Leitura Buffer PLC: " + Tempo_Leitura_PLC; });
            }

        }

        public string Tempo_Escrita_PLC_GS
        {
            get
            {
                return Tempo_Escrita_PLC;
            }
            set
            {
                Tempo_Escrita_PLC = value;
                LB_Escrita_PLC.Dispatcher.Invoke(delegate { LB_Escrita_PLC.Content = "Tempo Escrita Buffer PLC: " + Tempo_Escrita_PLC; });
            }

        }

    }
}
