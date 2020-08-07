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
using System.Windows.Threading;

namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interação lógica para conexoes.xam
    /// </summary>
    public partial class conexoes : UserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public conexoes()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            pckUser = pckIcone(pckUser, ConnectionDB(Utilidades.VariaveisGlobais.Connection_DB_Users_GS));

            pckEquipamentos = pckIcone(pckEquipamentos, ConnectionDB(Utilidades.VariaveisGlobais.Connection_DB_Equip_GS));

            pckProdutos = pckIcone(pckProdutos, ConnectionDB(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS));

            pckReceitas = pckIcone(pckReceitas, ConnectionDB(Utilidades.VariaveisGlobais.Connection_DB_Receitas_GS));



            timer.Start();

        }

        private MaterialDesignThemes.Wpf.PackIcon pckIcone(MaterialDesignThemes.Wpf.PackIcon pck, bool connection)
        {
            if (connection)
            {
                pck.Kind = MaterialDesignThemes.Wpf.PackIconKind.DatabaseCheck;
                pck.Foreground = new SolidColorBrush(Colors.Green);

            }
            else
            {
                pck.Kind = MaterialDesignThemes.Wpf.PackIconKind.DatabaseRemove;
                pck.Foreground = new SolidColorBrush(Colors.Red);
            }

            return pck;

        }

        private bool ConnectionDB(string Connection)
        {
            bool Conectou = false;

            try
            {
                dynamic Call = DataBase.SqlGlobalFuctions.ReturnCall(Connection);

                Call.Open();

                Call.Close();

                Conectou = true;
            }
            catch (Exception)
            {
                Conectou = false;

            }

            return Conectou;


        }

    }
}
