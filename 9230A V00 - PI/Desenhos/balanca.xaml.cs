using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interação lógica para balanca.xam
    /// </summary>
    public partial class balanca : UserControl
    {
        public event EventHandler abreTela;

        bool ticktack = false;
        public balanca()
        {
            InitializeComponent();
        }

        public void Actualize_UI(Utilidades.VariaveisGlobais.IndicadorPesagem indicadorPesagem) 
        {

            LbPeso.Content = Utilidades.VariaveisGlobais.indicadorPesagem.Valor_Atual_Indicador.ToString("N", CultureInfo.GetCultureInfo("pt-BR")) + " kg";


            if (indicadorPesagem.Erro_Leitura)
            {
                if (ticktack)
                {
                    recPrincipal.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    recPrincipal.Fill = new SolidColorBrush(Color.FromRgb(127,127,127));
                }

                ticktack = !ticktack;

            }
            else
            {
                recPrincipal.Fill = new SolidColorBrush(Color.FromRgb(127, 127, 127));
            }


        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.abreTela != null)
                this.abreTela(this, e);
        }

    
    }
}
