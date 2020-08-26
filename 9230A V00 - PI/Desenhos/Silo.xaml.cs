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

namespace _9230A_V00___PI.Desenhos
{
    /// <summary>
    /// Interação lógica para Silo.xam
    /// </summary>
    public partial class Silo : UserControl
    {

        bool Nivel_Alto;
        bool Nivel_Baixo;

        public Silo()
        {
            InitializeComponent();
        }

        public bool Nivel_Alto_GS
        {
            set
            {
                Nivel_Alto = value;

                if (Nivel_Alto)
                {
                    nivelSIlo_Superior.Fill = Brushes.Red;
                }
                else
                {
                    nivelSIlo_Superior.Fill = new SolidColorBrush(Color.FromRgb(0, 200, 0));
                }
            }
            get
            {
                return Nivel_Alto;
            }
        }

        public bool Nivel_Baixo_GS
        {
            set
            {
                Nivel_Baixo = value;

                if (Nivel_Baixo)
                {
                    nivelSIlo_Inferior.Fill = new SolidColorBrush(Color.FromRgb(0, 200, 0));
                }
                else
                {
                    nivelSIlo_Inferior.Fill = Brushes.Red;

                
                }
            }
            get
            {
                return Nivel_Baixo;
            }
        }


    }
}
