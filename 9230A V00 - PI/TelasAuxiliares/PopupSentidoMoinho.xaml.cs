using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace _9230A_V00___PI.TelasAuxiliares
{
    /// <summary>
    /// Interaction logic for PopupSentidoMoinho.xaml
    /// </summary>
    public partial class PopupSentidoMoinho : Window
    {
        public PopupSentidoMoinho()
        {
            InitializeComponent();
            //public bool Sentido = false;
            //Foto para anti-horário: RotateLeft;
            //Foto para horário: RotateRight;


        }

        private void btConfirmaSentido_Click(object sender, RoutedEventArgs e)
        {


            this.DialogResult = true;

        }

        public void Load(bool Sentido)
        {

            if (Sentido)
            {
                Icon_Sentido.Kind = MaterialDesignThemes.Wpf.PackIconKind.RotateRight;
                Label_Sentido.Content = "Horário";
            }
            else
            {
                Icon_Sentido.Kind = MaterialDesignThemes.Wpf.PackIconKind.RotateLeft;
                Label_Sentido.Content = "Anti-Horário";
            }
        }

        //criar para dr load public void

    }
}
